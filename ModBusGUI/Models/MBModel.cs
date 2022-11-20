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

namespace ModBusGUI.Models
{
    public class MBModel:BindableBase
    {
        private MBViewModel viewModel;
        private readonly ItemHandler _itemHandler;
        private SerialPort serialPort = new SerialPort(); //Create a new SerialPort object.
        private Modbus.Device.IModbusSerialMaster masterRtu, masterAscii;
        public bool[] ReadCoilData = { false, false, false, false };
        public bool[] ReadInputData = { false, false, false, false };
        public MBModel()
        {
            _itemHandler = new ItemHandler();
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
        public void OpenConnectionRTU(string portName, int baudRate, Parity parity, int dataBits, StopBits stopBits)
        {
            try
            {
                //MessageBox.Show(portName);
                serialPort.PortName = portName;
                serialPort.BaudRate = baudRate;
                serialPort.Parity = parity;
                serialPort.DataBits = dataBits;
                serialPort.StopBits = stopBits;
                ModbusSerialMaster masterRtu = ModbusSerialMaster.CreateRtu(serialPort);
                serialPort.Open();
                ProgressBarOpen = 100;
                //ModBusMainWindow modBusMainWindow = new ModBusMainWindow();
               //ProgressBarValue =100;
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
                masterRtu = ModbusSerialMaster.CreateRtu(serialPort);
                ReadInputData = masterRtu.ReadInputs(slaveAddress, coilAddress, numberOfPoints);    // read Input
              //  foreach (var item in ReadInputData)
              //  {
              //      //Console.WriteLine(item);
              //      arlist.Add(item);
              //      //MessageBox.Show(item.ToString());
              //  }
              //  ReadCoilProgressBar = 100;
              //  MessageBox.Show("Input 1 " + arlist[0] + "\n"
              //+ "Input 2 " + arlist[1] + "\n"
              //+ "Input 3 " + arlist[2] + "\n"
              //+ "Input 4 " + arlist[3] + "\n", "Input ON OFF Status");
              //  ReadCoilProgressBar = 0;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error");
            }
          
        }
        public ArrayList arlist = new ArrayList();
        public void ReadCoil(byte slaveAddress, ushort coilAddress, ushort numberOfPoints)
        {
            try
            {
                masterRtu = ModbusSerialMaster.CreateRtu(serialPort);
                ReadCoilData = masterRtu.ReadCoils(slaveAddress, coilAddress, numberOfPoints);    // read Coil
                //foreach (var item in ReadCoilData)
                //{
                //    //Console.WriteLine(item);
                //    arlist.Add(item);
                //}
                //ReadCoilProgressBar = 100;
                //MessageBox.Show("Coil 1 "+arlist[0]+"\n"
                //    +"Coil 2 "+arlist[1]+"\n"
                //    +"Coil 3 "+arlist[2]+"\n"
                //    +"Coil 4 "+arlist[3]+"\n","Coil ON OFF Status");
                //ReadCoilProgressBar = 0;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
           
        }
        public void WriteSingleCoil(byte slaveAddress, ushort coilAddress, bool value)
        {
            if(serialPort.IsOpen)
            {
                try
                {
                    masterRtu = ModbusSerialMaster.CreateRtu(serialPort);
                    masterRtu.WriteSingleCoil(slaveAddress, coilAddress, value);
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "Message",MessageBoxButton.OK,MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Connection is not Open ! Plaese Open Connection Then Perform Operation.");
            }
        }
        //*************************************** Write Multi Coil Function ********************************************//

        //Get Multi Coil Status
        public bool[] MultiStatus(byte slaveAddress, ushort coilAddress, ushort numberOfPoints)
        {
            try
            {
                masterRtu = ModbusSerialMaster.CreateRtu(serialPort);
                ReadCoilData = masterRtu.ReadCoils(slaveAddress, coilAddress, numberOfPoints);    // read Coil
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            return ReadCoilData;

        }

        public void WriteMultiCoils(byte slaveAddress, ushort startAddress, bool[] data)
        {
            try
            {
                masterRtu = ModbusSerialMaster.CreateRtu(serialPort);
                masterRtu.WriteMultipleCoils(slaveAddress, startAddress, data);    // write multi Coil
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

        public void AutoCoilStatus()
        {
            if (serialPort.IsOpen)
            {
                timeCB = new TimerCallback(PrintCoil);
                System.Threading.Timer t = new System.Threading.Timer(
                timeCB,   // The TimerCallback delegate type. 
                "Hi",     // Any info to pass into the called method.
                0,        // Amount of time to wait before starting.
                3000);
            }
        }
        //public static void UiInvoke(Action a)
        //{
        //    Application.Current.Dispatcher.Invoke(a);
        //}
        void PrintCoil(object state)
        {
            if (serialPort.IsOpen)
            {
                //if (viewModel.RTU)
                {
                    masterRtu = ModbusSerialMaster.CreateRtu(serialPort);
                    ReadCoilData = masterRtu.ReadCoils(10, 3999, 4);
                    //viewModel.DisplayCoil();
                    //UiInvoke(() => viewModel._itemHandler.Add(new Item("Hello")));
                    //Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new Action(
                    //         () => viewModel._itemHandler.Add(new Item("Hello"))));


                    //foreach (var item in ReadCoilData)
                    //{
                    //    MessageBox.Show(item.ToString());
                    //}
                    //viewModel.DisplayAutoCoilResult(ReadCoilData);
                }
                //else if (viewModel.ASCII)
                //{
                //    try
                //    {
                //        ReadCoilData = masterAscii.ReadCoils(10, 3999, 4);
                       
                //    }
                //    catch (Exception)
                //    {
                //        serialPort.Close();
                      
                //    }
                //}

                //Console.WriteLine("Time is: {0}, Param is: {1}", DateTime.Now.ToLongTimeString(), state.ToString());
                //if (this.listView4.InvokeRequired)
                //{
                //    CoilCount = 1;
                //    InputCount = 1;
                //    //ReadCoilData = masterRtu.ReadCoils(SlaveId, Address, Quentity);
                //    foreach (var item in ReadCoilData)
                //    {
                //        listView4.Invoke((MethodInvoker)(() => listView4.Items.Add("Coil " + CoilCount + " " + item.ToString())));
                //        CoilCount++;
                //    }

                //    if (listView4.Items.Count >= 5)
                //    {
                //        listView4.Invoke((MethodInvoker)(() => listView4.Items.Clear()));

                //        CoilCount = 1;
                //    }
                //}
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
        private int CoilCount;
        private int InputCount;
        private TimerCallback timeCB;

        public double ReadCoilProgressBar
        {
            get { return _ReadCoilProgressBar; }
            private set
            {
                SetProperty(ref _ReadCoilProgressBar, value);
            }
        }

    }
}
