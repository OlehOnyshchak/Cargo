using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Cargo.Controller.Models
{
    public class PersonModel : INotifyPropertyChanged
    {
        private string gName;
        private string mName;
        private string fName;

        public event PropertyChangedEventHandler PropertyChanged;

        public string GivenName
        {
            get { return gName; }
            set
            {
                gName = value;
                OnPropertyChanged("GivenName");
                OnPropertyChanged("FullName");
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
                OnPropertyChanged("FullName");
            }
        }

        public string FullName
        {
            get { return gName + " " + fName; }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
