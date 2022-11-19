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
    /// Interaction logic for ComboBox.xaml
    /// </summary>
    public partial class ComboBox : Window
    {
        public ComboBox()
        {
            InitializeComponent();
            person = new ObservableCollection<ComboItems>()
            {

                new ComboItems() { Name = "Prabhat", Address = "India" },

                new ComboItems() { Name = "Smith", Address = "US" }

            };
            ComboBox1.ItemsSource = LoadComboBoxData();
            //ComboBox1.ItemsSource = person;
        }
        private string[] LoadComboBoxData()
        {
            string[] strArray = {
            "Coffie",
            "Tea",
            "Orange Juice",
            "Milk",
            "Mango Shake",
            "Iced Tea",
            "Soda",
            "Water"
        };
            return strArray;
        }
       
        private ObservableCollection<ComboItems> person;
    }
   
    public class ComboItems
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
