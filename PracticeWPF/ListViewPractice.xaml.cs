using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PracticeWPF
{
    /// <summary>
    /// Interaction logic for ListViewPractice.xaml
    /// </summary>
    public partial class ListViewPractice : Window
    {
        private ObservableCollection<Person1> person;
        public ListViewPractice()
        {
            InitializeComponent();
            person = new ObservableCollection<Person1>()
            {
                new Person1(){Name="Rushikesh",Address="India"},
                new Person1(){Name="Pavan",Address="India"}

            };
            lstNames.ItemsSource = person;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ListDemo li = new ListDemo();
            li.Demo();
          
        }

        private void btnNames_Click(object sender, RoutedEventArgs e)
        {
            person.Add(new Person1() { Name = txtName.Text, Address = txtAddress.Text });
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            person.Clear();
        }
    }
    public class Person1
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
