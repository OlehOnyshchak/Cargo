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
using Cargo.Controller;
using Cargo.UI.AddViews;
using Cargo.UI.ShowViews;

namespace Cargo.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            _mainFrame.Navigate(new AboutPage());
        }

        // TODO: implement this awesome feature!
        //  _mainFrame.NavigationService.Navigate(new Uri("http://www.google.com/"));
        private void AddDriver_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new AddDriverPage());
        }

        private void AddVehicle_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new AddVehiclePage());
        }

        private void AddCompany_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new AddCompanyPage());
        }

        private void ShowDrivers_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new ShowDriversPage_New());
        }

        private void ShowVehicles_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new ShowVehiclesPage());
        }

        private void ShowCompanies_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new ShowCompaniesPage());
        }

        private void AddApplication_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new AddApplicationPage());
        }

        private void ShowApplications_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new ShowApplicationsPage());
        }

        private void AddRouteReport_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new AddRouteReportPage());
        }

        private void ShowReports_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new ShowRouteReporsPage());
        }

        private void GenerateReceipt_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new ShowRouteReporsPage(true));
        }

        private void GenerateSallary_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new ShowDriversPage_New(true));
        }
    }
}
