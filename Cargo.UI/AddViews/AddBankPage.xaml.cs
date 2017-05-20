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
    /// Interaction logic for AddBankPage.xaml
    /// </summary>
    public partial class AddBankPage : PageFunction<CompanyModel>
    {
        // TODO: implement selection from existing banks
        private CompanyModel model;
        private BankController controller = new BankController();

        public AddBankPage(CompanyModel Model)
        {
            InitializeComponent();

            model = Model;
            model.BankModel = new BankModel();
            this.DataContext = model.BankModel;

            this.KeepAlive = true;
            Application.Current.MainWindow.Title = "Add Bank Information - Step 2";
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            string error;
            if (controller.Validate(model.BankModel, out error))
            {
                var frame = Application.Current.MainWindow.FindName("_mainFrame") as Frame;
                if (frame.CanGoForward)
                {
                    frame.GoForward();
                }
                else
                {
                    var nextPage = new AddAddressPage(model, false);
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
            this.OnReturn(new ReturnEventArgs<CompanyModel>(this.model));
        }
    }
}
