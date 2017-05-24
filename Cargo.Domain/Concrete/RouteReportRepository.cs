using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cargo.Domain.Interfaces;
using Cargo.Domain.DB;
using Cargo.Domain.Entities;

namespace Cargo.Domain.Concrete
{
    public class RouteReportRepository : IRouteReportRepository
    {
        public bool Add(RouteReport report)
        {
            bool updated = false;
            using (var db = new CargoDbContext())
            {
                var updatedApp = report.Applications.First();
                var app = db.Applications.Where
                 (e => e.ApplicationId == updatedApp.ApplicationId).First();

                var veh = db.Vehicles.Where
                    (e => e.VehicleId == report.Vehicle.VehicleId).First();
                report.Vehicle = veh;

                var driver = db.Drivers.Where
                    (e => e.fDriverId == report.Driver.fDriverId).First();
                report.Driver = driver;

                db.Applications.Attach(app);

    //            app.RouteReport = report;
                app.LoadingDate = report.Applications.First().LoadingDate;
                app.UnloadingDate = report.Applications.First().UnloadingDate;


                report.Applications.Clear();
                report.Applications.Add(app);

                db.RouteReports.Add(report);
                updated = Repository.SaveChanges(db);
            }

            return updated;
        }

        public IList<RouteReport> RouteReports
        {
            get
            {
                IList<RouteReport> reports;
                using (var db = new CargoDbContext())
                {
                    reports = db.RouteReports.ToList();
                    foreach (var report in reports)
                    {
                        db.Entry(report).Reference(e => e.Driver).Load();
                        db.Entry(report).Reference(e => e.Vehicle).Load();
                    
                        db.Entry(report).Collection(e => e.Applications).Load();
                        db.Entry(report).Collection(e => e.ExternalSpendings).Load();
                        db.Entry(report).Collection(e => e.FuelSpendings).Load();
                    }
                }

                return reports;
            }
        }

        public IList<RouteReportShortView> RouteReportViews
        {
            get
            {
                IList<RouteReportShortView> reports;
                using (var db = new CargoDbContext())
                {
                    reports = db.RouteReportShortViews.ToList();
                }

                return reports;
            }

        }
    }
}
