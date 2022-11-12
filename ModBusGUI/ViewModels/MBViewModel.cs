using Prism.Mvvm;
using ModBusGUI.Models;
namespace ModBusGUI.ViewModels
{
    class MBViewModel:BindableBase
    {
        private string _Title = "ModBus Project";

        public string Header
        {
            get { return _Title; }
            set { SetProperty(ref _Title, value); }
        }
        public MBViewModel()
        {

        }
        // Open Connection set Values
        private string _PortName = "COM4";
        private int _BaudRate = 9600;
        private int _DataBits = 8;
        private string[] _Parity = { "None","Even","Odd"};
        private string[] _StopBits = { "One","Two" };
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
        public string[] StopBits
        {
            get { return _StopBits; }
            set
            {
                SetProperty(ref _StopBits, value);
            }
        }

        public string[] Parity
        {
            get { return _Parity; }
            set
            {
                SetProperty(ref _Parity,value);
            }
        }
    }
}
