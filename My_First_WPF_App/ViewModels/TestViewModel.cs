using System;
using System.Collections.Generic;
using System.Text;
using My_First_WPF_App.Models;
using Prism.Mvvm;

namespace My_First_WPF_App.ViewModels
{
    class TestViewModel:BindableBase
    {
        private TestModel testModel;
        public TestViewModel()
        {
            testModel = new TestModel();
            testModel.Message = "This Is Prism Example";
        }
        public TestModel TestModel
        {
            get
            {
                return testModel;
            }
            set
            {
                SetProperty(ref testModel, value);
            }
        }
    }
}
