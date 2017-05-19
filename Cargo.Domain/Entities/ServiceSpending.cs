namespace Cargo.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ServiceSpending
    {
        public int ServiceSpendingId { get; set; }

        public int fReceiptItem { get; set; }

        public int fVehicle { get; set; }

        public int SpentQuantity { get; set; }

        [ForeignKey("fReceiptItem")]
        public virtual ReceiptItem ReceiptItem { get; set; }

        [ForeignKey("fVehicle")]
        public virtual Vehicle Vehicle { get; set; }
    }
}
