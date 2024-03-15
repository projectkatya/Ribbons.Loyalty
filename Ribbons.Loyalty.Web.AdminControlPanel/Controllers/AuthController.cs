using Ribbons.Loyalty.Data.Definitions;
using Ribbons.Loyalty.Web.Controllers;
using Ribbons.Users.Authentication;

namespace Ribbons.Loyalty.Web.AdminControlPanel.Controllers
{
    public class AuthController : AuthControllerBase
    {
        public AuthController(IUserAuthenticator<LoyaltyUser> userAuthenticator) : base(LoyaltyUser.Admin, userAuthenticator) { }
    }
}