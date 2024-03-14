using Microsoft.Extensions.Logging;
using Ribbons.Data;
using Ribbons.Loyalty.Data.Databases;
using Ribbons.Loyalty.Data.Definitions;
using Ribbons.Users.Management;

namespace Ribbons.Loyalty.Services.UserManagement
{
    public sealed class MemberManager : UserManager<PartnerDb>
    {
        public MemberManager(ILogger<MemberManager> logger, IDatabaseManager<PartnerDb> databaseManager) : base(LoyaltyUserTypeId.Member, logger, databaseManager)
        {
        }
    }
}