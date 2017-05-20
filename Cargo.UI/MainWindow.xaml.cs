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
using Cargo.UI.AddViews;

namespace Cargo.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            _mainFrame.NavigationService.Navigate(new AboutPage());
        }

        // TODO: implement this awesome feature!
        //  _mainFrame.NavigationService.Navigate(new Uri("http://www.google.com/"));
        private void AddDriver_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.NavigationService.Navigate(new AddDriverPage());
        }

        private void AddVehicle_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.NavigationService.Navigate(new Uri("http://www.google.com/"));
        }

        private void AddCompany_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.NavigationService.Navigate(new Uri("http://www.google.com/"));
        }
    }
}
