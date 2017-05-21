using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cargo.Controller.Models;
using Cargo.Domain.Interfaces;
// TODO: add resolving of this with Ninject
using Cargo.Domain.Concrete;
using Cargo.Domain.Entities;

namespace Cargo.Controller
{
    public class CompanyController
    {
        private ICompanyRepository companyRep = new CompanyRepository();
        private AddressController addrController = new AddressController();
        private BankController bankController = new BankController();
        private PersonController persController = new PersonController();
        private const string ct_Client = "Client";
        private const string ct_Supplier = "Suplier";
        private const string ct_Both = "Both";

        public bool OnCompanyAdd(CompanyModel model, out string error)
        {
            Company company;
            if (!this.GenerateCompanyObject(model, out company, out error))
            {
                return false;
            }

            bool success = companyRep.Add(company);
            error = success ? Controller.Success : Controller.InternalErrorMessage;

            return success;
        }

        public bool Validate(CompanyGeneralModel model, out string error)
        {
            if (String.IsNullOrWhiteSpace(model.TaxNumber))
            {
                error = "Company's Tax Number should be specified";
                return false;
            }

            if (String.IsNullOrWhiteSpace(model.Title))
            {
                error = "Title should be specified";
                return false;
            }

            if (String.IsNullOrWhiteSpace(model.Email) &&
                String.IsNullOrWhiteSpace(model.Phone))
            {
                error = "At least one of the Phone and Email fields should be specified";
                return false;
            }

            if (String.IsNullOrWhiteSpace(model.CompanyType))
            {
                error = "Company's Type should be specified";
                return false;
            }

            if (!model.CompanyType.Equals(ct_Client, StringComparison.OrdinalIgnoreCase) &&
                !model.CompanyType.Equals(ct_Supplier, StringComparison.OrdinalIgnoreCase) &&
                !model.CompanyType.Equals(ct_Both, StringComparison.OrdinalIgnoreCase))
            {
                error = String.Format("Company's Type has invalid value. It could be either {0} or {1} or {2}",
                    ct_Client, ct_Supplier, ct_Both);
                return false;
            }

            error = Controller.Success;
            return true;
        }

        // TODO:  make models const in all "generator" functions
        internal bool GenerateCompanyObject(CompanyModel model, out Company company, out string error)
        {
            company = null;
            CompanyType ct;
            if (!this.GenerateCompanyTypeObject
                (model.GeneralModel.CompanyType, out ct, out error))
            {
                return false;
            }

            if (String.IsNullOrWhiteSpace(model.GeneralModel.Email))
            {
                model.GeneralModel.Email = null;
            }

            if (String.IsNullOrWhiteSpace(model.GeneralModel.Phone))
            {
                model.GeneralModel.Phone = null;
            }

            company = new Company
            {
                Title = model.GeneralModel.Title,
                TaxNumber = model.GeneralModel.TaxNumber,
                CompanyType = ct,
                Email = model.GeneralModel.Email,
                Phone = model.GeneralModel.Phone,
                BankNumber = model.BankModel.ClientAccount
            };

            company.LegalAddress = addrController.GenerateAddressObject(model.LegalAddressModel);
            company.ActualAddress = addrController.GenerateAddressObject(model.ActualAddressModel);
            company.Person = persController.GeneratePersonObject(model.PersonModel);
            company.Bank = bankController.GenerateBankObject(model.BankModel);

            error = Controller.Success;
            return true;
        }

        internal bool GenerateCompanyTypeObject(string Type, out CompanyType ct, out string error)
        {
            ct = new CompanyType();
            bool succeeded = true;
            error = Controller.Success;

            switch (Type)
            {
                case ct_Client:
                    ct = CompanyType.Client;
                    break;
                case ct_Supplier:
                    ct = CompanyType.Client;
                    break;
                case ct_Both:
                    ct = CompanyType.Client;
                    break;
                default:
                    succeeded = false;
                    error = "Invalid value for Company Type field";
                    break;
            }

            return succeeded;
        }
    }
}
