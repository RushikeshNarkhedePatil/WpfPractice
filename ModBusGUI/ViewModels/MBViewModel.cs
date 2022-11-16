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
        private byte _SlaveID = 10;
        private ushort _Address = 3999;
        private ushort _Quentity = 4;
        private int SingleCoilPosition;
        private bool WriteCoil = false;
        public bool[] ReadCoilData = { false, false, false, false };
        private bool[] WriteMultiCoilData = { false, false, false, false };

        public string Header
        {
            get { return _Title; }
            set { SetProperty(ref _Title, value); }
        }
        public MBViewModel()
        {

            mbModel = new MBModel();
            ClickCommandOpen = new DelegateCommand(OpenConnection);
            ClickCommandRead = new DelegateCommand(ReadCoilAndInput);
            CmdWriteSingleCoil = new DelegateCommand(WriteSingleCoil);
            CmdWriteMultiCoil = new DelegateCommand(WriteMultiCoil);
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
        public ICommand CmdWriteSingleCoil
        {
            get;
            private set;
        }
        public ICommand CmdWriteMultiCoil
        {
            get;
            private set;
        }
        // call Function
        private void OpenConnection()
        {
            if (_RTU == true)
            {
                MessageBox.Show(_PortName);
                parity = serialPort.Parity = (Parity)Enum.Parse(typeof(Parity), _Parity);               // typecast value
                stopBits = serialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), _StopBits);

                mbModel.OpenConnectionRTU(_PortName, _BaudRate, parity, _DataBits, stopBits);           // Call Open Connection
                _ProgressBarOpen = 100;
                
                MessageBox.Show(_ProgressBarOpen.ToString());

            }
            if (_ASCII == true)
            {
                MessageBox.Show("Implementation Remaining");
            }
            
        }

        private void ReadCoilAndInput()
        {
            if(_Coil)
            {
                MessageBox.Show("Click On Coil");
                mbModel.ReadCoil(_SlaveID, _Address, _Quentity);
            }
            else if(_Input)
            {
                MessageBox.Show("Click On Input");
                mbModel.ReadInput(_SlaveID, _Address, _Quentity);
            }
        }

        private int CheckSingleCoilPosition()
        {
            if (SingleCoil1)
            {
                return 0;   // coil 1
            }
            else if (SingleCoil2)
            {
                return 1;
            }
            else if (SingleCoil3)
            {
                return 2;
            }
            else if (SingleCoil4)
            {
                return 3;
            }
            else
            {
                return -1;
            }
        }
        public void WriteSingleCoil()
        {
            SingleCoilPosition = CheckSingleCoilPosition();     // check coil position status
            for (int i = 0; i < SingleCoilPosition; i++)        // find coil position
            {
                _Address++;
            }
            if (SingleCoilPosition == -1)          // filter
            {
                MessageBox.Show("Please Select Coil Position", "Information");
                return;
            }

            if (radioOnSingle)
            {
               
                if (RTU)
                {
                   mbModel.WriteSingleCoil(_SlaveID,_Address,true);
                }
                else if(ASCII)
                {
                    MessageBox.Show("ASCII emplementation remaining");
                }
                
            }
            else if(radioOffSingle)
            {
                if (RTU)
                {
                    mbModel.WriteSingleCoil(_SlaveID, _Address, false);
                }
                else if (ASCII)
                {
                    MessageBox.Show("ASCII emplementation remaining");
                }
            }
            else
            {
                MessageBox.Show("Plaese Select Value ON or OFF");
            }

        }

        public void MultiCoilStatus()
        {
            if (_CheckCoil1 || _CheckCoil2 || _CheckCoil3 || _CheckCoil4)
            {

                if (_CheckCoil1)
                {
                    WriteMultiCoilData[0] = true;
                }
                if (_CheckCoil2)
                {
                    WriteMultiCoilData[1] = true;
                }
                if (_CheckCoil3)
                {
                    WriteMultiCoilData[2] = true;
                }
                if (_CheckCoil4)
                {
                    WriteMultiCoilData[3] = true;
                }
            }
        }

        public void WriteMultiCoil()
        {
            if(RTU)
            {
                MultiCoilStatus();
                //WriteMultiCoilData = mbModel.MultiStatus(_SlaveID,3999,_Quentity);
                mbModel.WriteMultiCoils(_SlaveID,_Address,WriteMultiCoilData);      // call write multi coil method
            }
            if(radioOnMulti)
            {
                MessageBox.Show("Radio Multi ON");
            }
            else if(radioOffMulti)
            {
                MessageBox.Show("Radio Multi OFF");

            }

        }

        // check radio button active or not set values
        //Open Connection Mode
        private bool _RTU;
        private bool _ASCII;
        //read Coil and Input
        private bool _Coil;
        private bool _Input;
        //write single coil
        private bool _radioOnSingle;
        private bool _radioOffSingle;
        private bool _SingleCoil1;
        private bool _SingleCoil2;
        private bool _SingleCoil3;
        private bool _SingleCoil4;
        // write Multi coil
        private bool _radioOnMulti;
        private bool _radioOffMulti;
        private bool _CheckCoil1;
        private bool _CheckCoil2;
        private bool _CheckCoil3;
        private bool _CheckCoil4;
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
        // get and set Radio Button values
        public bool Coil
        {
            get { return _Coil; }
            set
            {
                SetProperty(ref _Coil, value);
            }
        }
        public bool Input
        {
            get { return _Input; }
            set
            {
                SetProperty(ref _Input, value);
            }
        }
        public bool radioOnSingle
        {
            get { return _radioOnSingle; }
            set
            {
                SetProperty(ref _radioOnSingle, value);
            }
        }
        public bool radioOffSingle
        {
            get { return _radioOffSingle; }
            set
            {
                SetProperty(ref _radioOffSingle, value);
            }
        }
        public bool SingleCoil1
        {
            get { return _SingleCoil1; }
            set
            {
                SetProperty(ref _SingleCoil1, value);
            }
        }
        public bool SingleCoil2
        {
            get { return _SingleCoil2; }
            set
            {
                SetProperty(ref _SingleCoil2, value);
            }
        }
        public bool SingleCoil3
        {
            get { return _SingleCoil3; }
            set
            {
                SetProperty(ref _SingleCoil3, value);
            }
        }
        public bool SingleCoil4
        {
            get { return _SingleCoil4; }
            set
            {
                SetProperty(ref _SingleCoil4, value);
            }
        }
        // set write multi coil radio button values
        public bool radioOnMulti
        {
            get { return _radioOnMulti; }
            set
            {
                SetProperty(ref _radioOnMulti, value);
            }
        }
        public bool radioOffMulti
        {
            get { return _radioOffMulti; }
            set
            {
                SetProperty(ref _radioOffMulti, value);
            }
        }
        public bool CheckCoil1
        {
            get { return _CheckCoil1; }
            set
            {
                SetProperty(ref _CheckCoil1, value);
            }
        }
        public bool CheckCoil2
        {
            get { return _CheckCoil2; }
            set
            {
                SetProperty(ref _CheckCoil2, value);
            }
        }
        public bool CheckCoil3
        {
            get { return _CheckCoil3; }
            set
            {
                SetProperty(ref _CheckCoil3, value);
            }
        }
        public bool CheckCoil4
        {
            get { return _CheckCoil4; }
            set
            {
                SetProperty(ref _CheckCoil4, value);
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
        // set Open Connection values
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
        private double _ProgressBarOpen=0;
        public double ProgressBar
        {
            get { return _ProgressBarOpen; }
            set
            {
                SetProperty(ref _ProgressBarOpen, value);
            }
        }
        // Set Read Coils and Input Values
        public byte SlaveID
        {
            get { return _SlaveID; }
            set
            {
                SetProperty(ref _SlaveID, value);
            }
        }

        public ushort Address
        {
            get { return _Address; }
            set
            {
                SetProperty(ref _Address, value);
            }
        }
        public ushort Quentity
        {
            get { return _Quentity; }
            set
            {
                SetProperty(ref _Quentity, value);
            }
        }
        private string _Items = "true";
        

        public string Items
        {
            get { return _Items; }
            set
            {
                SetProperty(ref _Items, value);
            }
        }
    }
}
