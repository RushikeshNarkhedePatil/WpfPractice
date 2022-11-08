using Modbus.Device;
using System.IO.Ports;

namespace ModBusGUI
{
    class OpenConnection
    {
        public void Open()
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
    }
}
