using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cargo.Domain.Entities;
using Cargo.Domain.Interfaces;
using Cargo.Domain.DB;

namespace Cargo.Domain.Concrete
{
    public class ApplicationRepository : IApplicationRepository
    {
        public bool Add(Application app)
        {
            bool updated = false;
            using (var db = new CargoDbContext())
            {
                var client = db.Companies.Where(c => c.CompanyId == app.Client.CompanyId).First();
                app.Client = client;

                var vehicle = db.Vehicles.Where(c => c.VehicleId == app.Vehicle.VehicleId).First();
                app.Vehicle = vehicle;

                db.Applications.Add(app);
                updated = Repository.SaveChanges(db);
            }

            return updated;
        }

        public bool Update(Application updatedApp)
        {
            bool updated = false;
            using (var db = new CargoDbContext())
            {
                var app = db.Applications.Where
                    (e => e.ApplicationId == updatedApp.ApplicationId).First();
 
                var report = db.RouteReports.Where
                    (e => e.RouteReportId == updatedApp.RouteReport.RouteReportId).First();

                db.Applications.Attach(app);

                app.RouteReport = report;
                app.LoadingDate = updatedApp.LoadingDate;
                app.UnloadingDate = updatedApp.UnloadingDate;

                updated = Repository.SaveChanges(db);
            }

            return updated;
        }

        public IList<Application> Applications
        {
            get
            {
                IList<Application> apps;
                using (var db = new CargoDbContext())
                {
                    apps = db.Applications.ToList();
                    foreach (var app in apps)
                    {
                        // TODO: implement separate functions and upload onlu needed information
                        db.Entry(app).Reference(e => e.LoadingAddress).Load();
                        db.Entry(app).Reference(e => e.UnloadingAddress).Load();
                        db.Entry(app).Reference(e => e.CustomsAddress).Load();
                        db.Entry(app).Reference(e => e.BorderAddress).Load();
                        db.Entry(app).Reference(e => e.ClearenceAddress).Load();
                        db.Entry(app).Reference(e => e.UnloadingAddress).Load();
                        db.Entry(app).Reference(e => e.Client).Load();
                        db.Entry(app).Reference(e => e.RouteReport).Load();
                        db.Entry(app).Reference(e => e.Vehicle).Load();
                    }
                }

                return apps;
            }
        }

        public IList<ApplicationShortView> ApplicationViews
        {
            get
            {
                IList<ApplicationShortView> apps;
                using (var db = new CargoDbContext())
                {
                    apps = db.ApplicationShortViews.ToList();
                    foreach (var app in apps)
                    {
                        db.Entry(app).Reference(e => e.RouteReport).Load();
                    }
                }

                return apps;
            }
        }

        public IList<ApplicationShortView> OpenApplicationViews
        {
            get
            {
                IList<ApplicationShortView> apps;
                using (var db = new CargoDbContext())
                {
                    apps = db.ApplicationShortViews.Where(e => e.fRouteReport == null).ToList();
                    foreach (var app in apps)
                    {
                        db.Entry(app).Reference(e => e.RouteReport).Load();
                    }
                }

                return apps;
            }
        }

    }
}
