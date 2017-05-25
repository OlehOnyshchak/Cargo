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
using Cargo.Controller.DocumentGenerator;

namespace Cargo.UI.ShowViews
{
    /// <summary>
    /// Interaction logic for ShowRouteReporsPage.xaml
    /// </summary>
    public partial class ShowRouteReporsPage : PageFunction<String>
    {
        private RouteReportController repContr = new RouteReportController();
        private OperationType type;

        public enum OperationType { Show, GenerateReceipt, GenerateAcceptCert }

        public ShowRouteReporsPage(OperationType type)
        {
            InitializeComponent();
            m_buttonSelect.Visibility = 
                type != OperationType.Show ? Visibility.Visible : Visibility.Hidden;

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
                if (type == OperationType.GenerateReceipt)
                {
                    GeneralController.GenerateReceip(model);
                    MessageBox.Show("Operation finished successfully", "Notification",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    AcceptanceCertificateManager manager = new AcceptanceCertificateManager();
                    manager.generate(model);
                }
            }
            else
            {
                MessageBox.Show("You must select the Client", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
