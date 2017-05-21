using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Cargo.Controller.Models
{
    public class VehicleModel : INotifyPropertyChanged
    {
        private string vehRegistration;
        private string trailerRegistration;
        private string brand;

        public event PropertyChangedEventHandler PropertyChanged;

        public string VehicleRegistration
        {
            get { return vehRegistration; }
            set
            {
                vehRegistration = value;
                OnPropertyChanged("VehicleRegistration");
            }
        }

        public string TrailerRegistration
        {
            get { return trailerRegistration; }
            set
            {
                trailerRegistration = value;
                OnPropertyChanged("TrailerRegistration");
            }
        }

        public string VehicleBrand
        {
            get { return brand; }
            set
            {
                brand = value;
                OnPropertyChanged("VehicleBrand");
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}