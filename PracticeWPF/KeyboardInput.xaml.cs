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
    /// Interaction logic for KeyboardInput.xaml
    /// </summary>
    public partial class KeyboardInput : Window
    {
        public KeyboardInput()
        {
            InitializeComponent();
        }
        private void OnTextInputKeyDown(object sender,KeyEventArgs e)
        {
            if (e.Key == Key.O && Keyboard.Modifiers == ModifierKeys.Control)
            {
                handle();
                e.Handled = true;
            }   
        }
        private void OnTextInputButtonClick(object sender, RoutedEventArgs e)
        {
            handle();
            e.Handled = true;
        }
        public void handle()
        {
            MessageBox.Show("Do you want to open a file?");
        }
    }
}
