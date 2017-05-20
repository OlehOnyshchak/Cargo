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
        public CompanyGeneralModel GeneralModel;
        public AddressModel LegalAddressModel;
        public AddressModel ActualAddressModel;
        public BankModel BankModel;
        public PersonModel PersonModel;
    }
}
