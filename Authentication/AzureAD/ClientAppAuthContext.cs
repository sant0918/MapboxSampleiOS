using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Azure.ActiveDirectory.GraphClient;

namespace Authentication.AzureAD
{
    public class ClientAppAuthContext
    {
        public Uri authenticationUri;
        public AuthenticationContext authenticationContext;
        public ClientCredential clientCred;
        public AuthenticationResult authenticationResult;
        public ActiveDirectoryClient activeDirectoryClient;
    }
}
