using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.AzureAD
{
    public class TenantInfo
    {
        public ClientAppAuthContext _caac;
        public string TenantName;
        public string TenantId;
        public string ClientId;
        public string ClientSecret;
        public string AuthString;
        public string GraphApiUrl = "https://graph.windows.net";
        public string redirectUrl = "https://localhost:44344";
        public string aadInstance = "https://login.microsoftonline.com/";
        
    }
}
