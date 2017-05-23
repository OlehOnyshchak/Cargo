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

namespace Cargo.UI.ShowViews
{
    /// <summary>
    /// Interaction logic for ShowCompaniesPage.xaml
    /// </summary>
    public partial class ShowCompaniesPage : PageFunction<String>
    {
        private CompanyController comContr = new CompanyController();
        private AddApplicationModel appModel = null;

        public ShowCompaniesPage()
        {
            InitializeComponent();
            m_listView.ItemsSource = comContr.GetCompanies();

            m_buttonSelect.Visibility = Visibility.Hidden;
        }

        public ShowCompaniesPage(AddApplicationModel model)
        {
            InitializeComponent();
            m_listView.ItemsSource = comContr.GetCompanies();

            appModel = model;
            m_buttonSelect.Visibility = Visibility.Visible;
            this.Title = "Choose Client - Step 4";
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
                    appModel.Client = m_listView.SelectedItem as CompanyModel;
                    var nextPage = new ShowVehiclesPage(appModel);
                    nextPage.Return += ReturnHandle;

                    frame.Navigate(nextPage);
                }
            }
            else
            {
                MessageBox.Show("You must select the Client", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
