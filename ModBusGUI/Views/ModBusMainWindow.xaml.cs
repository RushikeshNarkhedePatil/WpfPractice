using System.Windows;
using ModBusGUI.ViewModels;

namespace ModBusGUI.Views
{
    /// <summary>
    /// Interaction logic for ModBusMainWindow.xaml
    /// </summary>
    public partial class ModBusMainWindow : Window
    {
        //MBViewModel mBViewModel;
        public ModBusMainWindow()
        {
            
            InitializeComponent();
            this.DataContext = new MBViewModel();
        }

        private void OpenConnection_Button(object sender, RoutedEventArgs e)
        {

        }
    }
}
