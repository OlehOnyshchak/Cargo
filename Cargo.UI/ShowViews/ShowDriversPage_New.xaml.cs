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
using Cargo.UI.AddViews;

namespace Cargo.UI.ShowViews
{
    /// <summary>
    /// Interaction logic for ShowDriversPage_New.xaml
    /// </summary>
    public partial class ShowDriversPage_New : PageFunction<String>
    {
        private DriverController dController = new DriverController();
        private RouteReportModel reportModel = null;

        public ShowDriversPage_New()
        {
            InitializeComponent();
            m_listView.ItemsSource = dController.GetDrivers();

            this.KeepAlive = true;
            m_buttonSelect.Visibility = Visibility.Hidden;
            m_buttonSelect.Click += SelectButton_Click;
        }

        public ShowDriversPage_New(RouteReportModel model)
        {
            InitializeComponent();
            m_listView.ItemsSource = dController.GetDrivers();

            this.KeepAlive = true;
            reportModel = model;
            m_buttonSelect.Visibility = Visibility.Visible;
            m_buttonSelect.Click += SelectButton_Click;
        }

        public ShowDriversPage_New(bool generateSallary)
        {
            InitializeComponent();
            m_listView.ItemsSource = dController.GetDrivers();

            this.KeepAlive = true;
            m_buttonSelect.Visibility = Visibility.Visible;
            m_buttonSelect.Click += GenerateSallaryButton_Click;
        }

        private void SelectButton_Click(object sender, RoutedEventArgs e)
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
                    reportModel.Driver = m_listView.SelectedItem as DriverModel;
                    var nextPage = new ShowApplicationsPage(reportModel);
                    nextPage.Return += ReturnHandle;

                    frame.Navigate(nextPage);
                }
            }
            else
            {
                MessageBox.Show("You must select the Client", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GenerateSallaryButton_Click(object sender, RoutedEventArgs e)
        {
            if (m_listView.SelectedIndex != -1)
            {
                DriverModel model = m_listView.SelectedItem as DriverModel;
                
                var nextPage = new SelectDatesForQueryPage(model);
                nextPage.Return += ReturnHandle;

                var frame = Application.Current.MainWindow.FindName("_mainFrame") as Frame;
                frame.Navigate(nextPage);
            }
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var frame = Application.Current.MainWindow.FindName("_mainFrame") as Frame;
            frame.GoBack();
        }

        private void ReturnHandle(object sender, ReturnEventArgs<String> e)
        {
            this.Title = CommonProperties.ProgramName;
            this.OnReturn(null);
        }
    }
}
