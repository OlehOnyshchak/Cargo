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
    /// Interaction logic for AddApplicationDatesPage.xaml
    /// </summary>
    public partial class AddApplicationDatesPage : PageFunction<String>
    {
        private RouteReportModel reportModel = null;

        public AddApplicationDatesPage()
        {
            InitializeComponent();
        }

        public AddApplicationDatesPage(RouteReportModel model)
        {
            InitializeComponent();
            reportModel = model;

            this.DataContext = reportModel.Application;
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            this.OnReturn(null);
        }
    }
}
