using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cargo.Controller.Models;
using Cargo.Domain.DB;
using Cargo.Domain.Entities;
using System.IO;

namespace Cargo.Controller
{
    public static class GeneralController
    {
        public static string InternalErrorMessage = "Some internal error have occured" +
            "during updating the DB. Restarting the program might solve the problem";

        public static string Success = "Success";

        private static int num = 0;

        public static void GenerateReceip(ShowReportModel model)
        {
            using (var db = new CargoDbContext())
            {
                RouteReport report = db.RouteReports.Where(e => e.RouteReportId == model.ID).First();
                Application apl = report.Applications.First();
                Company myCompany = db.Companies.Where(e => e.CompanyType == CompanyType.Mine).First();
                string[] lines =
                    {
                    @"Рахунок",
                String.Format("Постачальник {0}, ЄДРПОу  {1}", myCompany.Title, myCompany.TaxNumber),
                String.Format("{0}, МФО  {1} : р/р {2}", myCompany.Bank.Name, myCompany.Bank.TaxNumber, myCompany.BankNumber),
                "",
                String.Format("Платник {0}", apl.Client.Title),
                String.Format("Рахунок №{0} від {1}", apl.DocumentNumber, apl.Date),
                "",
                "Транспортні послуги:",
                String.Format("{0} – {1} || Вартість: {2}", apl.LoadingAddress.City, apl.UnloadingAddress.City, apl.Compensation),
                "",
                String.Format("Дата: {0}                                            Підпис: _______________", DateTime.Today)
                };

                String path = num.ToString() + ".txt";
                System.IO.File.WriteAllLines(Path.Combine (@"D:\Projects\University\Cargo\Reports", path), lines);
                ++num;
            }
        }

        public static double CalculateSallary(DriverModel model, DateTime from, DateTime till)
        {
            using (var db = new CargoDbContext())
            {
                Driver driver = db.Drivers.Where(e => e.fDriverId == model.ID).First();
                IEnumerable<RouteReport> reports = driver.RouteReports.Where(e => from <= e.StartDate && e.EndDate <= till);
                double sum = 0.0;
                double delta = 0.0;
                foreach (var report in reports)
                {
                    Application apl = report.Applications.First();
                    sum += apl.Compensation;
                    delta += report.TotalSpendings - report.RoadCredit;
                }

                double sallary = sum * driver.InterestRate;
                sallary += delta;

                return sallary;
            }
        }
    }
}
