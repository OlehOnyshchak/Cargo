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
    /// Interaction logic for AddPerson.xaml
    /// </summary>
    public partial class AddPersonPage : PageFunction<CompanyModel>
    {
        private CompanyModel model;
        private PersonController persContr = new PersonController();
        private CompanyController compContr = new CompanyController();

        public AddPersonPage(CompanyModel Model)
        {
            InitializeComponent();

            model = Model;
            model.PersonModel = new PersonModel();
            this.DataContext = model.PersonModel;

            this.KeepAlive = true;
            Application.Current.MainWindow.Title = "Add Owner - Step 5";
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            string error;
            if (persContr.Validate(model.PersonModel, out error))
            {
                this.SaveNewCompany(sender, e);
            }
            else
            {
                MessageBox.Show(error, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SaveNewCompany(object sender, RoutedEventArgs e)
        {
            string error;
            if (compContr.OnCompanyAdd(model, out error))
            {
                MessageBox.Show("Operation finished successfully", "Notification",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                this.OnReturn(new ReturnEventArgs<CompanyModel>(this.model));
            }
            else
            {
                MessageBox.Show(error, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}