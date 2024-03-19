using Microsoft.EntityFrameworkCore;
using Ribbons.Loyalty.Data.Definitions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ribbons.Loyalty.Data
{
    [Table(TableNames.Partner)]
    [Index(nameof(CreatedDate))]
    [Index(nameof(ModifiedDate))]
    [Index(nameof(AccountNumber), IsUnique = true)]
    [Index(nameof(Alias), IsUnique = true)]
    [Index(nameof(Status))]
    [Index(nameof(Country))]
    [Index(nameof(State))]
    [Index(nameof(City))]
    [Index(nameof(ZipCode))]
    public class Partner
    {
        [Column(ColumnNames.PartnerId)]
        [Key]
        public long PartnerId { get; set; }

        [Column(ColumnNames.CreatedDate)]
        [Required]
        public DateTime CreatedDate { get; set; }

        [Column(ColumnNames.ModifiedDate)]
        [Required]
        public DateTime ModifiedDate { get; set; }

        [Column(ColumnNames.AccountNumber)]
        [Required]
        [StringLength(LengthConstraints.AccountNumberLength)]
        public string AccountNumber { get; set; }

        [Column(ColumnNames.Alias)]
        [Required]
        [StringLength(LengthConstraints.AliasLength)]
        public string Alias { get; set; }

        [Column(ColumnNames.Name)]
        [Required]
        [StringLength(LengthConstraints.NameLength)]
        public string Name { get; set; }

        [Column(ColumnNames.Status)]
        [Required]
        public PartnerStatus Status { get; set; }

        [Column(ColumnNames.BusinessName)]
        [StringLength(LengthConstraints.BusinessNameLength)]
        public string BusinessName { get; set; }

        [Column(ColumnNames.BillingAddress)]
        public string BillingAddress { get; set; }

        [Column(ColumnNames.Country)]
        [StringLength(LengthConstraints.CountryLength)]
        public string Country { get; set; }

        [Column(ColumnNames.State)]
        [StringLength(LengthConstraints.StateLength)]
        public string State { get; set; }

        [Column(ColumnNames.City)]
        [StringLength(LengthConstraints.CityLength)]
        public string City { get; set; }

        [Column(ColumnNames.ZipCode)]
        [StringLength(LengthConstraints.ZipCodeLength)]
        public string ZipCode { get; set; }
    }
}