using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargo.Controller.Models
{
    public class ShowReportModel
    {
        internal int ID { get; set; }
        public string VehicleRegistration { get; set; }
        public string FromCity { get; set; }
        public string ToCity { get; set; }
        public DateTime? StartDate { get; set; }
    }
}
