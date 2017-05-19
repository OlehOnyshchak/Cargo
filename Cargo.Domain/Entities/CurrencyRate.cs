namespace Cargo.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CurrencyRate
    {
        [Column(TypeName = "date")]
        public DateTime CurrencyRateId { get; set; }

        public double EurRate { get; set; }

        public double PlnRate { get; set; }
    }
}
