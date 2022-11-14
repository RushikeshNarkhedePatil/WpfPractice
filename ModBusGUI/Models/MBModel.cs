using Prism.Mvvm;
using ModBusGUI.Models;
using System.IO.Ports;
using Modbus.Device;
using System.Windows;
using System;

namespace ModBusGUI.Models
{
    public class MBModel:BindableBase
    {
        private SerialPort serialPort = new SerialPort(); //Create a new SerialPort object.
        //private String _PortName="COM4";
        //private int _BaudRate;
        //private int _DataBits;
        //private SerialPort _Parity;
        //private SerialPort _StopBits;
        // private object serialPort;
        public MBModel()
        { 
        }
       // Demo
       private string _Message;
        private string _PortName="COM4";
        private int _BaudRate = 9600;
        private int _DataBits = 8;
        private string _Parity = "None";
        private string _StopBits = "One";
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
        public string PortName
        {
            get { return _PortName; }
            set
            {
                SetProperty(ref _PortName, value);
            }
        }
        public int BaudRate
        {
            get { return _BaudRate; }
            set
            {
                SetProperty(ref _BaudRate, value);
            }
        }

        public int DataBits
        {
            get { return _DataBits; }
            set
            {
                SetProperty(ref _DataBits, value);
            }
        }
        public string StopBits
        {
            get { return _StopBits; }
            set
            {
                SetProperty(ref _StopBits, value);
            }
        }

        public string Parity
        {
            get { return _Parity; }
            set
            {
                SetProperty(ref _Parity, value);
            }
        }
        public void OpenConnection(string msg)
        //public void OpenConnection()
        {
            try
            {
                serialPort.PortName = _PortName;
                MessageBox.Show(_Parity.ToString());
                serialPort.BaudRate = _BaudRate;
                serialPort.DataBits = _DataBits;
                serialPort.Parity = (Parity)Enum.Parse(typeof(Parity), _Parity.ToString());
                serialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), _StopBits.ToString());
                serialPort.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
