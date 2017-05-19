using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Cargo.Domain.Entities
{
    public partial class Receipt
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Receipt()
        {
            ReceiptItems = new HashSet<ReceiptItem>();
        }

        public int ReceiptId { get; set; }

        public int fSupplierCompany { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        [ForeignKey("fSupplierCompany")]
        public virtual Company Supplier { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [InverseProperty("Receipt")]
        public virtual ICollection<ReceiptItem> ReceiptItems { get; set; }
    }
}
