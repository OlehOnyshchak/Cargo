using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cargo.Controller.Models;
using Cargo.Domain.Interfaces;
using Cargo.Domain.Concrete;
using Cargo.Domain.Entities;

namespace Cargo.Controller
{
    public class BankController
    {
        public bool Validate(BankModel model, out string error)
        {
            if (String.IsNullOrWhiteSpace(model.TaxNumber))
            {
                error = "Bank's Tax Number should be specified";
                return false;
            }

            if (String.IsNullOrWhiteSpace(model.BankName))
            {
                error = "Bank's Name should be specified";
                return false;
            }

            if (String.IsNullOrWhiteSpace(model.ClientAccount))
            {
                error = "Client's Account should be specified";
                return false;
            }

            error = Controller.Success;
            return true;
        }

        internal Bank GenerateBankObject(BankModel model)
        {
            return new Bank
            {
                Name = model.BankName,
                TaxNumber = model.TaxNumber
            };
        }
    }
}
