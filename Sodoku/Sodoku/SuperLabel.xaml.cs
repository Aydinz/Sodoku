using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sodoku
{
    /// <summary>
    /// Creates the label which will be used in the grid
    /// </summary>
    public partial class SuperLabel : UserControl
    {
        private int counter = 0;
        public SuperLabel()
        {
            this.VerticalAlignment = VerticalAlignment.Top;
            this.Width = 33;
            this.Height = 33;
            this.BorderThickness = new Thickness(0.25);
            this.BorderBrush = Brushes.Black;
            InitializeComponent();
        }
        // Eventhandler for the mousedownleft of the label
        private void mouseDownLeft(object sender, MouseButtonEventArgs e)
        {
            if (counter == 9)
            {
                counter = 1;
            }
            else
            {
                counter++;
            }
            temp.Content = counter.ToString();
        }
        // Eventhandler for the mousedownright of the label
        private void mouseDownRight(object sender, MouseButtonEventArgs e)
        {
            if (counter == 0 || counter == 1)
            {
                counter = 9;
            }

            else
            {
                counter--;
            }
            temp.Content = counter.ToString();
        }
    }
}
