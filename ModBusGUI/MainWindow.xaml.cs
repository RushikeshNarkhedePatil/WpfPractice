using System;
using System.Collections.Generic;
using System.IO.Ports;
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
using Modbus.Device;

namespace ModBusGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();
        }
        //private SerialPort serialPort = new SerialPort(); //Create a new SerialPort object.
        private Modbus.Device.IModbusSerialMaster masterRtu, masterAscii;
        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenConnection openConnection = new OpenConnection();
            try
            {
                openConnection.Open();
                progressbar.Value = 100;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }
    }
}
