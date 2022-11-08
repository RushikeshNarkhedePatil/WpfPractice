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
    /// Interaction logic for ModBus.xaml
    /// </summary>
    public partial class ModBus : Window
    {
        public ModBus()
        {
            InitializeComponent();
        }

        private void RowDefinition_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            ProgressBarOpen.Value = 100;
        }
    }
}
