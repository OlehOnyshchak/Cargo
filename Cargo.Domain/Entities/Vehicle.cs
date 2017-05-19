namespace Cargo.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Vehicle
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vehicle()
        {
            RouteReports = new HashSet<RouteReport>();
            ServiceSpendings = new HashSet<ServiceSpending>();
        }

        public int VehicleId { get; set; }

        [Required]
        [StringLength(8)]
        public string VehicleRegistration { get; set; }

        [Required]
        [StringLength(8)]
        public string TrailerRegistration { get; set; }

        [Required]
        [StringLength(20)]
        public string VehicleBrand { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [InverseProperty("Vehicle")]
        public virtual ICollection<RouteReport> RouteReports { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [InverseProperty("Vehicle")]
        public virtual ICollection<ServiceSpending> ServiceSpendings { get; set; }
    }
}
