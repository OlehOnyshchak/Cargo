using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Cargo.Domain.Entities
{
    public partial class Company
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Company()
        {
            Applications = new HashSet<Application>();
            Receipts = new HashSet<Receipt>();
        }

        public int CompanyId { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        [StringLength(10)]
        public string TaxNumber { get; set; }

        public int fLegalAddress { get; set; }

        public int fActualAddress { get; set; }

        public int fName { get; set; }

        public int fBank { get; set; }

        [Required]
        [StringLength(30)]
        public string BankNumber { get; set; }

        public CompanyType CompanyType { get; set; }

        [StringLength(55)]
        public string Email { get; set; }

        [StringLength(15)]
        public string Phone { get; set; }

        [ForeignKey("fLegalAddress")]
        public virtual Address LegalAddress { get; set; }

        [ForeignKey("fActualAddress")]
        public virtual Address ActualAddress { get; set; }

        [ForeignKey("fBank")]
        public virtual Bank Bank { get; set; }

        [ForeignKey("fName")]
        public virtual Person Person { get; set; }

        // TODO: split this class, so that we won't have two collections here
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [InverseProperty("Client")]
        public virtual ICollection<Application> Applications { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [InverseProperty("Supplier")]
        public virtual ICollection<Receipt> Receipts { get; set; }
    }

    public enum CompanyType : int
    {
        Mine = 1,
        Client = 2,
        Supplier = 4,
        Both = Client | Supplier
    };
}
