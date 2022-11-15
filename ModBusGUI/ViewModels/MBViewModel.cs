using Prism.Mvvm;
using ModBusGUI.Models;
using Prism.Commands;
using System.Windows.Input;
using System.Windows;
using System.Collections.Generic;
using System.IO.Ports;
using System;

namespace ModBusGUI.ViewModels
{
    class MBViewModel:BindableBase
    {
        private SerialPort serialPort = new SerialPort(); //Create a new SerialPort object.
        private MBModel mbModel;
        private string _Title = "ModBus Project";
        private Parity parity;
        private StopBits stopBits;
        private string _Message;
        private string _PortName = "COM4";
        private int _BaudRate = 9600;
        private int _DataBits = 8;
        private string _Parity = "None";
        private string _StopBits = "One";
        private string _SlaveID = "10";
        private string _Address = "3999";
        private string _Quentity = "4";

        public string Header
        {
            get { return _Title; }
            set { SetProperty(ref _Title, value); }
        }
        public MBViewModel()
        {
            //_InputStatus = new List<MBModel>
            //{

            //};

            mbModel = new MBModel();
            ClickCommandOpen = new DelegateCommand(OpenConnection);
            ClickCommandRead = new DelegateCommand(ReadCoilAndInput);

        }

        //Demo
       
        public ICommand ClickCommandRead
        {
            get;
            private set;
        }
        public ICommand ClickCommandOpen
        {
            get;
            private set;
        }
        //public MBModel TestModel
        //{
        //    get
        //    {
        //        return testModel;
        //    }
        //    set
        //    {
        //        SetProperty(ref testModel, value);
        //    }
        //}

        // call Function
        private void OpenConnection()
        {
            if (_RTU == true)
            {
                MessageBox.Show(_PortName);
                parity = serialPort.Parity = (Parity)Enum.Parse(typeof(Parity), _Parity);
                stopBits = serialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), _StopBits);
                mbModel.OpenConnectionRTU(_PortName, _BaudRate, parity, _DataBits, stopBits);
            }
            if (_ASCII == true)
            {
                MessageBox.Show("Check ASCII");
            }
            
        }
        private void ReadCoilAndInput()
        {
            //parity= serialPort.Parity = (Parity)Enum.Parse(typeof(Parity), _Parity);
            //stopBits = serialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), _StopBits);
            //mbModel.OpenConnectionRTU(_PortName, _BaudRate, parity, _DataBits, stopBits);
                mbModel.ReadCoilAndInput();

        }
        // check radio button active or not
        private bool _RTU;
        private bool _ASCII;

        public bool RTU
        {
            get { return _RTU; }
            set
            {
                SetProperty(ref _RTU, value);
            }
        }
        public bool ASCII
        {
            get { return _ASCII; }
            set
            {
                SetProperty(ref _ASCII, value);
            }
        }

        public MBModel MBModel
        {
            get { return mbModel; }
            set
            {
                SetProperty(ref mbModel, value);
            }
        }
        // Open Connection Demo
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

    }
}
