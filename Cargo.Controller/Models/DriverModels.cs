using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargo.Controller.Models
{
    class AddDriverModel
    {
        public string PassportNumber { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string Surname { get; set; }
        public double InterestRate { get; set; }
    }
}
