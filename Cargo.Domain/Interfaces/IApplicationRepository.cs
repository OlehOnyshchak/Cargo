﻿using System;
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
        bool Update(Application app);

        IList<Application> Applications { get; }
        IList<ApplicationShortView> ApplicationViews { get; }
        IList<ApplicationShortView> OpenApplicationViews { get; }
    }
}
