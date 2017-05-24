using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;
using Cargo.Domain.DB;
using Cargo.Controller.Models;

namespace Cargo.Controller.DocumentGenerator
{
    internal class AcceptanceCertificateManager
    {
        void generate()
        {
            Document document = application.Documents.Open(
         @"C:\Users\oleh.onyshchak\Desktop\CargoTemplates\AcceptanceCertificate_Template.doc");

            // Loop through all words in the document.
            int count = document.Words.Count;
            for (int i = 1; i <= count; i++)
            {
                // Write the word.
                string text = document.Words[i].Text;
                switch (text)
                {
                    case "MyCompanyOwnerOfficialName":
                        break;
                    case "ClientCompanyTitle":
                        break;
                    case "ClientCompanyOwnerOfficialName":
                        break;
                    case "DocumentNumber":
                        break;
                    case "CurrentDate":
                        break;
                    case "MyCompanyTitle":
                        break;
                    case "ApplicationDocumentNumber":
                        break;
                    case "ApplicationDate":
                        break;
                    case "VehicleRegistration":
                        break;
                    case "TrailerRegistration":
                        break;
                    case "LoadingAddresss":
                        break;
                    case "UnloadingAddress":
                        break;
                    case "ApplicationCompensation":
                        break;
                    case "CompensationWithouTax":
                        break;
                    case "TaxAmount":
                        break;
                    case "MyCompanyRealAddress":
                        break;
                    case "ClientCompanyRealAddress":
                        break;
                    case "MyCompanyBankNumber":
                        break;
                    case "ClientCompanyBankNumber":
                        break;
                    case "MyCompanyTaxNumber":
                        break;
                    case "ClientCompanyTaxNumber":
                        break;
                    case "MyCompanyBankName":
                        break;
                    case "ClientCompanyBankName":
                        break;
                    case "MyCompanyBankTaxNumber":
                        break;
                    case "ClientCompanyBankTaxNumber":
                        break;
                }
            }

            document.SaveAs(@"C:\Users\oleh.onyshchak\Desktop\CargoTemplates\AcceptanceCertificate_Template_НАМАНИЙ.doc");
            //Process.Start("WINWORD.EXE", "\"" + outputFileName + "\"");
        }
    }
}
