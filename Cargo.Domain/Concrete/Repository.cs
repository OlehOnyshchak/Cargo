using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cargo.Domain.DB;

namespace Cargo.Domain.Concrete
{
    class Repository
    {
        protected CargoDbContext context = new CargoDbContext();

        public bool SaveChanges()
        {
            bool succeeded = true;
            try
            {
                context.SaveChanges();
            }
            catch
            {
                succeeded = false;
            }

            return succeeded;
        }
    }
}
