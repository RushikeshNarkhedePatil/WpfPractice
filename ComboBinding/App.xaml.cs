using System.Windows;
using Prism.Ioc;
using ComboBinding.Views;
using Prism.Unity;
using DryIoc;
using ModBusGUI.Views;

namespace ComboBinding
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
