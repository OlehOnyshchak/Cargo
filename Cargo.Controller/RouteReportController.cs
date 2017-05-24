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
    public class RouteReportController
    {
        private ApplicationController appContr = new ApplicationController();
        private DriverController drivContr = new DriverController();
        private VehicleController vehContr = new VehicleController();

        private IRouteReportRepository routeRep = new RouteReportRepository();

        public bool OnRouteReport_Add(RouteReportModel model, out string error)
        {
            RouteReport company = this.GenerateRouteReport_Object(model);

            bool success = routeRep.Add(company);
            error = success ? GeneralController.Success : GeneralController.InternalErrorMessage;

            return success;
        }

        public bool Validate(RouteReportModel model, out string error)
        {
            error = GeneralController.Success;
            return true;
        }

        internal RouteReport GenerateRouteReport_Object(RouteReportModel model)
        {
            RouteReport rr = new RouteReport
            {
                RouteReportId = model.ID,
                RoadCredit = model.RoadCredit,
                RouteMileage = model.RouteMileage,

                TaxedMileage = 0,
                FuelLevelBefore = 0,
                FuelLevelAfter = 0,

                StartDate = (DateTime)model.Application.LoadingDate,
                BorderCrossingDate = null,
                EndDate = (DateTime)model.Application.UnloadingDate,

                DriverInterestRate = model.Driver.InterestRate,
                TotalSpendings = model.TotalSpendings,

                Driver = drivContr.GenerateDriverObject(model.Driver),
                Vehicle = vehContr.GenerateVehicleObject(model.Vehicle)
            };

            rr.Applications = new List<Application>();
            rr.Applications.Add(appContr.GenerateApplication_Object(model.Application));

            rr.Applications.First().RouteReport = rr;
            return rr;
        }

        internal RouteReportModel GenerateRouteReport_Model(RouteReport rr)
        {
            return null;
        }

        internal ShowReportModel GenerateRouteReportView_Model(RouteReportShortView rr)
        {
            return new ShowReportModel
            {
                ID = rr.RouteReportId,
                VehicleRegistration = rr.VehicleRegistration,
                FromCity = rr.FromCity,
                ToCity = rr.ToCity,
                StartDate = rr.StartDate
            };
        }

        public IList<ShowReportModel> GetApplicationsView()
        {
            IList<ShowReportModel> models = new List<ShowReportModel>();
            IList<RouteReportShortView> apps = routeRep.RouteReportViews;

            foreach (var app in apps)
            {
                models.Add(this.GenerateRouteReportView_Model(app));
            }

            return models;
        }
    }
}