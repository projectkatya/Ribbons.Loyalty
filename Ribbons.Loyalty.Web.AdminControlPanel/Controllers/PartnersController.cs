using Microsoft.AspNetCore.Mvc;

namespace Ribbons.Loyalty.Web.AdminControlPanel.Controllers
{
    public class PartnersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
