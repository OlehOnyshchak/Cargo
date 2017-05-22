using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargo.Controller.Models
{
    class AddApplicationModel
    {
        internal int ID { get; set; }
        public double Compensation { get; set; }
        public string DocumentNumber { get; set; }
        public AddressModel LoadingAddress { get; set; }
        public AddressModel UnloadingAddress { get; set; }
        public CompanyModel Client { get; set; }
        public VehicleModel Vehicle { get; set; }
    }
}
