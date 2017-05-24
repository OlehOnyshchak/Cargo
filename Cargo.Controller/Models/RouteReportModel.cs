using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargo.Controller.Models
{
    public class RouteReportModel
    {
        internal int ID { get; set; }
        public double RoadCredit { get; set; }
        public int RouteMileage { get; set; }
        public double TotalSpendings { get; set; }
        public DriverModel Driver { get; set; }
        public VehicleModel Vehicle { get; set; }
        public ShowApplicationModel Application { get; set; }
    }
}
