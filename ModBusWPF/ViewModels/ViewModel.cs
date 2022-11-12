using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModBusWPF.ViewModels
{

    class ViewModel:BindableBase
    {
        private string _Header = "My Window";

        public string Header
        {
            get { return _Header; }
            set { SetProperty(ref _Header, value); }
        }
    }
}
