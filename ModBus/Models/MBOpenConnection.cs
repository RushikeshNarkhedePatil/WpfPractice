using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

using Modbus.Device;
using System.IO.Ports;

namespace ModBus.Models
{
    class MBOpenConnection
    {
        private static MBOpenConnection oMBOpenConnection;
        private Modbus.Device.IModbusSerialMaster masterRtu, masterAscii;
        private byte SlaveId = 10;
        private ushort Address = 3999;     
        private ushort Quentity = 4;
        private bool WriteCoil = false;
        private bool ParityStatus = false;
        public MBOpenConnection()
        {
            try
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
        }
        public void OpenRTU()
        {
            try
            {
                SerialPort serialPort = new SerialPort(); //Create a new SerialPort object.
                serialPort.PortName = "COM4";
                serialPort.BaudRate = 9600;
                serialPort.DataBits = 8;
                serialPort.Parity = Parity.None;
                serialPort.StopBits = StopBits.One;
                serialPort.Open();
                ModbusSerialMaster master = ModbusSerialMaster.CreateRtu(serialPort);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
