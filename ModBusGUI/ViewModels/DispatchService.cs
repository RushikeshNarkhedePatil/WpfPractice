using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace ModBusGUI.ViewModels
{
    public static class DispatchService
    {
        public static void Invoke(Action action)
        {
            try
            {
                Dispatcher dispatchObject = Application.Current.Dispatcher;
                if (dispatchObject == null || dispatchObject.CheckAccess())
                {
                    action();
                }
                else
                {
                    dispatchObject.Invoke(action);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message,"Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }
           
        }
    }
}
