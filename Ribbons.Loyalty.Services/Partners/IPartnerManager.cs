using Ribbons.Loyalty.Services.Partners.Models;
using System.Threading.Tasks;

namespace Ribbons.Loyalty.Services.Partners
{
    public interface IPartnerManager
    {
        Task<CreatePartnerResponse> CreatePartnerAsync(CreatePartnerRequest createPartnerRequest);
    }
}