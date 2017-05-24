using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargo.Controller.Models
{
    public class AddApplicationModel
    {
        public AddApplicationModel()
        {
            Compensation = -1.0;
            Date = DateTime.MaxValue;
        }

        internal int ID { get; set; }
        public double Compensation { get; set; }
        public string DocumentNumber { get; set; }
        public DateTime Date { get; set; }
        public AddressModel LoadingAddress { get; set; }
        public AddressModel UnloadingAddress { get; set; }
        public CompanyModel Client { get; set; }
        public VehicleModel Vehicle { get; set; }
    }
}
