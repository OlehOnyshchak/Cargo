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
        private string clientAccount;

        public event PropertyChangedEventHandler PropertyChanged;

        public string BankName
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

        public string ClientAccount
        {
            get { return clientAccount; }
            set
            {
                clientAccount = value;
                OnPropertyChanged("BankNumber");
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}