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
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
