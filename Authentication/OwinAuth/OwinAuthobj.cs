using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IdentityModel.Claims;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Owin;
using Authentication.AzureAD;

namespace Authentication.OwinAuth
{
    public class OwinAuthobj
    {
        private static string clientId;
        private static string appKey;
        private static string aadInstance = "https://login.microsoftonline.com/";
        private static string tenantId = "4813bf99-9e7b-44d8-9892-8e72e6614d05";
        private static string postLogoutRedirectUri;
        private static string ApplicationdbContext = "INSERT CONNECTION STRING";
        public static string Authority { get; private set;}
        private static string graphResourceId;

        public OwinAuthobj(AzureAuthobj auth)
        {
            TenantInfo _tInfo = auth.GetTenantInfo();
            clientId = _tInfo.ClientId;
            appKey = _tInfo.ClientSecret;
            tenantId = _tInfo.TenantId;
            Authority = aadInstance + tenantId;
            graphResourceId = _tInfo.GraphApiUrl;
        }
       
        public void ConfigOpenIDAuth(IAppBuilder app)
        {
            
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);

            app.UseCookieAuthentication(new CookieAuthenticationOptions());

            app.UseOpenIdConnectAuthentication(
                new OpenIdConnectAuthenticationOptions
                {
                    ClientId = clientId,
                    Authority = aadInstance + tenantId,
                    PostLogoutRedirectUri = postLogoutRedirectUri,

                    Notifications = new OpenIdConnectAuthenticationNotifications()
                    {
                        // If there is a code in the OpenID Connect response, redeem it for an access token and refresh token, and store those away.
                        AuthorizationCodeReceived = (context) =>
                        {
                            var code = context.Code;
                            ClientCredential credential = new ClientCredential(clientId, appKey);
                            string signedInUserID = context.AuthenticationTicket.Identity.FindFirst(ClaimTypes.NameIdentifier).Value;
                            AuthenticationContext authContext = new AuthenticationContext(Authority, new ADALTokenCache(signedInUserID));
                            AuthenticationResult result = authContext.AcquireTokenByAuthorizationCode(
                            code, new Uri(HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Path)), credential, graphResourceId);

                            return Task.FromResult(0);
                        }
                    }
                });

            
        }
    }
}
