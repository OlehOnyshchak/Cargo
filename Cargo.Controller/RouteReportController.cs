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

        public bool OnRouteReport_Add(RouteReportModel model, out string error)
        {
            error = null;
            return false;
        }

        public bool Validate(RouteReportModel model, out string error)
        {
            error = null;
            return false;
        }

        internal RouteReport GenerateRouteReport_Object(RouteReportModel model)
        {
            return null;
        }

        internal RouteReportModel GenerateRouteReport_Model(RouteReport app)
        {
            return null;
        }
    }
}