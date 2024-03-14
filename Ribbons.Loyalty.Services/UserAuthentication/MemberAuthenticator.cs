using Microsoft.Extensions.Logging;
using Ribbons.Data;
using Ribbons.Loyalty.Data.Databases;
using Ribbons.Loyalty.Data.Definitions;
using Ribbons.Users.Authentication;

namespace Ribbons.Loyalty.Services.UserAuthentication
{
    public sealed class MemberAuthenticator : UserAuthenticator<PartnerDb>
    {
        public MemberAuthenticator(ILogger<MemberAuthenticator> logger, IDatabaseManager<PartnerDb> databaseManager) : 
            base(LoyaltyUserTypeId.Member, logger, databaseManager)
        {
        }
    }
}