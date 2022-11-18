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
    /// Interaction logic for ComboBox.xaml
    /// </summary>
    public partial class ComboBox : Window
    {
        public ComboBox()
        {
            InitializeComponent();
            combo.Items.Add("None");
            combo.Items.Add("Even");
            combo.Items.Add("Odd");

        }
    }
}
