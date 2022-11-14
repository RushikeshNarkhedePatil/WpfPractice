using Prism.Mvvm;
using ModBusGUI.Models;
using Prism.Commands;
using System.Windows.Input;
using System.Windows;

namespace ModBusGUI.ViewModels
{
    class MBViewModel:BindableBase
    {
        private MBModel mbModel;
        private string _Title = "ModBus Project";

        public string Header
        {
            get { return _Title; }
            set { SetProperty(ref _Title, value); }
        }
        public MBViewModel()
        {
            mbModel = new MBModel();
            ClickCommand = new DelegateCommand(OpenConnection);
        }

        //Demo
       
        public ICommand ClickCommand
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
        private void OpenConnection()
        {
            //TestModel.Message = "You Have Clicked the button";
            // MessageBox.Show("Click Open Connection");
            mbModel.OpenConnection("Hello");
        }


        // Open Connection set Values
        //private string _PortName = "COM4";
        //private int _BaudRate = 9600;
        //private int _DataBits = 8;
        //private string _Parity = "None";
        //private string _StopBits = "One";
        public MBModel MBModel
        {
            get { return mbModel; }
            set
            {
                SetProperty(ref mbModel, value);
            }
        }

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
        //        SetProperty(ref _Parity,value);
        //    }
        //}
    }
}
