using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cargo.Controller.Models;
using Cargo.Domain.Interfaces;
using Cargo.Domain.Concrete;
using Cargo.Domain.Entities;

namespace Cargo.Controller
{
    public class PersonController
    {
        public bool Validate(PersonModel model, out string error)
        {
            if (String.IsNullOrWhiteSpace(model.GivenName))
            {
                error = "Given Name should be specified";
                return false;
            }

            if (String.IsNullOrWhiteSpace(model.FamilyName))
            {
                error = "Family Name should be specified";
                return false;
            }

            error = Controller.Success;
            return true;
        }

        internal Person GeneratePersonObject(PersonModel model)
        {
            if (String.IsNullOrWhiteSpace(model.MiddleName))
            {
                model.MiddleName = null;
            }

            return new Person
            {
                Name = model.GivenName,
                MiddleName = model.MiddleName,
                Surname = model.FamilyName
            };
        }

        internal PersonModel GeneratePersonModel(Person person)
        {
            return new PersonModel
            {
                GivenName = person.Name,
                MiddleName = person.MiddleName,
                FamilyName = person.Surname
            };
        }
    }
}
