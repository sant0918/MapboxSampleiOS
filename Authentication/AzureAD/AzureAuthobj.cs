using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Azure.ActiveDirectory.GraphClient;
using System.Security.Cryptography.X509Certificates;

namespace Authentication.AzureAD
{
    sealed public class AzureAuthobj : IAzureAuthObj
    {

        // Maintains information on tenant.
        private TenantInfo _tInfo;
        
        // Used to verify that account is authenticated.
        public bool isAuthenticated { get; private set; }

        public string Accesstoken
        {
            get
            {
                return this._tInfo
                            ._caac.authenticationResult.AccessToken;
            }
        }

        public string TenantName
        {
            get
            {
                return this._tInfo.TenantName;
            }
        }

        /// <summary>
        /// Sets Azure tenant information used for authentication.
        /// </summary>
        /// <param name="tenantinfo"></param>
        public AzureAuthobj(TenantInfo tenantinfo)
        {
            // set tenant info.
            _tInfo = tenantinfo;
            if(String.IsNullOrEmpty(tenantinfo.AuthString))
                _tInfo.AuthString = "https://login.microsoftonline.com/" +
                _tInfo.TenantId +
                "/FederationMetadata/2007-06/FederationMetadata.xml";

            // configure ad client.
            ClientAppAuthContext caac = new ClientAppAuthContext();
            caac.authenticationUri = new Uri(_tInfo.GraphApiUrl + _tInfo.TenantId);
            caac.authenticationContext = new AuthenticationContext(_tInfo.AuthString, false);
            caac.clientCred = new ClientCredential(_tInfo.ClientId, _tInfo.ClientSecret);

            //X509Certificate2 cert = GetCertificateFromStore("CN=dbgbreakpoint.org O365api Cert"); // load from store or file
            
            //testing
            /*
            var certPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            certPath = certPath.Substring(0, certPath.LastIndexOf('\\')) + "\\o365apiCert.pfx";
            var certfile = System.IO.File.OpenRead(certPath);
            var certificateBytes = new byte[certfile.Length];
            certfile.Read(certificateBytes, 0, (int)certfile.Length);
            var cert = new X509Certificate2(
                certificateBytes,
                "",
                X509KeyStorageFlags.Exportable |
                X509KeyStorageFlags.MachineKeySet |
                X509KeyStorageFlags.PersistKeySet); //switchest are important to work in webjob

            ClientAssertionCertificate cac = new ClientAssertionCertificate(_tInfo.ClientId, cert);*/
            try
            {
                // this may fail if we can't authenticate for some reason.
                caac.authenticationResult = caac.authenticationContext.AcquireToken(_tInfo.GraphApiUrl, caac.clientCred);
               // caac.activeDirectoryClient = new ActiveDirectoryClient(caac.authenticationUri,
                                                                        //async () => await AcquireApplicationTokenAsync());
            } catch (Exception e)
            {
                // Implement better exception handling here.
                throw e;
            }
            
            _tInfo._caac = caac;
            isAuthenticated = true;
        }

        /// <summary>
        /// Returns tenant information.
        /// </summary>
        /// <returns></returns>
        public TenantInfo GetTenantInfo()
        {
            return _tInfo;
        }

       
        public async Task<string> AcquireApplicationTokenAsync()
        {
            AuthenticationContext authenticationContext = new AuthenticationContext(_tInfo.AuthString, false);

            // Config for OAuth client credentials 
            ClientCredential clientCred = new ClientCredential(
                _tInfo.ClientId,
                _tInfo.ClientSecret);

            //Use cert instead of client cred:
            /*X509Certificate2 cert = GetCertificateFromStore("CN=dbgbreakpoint.org O365api Cert"); // load from store or file
            ClientAssertionCertificate cac = new ClientAssertionCertificate(_tInfo.ClientId, cert);

            AuthenticationResult authenticationResult = await authenticationContext.AcquireTokenAsync(
                _tInfo.GraphApiUrl,
                cac);*/
            AuthenticationResult authenticationResult = await authenticationContext.AcquireTokenAsync(
                _tInfo.GraphApiUrl,
                clientCred);

            return authenticationResult.AccessToken;
            
                }

        private static X509Certificate2 GetCertificateFromStore(string certName)
        {

            // Get the certificate store for the current user.
            X509Store store = new X509Store(StoreLocation.CurrentUser);
            try
            {
                store.Open(OpenFlags.ReadOnly);

                // Place all certificates in an X509Certificate2Collection object.
                X509Certificate2Collection certCollection = store.Certificates;
                // If using a certificate with a trusted root you do not need to FindByTimeValid, instead:
                // currentCerts.Find(X509FindType.FindBySubjectDistinguishedName, certName, true);
                X509Certificate2Collection currentCerts = certCollection.Find(X509FindType.FindByTimeValid, DateTime.Now, false);
                X509Certificate2Collection signingCert = currentCerts.Find(X509FindType.FindBySubjectDistinguishedName, certName, false);
                if (signingCert.Count == 0)
                    return null;
                // Return the first certificate in the collection, has the right name and is current.
                return signingCert[0];
            }
            finally
            {
                store.Close();
            }

        }

        public bool IsUserMemberOfGroup(IUser user, string groupName)
        {

            //get group id
            var groupId = _tInfo._caac.activeDirectoryClient.Groups.Where(g => g.DisplayName == groupName).ExecuteSingleAsync().Result;

            //check if group id is in Users groups
            IUserFetcher retrievedUserFetcher = (User)user;
            var groups = retrievedUserFetcher.CheckMemberGroupsAsync
                (new List<string> { groupId.ObjectId }).Result.ToList();

            if (groups.Count() > 0)
            {
                return true;
            }
            else return false;

        }

        public IUser GetUser(string userToSearch)
        {
            IUserCollection userCollection = _tInfo._caac.activeDirectoryClient.Users;
            
            try
            {
                var searchResults = userCollection.Where(user =>
                user.UserPrincipalName.StartsWith(userToSearch) ||
                user.DisplayName.StartsWith(userToSearch) ||
                user.GivenName.StartsWith(userToSearch) ||
                user.Surname.StartsWith(userToSearch)).ExecuteAsync().Result;

                return searchResults.CurrentPage.First();

            } catch (Exception e)
            {
                throw e;
                
            }
        }
    }
}
