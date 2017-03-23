using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.AzureAD
{
    public class O365TenantInfo
    {
        public ClientAppAuthContext _caac;
        public string TenantId;
        public string ClientId;
        public string ClientSecret;
        public string AuthString;
        public string O365ApiUrl = "https://manage.office.com/";
        public string redirectUrl = "https://localhost:44344";
        public string aadInstance = "https://login.microsoftonline.com/";
    }
}
