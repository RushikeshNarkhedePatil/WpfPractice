using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.IO.Ports;
using Modbus.Device;

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
              
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
