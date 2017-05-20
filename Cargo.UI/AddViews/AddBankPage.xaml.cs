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
        public AddBankPage(CompanyModel Model)
        {
            InitializeComponent();

            model = Model;
            model.BankModel = new BankModel();
            this.DataContext = model.BankModel;

             this.KeepAlive = true;
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            this.OnReturn(new ReturnEventArgs<CompanyModel>(this.model));
        }
    }
}
