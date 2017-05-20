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

        public IEnumerable<Driver> Drivers
        {
            get
            {
                using (var db = new CargoDbContext())
                {
                    return db.Drivers;
                }
            }
        }
    }
}
