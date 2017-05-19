namespace Cargo.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class WarehouseItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int fWarehouseItemId { get; set; }

        public int AvailableQuantity { get; set; }

        public virtual ReceiptItem ReceiptItem { get; set; }
    }
}
