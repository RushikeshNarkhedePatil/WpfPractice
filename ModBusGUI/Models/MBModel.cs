using Prism.Mvvm;
using ModBusGUI.Models;
using System.IO.Ports;
using Modbus.Device;
using System.Windows;
using System;

namespace ModBusGUI.Models
{
    class MBModel:BindableBase
    {
        //private SerialPort serialPort = new SerialPort(); //Create a new SerialPort object.
        private String _PortName="COM4";
        private int _BaudRate;
        private int _DataBits;
        private SerialPort _Parity;
        private SerialPort _StopBits;

        public void OpenConnection()
        {
            //SerialPort serialPort = new SerialPort(); //Create a new SerialPort object.
            //serialPort.PortName = "COM4";
            //serialPort.BaudRate = 9600;
            //serialPort.DataBits = 8;
            //serialPort.Parity = Parity.None;
            //serialPort.StopBits = StopBits.One;
            //serialPort.Open();
            //ModbusSerialMaster master = ModbusSerialMaster.CreateRtu(serialPort);
        }

        //public SerialPort PortName
        //{
        //    get
        //    {
        //        return _PortName;
        //    }
        //    set
        //    {
        //        SetProperty(ref _PortName, value);
        //    }
        //}
        //public SerialPort BaudRate
        //{
        //    get
        //    {
        //        return _BaudRate;
        //    }
        //    set
        //    {
        //        SetProperty(ref _BaudRate, value);
        //    }
        //}
        //public SerialPort DataBits
        //{
        //    get
        //    {
        //        return _DataBits;
        //    }
        //    set
        //    {
        //        SetProperty(ref _DataBits, value);
        //    }
        //}
        public SerialPort Parity
        {
            get
            {
                return _Parity;
            }
            set
            {
                SetProperty(ref _Parity, value);
            }
        }
        public SerialPort StopBits
        {
            get
            {
                return _StopBits;
            }
            set
            {
                SetProperty(ref _StopBits, value);
            }
        }

        //public void OpenRTU()
        //{
        //    try
        //    {
        //        SerialPort serialPort = new SerialPort(); //Create a new SerialPort object.
        //        serialPort.PortName = "COM4";
        //        serialPort.BaudRate = 9600;
        //        serialPort.DataBits = 8;
        //        serialPort.Parity = Parity.None;
        //        serialPort.StopBits = StopBits.One;
        //        serialPort.Open();
        //        ModbusSerialMaster master = ModbusSerialMaster.CreateRtu(serialPort);
        //    }
        //    catch (Exception err)
        //    {
        //        MessageBox.Show(err.Message);
        //    }
        //}
    }
}
