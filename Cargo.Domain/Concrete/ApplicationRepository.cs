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
                db.Applications.Add(app);
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
    }
}
