using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Cargo.Controller.Models
{
    public class BankModel : INotifyPropertyChanged
    {
        private string name;
        private string taxNum;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public string TaxNumber
        {
            get { return taxNum; }
            set
            {
                taxNum = value;
                OnPropertyChanged("TaxNumber");
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}