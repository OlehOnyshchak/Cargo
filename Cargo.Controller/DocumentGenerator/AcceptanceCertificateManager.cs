using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;
using Cargo.Domain.DB;
using Cargo.Domain.Entities;
using Cargo.Controller.Models;
using Cargo.Controller;
using System.IO;
using System.Diagnostics;

namespace Cargo.Controller.DocumentGenerator
{
    public class AcceptanceCertificateManager
    {
        private RouteReportController repContr = new RouteReportController();

        // TODO: fix relative paths
        //private const string templateFilePath = @"..\DocumentTemplates\AcceptanceCertificate_Template.doc";
        //private const string outputDir = @"..\..\Reports\AcceptanceCertificate";

        private const string templateFilePath = @"D:\Projects\University\Cargo\Cargo.Controller\DocumentTemplates\AcceptanceCertificate_Template.doc";
        private const string outputDir = @"D:\Projects\University\Cargo\Reports\AcceptanceCertificate";
        private static int DocumentNumber = 0;

        public void generate(ShowReportModel model)
        {
            using (var db = new CargoDbContext())
            {
                RouteReport report = db.RouteReports.Where(e => e.RouteReportId == model.ID).First();
                Company myCompany = db.Companies.Where(e => e.CompanyType == CompanyType.Mine).First();
                Cargo.Domain.Entities.Application app = report.Applications.First();
                Company clientCompany = app.Client;

                Microsoft.Office.Interop.Word.Application application =
            new Microsoft.Office.Interop.Word.Application();

                //         Document document = DocumentManager.Application.Documents.Open(templateFilePath);
                Document document = application.Documents.Open(templateFilePath);
                ++DocumentNumber;

                int count = document.Words.Count;
                for (int i = 1; i <= document.Words.Count;)
                {
                    switch (document.Words[i].Text)
                    {
                        case "MyCompanyOwnerOfficialName":
                            document.Words[i].Text = DocumentManager
                                .GetOfficialName(myCompany.Person);
                            break;
                        case "ClientCompanyTitle":
                            document.Words[i].Text = clientCompany.Title;
                            break;
                        case "ClientCompanyOwnerOfficialName":
                            document.Words[i].Text = DocumentManager
                                .GetOfficialName(clientCompany.Person);
                            break;
                        case "DocumentNumber":
                            document.Words[i].Text = DocumentNumber.ToString();
                            break;
                        case "CurrentDate":
                            string date = DateTime.Now.ToString("dd.MM.yyyy");
                            document.Words[i].Text = date;
                            break;
                        case "MyCompanyTitle":
                            document.Words[i].Text = myCompany.Title;
                            break;
                        case "ApplicationDocumentNumber":
                            document.Words[i].Text = app.DocumentNumber;
                            break;
                        case "ApplicationDate":
                            document.Words[i].Text = app.Date.ToString("dd.MM.yyyy");
                            break;
                        case "VehicleRegistration":
                            document.Words[i].Text = report.Vehicle.VehicleRegistration;
                            break;
                        case "TrailerRegistration":
                            document.Words[i].Text = report.Vehicle.TrailerRegistration;
                            break;
                        case "LoadingAddress":
                            document.Words[i].Text = DocumentManager.
                                GetShortAddress(app.LoadingAddress);
                            break;
                        case "UnloadingAddress":
                            document.Words[i].Text = DocumentManager.
                                GetShortAddress(app.UnloadingAddress);
                            break;
                        case "ApplicationCompensation":
                            document.Words[i].Text = app.Compensation.ToString("F2");
                            break;
                        case "CompensationWithouTax":
                            document.Words[i].Text = (app.Compensation - app.Compensation / 6)
                                    .ToString("F2");
                            break;
                        case "TaxAmount":
                            document.Words[i].Text = (app.Compensation / 6).ToString("F2");
                            break;
                        case "MyCompanyRealAddress":
                            document.Words[i].Text = DocumentManager.
                                GetFullAddress(myCompany.ActualAddress);
                            break;
                        case "ClientCompanyRealAddress":
                            document.Words[i].Text = DocumentManager.
                                GetFullAddress(clientCompany.ActualAddress);
                            break;
                        case "MyCompanyBankNumber":
                            document.Words[i].Text = myCompany.BankNumber;
                            break;
                        case "ClientCompanyBankNumber":
                            document.Words[i].Text = clientCompany.BankNumber;
                            break;
                        case "MyCompanyTaxNumber":
                            document.Words[i].Text = myCompany.TaxNumber;
                            break;
                        case "ClientCompanyTaxNumber":
                            document.Words[i].Text = clientCompany.TaxNumber;
                            break;
                        case "MyCompanyBankName":
                            document.Words[i].Text = myCompany.Bank.Name;
                            break;
                        case "ClientCompanyBankName":
                            document.Words[i].Text = clientCompany.Bank.Name;
                            break;
                        case "MyCompanyBankTaxNumber":
                            document.Words[i].Text = myCompany.Bank.TaxNumber;
                            break;
                        case "ClientCompanyBankTaxNumber": 
                            document.Words[i].Text = clientCompany.Bank.Name;
                            break;
                    }

                    if (document.Words[i].Text.Contains('#'))
                    {
                        document.Words[i].Text = document.Words[i].Text.Replace("#", String.Empty);
                    }
                    else
                    {
                        ++i;
                    }
                }

                string filename = app.LoadingAddress.City + "_" + app.UnloadingAddress.City+ "_" + Guid.NewGuid().ToString() + ".doc";
                string outFilePath = Path.Combine(outputDir, filename);
                document.SaveAs(outFilePath);
                document.Close();
                application.Quit();
                Process.Start("WINWORD.EXE", outFilePath);
            }
        }
    }
}
