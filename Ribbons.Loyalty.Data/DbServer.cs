using Microsoft.EntityFrameworkCore;
using Ribbons.Data;
using Ribbons.Loyalty.Data.Definitions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ribbons.Loyalty.Data
{
    [Table(TableNames.DbServer)]
    [Index(nameof(Name), IsUnique = true)]
    [Index(nameof(Provider))]
    public class DbServer
    {
        [Column(ColumnNames.DbServerId)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long DbServerId { get; set; }

        [Column(ColumnNames.Name)]
        [Required]
        [StringLength(LengthConstraints.NameLength)]
        public string Name { get; set; }

        [Column(ColumnNames.Provider)]
        [Required]
        public DatabaseProvider Provider { get; set; }

        [Column(ColumnNames.ConnectionString)]
        [Required]
        public string ConnectionString { get; set; }
    }
}