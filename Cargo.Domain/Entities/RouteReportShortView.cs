using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Cargo.Domain.Entities
{
    [Table("RouteReportShortView")]
    public partial class RouteReportShortView
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RouteReportId { get; set; }

        [StringLength(8)]
        public string VehicleRegistration { get; set; }

        [StringLength(50)]
        public string FromCity { get; set; }

        [StringLength(50)]
        public string ToCity { get; set; }

        [Column(TypeName = "date")]
        public DateTime? StartDate { get; set; }
    }
}
