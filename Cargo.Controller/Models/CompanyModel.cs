using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cargo.Domain.Entities;

namespace Cargo.Controller.Models
{
    public class CompanyModel
    {
        public CompanyGeneralModel GeneralModel { get; set; }
        public AddressModel LegalAddressModel { get; set; }
        public AddressModel ActualAddressModel { get; set; }
        public BankModel BankModel { get; set; }
        public PersonModel PersonModel { get; set; }
    }
}
