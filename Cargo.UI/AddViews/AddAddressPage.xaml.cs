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
    /// Interaction logic for AddAddressPage.xaml
    /// </summary>
    public partial class AddAddressPage : PageFunction<CompanyModel>
    {
        private CompanyModel model;
        private AddressController controller = new AddressController();
        private bool isActualAddress;

        public AddAddressPage(CompanyModel _Model, bool _IsActualAddress)
        {
            InitializeComponent();

            this.model = _Model;
            this.isActualAddress = _IsActualAddress;
            var addrModel = new AddressModel();

            if (isActualAddress)
                model.ActualAddressModel = addrModel;
            else
                model.LegalAddressModel = addrModel;
            
            this.DataContext = addrModel;
            this.KeepAlive = true;
            Application.Current.MainWindow.Title = isActualAddress ? 
                "Add Actual Address - Step 4" : "Add Legal Address - Step 3";
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            string error;
            AddressModel mod = isActualAddress ? 
                model.ActualAddressModel : model.LegalAddressModel;
            if (controller.Validate(mod, out error))
            {
                var frame = Application.Current.MainWindow.FindName("_mainFrame") as Frame;
                if (frame.CanGoForward)
                {
                    frame.GoForward();
                }
                else
                {
                    var eventHandler = new ReturnEventHandler<CompanyModel>(NewCompanyAdded);
                    if (isActualAddress)
                    {
                        var nextPage = new AddPersonPage(model);
                        nextPage.Return += eventHandler;
                        frame.Navigate(nextPage);
                    }
                    else
                    {
                        var nextPage = new AddAddressPage(model, true);
                        nextPage.Return += eventHandler;
                        frame.Navigate(nextPage);
                    }
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
