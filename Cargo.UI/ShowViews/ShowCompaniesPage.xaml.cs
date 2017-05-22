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

        public ShowCompaniesPage()
        {
            InitializeComponent();
            m_listView.ItemsSource = comContr.GetCompanies();
        }
    }
}
