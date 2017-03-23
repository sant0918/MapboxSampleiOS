using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Authentication.AzureAD;
using Owin;

namespace Authentication.B2C
{
    public interface IB2CAuth
    {
        IB2CAuth SetSignUpPolicyId(String s);

        IB2CAuth SetSignInPolicyId(String s);

        IB2CAuth SetProfilePolicyId(String s);

        IB2CAuth SetTenantInfo(TenantInfo t);
        void ConfigureAuth(IAppBuilder app);
        
    }
}
