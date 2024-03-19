using System.Collections.Generic;

namespace Ribbons.Loyalty.Services.Partners.Models
{
    public sealed class CreatePartnerResponse : PartnerManagerResponse<CreatePartnerStatus>
    {
        private CreatePartnerResponse(CreatePartnerStatus status) : base(PartnerManagerAction.CreatePartner)
        {
            Status = status;
        }

        public static CreatePartnerResponse Ok() => new(CreatePartnerStatus.Ok);
        
        public static CreatePartnerResponse PartnerInvalid(Dictionary<string, string> validationErrors) => new(CreatePartnerStatus.PartnerInvalid)
        {
            ValidationErrors = validationErrors
        };

        public static CreatePartnerResponse RootUserInvalid(Dictionary<string, string> validationErrors) => new(CreatePartnerStatus.RootUserInvalid)
        {
            ValidationErrors = validationErrors
        };
        
        public static CreatePartnerResponse AccountNumberTaken() => new(CreatePartnerStatus.AccountNumberTaken);
        
        public static CreatePartnerResponse AliasTaken() => new(CreatePartnerStatus.AliasTaken);

        public static CreatePartnerResponse Error() => new(CreatePartnerStatus.Error);

        public static CreatePartnerResponse DbServerNotFound() => new(CreatePartnerStatus.DbServerNotFound);
    }
}