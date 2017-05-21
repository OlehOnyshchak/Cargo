using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cargo.Controller.Models;
using Cargo.Domain.Interfaces;
// TODO: add resolving of this with Ninject
using Cargo.Domain.Concrete;
using Cargo.Domain.Entities;

namespace Cargo.Controller
{
    public class VehicleController
    {
        private IVehicleRepository vehRep = new VehicleRepository();

        public bool OnAddVehicle(VehicleModel model, out string error)
        {
            Vehicle driver = this.GenerateVehicleObject(model);

            bool success = vehRep.Add(driver);
            error = success ? Controller.Success : Controller.InternalErrorMessage;

            return success;
        }

        public bool Validate(VehicleModel model, out string error)
        {
            if (String.IsNullOrWhiteSpace(model.VehicleBrand))
            {
                error = "Vehicle Brand should be specified";
                return false;
            }

            if (String.IsNullOrWhiteSpace(model.VehicleRegistration))
            {
                error = "Vehicle Registration should be specified";
                return false;
            }

            if (String.IsNullOrWhiteSpace(model.TrailerRegistration))
            {
                error = "Trailer Registration should be specified";
                return false;
            }

            error = Controller.Success;
            return true;
        }

        internal Vehicle GenerateVehicleObject(VehicleModel model)
        {
            return new Vehicle
            {
                VehicleBrand = model.VehicleBrand,
                VehicleRegistration = model.VehicleRegistration,
                TrailerRegistration = model.TrailerRegistration
            };
        }

    }
}
