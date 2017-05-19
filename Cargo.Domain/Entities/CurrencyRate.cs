using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Cargo.Domain.Entities
{
    public partial class CurrencyRate
    {
        [Column(TypeName = "date")]
        public DateTime CurrencyRateId { get; set; }

        public double EurRate { get; set; }

        public double PlnRate { get; set; }
    }
}
