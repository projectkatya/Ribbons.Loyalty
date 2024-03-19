using Microsoft.EntityFrameworkCore;
using Ribbons.Data;
using Ribbons.Loyalty.Data.Definitions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ribbons.Loyalty.Data
{
    [Table(TableNames.PartnerDeployment)]
    [Index(nameof(PartnerId))]
    [Index(nameof(Status))]
    [Index(nameof(StartDate))]
    [Index(nameof(FinishDate))]
    [Index(nameof(DbMigrationStartDate))]
    [Index(nameof(DbMigrationFinishDate))]
    [Index(nameof(DbMigrationStatus))]
    public class PartnerDeployment
    {
        [Column(ColumnNames.PartnerDeploymentId)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long PartnerDeploymentId { get; set; }

        [Column(ColumnNames.PartnerId)]
        [Required]
        public long PartnerId { get; set; }

        [Column(ColumnNames.Status)]
        [Required]
        public PartnerDeploymentStatus Status { get; set; }

        [Column(ColumnNames.StartDate)]
        [Required]
        public DateTime StartDate { get; set; }

        [Column(ColumnNames.DbMigrationStartDate)]
        public DateTime? DbMigrationStartDate { get; set; }

        [Column(ColumnNames.DbMigrationFinishDate)]
        public DateTime? DbMigrationFinishDate { get; set; }

        [Column(ColumnNames.DbMigrationStatus)]
        public MigrationStatus? DbMigrationStatus { get; set; }

        [Column(ColumnNames.FinishDate)]
        public DateTime? FinishDate { get; set; }
    }
}