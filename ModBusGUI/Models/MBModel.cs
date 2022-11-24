using Prism.Mvvm;
using ModBusGUI.Models;
using System.IO.Ports;
using Modbus.Device;
using System.Windows;
using System;
using ModBusGUI.ViewModels;
using System.Collections;
using System.Threading;
using System.Windows.Threading;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Prism.Commands;

namespace ModBusGUI.Models
{
    public class MBModel:BindableBase
    {
        //private MBViewModel viewModel;
        private readonly ItemHandler _itemHandler;
        private SerialPort serialPort = new SerialPort(); //Create a new SerialPort object.
        private IModbusSerialMaster masterAscii;
        private IModbusSerialMaster masterRtu;
        public bool[] ReadCoilData = { false, false, false, false };
        public bool[] ReadInputData = { false, false, false, false };
        public MBModel()
        {
            _itemHandler = new ItemHandler();
            ClearSCList = new DelegateCommand(ClearSCoilList);
            ClearMCList = new DelegateCommand(ClearMCoilList);
            //_itemHandler.AutoCoilAdd(new AutoCoilItem("Hello"));
        }
        public ICommand ClearSCList
        {
            get;
            private set;
        }
        public ICommand ClearMCList
        {
            get;
            private set;
        }
        public ICommand ClearReadList
        {
            get;
            private set;
        }
        private void ClearMCoilList()
        {
            WriteMCoil.Clear();
            WriteMCoilProgressBar = 0;
        }
        private void ClearCoilAndInput()
        {
            Read.Clear();
            ReadCoilProgressBar = 0;
        }
        private void ClearSCoilList()
        {
            Items.Clear();
            WriteSCoilProgressBar = 0;
        }
        // list view
        public ObservableCollection<AutoCoilItem> AutoCoil
        {
            get { return _itemHandler.AutoCoil; }
        }
        public ObservableCollection<AutoInputItem> AutoInput
        {
            get { return _itemHandler.AutoInput; }
        }
        public ObservableCollection<Item> Items
        {
            get { return _itemHandler.Items; }
        }
        public ObservableCollection<ReadItem> Read
        {
            get { return _itemHandler.Read; }
        }
        public ObservableCollection<WriteItem> WriteMCoil
        {
            get { return _itemHandler.WriteMCoil; }
        }
        // Demo

        private string _Message;
      
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
      
        // Open Connection Functionality
        public void OpenConnectionRTU(string portName, int baudRate, Parity parity, int dataBits, StopBits stopBits,string mode)
        {
            try
            {
                //MessageBox.Show(portName);
                serialPort.PortName = portName;
                serialPort.BaudRate = baudRate;
                serialPort.Parity = parity;
                serialPort.DataBits = dataBits;
                serialPort.StopBits = stopBits;
                masterRtu = ModbusSerialMaster.CreateRtu(serialPort);
                serialPort.Open();
                ProgressBarOpen = 100;
                serialPort.ReadTimeout = 3000;
                serialPort.WriteTimeout = 3000;
                AutoInputStatus(mode);
                AutoCoilStatus(mode);
                //ModBusMainWindow modBusMainWindow = new ModBusMainWindow();
                //ProgressBarValue =100;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            
        }
        public void OpenConnectionASCII(string portName, int baudRate, Parity parity, int dataBits, StopBits stopBits,string mode)
        {
            try
            {
                //MessageBox.Show(portName);
                serialPort.PortName = portName;
                serialPort.BaudRate = baudRate;
                serialPort.Parity = parity;
                serialPort.DataBits = dataBits;
                serialPort.StopBits = stopBits;
                masterAscii = ModbusSerialMaster.CreateAscii(serialPort);
                serialPort.Open();
                ProgressBarOpen = 100;
                //serialPort.ReadTimeout = 1000;
                //serialPort.WriteTimeout = 1000;
                //AutoInputStatus(mode);
                //AutoCoilStatus(mode);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }

        public void CloseConnection()
        {
            if(serialPort.IsOpen)
            {
                serialPort.Close();
                ProgressBarOpen = 0;
            }
            else
            {
                MessageBox.Show("Connection already Close");
            }
        }
       
        public void ReadInput(byte slaveAddress, ushort coilAddress, ushort numberOfPoints)
        {
            try
            {
                //masterRtu = ModbusSerialMaster.CreateRtu(serialPort);
                ReadInputData = masterRtu.ReadInputs(slaveAddress, coilAddress, numberOfPoints);    // read Input
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error");
            }
          
        }
        public ArrayList arlist = new ArrayList();
        public void ReadCoil(byte slaveAddress, ushort coilAddress, ushort numberOfPoints,string mode)
        {
            if(mode=="RTU")
            {
                try
                {
                    //masterRtu = ModbusSerialMaster.CreateRtu(serialPort);
                    ReadCoilData = masterRtu.ReadCoils(slaveAddress, coilAddress, numberOfPoints);    // read Coil
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
            else if(mode=="ASCII")
            {
                try
                {
                    masterAscii = ModbusSerialMaster.CreateAscii(serialPort);
                    ReadCoilData = masterAscii.ReadCoils(slaveAddress, coilAddress, numberOfPoints);    // read Coil
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
           
           
        }
        public void WriteSingleCoil(byte slaveAddress, ushort coilAddress, bool value,string mode)
        {
            if(serialPort.IsOpen)
            {
                if(mode=="RTU")
                {
                    try
                    {
                        //masterRtu = ModbusSerialMaster.CreateRtu(serialPort);
                        masterRtu.WriteSingleCoil(slaveAddress, coilAddress, value);
                        _itemHandler.Add(new Item(value.ToString()));
                        WriteSCoilProgressBar = 100;
                        AutoCoilStatus(mode);
                        //AutoInputStatus(mode);
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message, "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else if(mode=="ASCII")
                {
                    try
                    {
                        masterAscii = ModbusSerialMaster.CreateAscii(serialPort);
                        masterAscii.WriteSingleCoil(slaveAddress, coilAddress, value);
                        AutoCoilStatus(mode);
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message, "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
              
            }
            else
            {
                MessageBox.Show("Connection is not Open ! Plaese Open Connection Then Perform Operation.");
            }
        }
        //*************************************** Write Multi Coil Function ********************************************//

        //Get Multi Coil Status
        public bool[] MultiStatus(byte slaveAddress, ushort coilAddress, ushort numberOfPoints, string mode)
        {
            try
            {
                if(mode=="RTU")
                {
                    //masterRtu = ModbusSerialMaster.CreateRtu(serialPort);
                    ReadCoilData = masterRtu.ReadCoils(slaveAddress, coilAddress, numberOfPoints);    // read Coil
                }
                else if(mode=="ASCII")
                {
                    masterAscii = ModbusSerialMaster.CreateAscii(serialPort);
                    ReadCoilData = masterAscii.ReadCoils(slaveAddress, coilAddress, numberOfPoints);    // read Coil
                }
               
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            return ReadCoilData;

        }

        public void WriteMultiCoils(byte slaveAddress, ushort startAddress, bool[] data,string mode)
        {
            try
            {
                if(mode=="RTU")
                {
                   // masterRtu = ModbusSerialMaster.CreateRtu(serialPort);
                    masterRtu.WriteMultipleCoils(slaveAddress, startAddress, data);    // write multi Coil
                    if (WriteMCoil.Count <= 4)
                    {
                        WriteMCoil.Clear();
                    }
                    foreach (var item in data)
                    {
                        _itemHandler.WriteMAdd(new WriteItem(item.ToString()));
                    }
                    WriteMCoilProgressBar = 100;
                    AutoCoilStatus(mode);
                    //AutoInputStatus(mode);
                }
                else if(mode=="ASCII")
                {
                    masterAscii = ModbusSerialMaster.CreateAscii(serialPort);
                    masterAscii.WriteMultipleCoils(slaveAddress, startAddress, data);    // write multi Coil
                    AutoCoilStatus(mode);
                }
                else
                {
                    MessageBox.Show("Check Connection", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        public bool CheckPortOnOff()
        {
            if(serialPort.IsOpen)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //****************************************Auto Display Coil Status**************************************//

        public void AutoCoilStatus(string mode)
        {
            if (serialPort.IsOpen)
            {
                if(mode=="RTU")
                {
                    timeCB = new TimerCallback(PrintCoilRTU);
                    System.Threading.Timer t = new System.Threading.Timer(
                    timeCB, 
                    "Hi",    
                    0,       
                    1000);
                }
                else if(mode=="ASCII")
                {

                    timeCB = new TimerCallback(PrintCoilASCII);
                    System.Threading.Timer t = new System.Threading.Timer(
                    timeCB,
                    "Hi",
                    0,
                    1000);
                }
               
            }
        }

        void PrintCoilRTU(object state)
        {
            if (serialPort.IsOpen)
            {
                try
                {
                    //masterRtu = ModbusSerialMaster.CreateRtu(serialPort);
                    ReadCoilData = masterRtu.ReadCoils(10, 3999, 4);
                }
                catch (Exception err)
                {
                    //MessageBox.Show(err.Message);
                }
                DispatchService.Invoke(() =>
                {
 
                    foreach (var item in ReadCoilData)
                    {
                        _itemHandler.AutoCoilAdd(new AutoCoilItem(item.ToString()));
                       
                    }
                    if (AutoCoil.Count >= 5)
                    {
                        AutoCoil.Clear();
                    }

                });
            }
        }
        void PrintCoilASCII(object state)
        {
            if (serialPort.IsOpen)
            {
                DispatchService.Invoke(() =>
                {
                    masterAscii = ModbusSerialMaster.CreateAscii(serialPort);
                    ReadCoilData = masterAscii.ReadCoils(10, 3999, 4);
                    //ProgressBarOpen = 50;

                    foreach (var item in ReadCoilData)
                    {
                        _itemHandler.AutoCoilAdd(new AutoCoilItem(item.ToString()));

                    }
                    if (AutoCoil.Count >= 5)
                    {
                        AutoCoil.Clear();
                    }

                });
            }
        }
        public void AutoInputStatus(string mode)
        {
            if (serialPort.IsOpen)
            {
                if (mode == "RTU")
                {
                    timeCB = new TimerCallback(PrintInputRTU);
                    System.Threading.Timer t = new System.Threading.Timer(
                    timeCB,   
                    "Hi",    
                    0,        
                    1000);
                }
                else if (mode == "ASCII")
                {
                    timeCB = new TimerCallback(PrintInputASCII);
                    System.Threading.Timer t = new System.Threading.Timer(
                    timeCB,   
                    "Hi",     
                    0,       
                    1000);
                }
               
            }
        }

        private void PrintInputRTU(object state)
        {
            if (serialPort.IsOpen)
            {
                DispatchService.Invoke(() =>
                {
                    //masterRtu = ModbusSerialMaster.CreateRtu(serialPort);
                    ReadCoilData = masterRtu.ReadInputs(10, 7999, 4);
                    //ProgressBarOpen = 50;

                    foreach (var item in ReadCoilData)
                    {
                        _itemHandler.AutoInputAdd(new AutoInputItem(item.ToString()));

                    }
                    if (AutoInput.Count >= 5)
                    {
                        AutoInput.Clear();
                    }

                });
            }
        }
        private void PrintInputASCII(object state)
        {
            if (serialPort.IsOpen)
            {
                DispatchService.Invoke(() =>
                {
                    masterAscii = ModbusSerialMaster.CreateAscii(serialPort);
                    ReadCoilData = masterAscii.ReadInputs(10, 7999, 4);
                    //ProgressBarOpen = 50;

                    foreach (var item in ReadCoilData)
                    {
                        _itemHandler.AutoInputAdd(new AutoInputItem(item.ToString()));

                    }
                    if (AutoInput.Count >= 5)
                    {
                        AutoInput.Clear();
                    }

                });
            }
        }

        //**********************************************Set Progress Bar Values*************************************************//
        private double _ProgressBarOpen;
        public double ProgressBarOpen
        {
            get { return _ProgressBarOpen; }
            set
            {
                SetProperty(ref _ProgressBarOpen, value);
            }
        }

        private double _ReadCoilProgressBar = 0;

        private TimerCallback timeCB;

        public double ReadCoilProgressBar
        {
            get { return _ReadCoilProgressBar; }
            private set
            {
                SetProperty(ref _ReadCoilProgressBar, value);
            }
        }

        private double _WriteSCoilProgressBar = 0;
        public double WriteSCoilProgressBar
        {
            get { return _WriteSCoilProgressBar; }
            private set
            {
                SetProperty(ref _WriteSCoilProgressBar, value);
            }
        }
        private double _WriteMCoilProgressBar = 0;
        public double WriteMCoilProgressBar
        {
            get { return _WriteMCoilProgressBar; }
            private set
            {
                SetProperty(ref _WriteMCoilProgressBar, value);
            }
        }
    }
}
