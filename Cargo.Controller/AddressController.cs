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
            // TODO: implement
            error = Controller.Success;
            return true;
        }
    }
}
