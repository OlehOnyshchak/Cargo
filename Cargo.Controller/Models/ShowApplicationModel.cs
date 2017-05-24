using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargo.Controller.Models
{
    public class ShowApplicationModel
    {
        internal int ID { get; set; }
        public string VehicleRegistration { get; set; }
        public string FromCity { get; set; }
        public string ToCity { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? LoadingDate { get; set; }
        public DateTime? UnloadingDate { get; set; }
        public virtual RouteReportModel RouteReport { get; set; }
    }
}
