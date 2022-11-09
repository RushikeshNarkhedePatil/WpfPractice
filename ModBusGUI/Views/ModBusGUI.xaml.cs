using ModBus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ModBusGUI.Views
{
    /// <summary>
    /// Interaction logic for ModBusGUI.xaml
    /// </summary>
    public partial class ModBusGUI : Window
    {
        public ModBusGUI()
        {
            InitializeComponent();
        }
        private void OpenConnectionButton(object sender, RoutedEventArgs e)
        {
            MBOpenConnection openConnection = new MBOpenConnection();
            openConnection.OpenRTU();
            ProgressBarOpen.Value = 100;
        }
    }
}
