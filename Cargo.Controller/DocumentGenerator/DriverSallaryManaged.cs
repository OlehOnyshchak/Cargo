using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cargo.Domain.DB;
using Cargo.Domain.Entities;
using Microsoft.Office.Interop.Word;
using Cargo.Controller;
using Cargo.Controller.Models;
using System.IO;
using System.Diagnostics;

namespace Cargo.Controller.DocumentGenerator
{
    public class DriverSallaryManager
    {
        private const string templateFilePath = @"D:\Projects\University\Cargo\Cargo.Controller\DocumentTemplates\DriverSallary_Template.doc";
        private const string outputDir = @"D:\Projects\University\Cargo\Reports\DriverSallary";

        public bool generate(DriverModel dm, DateTime from, DateTime till)
        {
            using (var db = new CargoDbContext())
            {
                Microsoft.Office.Interop.Word.Application application =
                    new Microsoft.Office.Interop.Word.Application();

                Driver driver = db.Drivers.Where(e => e.fDriverId == dm.ID).First();
                List<RouteReport> reports = driver.RouteReports
                                .Where(e => from <= e.StartDate && e.StartDate <= till)
                                .ToList();

                Document document = application.Documents.Open(templateFilePath);
                var table = document.Tables[1];
                Row templateRow = table.Rows[2];

                int count = reports.Count;
                // TODO: add handling of 0 reports here withing document!
                if (count == 0) return false;

                var header = document.Range(document.Content.Start, table.Range.Start)
                    .FormattedText.Words;
                for (int i = 1; i <= header.Count; )
                {
                    switch (header[i].Text)
                    {
                        case "FullName":
                            header[i].Text = driver.Person.Name + " " + driver.Person.Surname;
                            break;
                        case "StartReportDate":
                            header[i].Text = from.ToString("dd.MM.yyyy"); ;
                            break;
                        case "EndReportDate":
                            header[i].Text = till.ToString("dd.MM.yyyy"); ;
                            break;
                    }
                    if (header[i].Text.Contains("#"))
                    {
                        header[i].Text = header[i].Text.Replace("#", String.Empty);
                    }
                    else
                    {
                        ++i;
                    }
                }

                for (int i = 0; i < count - 1; ++i)
                {
                    table.Rows.Add(templateRow);
                    table.Rows[2 + i].Range.FormattedText = templateRow.Range.FormattedText;
                    table.Rows[3 + i].Delete();
                }

                for (int i = 0; i < count; ++i)
                {
                    var report = reports[i];
                    var apl = report.Applications.First();
                    var rowWords = table.Rows[i + 2].Range.FormattedText.Words;
                    for (int j = 1; j <= rowWords.Count;)
                    {
                        switch (rowWords[j].Text)
                        {
                            case "FromCity":
                                rowWords[j].Text = apl.LoadingAddress.City;
                                break;
                            case "ToCity":
                                rowWords[j].Text = apl.UnloadingAddress.City;
                                break;
                            case "StartDate":
                                rowWords[j].Text = report.StartDate.ToString("dd.MM.yyyy");
                                break;
                            case "EndDate":
                                rowWords[j].Text = report.EndDate.ToString("dd.MM.yyyy");
                                break;
                            case "Compensation":
                                rowWords[j].Text = CalculateTotalCompensation(report).ToString();
                                break;
                            case "Credit":
                                rowWords[j].Text = report.RoadCredit.ToString();
                                break;
                            case "TotalSpendings":
                                rowWords[j].Text = report.TotalSpendings.ToString();
                                break;
                            case "InterestRate":
                                rowWords[j].Text = driver.InterestRate.ToString();
                                break;
                            case "Sallary":
                                rowWords[j].Text = CalculateRouteSallary(driver, report).ToString();
                                break;
                        }

                        if (rowWords[j].Text.Contains("#"))
                        {
                            rowWords[j].Text = rowWords[j].Text.Replace("#", String.Empty);
                        }
                        else
                        {
                            ++j;
                        }
                    }
                }

                var footer = document.Range(table.Range.End, document.Content.End)
                    .FormattedText.Words;

                for (int i = 1; i <= footer.Count;)
                {
                    if (footer[i].Text == "TotalSallary")
                    {
                        footer[i].Text = CalculateTotalSallary(driver, reports).ToString();
                    }

                    if (footer[i].Text.Contains("#"))
                    {
                        footer[i].Text = footer[i].Text.Replace("#", String.Empty);
                    }
                    else
                    {
                        ++i;
                    }
                }

                string filename = Guid.NewGuid().ToString() + ".doc";
                string outFilePath = Path.Combine(outputDir, filename);
                document.SaveAs(outFilePath);
                document.Close();
                // TODO: use singleton
                application.Quit();
                Process.Start("WINWORD.EXE", outFilePath);
            }

            return true;
        }

        
        private static double CalculateRouteSallary(Driver driver, RouteReport report)
        {
            double sum = 0.0;
            double delta = 0.0;

            var apps = report.Applications;
            foreach (var app in apps)
            {
                sum += app.Compensation;
                delta += report.TotalSpendings - report.RoadCredit;
            }

            double sallary = sum * driver.InterestRate;
            sallary += delta;

            return sallary;
        }


        private static double CalculateTotalSallary(Driver driver, List<RouteReport> reports)
        {
            double sum = 0.0;
            double delta = 0.0;
            foreach (var report in reports)
            {
                var apps = report.Applications;
                foreach (var app in apps)
                {
                    sum += app.Compensation;
                    delta += report.TotalSpendings - report.RoadCredit;
                }
            }

            double sallary = sum * driver.InterestRate;
            sallary += delta;

            return sallary;
        }

        private static double CalculateTotalCompensation(RouteReport report)
        {
            double total = 0.0;
            var apps = report.Applications;
            foreach (var app in apps)
            {
                total += app.Compensation;
            }

            return total;
        }
    }
}
