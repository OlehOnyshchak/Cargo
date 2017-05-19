namespace Cargo.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FuelSpending
    {
        public int FuelSpendingId { get; set; }

        public int fReceiptItem { get; set; }

        public int? fRouteReport { get; set; }

        public int SpentQuantity { get; set; }

        [ForeignKey("fReceiptItem")]
        public virtual ReceiptItem ReceiptItem { get; set; }

        [ForeignKey("fRouteReport")]
        public virtual RouteReport RouteReport { get; set; }
    }
}
