namespace Cargo.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ReceiptItem
    {
        public int ReceiptItemId { get; set; }

        public int fReceipt { get; set; }

        [Required]
        [StringLength(20)]
        public string Producer { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        public GoodType GoodType { get; set; }

        [StringLength(40)]
        public string GoodName { get; set; }

        [ForeignKey("fReceipt")]
        public virtual Receipt Receipt { get; set; }
    }

    public enum GoodType : int
    {
        Fuel = 1,
        Detail = 2,
        Service = 4
    }
}
