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
    class ApplicationController
    {
        // TODO: make controllers lightweiths if we would work in single-threaded env
        private IApplicationRepository appRep = new ApplicationRepository();
        private AddressController addrContr = new AddressController();
        private PersonController persContr = new PersonController();
        private VehicleController vehContr = new VehicleController();
        private CompanyController compContr = new CompanyController();

        public bool OnApplicationAdd(AddApplicationModel model, out string error)
        {
            Application app = GenerateApplication_Object(model);

            bool success = appRep.Add(app);
            error = success ? Controller.Success : Controller.InternalErrorMessage;

            return success;
        }

        public bool Validate(AddApplicationModel model, out string error)
        {
            error = Controller.Success;
            return true;
        }

        internal Application GenerateApplication_Object(AddApplicationModel model)
        {
            return new Application
            {
                ApplicationId = model.ID,
                Compensation = model.Compensation,
                IsCashCompensation = true,
                Date = DateTime.Today,
                DocumentNumber = model.DocumentNumber,

                LoadingAddress = addrContr.GenerateAddressObject(model.LoadingAddress),
                CustomsAddress = null,
                BorderAddress = null,
                ClearenceAddress = null,
                UnloadingAddress = addrContr.GenerateAddressObject(model.UnloadingAddress),

                LoadingDate = null,
                UnloadingDate = null,
                Client = compContr.GenerateCompanyObject(model.Client),
                RouteReport = null,
                Vehicle = vehContr.GenerateVehicleObject(model.Vehicle)
            };
        }

        internal AddApplicationModel GenerateApplication_Model(Application app)
        {
            return new AddApplicationModel
            {
                ID = app.ApplicationId,
                Compensation = app.Compensation,
                DocumentNumber = app.DocumentNumber,

                LoadingAddress = addrContr.GenerateAddressModel(app.LoadingAddress),
                UnloadingAddress = addrContr.GenerateAddressModel(app.UnloadingAddress),

                Client = compContr.GenerateCompanyModel(app.Client),
                Vehicle = vehContr.GenerateVehicleModel(app.Vehicle)
            };
        }
    }
}
