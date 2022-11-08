using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ModBus.ViewModels;
using Modbus.Device;
using Modbus.IO;
namespace ModBus.Views
{
    /// <summary>
    /// Interaction logic for ModBusGUI.xaml
    /// </summary>
    public partial class ModBusGUI : Window
    {
        private SerialPort serialPort = new SerialPort(); //Create a new SerialPort object.
        private Modbus.Device.IModbusSerialMaster masterRtu, masterAscii;
        
        public ModBusGUI()
        {
            InitializeComponent();
            this.DataContext = new ModBusViewModel();
        }
        private void OpenConnectionButton(object sender, RoutedEventArgs e)
        {
            ProgressBarOpen.Value = 100;
        }

    }
}
