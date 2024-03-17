using Microsoft.EntityFrameworkCore;
using Ribbons.Data;
using Ribbons.Loyalty.Data.Definitions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ribbons.Loyalty.Data
{
    [Table(TableNames.PartnerDbConfig)]
    [Index(nameof(Provider))]
    public class PartnerDbConfig
    {
        [Column(ColumnNames.PartnerId)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long PartnerId { get; set; }

        [Column(ColumnNames.Provider)]
        [Required]
        public DatabaseProvider Provider { get; set; }

        [Column(ColumnNames.ConnectionString)]
        [Required]
        public string ConnectionString { get; set; }
    }
}