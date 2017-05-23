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
using Cargo.UI.ShowViews;

namespace Cargo.UI.AddViews
{
    /// <summary>
    /// Interaction logic for AddAddressPage.xaml
    /// </summary>
    public partial class AddAddressPage : PageFunction<String>
    {
        private CompanyModel compModel;
        private AddApplicationModel appModel;
        private AddressController controller = new AddressController();

        protected enum Type { LoadingAddr, UnloadingAddr, ActualAddr, LegalAddr };
        private Type type;

        protected enum Mode { CompanyWizard, ApplicationWizard };
        private Mode mode;

        public AddAddressPage(CompanyModel _Model, bool IsActualAddress)
        {
            InitializeComponent();

            mode = Mode.CompanyWizard;
            this.compModel = _Model;

            this.type = IsActualAddress ? Type.ActualAddr : Type.LegalAddr;
            var addrModel = new AddressModel();

            if (type == Type.ActualAddr)
                compModel.ActualAddressModel = addrModel;
            else
                compModel.LegalAddressModel = addrModel;
            
            this.DataContext = addrModel;
            this.KeepAlive = true;
            Application.Current.MainWindow.Title = type == Type.ActualAddr ? 
                "Add Actual Address - Step 4" : "Add Legal Address - Step 3";
        }

        public AddAddressPage(AddApplicationModel _Model, bool isLoadingAddr)
        {
            InitializeComponent();

            mode = Mode.ApplicationWizard;
            this.appModel = _Model;

            this.type = isLoadingAddr ? Type.LoadingAddr : Type.UnloadingAddr;
            var addrModel = new AddressModel();

            if (type == Type.LoadingAddr)
                appModel.LoadingAddress = addrModel;
            else
                appModel.UnloadingAddress = addrModel;

            this.DataContext = addrModel;
            this.KeepAlive = true;

            Application.Current.MainWindow.Title = type == Type.LoadingAddr ?
                "Add Loading Address - Step 2" : "Add Unloading Address - Step 3";
        }

        private AddressModel GetCurrentModel()
        {
            AddressModel currMod;
            if (mode == Mode.CompanyWizard)
            {
                currMod = type == Type.ActualAddr ?
                compModel.ActualAddressModel : compModel.LegalAddressModel;
            }
            else // mode == Mode.ApplicationWizard
            {
                currMod = type == Type.LoadingAddr ?
                appModel.LoadingAddress : appModel.UnloadingAddress;
            }

            return currMod;
        }

        private void NextCompanyWizardStep(Frame frame)
        {
            var eventHandler = new ReturnEventHandler<String>(ReturnHandle);

            PageFunction<String> INextPage;
            if (type == Type.ActualAddr)
            {
                INextPage = new AddPersonPage(compModel);
            }
            else
            {
                INextPage = new AddAddressPage(compModel, true);
            }

            INextPage.Return += eventHandler;
            frame.Navigate(INextPage);
        }

        private void NextApplicationWizardStep(Frame frame)
        {
            var eventHandler = new ReturnEventHandler<String>(ReturnHandle);
            PageFunction<String> INextPage;

            if (type == Type.LoadingAddr)
            {
                INextPage = new AddAddressPage(appModel, false);
            }
            else
            {
                INextPage = new ShowCompaniesPage(appModel);
            }

            INextPage.Return += eventHandler;
            frame.Navigate(INextPage);
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            string error;
            AddressModel mod = this.GetCurrentModel();
            if (controller.Validate(mod, out error))
            {
                var frame = Application.Current.MainWindow.FindName("_mainFrame") as Frame;
                if (frame.CanGoForward)
                {
                    frame.GoForward();
                }
                else
                {
                    if (mode == Mode.CompanyWizard)
                    {
                        NextCompanyWizardStep(frame);
                    }
                    else
                    {
                        NextApplicationWizardStep(frame);
                    }
                }
            }
            else
            {
                MessageBox.Show(error, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ReturnHandle(object sender, ReturnEventArgs<String> e)
        {
            this.Title = CommonProperties.ProgramName;
            this.OnReturn(null);
        }
    }
}
