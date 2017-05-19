namespace Cargo.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ExternalSpending
    {
        public int ExternalSpendingId { get; set; }

        public int fRouteReport { get; set; }

        public int GoodType { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        [StringLength(40)]
        public string GoodName { get; set; }

        [ForeignKey("fRouteReport")]
        public virtual RouteReport RouteReport { get; set; }
    }
}
