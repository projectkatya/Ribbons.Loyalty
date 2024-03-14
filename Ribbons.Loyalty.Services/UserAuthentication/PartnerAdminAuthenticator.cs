using Microsoft.Extensions.Logging;
using Ribbons.Data;
using Ribbons.Loyalty.Data.Databases;
using Ribbons.Loyalty.Data.Definitions;
using Ribbons.Users.Authentication;

namespace Ribbons.Loyalty.Services.UserAuthentication
{
    public sealed class PartnerAdminAuthenticator : UserAuthenticator<PartnerDb>
    {
        public PartnerAdminAuthenticator(ILogger<PartnerAdminAuthenticator> logger, IDatabaseManager<PartnerDb> databaseManager) : 
            base(LoyaltyUserTypeId.PartnerAdmin, logger, databaseManager)
        {
        }
    }
}