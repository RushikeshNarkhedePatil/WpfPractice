using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeMVVM.ViewModel
{
    class UserViewModel:BindableBase
    {
        String _Title="Demo";
        public String Title 
        {
        get { return _Title; }
            set
            {
                SetProperty(ref _Title ,value);
            }
        }
    }
}