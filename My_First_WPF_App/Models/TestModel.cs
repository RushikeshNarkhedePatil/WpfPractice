using System;
using System.Collections.Generic;
using System.Text;
using Prism.Mvvm;

namespace My_First_WPF_App.Models
{
    class TestModel: BindableBase
    {
        private string _Message;
        public string Message
        {
            get
            {
                return _Message;
            }
            set
            {
                SetProperty(ref _Message, value);
            }
        }
    }
}
