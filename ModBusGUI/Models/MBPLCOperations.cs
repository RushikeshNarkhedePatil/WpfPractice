using Prism.Mvvm;
using System.IO.Ports;
using Modbus.Device;
using System.Windows;
using System;
using System.Threading;
using ModBusGUI.ViewModels;

namespace ModBusGUI.Models
{
    public class MBPLCOperations:BindableBase
    {
        //private readonly ItemHandler _itemHandler;
        private SerialPort serialPort = new SerialPort(); //Create a new SerialPort object.
        private IModbusSerialMaster masterAscii;
        private IModbusSerialMaster master;
        public bool[] ReadCoilData = { false, false, false, false };
        public bool[] ReadInputData = { false, false, false, false };
        public bool status=false;
        private TimerCallback timeCB;
        private MBViewModel ViewModel;
        private ItemHandler _itemHandler;
        //****************************Create Constructer***************************************//
        public MBPLCOperations()
        {
           
        }
        //*********************************Open Connection**************************************//
        public bool OpenConnection(string portName, int baudRate, Parity parity, int dataBits, StopBits stopBits, string mode)
        {
            try
            {
                //MessageBox.Show(portName);
                serialPort.PortName = portName;
                serialPort.BaudRate = baudRate;
                serialPort.Parity = parity;
                serialPort.DataBits = dataBits;
                serialPort.StopBits = stopBits;
                serialPort.Open();
                if(mode=="RTU")
                {
                    master = ModbusSerialMaster.CreateRtu(serialPort);
                }
                else if(mode=="ASCII")
                {
                    master = ModbusSerialMaster.CreateAscii(serialPort);
                }
                status = true;
                //serialPort.ReadTimeout = 3000;
                master.Transport.ReadTimeout = 3000;
                //serialPort.WriteTimeout = 3000;
                //AutoCoilStatus();
                //AutoInputStatus(mode);
                //AutoCoilStatus(mode);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            return status;
        }

        //****************************************Auto Display Coil Status**************************************//

        //public void AutoCoilStatus()
        //{
        //    if (serialPort.IsOpen)
        //    {
        //        timeCB = new TimerCallback(PrintCoil);
        //        System.Threading.Timer t = new System.Threading.Timer(
        //        timeCB,
        //        "Hi",
        //        0,
        //        1000);
        //    }
        //}
        public void PrintCoil(object state)
        {
            if (serialPort.IsOpen)
            {
                status = false;
                try
                {
                    ReadCoilData = master.ReadCoils(10, 3999, 4);
                    //Application.Current.Dispatcher.Invoke(new Action(() =>
                    //{
                    //    foreach (var item in ReadCoilData)
                    //    {
                    //        _itemHandler.AutoCoilAdd(new AutoCoilItem(item.ToString()));

                    //    }
                    //}));
                    status = true;
                }
                catch (Exception)
                {
                    //MessageBox.Show(err.Message);
                }

            }
        }

        public bool OpenConnectionASCII(string portName, int baudRate, Parity parity, int dataBits, StopBits stopBits, string mode)
        {
            try
            {
                //MessageBox.Show(portName);
                serialPort.PortName = portName;
                serialPort.BaudRate = baudRate;
                serialPort.Parity = parity;
                serialPort.DataBits = dataBits;
                serialPort.StopBits = stopBits;
                master = ModbusSerialMaster.CreateAscii(serialPort);
                serialPort.Open();
                status = true;
                serialPort.ReadTimeout = 1000;
                serialPort.WriteTimeout = 1000;
                //AutoInputStatus(mode);
                //AutoCoilStatus(mode);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            return status;
        }
        //********************************************Close Connection***********************************************//
        public bool CloseConnection()
        {
            status = false;
            if(serialPort.IsOpen)
            {
                serialPort.Close();
                status = true;
            }
            return status;
        }
        //********************************************Read Coils*****************************************************//
        public bool ReadCoil(byte slaveAddress, ushort coilAddress, ushort numberOfPoints)
        {
            status = false;
            try
            {
                ReadCoilData = master.ReadCoils(slaveAddress, coilAddress, numberOfPoints);    // read Coil
                status = true;
            }
            catch (Exception err)
            {
                MessageBox.Show("Check Address and Try again \n" + err.Message, "Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return status;
        }
        //********************************************Read Input ****************************************************//
        public bool ReadInput(byte slaveAddress, ushort coilAddress, ushort numberOfPoints)
        {
            status = false;
            try
            {
                ReadInputData = master.ReadInputs(slaveAddress, coilAddress, numberOfPoints);    // read Input
                status = true;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error");
            }
            return status;
        }
        //********************************************Write Single Coils**********************************************//
        public bool WriteSingleCoil(byte slaveAddress, ushort coilAddress, bool value)
        {
            status = false;
            if (serialPort.IsOpen)
            {
                try
                {
                    master.WriteSingleCoil(slaveAddress, coilAddress, value);
                    status = true;
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Connection is not Open ! Plaese Open Connection Then Perform Operation.");
            }
            return status;
        }
        //********************************************Write Multiple Coils********************************************//

        public bool WriteMultiCoils(byte slaveAddress, ushort startAddress, bool[] data)
        {
            status = false;
            try
            {
                master.WriteMultipleCoils(slaveAddress, startAddress, data);    // write multi Coil
                status = true;

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            return status;
        }
        // Check Multi Coil Status
        public bool[] MultiStatus(byte slaveAddress, ushort coilAddress, ushort numberOfPoints)
        {
            try
            {

                ReadCoilData = master.ReadCoils(slaveAddress, coilAddress, numberOfPoints);    // read Coil
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            return ReadCoilData;

        }
       
    }
}
