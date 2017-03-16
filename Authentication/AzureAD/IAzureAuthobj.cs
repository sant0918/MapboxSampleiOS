using System.Threading.Tasks;
using Microsoft.Azure.ActiveDirectory.GraphClient;


namespace Authentication.AzureAD
{
    interface IAzureAuthObj
    {
        TenantInfo GetTenantInfo();
        Task<string> AcquireApplicationTokenAsync();
        IUser GetUser(string userToSearch);
        bool IsUserMemberOfGroup(IUser user, string groupName);

    }
}
