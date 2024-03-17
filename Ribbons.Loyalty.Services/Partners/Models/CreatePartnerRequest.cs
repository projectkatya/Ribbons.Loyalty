using Ribbons.RegularExpressions;
using Ribbons.Users.Management.Models;
using Ribbons.Validation;
using System.ComponentModel.DataAnnotations;

namespace Ribbons.Loyalty.Services.Partners.Models
{
    public sealed class CreatePartnerRequest
    {
        [Required]
        [Regex(RegexPatternType.AlphaNumericDotUnderscore)]
        public string Alias { get; set; }

        [Required]
        public string Name { get; set; }

        public string BusinessName { get; set; }
        public string BillingAddress { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public long DbServerId { get; set; }

        public CreateUserRequest RootUser { get; set; }
    }
}