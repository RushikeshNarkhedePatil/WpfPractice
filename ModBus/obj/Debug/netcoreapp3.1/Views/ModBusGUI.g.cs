#pragma checksum "..\..\..\..\Views\ModBusGUI.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "32588BD17F7A15F51126EA7A29B0FAEB45F87226"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ModBus.Views;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace ModBus.Views {
    
    
    /// <summary>
    /// ModBusGUI
    /// </summary>
    public partial class ModBusGUI : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 47 "..\..\..\..\Views\ModBusGUI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPort;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\Views\ModBusGUI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBaudRate;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\Views\ModBusGUI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtData;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\Views\ModBusGUI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CombParityBit;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\Views\ModBusGUI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CombStopBit;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\Views\ModBusGUI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnOpen;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\..\Views\ModBusGUI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClose;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\..\Views\ModBusGUI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar ProgressBarOpen;
        
        #line default
        #line hidden
        
        
        #line 126 "..\..\..\..\Views\ModBusGUI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar readProgressBar;
        
        #line default
        #line hidden
        
        
        #line 128 "..\..\..\..\Views\ModBusGUI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ListViewRead;
        
        #line default
        #line hidden
        
        
        #line 155 "..\..\..\..\Views\ModBusGUI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSingleCoilSlaveID;
        
        #line default
        #line hidden
        
        
        #line 156 "..\..\..\..\Views\ModBusGUI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSingleCoilAddress;
        
        #line default
        #line hidden
        
        
        #line 157 "..\..\..\..\Views\ModBusGUI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSingleCoilData;
        
        #line default
        #line hidden
        
        
        #line 225 "..\..\..\..\Views\ModBusGUI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtWriteMultiSlaveId;
        
        #line default
        #line hidden
        
        
        #line 226 "..\..\..\..\Views\ModBusGUI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtWriteMultiAddress;
        
        #line default
        #line hidden
        
        
        #line 227 "..\..\..\..\Views\ModBusGUI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CombWriteMultiCoil;
        
        #line default
        #line hidden
        
        
        #line 274 "..\..\..\..\Views\ModBusGUI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ListViewAutoCoil;
        
        #line default
        #line hidden
        
        
        #line 279 "..\..\..\..\Views\ModBusGUI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ListViewAutoInput;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.16.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ModBus;component/views/modbusgui.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\ModBusGUI.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.16.0")]
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
            
            #line 52 "..\..\..\..\Views\ModBusGUI.xaml"
            this.btnOpen.Click += new System.Windows.RoutedEventHandler(this.OpenConnectionButton);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnClose = ((System.Windows.Controls.Button)(target));
            return;
            case 8:
            this.ProgressBarOpen = ((System.Windows.Controls.ProgressBar)(target));
            return;
            case 9:
            this.readProgressBar = ((System.Windows.Controls.ProgressBar)(target));
            return;
            case 10:
            this.ListViewRead = ((System.Windows.Controls.ListView)(target));
            return;
            case 11:
            this.txtSingleCoilSlaveID = ((System.Windows.Controls.TextBox)(target));
            return;
            case 12:
            this.txtSingleCoilAddress = ((System.Windows.Controls.TextBox)(target));
            return;
            case 13:
            this.txtSingleCoilData = ((System.Windows.Controls.TextBox)(target));
            return;
            case 14:
            this.txtWriteMultiSlaveId = ((System.Windows.Controls.TextBox)(target));
            return;
            case 15:
            this.txtWriteMultiAddress = ((System.Windows.Controls.TextBox)(target));
            return;
            case 16:
            this.CombWriteMultiCoil = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 17:
            this.ListViewAutoCoil = ((System.Windows.Controls.ListView)(target));
            return;
            case 18:
            this.ListViewAutoInput = ((System.Windows.Controls.ListView)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

