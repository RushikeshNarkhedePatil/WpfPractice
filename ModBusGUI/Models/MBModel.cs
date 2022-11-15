using Prism.Mvvm;
using ModBusGUI.Models;
using System.IO.Ports;
using Modbus.Device;
using System.Windows;
using System;
using ModBusGUI.Views;

namespace ModBusGUI.Models
{
    public class MBModel:BindableBase
    {
        private SerialPort serialPort = new SerialPort(); //Create a new SerialPort object.
        private Modbus.Device.IModbusSerialMaster masterRtu, masterAscii;
        //private String _PortName="COM4";
        //private int _BaudRate;
        //private int _DataBits;
        //private SerialPort _Parity;
        //private SerialPort _StopBits;
        // private object serialPort;
        private Parity parity;
        private StopBits stopBits;
        public MBModel()
        { 
        }
        // Demo
        private byte slaveID;
        private ushort address;
        private ushort quentity;

        public bool[] ReadCoilData = { false, false, false, false };

        private string _Message;
        //private string _PortName="COM4";
        //private int _BaudRate = 9600;
        //private int _DataBits = 8;
        //private string _Parity = "None";
        //private string _StopBits = "One";
        private string _SlaveID="10";
        private string _Address = "3999";
        private string _Quentity = "4";
        public string Message  
        {  
            get   
            {  
                return _Message;  
            }  
            set  
            {  
                SetProperty(ref _Message, value);  
            }  
        }
        //public string PortName
        //{
        //    get { return _PortName; }
        //    set
        //    {
        //        SetProperty(ref _PortName, value);
        //    }
        //}
        //public int BaudRate
        //{
        //    get { return _BaudRate; }
        //    set
        //    {
        //        SetProperty(ref _BaudRate, value);
        //    }
        //}

        //public int DataBits
        //{
        //    get { return _DataBits; }
        //    set
        //    {
        //        SetProperty(ref _DataBits, value);
        //    }
        //}
        //public string StopBits
        //{
        //    get { return _StopBits; }
        //    set
        //    {
        //        SetProperty(ref _StopBits, value);
        //    }
        //}

        //public string Parity
        //{
        //    get { return _Parity; }
        //    set
        //    {
        //        SetProperty(ref _Parity, value);
        //    }
        //}
        //public void OpenConnection()
        //{
        //    try
        //    {
        //        //ModBusMainWindow modBusMain = new ModBusMainWindow();
        //        //string parity = modBusMain.CombParityBit.SelectedItem.ToString();
        //        serialPort.PortName = _PortName;
        //        //MessageBox.Show(_Parity);
        //        serialPort.BaudRate = _BaudRate;
        //        serialPort.DataBits = _DataBits;
        //        serialPort.Parity = (Parity)Enum.Parse(typeof(Parity), _Parity);
        //        serialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), _StopBits);
        //        serialPort.Open();
               
        //        if (serialPort.IsOpen)
        //        {
        //            MessageBox.Show("Connection Open Successfully");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
        public void OpenConnectionRTU(string portName, int baudRate, Parity parity, int dataBits, StopBits stopBits)
        {
            try
            {
                MessageBox.Show(portName);
                ModbusSerialMaster masterRtu = ModbusSerialMaster.CreateRtu(serialPort);
                serialPort.Open();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            
        }

        // Read Coil and Input get and set values
        public string SlaveID
        {
            get { return _SlaveID; }
            set
            {
                SetProperty(ref _SlaveID, value);
            }
        }

        public string Address
        {
            get { return _Address; }
            set
            {
                SetProperty(ref _Address, value);
            }
        }
        public string Quentity
        {
            get { return _Quentity; }
            set
            {
                SetProperty(ref _Quentity, value);
            }
        }
        private string _Items="true";
        public string Items
        {
            get { return _Items; }
            set
            {
                SetProperty(ref _Items, value);
            }
        }
        
        public void ReadCoilAndInput()
        {
            //MessageBox.Show(_SlaveID);
           
            //MessageBox.Show(quentity.ToString());
            try
            {
                ModbusSerialMaster masterRtu = ModbusSerialMaster.CreateRtu(serialPort);
                slaveID = Convert.ToByte(_SlaveID);
                address = Convert.ToUInt16(_Address);
                quentity = Convert.ToUInt16(_Quentity);
                //masterRtu.WriteSingleCoil(10, 3999, false);
                ReadCoilData = masterRtu.ReadCoils(Convert.ToByte(_SlaveID), Convert.ToUInt16(_Address), Convert.ToUInt16(_Quentity));    // read Coil
                foreach (var item in ReadCoilData)
                {
                    //Console.WriteLine(item);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
          
        }

    }
}
