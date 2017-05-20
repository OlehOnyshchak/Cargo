using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cargo.Domain.Entities;

namespace Cargo.Domain.Interfaces
{
    interface ICompanyRepository
    {
        bool Add(Company driver);

        IList<Company> Drivers { get; }
    }
}
