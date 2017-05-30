using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls.DataVisualization.Charting;
using Cargo.Controller.Models;
using Cargo.Controller.DocumentGenerator;

namespace Cargo.UI.ShowViews
{
    /// <summary>
    /// Interaction logic for ShowVehicleStatistics.xaml
    /// </summary>
    public partial class ShowVehicleStatistics : PageFunction<String>
    {
        private List<KeyValuePair<string, int>> values = new List<KeyValuePair<string, int>>();
        public ShowVehicleStatistics(VehicleModel vm)
        {
            InitializeComponent();

            VehicleStatisticManager man = new VehicleStatisticManager();
            man.generate(vm, values);

            if (values.Count != 0)
            {
                ColumnChart1.DataContext = values;
            }
            else
            {
                MessageBox.Show(String.Format("Vehicle {0}, {1} haven't any routes",
                    vm.VehicleBrand, vm.VehicleRegistration),
                    "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                this.OnReturn(null);
            }
        }

        private void ReturnHandle(object sender, ReturnEventArgs<String> e)
        {
            this.OnReturn(null);
        }
    }
}