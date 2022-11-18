using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace PracticeMVVM.ViewModel
{
    class UserViewModel:BindableBase
    {
        //private ObservableCollection<Person> person;
        public UserViewModel()
        {
             //person = new ObservableCollection<Person>()
             //{
             //    new Person(){Name="Prabhat",Address="India"},

             //    new Person(){Name="Smith",Address="US"}
             //};
            //lstNames.ItemsSource = person;

            ClickCommand = new DelegateCommand(ClickCommandFun);
        }
        public ICommand ClickCommand
        {
            get;
            private set;
        }

        public void ClickCommandFun()
        {
            MessageBox.Show("Click Event");
        }

        private String _Title="Demo";

        public String Title 
        {
        get { return _Title; }
            set
            {
                SetProperty(ref _Title ,value);
            }
        }
    }
    //public class Person
    //{
    //    public string Name { get; set; }
    //    public string Address { get; set; }
    //}
}