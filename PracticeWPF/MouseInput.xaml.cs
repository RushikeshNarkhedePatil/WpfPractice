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
    /// Interaction logic for MouseInput.xaml
    /// </summary>
    public partial class MouseInput : Window
    {
        public MouseInput()
        {
            InitializeComponent();
        }
        private void OnMouseEnter(object sender,MouseEventArgs e)
        {
            Rectangle source = e.Source as Rectangle;
            if (source != null)
            {
                source.Fill = Brushes.SlateGray;
            }
            txt1.Text = "Mouse Enter";
        }

        private void OnMouseLeave(object sender,MouseEventArgs e)
        {
            // Cast the source of the event to a Button. 
            Rectangle source = e.Source as Rectangle;

            // If source is a Button. 
            if (source != null)
            {
                source.Fill = Brushes.AliceBlue;
            }

            txt1.Text = "Mouse Leave";
            txt2.Text = "";
            txt3.Text = "";

        }
        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            Point pnt = e.GetPosition(mrRec);
            txt2.Text = "Mouse Move: " + pnt.ToString();
        }
        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            Rectangle source = e.Source as Rectangle;
            Point pnt = e.GetPosition(mrRec);
            txt3.Text = "Mouse Click: " + pnt.ToString();

            if (source != null)
            {
                source.Fill = Brushes.Beige;
            }
        }

    }
}
