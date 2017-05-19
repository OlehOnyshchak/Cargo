namespace Cargo.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bank
    {
        public int BankId { get; set; }

        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        public string TaxNumber { get; set; }
    }
}
