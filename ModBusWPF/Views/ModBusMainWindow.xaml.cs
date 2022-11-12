using ModBusWPF.ViewModels;
using System.Windows;

namespace ModBusWPF.Views
{
    /// <summary>
    /// Interaction logic for ModBusMainWindow.xaml
    /// </summary>
    public partial class ModBusMainWindow : Window
    {
        public ModBusMainWindow()
        {
            InitializeComponent();
            this.DataContext = new ViewModel();
        }
    }
}
