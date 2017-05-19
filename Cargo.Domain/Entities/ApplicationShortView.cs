namespace Cargo.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ApplicationShortView")]
    public partial class ApplicationShortView
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ApplicationId { get; set; }

        [StringLength(8)]
        public string VehicleRegistration { get; set; }

        [StringLength(50)]
        public string FromCity { get; set; }

        [StringLength(50)]
        public string ToCity { get; set; }

        [Column(TypeName = "date")]
        public DateTime? StartDate { get; set; }

        public int? fRouteReport { get; set; }

        [ForeignKey("fRouteReport")]
        public virtual RouteReport RouteReport { get; set; }
    }
}
