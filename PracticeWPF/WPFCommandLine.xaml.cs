using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for WPFCommandLine.xaml
    /// </summary>
    public partial class WPFCommandLine : Window
    {
        public WPFCommandLine()
        {
            InitializeComponent();
            String[] args = App.Args;

            try
            {
                // Open the text file using stream reader.
                using(StreamReader sr=new StreamReader(args[0]))
                {
                    // Read the stream to a string, and write  
                    // the string to the text box 
                    string line = sr.ReadToEnd();
                    textBox.AppendText(line.ToString());
                    textBox.AppendText("\n");
                }
            }
            catch (Exception e)
            {
                textBox.AppendText("The file could not be read:");
                textBox.AppendText("\n");
                textBox.AppendText(e.Message);
            }
        }
       
    }
}
