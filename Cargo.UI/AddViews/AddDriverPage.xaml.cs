﻿using System;
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
    /// Interaction logic for AddDriverPage.xaml
    /// </summary>
    public partial class AddDriverPage : PageFunction<String>
    {
        private DriverModel model = new DriverModel();
        private DriverController dController = new DriverController();

        public AddDriverPage()
        {
            InitializeComponent();
            this.DataContext = model;
        }

        private void AddDriver_Click(object sender, RoutedEventArgs e)
        {
            if (dController.OnAddDriver(model))
            {
                MessageBox.Show("Operation finished successfully", "Notification",
                    MessageBoxButton.OK, MessageBoxImage.Exclamation);

                this.OnReturn(null);
            }
            else
            {
                MessageBox.Show("You filed incorect data", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
