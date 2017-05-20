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
    public class DriverController
    {
        private IDriverRepository driverRep = new DriverRepository();

        public bool OnAddDriver(DriverModel model)
        {
            Person person = new Person
            {
                Name = model.GivenName,
                MiddleName = model.MiddleName,
                Surname = model.FamilyName
            };

            Driver driver = new Driver
            {
                Person = person,
                InterestRate = model.InterestRate,
                PassportNum = model.PassportNumber
            };

            return driverRep.Add(driver);
        }
    }
}
