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
using Cargo.Controller.Models;
using Cargo.Controller;

namespace Cargo.UI.AddViews
{
    /// <summary>
    /// Interaction logic for SelectDatesForQueryPage.xaml
    /// </summary>
    public partial class SelectDatesForQueryPage : PageFunction<String>
    {
        private DriverModel driverModel;
        public SelectDatesForQueryPage()
        {
            InitializeComponent();
        }

        public SelectDatesForQueryPage(DriverModel model)
        {
            InitializeComponent();

            driverModel = model;
            m_upLabel.Content = "From";
            m_downLabel.Content = "To";
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime from, till;
            if (DateTime.TryParse(m_upTextBox.Text, out from) &&
                DateTime.TryParse(m_downTextBox.Text, out till))
            {
                double sallary = GeneralController.CalculateSallary(driverModel, from, till);
                MessageBox.Show(String.Format("{0}'s sallary from {1} to {2} equals = {3} UAH",
                    driverModel.GivenName + ' ' + driverModel.FamilyName, from.ToShortDateString(), till.ToShortDateString(),
                    sallary), "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                this.OnReturn(null);
            }
            else
            {
                MessageBox.Show("You have submit invalid dates", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
