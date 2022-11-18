﻿#pragma checksum "..\..\..\Views\ModBusMainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "159A8963633A44344ED5FE4551D30E8CFD03EAD967D95695376460F927718154"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ModBusGUI.Models;
using ModBusGUI.ViewModels;
using ModBusGUI.Views;
using Prism.DryIoc;
using Prism.Interactivity;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Regions.Behaviors;
using Prism.Services.Dialogs;
using Prism.Unity;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace ModBusGUI.Views {
    
    
    /// <summary>
    /// ModBusMainWindow
    /// </summary>
    public partial class ModBusMainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 50 "..\..\..\Views\ModBusMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPort;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\Views\ModBusMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBaudRate;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\Views\ModBusMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtData;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\Views\ModBusMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CombParityBit;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\Views\ModBusMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CombStopBit;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\Views\ModBusMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnOpen;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\Views\ModBusMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClose;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\Views\ModBusMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar ProgressBarOpen;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\Views\ModBusMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton radioRTU;
        
        #line default
        #line hidden
        
        
        #line 150 "..\..\..\Views\ModBusMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar readProgressBar;
        
        #line default
        #line hidden
        
        
        #line 154 "..\..\..\Views\ModBusMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lstRead;
        
        #line default
        #line hidden
        
        
        #line 194 "..\..\..\Views\ModBusMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSingleCoilSlaveID;
        
        #line default
        #line hidden
        
        
        #line 197 "..\..\..\Views\ModBusMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSingleCoilAddress;
        
        #line default
        #line hidden
        
        
        #line 200 "..\..\..\Views\ModBusMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSingleCoilData;
        
        #line default
        #line hidden
        
        
        #line 277 "..\..\..\Views\ModBusMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtWriteMultiSlaveId;
        
        #line default
        #line hidden
        
        
        #line 280 "..\..\..\Views\ModBusMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtWriteMultiAddress;
        
        #line default
        #line hidden
        
        
        #line 283 "..\..\..\Views\ModBusMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CombWriteMultiCoil;
        
        #line default
        #line hidden
        
        
        #line 336 "..\..\..\Views\ModBusMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ListViewAutoCoil;
        
        #line default
        #line hidden
        
        
        #line 339 "..\..\..\Views\ModBusMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ListViewAutoInput;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ModBusGUI;component/views/modbusmainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\ModBusMainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.txtPort = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txtBaudRate = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtData = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.CombParityBit = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.CombStopBit = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.btnOpen = ((System.Windows.Controls.Button)(target));
            return;
            case 7:
            this.btnClose = ((System.Windows.Controls.Button)(target));
            return;
            case 8:
            this.ProgressBarOpen = ((System.Windows.Controls.ProgressBar)(target));
            return;
            case 9:
            this.radioRTU = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 10:
            this.readProgressBar = ((System.Windows.Controls.ProgressBar)(target));
            return;
            case 11:
            this.lstRead = ((System.Windows.Controls.ListView)(target));
            return;
            case 12:
            this.txtSingleCoilSlaveID = ((System.Windows.Controls.TextBox)(target));
            return;
            case 13:
            this.txtSingleCoilAddress = ((System.Windows.Controls.TextBox)(target));
            return;
            case 14:
            this.txtSingleCoilData = ((System.Windows.Controls.TextBox)(target));
            return;
            case 15:
            this.txtWriteMultiSlaveId = ((System.Windows.Controls.TextBox)(target));
            return;
            case 16:
            this.txtWriteMultiAddress = ((System.Windows.Controls.TextBox)(target));
            return;
            case 17:
            this.CombWriteMultiCoil = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 18:
            this.ListViewAutoCoil = ((System.Windows.Controls.ListView)(target));
            return;
            case 19:
            this.ListViewAutoInput = ((System.Windows.Controls.ListView)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

