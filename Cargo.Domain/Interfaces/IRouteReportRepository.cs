using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cargo.Domain.Entities;

namespace Cargo.Domain.Interfaces
{
    public interface IRouteReportRepository
    {
        bool Add(RouteReport report);

        IList<RouteReport> RouteReports { get; }
        IList<RouteReportShortView> RouteReportViews { get; }
    }
}
