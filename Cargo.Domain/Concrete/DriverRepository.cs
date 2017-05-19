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
    class DriverRepository : Repository,  IDriverRepository
    {
        public bool Add(Driver driver)
        {
            if (driver.Person == null)
            {
                return false;
            }

            context.Drivers.Add(driver);
            return base.SaveChanges();
        }

        public IEnumerable<Driver> Drivers
        {
            get { return context.Drivers; }
        }
    }
}
