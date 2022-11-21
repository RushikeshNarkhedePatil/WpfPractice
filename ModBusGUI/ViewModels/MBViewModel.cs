using Prism.Mvvm;
using ModBusGUI.Models;
using ModBusGUI.Views;
using Prism.Commands;
using System.Windows.Input;
using System.Windows;
using System.Collections.Generic;
using System.IO.Ports;
using System;
using System.Collections.ObjectModel;
using System.Windows.Threading;

namespace ModBusGUI.ViewModels
{
    //********************************************************Set List View Collection **************************************************//
    public class WriteItem
    {
        public WriteItem(string name)
        {
            WriteMCoil = name;
        }
        public string WriteMCoil { get; set; }
    }
    public class ReadItem
    {
        public ReadItem(string name)
        {
            Read = name;
        }
        public string Read { get; set; }
    }
    public class AutoCoilItem
    {
        public AutoCoilItem(string name)
        {
            ACName = name;
        }
        public string ACName { get; set; }
    }

    public class AutoInputItem
    {
        public AutoInputItem(string name)
        {
            AIName = name;
        }
        public string AIName { get; set; }
    }

    public class Item
    {
        public Item(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
      
    }

    public class ItemHandler
    {
        public ItemHandler()
        {
            Items = new ObservableCollection<Item>();
            Read = new ObservableCollection<ReadItem>();
            WriteMCoil = new ObservableCollection<WriteItem>();
            AutoCoil = new ObservableCollection<AutoCoilItem>();
            AutoInput = new ObservableCollection<AutoInputItem>();
        }

        public ObservableCollection<Item> Items { get; private set; }
        public ObservableCollection<WriteItem> WriteMCoil { get; private set; }
        public ObservableCollection<ReadItem> Read { get; private set; }
        public ObservableCollection<AutoCoilItem> AutoCoil { get; private set; }
        public ObservableCollection<AutoInputItem> AutoInput { get; private set; }

        public void Add(Item item)
        {
            Items.Add(item);
        }
        public void ReadAdd(ReadItem item)
        {
            Read.Add(item);
        }
        public void WriteMAdd(WriteItem item)
        {
            WriteMCoil.Add(item);
        }
        public void AutoCoilAdd(AutoCoilItem item)
        {
            AutoCoil.Add(item);
        }
        public void AutoInputAdd(AutoInputItem item)
        {
            AutoInput.Add(item);
        }
    }
    //*************************************End List View Classes*********************************************************//
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
        private ushort OriginalAddress;
        private ushort _Quentity = 4;
        private int SingleCoilPosition;
        private bool WriteCoil = false;
        private bool PortStatus = false;
        public bool[] ReadCoilData = { false, false, false, false };
        private bool[] WriteMultiCoilData = { false, false, false, false };

        public string Header
        {
            get { return _Title; }
            set { SetProperty(ref _Title, value); }
        }
        // Create Observable Collection
        private ObservableCollection<Person> person;
        public readonly ItemHandler _itemHandler;
        public MBViewModel()
        {

            mbModel = new MBModel();
            OriginalAddress = _Address;
            
            //**************************************Call Button after Click*************************************************//
            ClickCommandOpen = new DelegateCommand(OpenConnection);
            ClickCommandRead = new DelegateCommand(ReadCoilAndInput);
            CmdWriteSingleCoil = new DelegateCommand(WriteSingleCoil);
            CmdWriteMultiCoil = new DelegateCommand(WriteMultiCoil);
            ClickCommandClose = new DelegateCommand(CloseConnection);
            ClearReadList = new DelegateCommand(ClearCoilAndInput);
            ClearSCList = new DelegateCommand(ClearSCoilList);
            ClearMCList = new DelegateCommand(ClearMCoilList);

            //ModBusMainWindow mainview = new ModBusMainWindow();
            // Observable Collection
            //person = new ObservableCollection<Person>()
            //{

            //    new Person() { Name = "Prabhat", Address = "India" },

            //    new Person() { Name = "Smith", Address = "US" }
            //};
            //lstRead.ItemsSource = person;

            // List View Item
            _itemHandler = new ItemHandler();
            //_itemHandler.Add(new Item("John Doe"));
            //_itemHandler.AutoCoilAdd(new AutoCoilItem("John Doe"));


            //******************************************* Combo Box Values**********************************//
            Persons = new ObservableCollection<Person>()
            {
              new Person(){Name="true"}
              ,new Person(){Name="false"}
            };
            PBits = new ObservableCollection<CombParityBit>()
            {
                new CombParityBit() { Name="None"},
                new CombParityBit() { Name="Even"},
                new CombParityBit() { Name="Odd"}
            };
            CombStopBits = new ObservableCollection<CombStopBit>()
            {
                new CombStopBit(){Name="One"},
                new CombStopBit(){Name="Two"}
            };
            combReadAddresses = new ObservableCollection<CombReadAddress>()
            {
                new CombReadAddress(){Name=3999},
                new CombReadAddress(){Name=7999}
            };
        }// MBViewModel Constructer End

       



        //*****************************************get ListView Value********************************************//
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
        //public ObservableCollection<AutoCoilItem> AutoCoil
        //{
        //    get { return _itemHandler.AutoCoil; }
        //}
        //public ObservableCollection<AutoInputItem> AutoInput
        //{
        //    get { return _itemHandler.AutoInput; }
        //}
        //********************************************Demo Combo Box**********************************************//
        private ObservableCollection<Person> _persons;
        private ObservableCollection<CombParityBit> _PBits; 
        private ObservableCollection<CombStopBit> _CombStopBits;
        private ObservableCollection<CombReadAddress> _combReadAddresses;
        public ObservableCollection<Person> Persons
        {
            get { return _persons; }
            set 
            {
                SetProperty(ref _persons, value);
            }
        }
        private Person _sperson;

        public Person SPerson
        {
            get { return _sperson; }
            set 
            {
                SetProperty(ref _sperson, value);
            }
        }
        //**********************************Set ParityBit Class**********************************//
        public ObservableCollection<CombParityBit> PBits
        {
            get { return _PBits; }
            set
            {
                SetProperty(ref _PBits, value);
            }
        }
        private CombParityBit _SPBits;
        public CombParityBit SPBits
        {
            get { return _SPBits; }
            set
            {
                SetProperty(ref _SPBits,value);
            }
        }
        //***********************************Combo Stop Bits********************************//
        public ObservableCollection<CombStopBit> CombStopBits
        {
            get { return _CombStopBits; }
            set
            {
                SetProperty(ref _CombStopBits, value);
            }
        }
        private CombStopBit _SCombStopBits;
        public CombStopBit SCombStopBits
        {
            get { return _SCombStopBits; }
            set
            {
                SetProperty(ref _SCombStopBits, value);
            }
        }
        //**********************************Comb Read Address****************************************//
        public ObservableCollection<CombReadAddress> combReadAddresses
        {
            get { return _combReadAddresses; }
            set
            {
                SetProperty(ref _combReadAddresses, value);
            }
        }
        private CombReadAddress _ScombReadAddresses;
        public CombReadAddress ScombReadAddresses
        {
            get { return _ScombReadAddresses; }
            set
            {
                SetProperty(ref _ScombReadAddresses, value);
            }
        }
        //****************************************Set Button Commands To Call Function******************************************//
        public ICommand ClickCommandRead
        {
            get;
            private set;
        }
        public ICommand ClearReadList
        {
            get;
            private set;
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
        public ICommand ClickCommandOpen
        {
            get;
            private set;
        }
        public ICommand ClickCommandClose
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


        //********************************************Functions**************************************************************//
        private void OpenConnection()
        {
            if (SPBits== null || SCombStopBits == null||RTU==false||PortName==null||BaudRate==0||DataBits==0)
            {
                MessageBox.Show("Please fill all values","Message");
            }
            else
            {
                if (_RTU == true)
                {
                    //MessageBox.Show(_PortName);
                    parity = serialPort.Parity = (Parity)Enum.Parse(typeof(Parity), _SPBits.Name);               // typecast value
                    stopBits = serialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), _SCombStopBits.Name);

                    mbModel.OpenConnectionRTU(_PortName, _BaudRate, parity, _DataBits, stopBits);           // Call Open Connection
                    mbModel.AutoCoilStatus();
                }
                if (_ASCII == true)
                {
                    MessageBox.Show("Implementation Remaining");
                }
            } 
        }
        public void CloseConnection()
        {
            mbModel.CloseConnection();
           // _itemHandler.AutoCoilAdd(new AutoCoilItem("Hello"));
            //ProgressBarOpen = 0;
        }
        private void ReadCoilAndInput()
        {

            //Dictionary<string, string> DicReadInputCoil =new Dictionary<string, string>();
            if (_Coil&&ScombReadAddresses!=null&&_SlaveID!=0&&_Quentity!=0)
            {
                PortStatus=mbModel.CheckPortOnOff();    // check on off serial port connection
                if (PortStatus)
                {
                    _Address = ScombReadAddresses.Name;
                    mbModel.ReadCoil(_SlaveID, _Address, _Quentity);
                    short i = 0;
                    if (Read.Count != 0)   // if list is not empty then first clear list then add new item
                    {
                        Read.Clear();   // clear list
                    }

                    foreach (var item in mbModel.ReadCoilData)
                    {
                        //DicReadInputCoil.Add("Coil "+i.ToString(),item.ToString());
                        i++;
                        _itemHandler.ReadAdd(new ReadItem("Coil" + i.ToString() + "  " + item.ToString()));
                    }
                    ReadCoilProgressBar = 100;
                }
                else
                {
                    MessageBox.Show("Connection is Close Please Check Connection and Try again","Message");
                }
 
            }
           
            else if(_Input && ScombReadAddresses != null && _SlaveID != 0 && _Quentity != 0)
            {
                _Address = ScombReadAddresses.Name;
                MessageBox.Show("Click On Input");
                mbModel.ReadInput(_SlaveID, _Address, _Quentity);
                int i = 0;
                foreach (var item in mbModel.ReadInputData)
                {
                    //DicReadInputCoil.Add("Coil "+i.ToString(),item.ToString());
                    i++;
                    _itemHandler.ReadAdd(new ReadItem("Input" + i.ToString() + "  " + item.ToString()));
                }
                ReadCoilProgressBar = 100;
            }
            else
            {
                MessageBox.Show("Please Fill all Values", "Message");
            }
        }
        private void ClearCoilAndInput()
        {
            Read.Clear();
            ReadCoilProgressBar = 0;
        }
        private void ClearMCoilList()
        {
            WriteMCoil.Clear();
        }

        private void ClearSCoilList()
        {
            Items.Clear();
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
            _Address = OriginalAddress;
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
                    //mbModel.ReadCoil(_SlaveID, 3999, _Quentity);  //update Coil Data
                    _itemHandler.Add(new Item("true"));
                    WriteSCoilProgressBar = 100;
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
                    _itemHandler.Add(new Item("false"));
                    WriteSCoilProgressBar = 100;
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

        public void MultiOnCoilStatus()         // multi On Status
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
        public void MultiOffCoilStatus()         // multi On Status
        {
            if (_CheckCoil1 || _CheckCoil2 || _CheckCoil3 || _CheckCoil4)
            {

                if (_CheckCoil1)
                {
                    WriteMultiCoilData[0] = false;
                }
                if (_CheckCoil2)
                {
                    WriteMultiCoilData[1] = false;
                }
                if (_CheckCoil3)
                {
                    WriteMultiCoilData[2] = false;
                }
                if (_CheckCoil4)
                {
                    WriteMultiCoilData[3] = false;
                }
            }
        }

        public void WriteMultiCoil()
        {
            _Address = OriginalAddress;
            //_itemHandler.WriteMAdd(new WriteItem(SPerson.Name));
            if (RTU)
            {
                WriteMultiCoilData = mbModel.MultiStatus(_SlaveID, _Address, _Quentity); // check status
               
            }
            if(radioOnMulti)
            {
                MultiOnCoilStatus();
                mbModel.WriteMultiCoils(_SlaveID, _Address, WriteMultiCoilData);      // call write multi coil method
                if(WriteMCoil.Count<=4)
                {
                    WriteMCoil.Clear();
                }
                foreach (var item in WriteMultiCoilData)
                {
                    _itemHandler.WriteMAdd(new WriteItem(item.ToString()));
                }
                WriteMCoilProgressBar = 100;
            }
            else if(radioOffMulti)
            {
                MultiOffCoilStatus();
                mbModel.WriteMultiCoils(_SlaveID, _Address, WriteMultiCoilData);      // call write multi coil method
                if (WriteMCoil.Count <= 4)
                {
                    WriteMCoil.Clear();
                }
                foreach (var item in WriteMultiCoilData)
                {
                    _itemHandler.WriteMAdd(new WriteItem(item.ToString()));
                }
                WriteMCoilProgressBar = 100;

            }

        }
        //*******************************************End Functions*********************************************//

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
    // Combox Practice Classes
    class Person
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
    class CombParityBit
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
    class CombStopBit
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }

    class CombReadAddress
    {
        private ushort _name;

        public ushort Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
    // Dispatcher Practice class
    //public static class DispatchService
    //{
    //    public static void Invoke(Action action)
    //    {
    //        Dispatcher dispatchObject = Application.Current.Dispatcher;
    //        if (dispatchObject == null || dispatchObject.CheckAccess())
    //        {
    //            action();
    //        }
    //        else
    //        {
    //            dispatchObject.Invoke(action);
    //        }
    //    }
    //}
}
