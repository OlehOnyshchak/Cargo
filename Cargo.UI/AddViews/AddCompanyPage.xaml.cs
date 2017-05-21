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

namespace Cargo.UI.AddViews
{
    /// <summary>
    /// Interaction logic for AddCompanyPage.xaml
    /// </summary>
    public partial class AddCompanyPage : PageFunction<String>
    {
        private CompanyModel model = new CompanyModel();
        private List<string> companyTypes = new List<string>();
        private CompanyController controller = new CompanyController();

        public AddCompanyPage()
        {
            InitializeComponent();

            companyTypes.Add("Client");
            companyTypes.Add("Supplier");
            companyTypes.Add("Both");
            this.m_comboBoxType.ItemsSource = companyTypes;
            this.m_comboBoxType.SelectedIndex = 0;

            model.GeneralModel = new CompanyGeneralModel();
            this.DataContext = model.GeneralModel;

            this.KeepAlive = true;
            Application.Current.MainWindow.Title = "Add Company - Step 1";
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            string error;
            if (controller.Validate(model.GeneralModel, out error))
            {
                var frame = Application.Current.MainWindow.FindName("_mainFrame") as Frame;
                if (frame.CanGoForward)
                {
                    frame.GoForward();
                }
                else
                {
                    var nextPage = new AddBankPage(model);
                    nextPage.Return += new ReturnEventHandler<CompanyModel>(NewCompanyAdded);

                    frame.Navigate(nextPage);
                }
            }
            else
            {
                MessageBox.Show(error, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void NewCompanyAdded(object sender, ReturnEventArgs<CompanyModel> e)
        {
            CompanyModel m = e.Result;
            this.OnReturn(null);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Title = "Main Window";
            this.OnReturn(null);
        }
    }
}
