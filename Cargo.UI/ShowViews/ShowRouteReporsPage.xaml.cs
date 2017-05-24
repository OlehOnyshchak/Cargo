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
    /// Interaction logic for ShowRouteReporsPage.xaml
    /// </summary>
    public partial class ShowRouteReporsPage : PageFunction<String>
    {
        private RouteReportController repContr = new RouteReportController();

        public ShowRouteReporsPage(bool generate = false)
        {
            InitializeComponent();
            m_buttonSelect.Visibility = generate ? Visibility.Visible : Visibility.Hidden;

            m_listView.ItemsSource = repContr.GetApplicationsView();
        }


        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var frame = Application.Current.MainWindow.FindName("_mainFrame") as Frame;
            frame.GoBack();
        }


        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            if (m_listView.SelectedIndex != -1)
            {
                ShowReportModel model = m_listView.SelectedItem as ShowReportModel;
                GeneralController.GenerateReceip(model);
                MessageBox.Show("Operation finished successfully", "Notification",
       MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("You must select the Client", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
