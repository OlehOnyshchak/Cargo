namespace Cargo.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RouteReport
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RouteReport()
        {
            Applications = new HashSet<Application>();
            ExternalSpendings = new HashSet<ExternalSpending>();
            FuelSpendings = new HashSet<FuelSpending>();
        }

        public int RouteReportId { get; set; }

        public double RoadCredit { get; set; }

        public int RouteMileage { get; set; }

        public int TaxedMileage { get; set; }

        public int FuelLevelBefore { get; set; }

        public int FuelLevelAfter { get; set; }

        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BorderCrossingDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }

        public double DriverInterestRate { get; set; }

        public double TotalSpendings { get; set; }

        public int fDriver { get; set; }

        public int fVehicle { get; set; }

        [ForeignKey("fDriver")]
        public virtual Driver Driver { get; set; }

        [ForeignKey("fVehicle")]
        public virtual Vehicle Vehicle { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [InverseProperty("RouteReport")]
        public virtual ICollection<Application> Applications { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [InverseProperty("RouteReport")]
        public virtual ICollection<ExternalSpending> ExternalSpendings { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [InverseProperty("RouteReport")]
        public virtual ICollection<FuelSpending> FuelSpendings { get; set; }
    }
}
