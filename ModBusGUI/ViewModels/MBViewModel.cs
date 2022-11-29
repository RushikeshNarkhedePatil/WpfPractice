using Prism.Mvvm;
using ModBusGUI.Models;
using Prism.Commands;
using System.Windows.Input;
using System.Windows;
using System.IO.Ports;
using System;
using System.Collections.ObjectModel;
using System.Threading;

namespace ModBusGUI.ViewModels
{

    class MBViewModel:BindableBase
    {
        private SerialPort serialPort = new SerialPort(); //Create a new SerialPort object.
        private MBModel mbModel;
        private MBPLCOperations MBPLC;
       // private MBDisplayOutput MBDisplayOutput;
        private string _Title = "ModBus Project";
        private Parity parity;
        private StopBits stopBits;
        //private string _Message;
        private string _PortName = "COM4";
        private int _BaudRate = 9600;
        private int _DataBits=8;
        private string _Parity;
        private string _StopBits;
        private byte _SlaveID = 10;
        private ushort _Address = 3999;
        private ushort _MCAddress = 3999;
        private ushort TempSAddress;
        private ushort TempMAddress;
        private ushort _Quentity = 4;
        //private int SingleCoilPosition;
        private ushort TempReadCoilAddresss;
        private bool WriteCoil = false;
        private string Mode;
        private bool PortStatus = false;
        public bool[] ReadCoilData = { false, false, false, false };
        private bool[] WriteMultiCoilData = { false, false, false, false };
        private bool status = false;
       //private bool validateDataStatus;

        public string Header
        {
            get { return _Title; }
            set { SetProperty(ref _Title, value); }
        }
        // Create Observable Collection
        //private ObservableCollection<Person> person;
        public readonly ItemHandler _itemHandler;
        public MBViewModel()
        {
            MBPLC = new MBPLCOperations();
            mbModel = new MBModel();
            //MBDisplayOutput = new MBDisplayOutput();
            // Set Check Box and Radio Button Values
            CheckCoil1 = true;
            RTU = true;
            radioOnSingle = true;
            radioOnMulti = true;
            SingleCoil1 = true;
            Coil = true;
            //**************************************Call Button after Click*************************************************//
            ClickCommandOpen = new DelegateCommand(OpenConnection);
            ClickCommandRead = new DelegateCommand(ReadCoilAndInput);
            CmdWriteSingleCoil = new DelegateCommand(WriteSingleCoil);
            CmdWriteMultiCoil = new DelegateCommand(WriteMultiCoil);
            ClickCommandClose = new DelegateCommand(CloseConnection);
            RadioRTU = new DelegateCommand(SetRTUValue);
            RadioASCII = new DelegateCommand(SetASCIIValue);
            ClearReadList = new DelegateCommand(ClrReadList);
            ClearSCList = new DelegateCommand(ClrSList);
            ClearMCList = new DelegateCommand(ClrMList);

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
            SPBits = PBits[0]; //SET Selected Value None
            CombStopBits = new ObservableCollection<CombStopBit>()
            {
                new CombStopBit(){Name="One"},
                new CombStopBit(){Name="Two"}
            };
            SCombStopBits = CombStopBits[0];
            combReadAddresses = new ObservableCollection<CombReadAddress>()
            {
                new CombReadAddress(){Name=3999},
                new CombReadAddress(){Name=7999}
            };
            ScombReadAddresses = combReadAddresses[0];
        }// MBViewModel Constructer End

        private void ClrMList()
        {
            //mbModel.ClearMCoilList();
            WriteMCoil.Clear();
            WriteMCoilProgressBar = 0;
        }

        private void ClrSList()
        {
            //mbModel.ClearSCoilList();
            Items.Clear();
            WriteSCoilProgressBar = 0;

        }

        private void ClrReadList()
        {
            //mbModel.ClearReadCoilAndInput();
            Read.Clear();
            ReadCoilProgressBar = 0;
        }

        private void SetRTUValue()  //set radio values after click
        {
            DataBits = 8;
        }
        private void SetASCIIValue()
        {
            DataBits = 7;
        }

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
        public ObservableCollection<AutoCoilItem> AutoCoil
        {
            get { return _itemHandler.AutoCoil; }
        }
        public ObservableCollection<AutoInputItem> AutoInput
        {
            get { return _itemHandler.AutoInput; }
        }
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
        public ICommand RadioRTU
        {
            get;
            private set;
        }
        public ICommand RadioASCII
        {
            get;
            private set;
        }
        public ICommand ClearMCList
        {
            get;
            private set;
        }
        public ICommand ClearSCList
        {
            get;
            private set;
        }

        public ICommand ClearReadList
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
        //*******************************************Auto Coil****************************************************************//
        public void AutoCoilStatus()
        {
            if (status)
            {
                timeCB = new TimerCallback(MBPLC.PrintCoil);
                System.Threading.Timer t = new System.Threading.Timer(
                timeCB,
                "Hi",
                0,
                1000);

                if (MBPLC.status)
                {
                    DispatchService.Invoke(() =>
                    {

                        foreach (var item in MBPLC.ReadCoilData)
                        {
                            _itemHandler.AutoCoilAdd(new AutoCoilItem(item.ToString()));

                        }
                        if (AutoCoil.Count >= 5)
                        {
                            AutoCoil.Clear();
                        }

                    });
                }
                else
                {
                    MessageBox.Show("Check Connection");
                }
            }
        }
        //public void AutoCoilDisplay()
        //{
        //    DispatchService.Invoke(() =>
        //    {

        //        foreach (var item in ReadCoilData)
        //        {
        //            _itemHandler.AutoCoilAdd(new AutoCoilItem(item.ToString()));

        //        }
        //        if (AutoCoil.Count >= 5)
        //        {
        //            AutoCoil.Clear();
        //        }

        //    });
        //}
        public string CheckMode()
        {
            if(RTU)
            {
                return "RTU";
            }
            else if(ASCII)
            {
                return "ASCII";
            }
            return "-1";
        }
        //private bool validateInformation()
        //{
        //    Set all Values
        //   var ReqParityBit = serialPort.Parity.ToString();
        //    var ReqStopBit = serialPort.StopBits.ToString();
        //    int ReqDataBit = serialPort.DataBits;
        //    int ReqBaudRate = serialPort.BaudRate;
        //    string ReqCompPort = serialPort.PortName;
        //    var ReqMode = ModbusSerialMaster.CreateRtu(serialPort).ToString();
        //    if (ReqDataBit != DataBits)
        //    {
        //        MessageBox.Show("Not Supported Communication Mode? Check Communication Mode again and Try", "Message", MessageBoxButton.OK, MessageBoxImage.Warning);
        //        return false;
        //    }
        //    else if (ReqParityBit == _SPBits.Name && ReqStopBit == _SCombStopBits.Name && ReqDataBit == _DataBits && ReqBaudRate == BaudRate)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        MessageBoxResult result = MessageBox.Show("Please Check all Information Correct Or Not\n" + "Do you want Any suggestion?", "suggestion",
        //            MessageBoxButton.YesNo, MessageBoxImage.Information);
        //        if (result == MessageBoxResult.Yes)
        //        {
        //            MessageBox.Show("ParityBit  \t = " + ReqParityBit + "\n" +
        //                "StopBits\t = " + ReqStopBit + "\n" +
        //                "CompPort = " + ReqCompPort + "\n" +
        //                "DataBits\t = " + ReqDataBit.ToString() + "\n" +
        //                "BaudRate = " + ReqBaudRate.ToString(), "Suggestion", MessageBoxButton.OK, MessageBoxImage.Warning);
        //        }
        //        else
        //        {
        //            No code here
        //        }
        //        return false;
        //    }
        //}
        private void OpenConnection()
        {
            Mode = CheckMode();
            
            if (SPBits== null || SCombStopBits == null||RTU==false&&ASCII==false||PortName==null||BaudRate==0||DataBits==0)
            {
                MessageBox.Show("Please fill all values","Message");
            }
            else
            {
                //validateDataStatus = validateInformation(); // Check for validation
                parity = serialPort.Parity = (Parity)Enum.Parse(typeof(Parity), _SPBits.Name);               // Set values
                stopBits = serialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), _SCombStopBits.Name);
                if(serialPort.DataBits!=DataBits)
                {
                    MessageBox.Show("Not Supported Communication Mode", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                status = MBPLC.OpenConnection(_PortName, _BaudRate, parity, _DataBits, stopBits, Mode);
                if (status)
                {
                    ProgressBarOpen = 100;
                    AutoCoilStatus();
                }
            } 
        }
        public void CloseConnection()
        {
            //mbModel.CloseConnection();
            // _itemHandler.AutoCoilAdd(new AutoCoilItem("Hello"));
            //ProgressBarOpen = 0;
            status = MBPLC.CloseConnection();
            if (status)
            {
                //serialPort.Close();
                ProgressBarOpen = 0;
                ReadCoilProgressBar = 0;
                WriteMCoilProgressBar = 0;
                WriteSCoilProgressBar = 0;
                Read.Clear();
                Items.Clear();
                WriteMCoil.Clear();
                //AutoCoil.Clear();
                //AutoInput.Clear();
            }
            else
            {
                MessageBox.Show("Connection already Close");
            }
        }
        private void ReadCoilAndInput()
        {

            if (_Coil&&ScombReadAddresses!=null&&_SlaveID!=0&&_Quentity!=0)
            {
                //Mode = CheckMode(); // Check communication mode RTU or ASCII
                TempReadCoilAddresss = ScombReadAddresses.Name;
                //mbModel.ReadCoil(_SlaveID, TempReadCoilAddresss, _Quentity,Mode);
                status = MBPLC.ReadCoil(_SlaveID, TempReadCoilAddresss, _Quentity);
                if (status)
                {
                    short i = 0;
                    if (Read.Count != 0)   // if list is not empty then first clear list then add new item
                    {
                        Read.Clear();   // clear list
                    }

                    foreach (var item in MBPLC.ReadCoilData)
                    {
                        //DicReadInputCoil.Add("Coil "+i.ToString(),item.ToString());
                        i++;
                        _itemHandler.ReadAdd(new ReadItem("Coil" + i.ToString() + "  " + item.ToString()));
                    }
                    ReadCoilProgressBar = 100;
                }
            }
           
            else if(_Input && ScombReadAddresses != null && _SlaveID != 0 && _Quentity != 0)
            {
                TempReadCoilAddresss = ScombReadAddresses.Name;
                //MessageBox.Show("Click On Input");
                //mbModel.ReadInput(_SlaveID, TempReadCoilAddresss, _Quentity);
                status = MBPLC.ReadInput(_SlaveID, TempReadCoilAddresss, _Quentity);
                if (status)
                {
                    short i = 0;
                    if (Read.Count != 0)   // if list is not empty then first clear list then add new item
                    {
                        Read.Clear();   // clear list
                    }

                    foreach (var item in MBPLC.ReadInputData)
                    {
                        //DicReadInputCoil.Add("Coil "+i.ToString(),item.ToString());
                        i++;
                        _itemHandler.ReadAdd(new ReadItem("Input" + i.ToString() + "  " + item.ToString()));
                    }
                    ReadCoilProgressBar = 100;
                }
                else
                {
                    MessageBox.Show("Check Connection");
                }

            }
            else
            {
                MessageBox.Show("Please Fill all Values", "Message");
            }
        }
        //private void ClearCoilAndInput()
        //{
        //    Read.Clear();
        //    ReadCoilProgressBar = 0;
        //}
        //private void ClearMCoilList()
        //{
        //    WriteMCoil.Clear();
        //    WriteMCoilProgressBar = 0;
        //}

        //private void ClearSCoilList()
        //{
        //    Items.Clear();
        //    WriteSCoilProgressBar = 0;
        //}
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
            //SingleCoilPosition = CheckSingleCoilPosition();     // check coil position status
            TempSAddress = Address;

            if (radioOnSingle)
            {
                //mbModel.WriteSingleCoil(_SlaveID, TempSAddress, true,Mode);
                status=MBPLC.WriteSingleCoil(_SlaveID, TempSAddress, true);
                if(status)
                {
                    if (Items.Count >= 8)
                    {
                        Items.Clear();
                    }
                    _itemHandler.Add(new Item(true.ToString()));
                    WriteSCoilProgressBar = 100;
                    AutoCoilStatus();
                }
                else
                {
                    MessageBox.Show("Check Connection");
                }
            }
            else if(radioOffSingle)
            {
                //mbModel.WriteSingleCoil(_SlaveID, TempSAddress, false,Mode);
                status=MBPLC.WriteSingleCoil(_SlaveID, TempSAddress, false);
                if (status)
                {
                    if (Items.Count >= 8)
                    {
                        Items.Clear();
                    }
                    _itemHandler.Add(new Item(false.ToString()));
                    WriteSCoilProgressBar = 100;
                    AutoCoilStatus();
                }
                else
                {
                    MessageBox.Show("Check Connection");
                }
            }
            else
            {
                MessageBox.Show("Plaese Select Value ON or OFF", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
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
            TempMAddress = MCAddress;
            //_itemHandler.WriteMAdd(new WriteItem(SPerson.Name));
            WriteMultiCoilData = MBPLC.MultiStatus(_SlaveID, TempMAddress, _Quentity); // check status
            if (radioOnMulti && (CheckCoil1 || CheckCoil2 || CheckCoil3 || CheckCoil4))
            {
                MultiOnCoilStatus();
                //mbModel.WriteMultiCoils(_SlaveID, TempMAddress, WriteMultiCoilData, Mode);      // call write multi coil method
                status=MBPLC.WriteMultiCoils(_SlaveID, TempMAddress, WriteMultiCoilData);      // call write multi coil method
                if(status)
                {
                    if (WriteMCoil.Count <= 4)
                    {
                        WriteMCoil.Clear();
                    }
                    foreach (var item in WriteMultiCoilData)
                    {
                        _itemHandler.WriteMAdd(new WriteItem(item.ToString()));
                    }
                    WriteMCoilProgressBar = 100;
                    AutoCoilStatus();
                }
                else
                {
                    MessageBox.Show("Check Connection");
                }
                //if (WriteMCoil.Count <= 4)
                //{
                //    WriteMCoil.Clear();
                //}
                //foreach (var item in WriteMultiCoilData)
                //{
                //    _itemHandler.WriteMAdd(new WriteItem(item.ToString()));
                //}
                //WriteMCoilProgressBar = 100;
            }
            else if (radioOffMulti && (CheckCoil1 || CheckCoil2 || CheckCoil3 || CheckCoil4))
            {
                TempMAddress = MCAddress;
                MultiOffCoilStatus();
                MBPLC.WriteMultiCoils(_SlaveID, TempMAddress, WriteMultiCoilData);      // call write multi coil method
                if (status)
                {
                    if (WriteMCoil.Count <= 4)
                    {
                        WriteMCoil.Clear();
                    }
                    foreach (var item in WriteMultiCoilData)
                    {
                        _itemHandler.WriteMAdd(new WriteItem(item.ToString()));
                    }
                    WriteMCoilProgressBar = 100;
                    AutoCoilStatus();
                }
                else
                {
                    MessageBox.Show("Check Connection");
                }
                //if (WriteMCoil.Count <= 4)
                //{
                //    WriteMCoil.Clear();
                //}
                //foreach (var item in WriteMultiCoilData)
                //{
                //    _itemHandler.WriteMAdd(new WriteItem(item.ToString()));
                //}
                //WriteMCoilProgressBar = 100;

            }
            else
            {
                MessageBox.Show("Fill all Information");
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
        public ushort MCAddress
        {
            get { return _MCAddress; }
            set
            {
                SetProperty(ref _MCAddress, value);
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
        private TimerCallback timeCB;

        public double WriteMCoilProgressBar
        {
            get { return _WriteMCoilProgressBar; }
            private set
            {
                SetProperty(ref _WriteMCoilProgressBar, value);
            }
        }

    }
    //************************************ Combox Set Value Classes************************************//
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
}
