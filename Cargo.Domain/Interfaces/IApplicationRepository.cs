using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cargo.Domain.Entities;

namespace Cargo.Domain.Interfaces
{
    public interface IApplicationRepository
    {
        bool Add(Application app);

        IList<Application> Applications { get; }
    }
}
