using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Cargo.Domain.Entities
{
    [Table("Persons")]
    public partial class Person
    {
        public int PersonId { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [StringLength(20)]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(20)]
        public string Surname { get; set; }
    }
}
