using System;
using System.IO.Ports;
using System.Windows;
using ModBusGUI.ViewModels;

namespace ModBusGUI.Views
{
    /// <summary>
    /// Interaction logic for ModBusMainWindow.xaml
    /// </summary>
    public partial class ModBusMainWindow : Window
    {
        //MBViewModel mBViewModel;
        public ModBusMainWindow()
        {
            
            InitializeComponent();
            this.DataContext = new MBViewModel();
        }
        private SerialPort serialPort = new SerialPort(); //Create a new SerialPort object.
        
        //private void OpenConnection_Button(object sender, RoutedEventArgs e)
        //{
            
        //    try
        //    {
        //        serialPort.PortName = txtPort.Text;
        //        serialPort.BaudRate = Convert.ToInt32(txtBaudRate.Text);
        //        serialPort.DataBits = Convert.ToInt32(txtData.Text);
        //        serialPort.Parity = (Parity)Enum.Parse(typeof(Parity), CombParityBit.Text);
        //        serialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), CombStopBit.Text);
        //        serialPort.Open();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
    }
}
