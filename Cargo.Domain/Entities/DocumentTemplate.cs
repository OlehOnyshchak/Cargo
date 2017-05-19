namespace Cargo.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DocumentTemplate
    {
        public int DocumentTemplateId { get; set; }

        [Required]
        [StringLength(16)]
        public string Number { get; set; }

        [Required]
        public string Template { get; set; }
    }
}
