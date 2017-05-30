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
using Cargo.Controller.Models;
using Cargo.Controller.DocumentGenerator;

namespace Cargo.UI.ShowViews
{
    /// <summary>
    /// Interaction logic for ShowVehiclesPage.xaml
    /// </summary>
    public partial class ShowVehiclesPage : PageFunction<String>
    {
        private VehicleController vehContr = new VehicleController();
        private AddApplicationModel appModel = null;
        private RouteReportModel reportModel = null;
        private List<KeyValuePair<string, int>> values;

        public ShowVehiclesPage()
        {
            InitializeComponent();
            m_listView.ItemsSource = vehContr.GetVehicles();
            m_buttonSelect.Visibility = Visibility.Hidden;
        }

        public ShowVehiclesPage(AddApplicationModel appMod)
        {
            InitializeComponent();
            m_listView.ItemsSource = vehContr.GetVehicles();
            appModel = appMod;

            m_buttonSelect.Visibility = Visibility.Visible;
            this.Title = "Choose Vehicle - Step 5";
            m_buttonSelect.Click += appSelectButton_Click;
        }

        public ShowVehiclesPage(RouteReportModel repMod)
        {
            InitializeComponent();
            m_listView.ItemsSource = vehContr.GetVehicles();
            reportModel = repMod;

            m_buttonSelect.Visibility = Visibility.Visible;
            this.Title = "Choose Vehicle - Step 2";
            m_buttonSelect.Click += repSelectButton_Click;
        }
        
        public ShowVehiclesPage(bool val)
        {
            InitializeComponent();
            m_listView.ItemsSource = vehContr.GetVehicles();

            m_buttonSelect.Visibility = Visibility.Visible;
            this.Title = "Choose Vehicle - Step 2";
            m_buttonSelect.Click += statSelectButton_Click;
        }

        private void statSelectButton_Click(object sender, RoutedEventArgs e)
        {
            if (m_listView.SelectedIndex != -1)
            {
                m_buttonSelect.Click -= statSelectButton_Click;

                VehicleModel vm = m_listView.SelectedItem as VehicleModel;
                var frame = Application.Current.MainWindow.FindName("_mainFrame") as Frame;
                var nextPage = new ShowVehicleStatistics(vm);
                nextPage.Return += new ReturnEventHandler<String>(ReturnHandle);
                frame.Navigate(nextPage);
            }
            else
            {
                MessageBox.Show("You must select the Vehicle", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void appSelectButton_Click(object sender, RoutedEventArgs e)
        {
            if (m_listView.SelectedIndex != -1)
            {
                m_buttonSelect.Click -= appSelectButton_Click;
                appModel.Vehicle = m_listView.SelectedItem as VehicleModel;
                this.OnReturn(null);
            }
            else
            {
                MessageBox.Show("You must select the Vehicle", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void repSelectButton_Click(object sender, RoutedEventArgs e)
        {
            if (m_listView.SelectedIndex != -1)
            {
                var frame = Application.Current.MainWindow.FindName("_mainFrame") as Frame;
                if (frame.CanGoForward)
                {
                    frame.GoForward();
                }
                else
                {
                    reportModel.Vehicle = m_listView.SelectedItem as VehicleModel;
                    var nextPage = new ShowDriversPage_New(reportModel);
                    nextPage.Return += new ReturnEventHandler<String>(ReturnHandle);

                    frame.Navigate(nextPage);
                }
            }
            else
            {
                MessageBox.Show("You must select the Vehicle", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var frame = Application.Current.MainWindow.FindName("_mainFrame") as Frame;
            frame.GoBack();
        }

        private void ReturnHandle(object sender, ReturnEventArgs<String> e)
        {
            this.OnReturn(null);
        }
    }
}
