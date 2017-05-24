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
    public class AddressController
    {
        public bool Validate(AddressModel model, out string error)
        {
            if (String.IsNullOrWhiteSpace(model.Country))
            {
                error = "Country should be specified";
                return false;
            }

            if (String.IsNullOrWhiteSpace(model.City))
            {
                error = "City should be specified";
                return false;
            }

            error = GeneralController.Success;
            return true;
        }

        internal Address GenerateAddressObject(AddressModel model)
        {
            if (String.IsNullOrWhiteSpace(model.Street))
            {
                model.Street = null;
            }

            if (String.IsNullOrWhiteSpace(model.Number))
            {
                model.Number = null;
            }

            if (String.IsNullOrWhiteSpace(model.PostCode))
            {
                model.PostCode = null;
            }

            return new Address
            {
                Country = model.Country,
                City = model.City,
                Street = model.Street,
                Number = model.Number,
                PostCode = model.PostCode
            };
        }

        internal AddressModel GenerateAddressModel(Address addr)
        {
            return new AddressModel
            {
                Country = addr.Country,
                City = addr.City,
                Street = addr.Street,
                Number = addr.Number,
                PostCode = addr.PostCode
            };
        }
    }
}
