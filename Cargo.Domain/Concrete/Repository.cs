using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cargo.Domain.DB;

namespace Cargo.Domain.Concrete
{
    static class Repository
    {
        public static bool SaveChanges(CargoDbContext context)
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
