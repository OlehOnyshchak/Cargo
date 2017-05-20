using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Cargo.Controller.Models
{
    public class DriverModel : INotifyPropertyChanged
    {
        private string pass;
        private string gName;
        private string mName;
        private string fName;
        private double rate; 

        public event PropertyChangedEventHandler PropertyChanged;

        public DriverModel()
        {
            InterestRate = -1.0;
        }

        public string PassportNumber
        {
            get { return pass; }
            set
            {
                pass = value;
                OnPropertyChanged("PassportNumber");
            }
        }

        public string GivenName
        {
            get { return gName; }
            set
            {
                gName = value;
                OnPropertyChanged("GivenName");
            }
        }

        public string MiddleName
        {
            get { return mName; }
            set
            {
                mName = value;
                OnPropertyChanged("MiddleName");
            }
        }

        public string FamilyName
        {
            get { return fName; }
            set
            {
                fName = value;
                OnPropertyChanged("FamilyName");
            }
        }

        public double InterestRate
        {
            get { return rate; }
            set
            {
                rate = value;
                OnPropertyChanged("InterestRate");
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
