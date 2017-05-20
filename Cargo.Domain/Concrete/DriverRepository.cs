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
    public class DriverRepository : IDriverRepository
    {
        public bool Add(Driver driver)
        {
            bool updated = false;
            using (var db = new CargoDbContext())
            {
                if (driver.Person == null)
                {
                    return false;
                }

                var dr = db.Drivers.ToList();

                db.Drivers.Add(driver);
                updated = Repository.SaveChanges(db);
            }

            return updated;
        }

        public IList<Driver> Drivers
        {
            get
            {
                IList<Driver> drivers;
                using (var db = new CargoDbContext())
                {
                    drivers = db.Drivers.ToList();
                    foreach (var driver in drivers)
                    {
                        db.Entry(driver).Reference(d => d.Person).Load();
                    }
                }

                return drivers;
            }
        }
    }
}
