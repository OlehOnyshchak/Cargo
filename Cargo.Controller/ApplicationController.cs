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
    public class ApplicationController
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
            error = success ? GeneralController.Success : GeneralController.InternalErrorMessage;

            return success;
        }

        //public bool OnApplicationUpdate(ShowApplicationModel model, out string error)
        //{
        //    Application app = GenerateApplication_Object(model);

        //    bool success = appRep.Add(app);
        //    error = success ? Controller.Success : Controller.InternalErrorMessage;

        //    return success;
        //}

        public bool Validate(AddApplicationModel model, out string error)
        {
            GetApplicationsView();

            if (model.Compensation < 0.0)
            {
                error = "Compensation should be specified and it should be positive";
                return false;
            }

            if (String.IsNullOrWhiteSpace(model.DocumentNumber))
            {
                error = "Document Number should be specified";
                return false;
            }

            if (model.Date == DateTime.MaxValue)
            {
                error = "Incorrect Date";
                return false;
            }

            error = GeneralController.Success;
            return true;
        }

        internal Application GenerateApplication_Object(AddApplicationModel model)
        {
            return new Application
            {
                ApplicationId = model.ID,
                Compensation = model.Compensation,
                IsCashCompensation = true,
                Date = model.Date,
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

        internal Application GenerateApplication_Object(ShowApplicationModel model)
        {
            return new Application
            {
                ApplicationId = model.ID,
                LoadingDate = model.LoadingDate,
                UnloadingDate = model.UnloadingDate
                // TODO: somehow move parsing of RouteReport here, i.e uncomment this
//                RouteReport = routeContr.GenerateRouteReport_Object(model.RouteReport)
            };
        }


        internal AddApplicationModel GenerateAddApplication_Model(Application app)
        {
            return new AddApplicationModel
            {
                ID = app.ApplicationId,
                Compensation = app.Compensation,

                DocumentNumber = app.DocumentNumber,
                Date = app.Date,

                LoadingAddress = addrContr.GenerateAddressModel(app.LoadingAddress),
                UnloadingAddress = addrContr.GenerateAddressModel(app.UnloadingAddress),

                Client = compContr.GenerateCompanyModel(app.Client),
                Vehicle = vehContr.GenerateVehicleModel(app.Vehicle)
            };
        }

        internal ShowApplicationModel GenerateShowApplication_Model(ApplicationShortView app)
        {
            return new ShowApplicationModel
            {
                ID = app.ApplicationId,
                FromCity = app.FromCity,
                ToCity = app.ToCity,
                StartDate = app.StartDate,
                VehicleRegistration = app.VehicleRegistration
            };
        }

        public IList<AddApplicationModel> GetApplications()
        {
            IList<AddApplicationModel> models = new List<AddApplicationModel>();
            IList<Application> apps = appRep.Applications;

            foreach (var app in apps)
            {
                models.Add(this.GenerateAddApplication_Model(app));
            }

            return models;
        }

        public IList<ShowApplicationModel> GetApplicationsView()
        {
            IList<ShowApplicationModel> models = new List<ShowApplicationModel>();
            IList<ApplicationShortView> apps = appRep.OpenApplicationViews;

            foreach (var app in apps)
            {
                models.Add(this.GenerateShowApplication_Model(app));
            }

            return models;
        }
    }
}
