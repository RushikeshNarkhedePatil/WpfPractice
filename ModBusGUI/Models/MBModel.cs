using Prism.Mvvm;
using ModBusGUI.Models;
using System.IO.Ports;
using Modbus.Device;
using System.Windows;
using System;
using ModBusGUI.Views;
using System.Collections;

namespace ModBusGUI.Models
{
    public class MBModel:BindableBase
    {
        private SerialPort serialPort = new SerialPort(); //Create a new SerialPort object.
        private Modbus.Device.IModbusSerialMaster masterRtu, masterAscii;
        public bool[] ReadCoilData = { false, false, false, false };
        public bool[] ReadInputData = { false, false, false, false };
        public MBModel()
        {

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
                foreach (var item in ReadInputData)
                {
                    //Console.WriteLine(item);
                    arlist.Add(item);
                    //MessageBox.Show(item.ToString());
                }
                ReadCoilProgressBar = 100;
                MessageBox.Show("Input 1 " + arlist[0] + "\n"
              + "Input 2 " + arlist[1] + "\n"
              + "Input 3 " + arlist[2] + "\n"
              + "Input 4 " + arlist[3] + "\n", "Input ON OFF Status");
                ReadCoilProgressBar = 0;
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
                
                masterRtu = ModbusSerialMaster.CreateRtu(serialPort);
                masterRtu.WriteSingleCoil(slaveAddress, coilAddress, value);
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

        //public void ReadCoilAndInput(byte slaveAddress, ushort coilAddress, ushort numberOfPoints)
        //{

        //    try
        //    {
        //        masterRtu = ModbusSerialMaster.CreateRtu(serialPort);
        //        masterRtu.WriteSingleCoil(10, 3999, true);
        //        ReadCoilData = masterRtu.ReadCoils(slaveAddress,coilAddress,numberOfPoints);    // read Coil
        //        foreach (var item in ReadCoilData)
        //        {
        //            //Console.WriteLine(item);
        //            MessageBox.Show(item.ToString());
        //        }
        //    }
        //    catch (Exception err)
        //    {
        //        MessageBox.Show(err.Message);
        //    }

        //}

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
