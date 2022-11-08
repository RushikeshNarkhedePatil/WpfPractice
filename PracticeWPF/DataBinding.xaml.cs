using System;
using System.Collections.Generic;
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
    /// Interaction logic for DataBinding.xaml
    /// </summary>
    public partial class DataBinding : Window
    {
        Person person = new Person{Name = "Rushikesh", Age = 24};
        public DataBinding()
        {
            InitializeComponent();
            this.DataContext = person;
        }
        private void Show(object sender, RoutedEventArgs e)
        {
            string message = person.Name + " " + person.Age;
            MessageBox.Show(message);
        }
    }
    // Create another class
    public class Person
    {
        private string nameValue;
        public string Name
        {
            get { return nameValue; }
            set
            {
                nameValue = value;
            }
        }
        private double ageValue;
        public double Age
        {
            get { return ageValue; }

            set
            {
                if (value != ageValue)
                {
                    ageValue = value;
                }
            }
        }

    }
}
