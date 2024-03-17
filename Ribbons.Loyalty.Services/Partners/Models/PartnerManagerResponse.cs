using System.Collections.Generic;

namespace Ribbons.Loyalty.Services.Partners.Models
{
    public abstract class PartnerManagerResponse<TStatus>
    {
        public PartnerManagerAction Action { get; }
        public TStatus Status { get; internal set; }
        public Dictionary<string, string> ValidationErrors { get; internal set; }

        protected PartnerManagerResponse(PartnerManagerAction action)
        {
            Action = action;
        }
    }
}