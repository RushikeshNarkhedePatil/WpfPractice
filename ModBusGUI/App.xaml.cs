
using ModBusGUI.Views;
using Prism.DryIoc;
using Prism.Ioc;
using System.Windows;

namespace ModBusGUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<ModBusMainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }
    }
}
