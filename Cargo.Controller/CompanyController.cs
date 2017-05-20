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

        public bool OnCompanyAdd(CompanyModel model, out string error)
        {
            if (!Validate(model, out error))
                return false;

            Company company;
            this.GenerateCompanyObject(model, out company);

            bool success = companyRep.Add(company);
            error = success ? Controller.Success : Controller.InternalErrorMessage;

            return success;
        }

        public bool Validate(CompanyGeneralModel model, out string error)
        {
            // TODO: implement
            error = Controller.Success;
            return true;
        }

        private bool GenerateCompanyObject(CompanyModel model, out Company company)
        {
            company = null;
            return false;
        }

        private bool Validate(CompanyModel model, out string error)
        {
            // TODO: implement
            error = Controller.Success;
            return true;
        }
    }
}
