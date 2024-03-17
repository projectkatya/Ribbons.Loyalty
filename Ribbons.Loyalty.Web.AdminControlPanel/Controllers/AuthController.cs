using Ribbons.Loyalty.Data.Definitions;
using Ribbons.Loyalty.Services.Users;
using Ribbons.Loyalty.Web.Controllers;

namespace Ribbons.Loyalty.Web.AdminControlPanel.Controllers
{
    public class AuthController : AuthControllerBase
    {
        public AuthController(IUserAuthenticator userAuthenticator) : base(LoyaltyUser.Admin, userAuthenticator) { }
    }
}