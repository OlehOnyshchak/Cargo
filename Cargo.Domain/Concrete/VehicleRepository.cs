using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cargo.Domain.Interfaces;
using Cargo.Domain.DB;
using Cargo.Domain.Entities;
using System.Data.Entity;

namespace Cargo.Domain.Concrete
{
    public class VehicleRepository : IVehicleRepository
    {
        public bool Add(Vehicle veh)
        {
            bool updated = false;
            using (var db = new CargoDbContext())
            {
                db.Vehicles.Add(veh);
                updated = Repository.SaveChanges(db);
            }

            return updated;
        }

        public IList<Vehicle> Vehicles
        {
            get
            {
                IList<Vehicle> vehicles;
                using (var db = new CargoDbContext())
                {
                    vehicles = db.Vehicles.ToList();
                    foreach (var veh in vehicles)
                    {
                        db.Entry(veh).Collection(e => e.RouteReports).Load();
                        db.Entry(veh).Collection(e => e.ServiceSpendings).Load();
                    }
                }

                return vehicles;
            }
        }

    }
}
