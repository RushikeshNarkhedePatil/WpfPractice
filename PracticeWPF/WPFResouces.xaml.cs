﻿using System;
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
    /// Interaction logic for WPFResouces.xaml
    /// </summary>
    public partial class WPFResouces : Window
    {
        public WPFResouces()
        {
            InitializeComponent();
        }

        private void changeResourceButton_Click(object sender, RoutedEventArgs e)
        {
            this.Resources["brushResource"] = new SolidColorBrush(Colors.Red);
            //try
            //{
               
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            
        }
    }
}
