using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;
using Cargo.Domain.Entities;

namespace Cargo.Controller.DocumentGenerator
{
    static public class DocumentManager
    {
        static internal string GetOfficialName(Person person)
        {
            string middle = person.MiddleName != null? person.MiddleName[0] + "." : String.Empty;
            return person.Surname + " " + person.Name[0] + "." + middle;
        }

        static internal string GetFullAddress(Address addr)
        {
            string postCode = addr.PostCode != null ? addr.PostCode + "," : String.Empty;
            string mainPart = addr.Country + " м." + addr.City + ", ";
            string street = addr.Street != null ? "вул. " + addr.Street + " " : String.Empty;
            string buildNum = addr.Number != null ? addr.Number : String.Empty;

            return postCode + mainPart + street + buildNum;
        }

        static internal string GetShortAddress(Address addr)
        {
            return addr.Country + " м." + addr.City; ;
        }

        static public void Free()
        {
  //          application.Quit();
        }
    }
}
