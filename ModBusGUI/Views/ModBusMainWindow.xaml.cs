using System;
using System.IO.Ports;
using System.Windows;
using ModBusGUI.ViewModels;
using ModBusGUI.Models;
using Modbus.Device;
using System.Collections.ObjectModel;

namespace ModBusGUI.Views
{
    /// <summary>
    /// Interaction logic for ModBusMainWindow.xaml
    /// </summary>
    public partial class ModBusMainWindow : Window
    {
        public ModBusMainWindow()
        {

            InitializeComponent();
            DataContext = new MBViewModel();
        }

        private void radioRTU_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
