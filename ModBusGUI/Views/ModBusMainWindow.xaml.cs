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
        //private ObservableCollection<Person> person;
        //MBViewModel mBViewModel;
        public ModBusMainWindow()
        {
            

            InitializeComponent();
            //person = new ObservableCollection<Person>()
            //{

            //    new Person() { Name = "Prabhat", Address = "India" },

            //    new Person() { Name = "Smith", Address = "US" }
            //};
            //lstRead.ItemsSource = person;

            this.DataContext = new MBViewModel();
        }
        private SerialPort serialPort = new SerialPort(); //Create a new SerialPort object.

        public bool[] ReadCoilData { get; private set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //bool[] arr = { false, false, false, false };
            MBModel mB = new MBModel();
            mB.ReadCoil(10, 3999, 4);
            ModbusSerialMaster masterRtu = ModbusSerialMaster.CreateRtu(serialPort);
            //ReadCoilData = masterRtu.ReadCoils(10, 3999, 4);    // read Coil
            foreach (var item in mB.arlist)
            {
                //ListViewRead.Items.Add(item);
            }
        }
        public void ViewListData()
        {
            //person.Add(new Person() { Name = "hello", Address = "word" });
        }

        private void Window_SelectedDatesChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
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
    
    //class Person
    //{
    //    public string Name { get; set; }
    //    public string Address { get; set; }
    //}
}
