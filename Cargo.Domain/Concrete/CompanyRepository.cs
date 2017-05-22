using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cargo.Domain.Interfaces;
using Cargo.Domain.DB;
using Cargo.Domain.Entities;

namespace Cargo.Domain.Concrete
{
    public class CompanyRepository : ICompanyRepository
    {
        public bool Add(Company company)
        {
            bool updated = false;
            using (var db = new CargoDbContext())
            {
                db.Companies.Add(company);
                updated = Repository.SaveChanges(db);
            }

            return updated;
        }

        public IList<Company> Companies
        {
            get
            {
                IList<Company> companies;
                using (var db = new CargoDbContext())
                {
                    companies = db.Companies.ToList();
                    foreach (var company in companies)
                    {
                        db.Entry(company).Reference(e => e.ActualAddress).Load();
                        db.Entry(company).Reference(e => e.LegalAddress).Load();
                        db.Entry(company).Reference(e => e.Person).Load();
                        db.Entry(company).Reference(e => e.Bank).Load();

                        db.Entry(company).Collection(e => e.Applications).Load();
                        db.Entry(company).Collection(e => e.Receipts).Load();
                    }
                }

                return companies;
            }
        }
    }
}
