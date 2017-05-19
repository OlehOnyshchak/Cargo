using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Cargo.Domain.Entities
{
    public partial class Application
    {
        public int ApplicationId { get; set; }

        public double Compensation { get; set; }

        public bool IsCashCompensation { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(16)]
        public string DocumentNumber { get; set; }

        public int fClientCompany { get; set; }

        public int fLoadingAddress { get; set; }

        public int? fCustomsAddress { get; set; }

        public int? fBorderAddress { get; set; }

        public int? fClearenceAddress { get; set; }

        public int fUnloadingAddress { get; set; }

        public int fVehicle { get; set; }

        public int? fRouteReport { get; set; }

        [Column(TypeName = "date")]
        public DateTime? LoadingDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? UnloadingDate { get; set; }

        [ForeignKey("fLoadingAddress")]
        public virtual Address LoadingAddress { get; set; }

        [ForeignKey("fCustomsAddress")]
        public virtual Address CustomsAddress { get; set; }

        [ForeignKey("fBorderAddress")]
        public virtual Address BorderAddress { get; set; }

        [ForeignKey("fClearenceAddress")]
        public virtual Address ClearenceAddress { get; set; }

        [ForeignKey("fUnloadingAddress")]
        public virtual Address UnloadingAddress { get; set; }

        [ForeignKey("fClientCompany")]
        public virtual Company Client { get; set; }

        [ForeignKey("fRouteReport")]
        public virtual RouteReport RouteReport { get; set; }

        [ForeignKey("fVehicle")]
        public virtual Vehicle Vehicle { get; set; }
    }
}
