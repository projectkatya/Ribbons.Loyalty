using Ribbons.Loyalty.Data.Definitions;
using Ribbons.RegularExpressions;
using Ribbons.Users.Management.Models;
using Ribbons.Validation;
using System.ComponentModel.DataAnnotations;

namespace Ribbons.Loyalty.Services.Partners.Models
{
    public sealed class CreatePartnerRequest
    {
        [Required(ErrorMessage = ValidationErrorMessages.Required)]
        [Regex(RegexPatternType.AlphaNumericDotUnderscore, ErrorMessage = ValidationErrorMessages.PatternInvalid)]
        public string Alias { get; set; }

        [Required(ErrorMessage = ValidationErrorMessages.Required)]
        [StringLength(LengthConstraints.AliasLength, ErrorMessage = ValidationErrorMessages.LengthInvalid)]
        public string Name { get; set; }

        [StringLength(LengthConstraints.BusinessNameLength, ErrorMessage = ValidationErrorMessages.LengthInvalid)]
        public string BusinessName { get; set; }

        [StringLength(LengthConstraints.BillingAddressLength, ErrorMessage = ValidationErrorMessages.LengthInvalid)]
        public string BillingAddress { get; set; }

        [StringLength(LengthConstraints.CountryLength, ErrorMessage = ValidationErrorMessages.LengthInvalid)]
        public string Country { get; set; }

        [StringLength(LengthConstraints.StateLength, ErrorMessage = ValidationErrorMessages.LengthInvalid)]
        public string State { get; set; }

        [StringLength(LengthConstraints.CityLength, ErrorMessage = ValidationErrorMessages.LengthInvalid)]
        public string City { get; set; }

        [StringLength(LengthConstraints.ZipCodeLength, ErrorMessage = ValidationErrorMessages.LengthInvalid)]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = ValidationErrorMessages.Required)]
        public long? DbServerId { get; set; }
    }
}