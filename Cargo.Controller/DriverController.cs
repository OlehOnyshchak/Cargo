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

        public bool OnAddDriver(DriverModel model, out string error)
        {
            if (!Validate(model, out error))
                return false;

            Driver driver;
            this.GenerateDriverObject(model, out driver);

            bool success = driverRep.Add(driver);
            error = success ? Controller.Success : Controller.InternalErrorMessage;

            return success;
        }

        private bool Validate(DriverModel model, out string error)
        {
            // TODO: implement
            error = Controller.Success;
            return true;
        }

        private bool GenerateDriverModel(Driver driver, out DriverModel model)
        {
            if (driver.Person == null)
            {
                model = null;
                return false;
            }

            model = new DriverModel
            {
                GivenName = driver.Person.Name,
                MiddleName = driver.Person.MiddleName,
                FamilyName = driver.Person.Surname,
                PassportNumber = driver.PassportNum,
                InterestRate = driver.InterestRate
            };

            return true;
        }

        private void GenerateDriverObject(DriverModel model, out Driver driver)
        {
            Person person = new Person
            {
                Name = model.GivenName,
                MiddleName = model.MiddleName,
                Surname = model.FamilyName
            };

            driver = new Driver
            {
                Person = person,
                InterestRate = model.InterestRate,
                PassportNum = model.PassportNumber
            };
        }

        public IList<DriverModel> GetDrivers()
        {
            IList<DriverModel> models = new List<DriverModel>();
            IList<Driver> drivers = new List<Driver>(driverRep.Drivers.ToList());
            //IList<Driver> drivers = driverRep.Drivers.ToList();

            foreach (var driver in drivers)
            {
                DriverModel mod;
                this.GenerateDriverModel(driver, out mod);

                models.Add(mod);
            }
            
            return models;
        }
    }
}
