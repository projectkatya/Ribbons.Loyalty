using Microsoft.AspNetCore.Mvc;
using Ribbons.Loyalty.Services.Partners;
using Ribbons.Loyalty.Services.Partners.Models;
using System.Threading.Tasks;

namespace Ribbons.Loyalty.Web.AdminControlPanel.Controllers
{
    [Route("partners")]
    public class PartnersController : Controller
    {
        private IPartnerManager PartnerManager { get; }

        public PartnersController(IPartnerManager partnerManager)
        {
            PartnerManager = partnerManager;
        }

        [Route("create")]
        [HttpPost]
        public async Task<CreatePartnerResponse> CreatePartnerAsync([FromBody] CreatePartnerRequest createPartnerRequest)
        {
            return await PartnerManager.CreatePartnerAsync(createPartnerRequest);
        }
    }
}