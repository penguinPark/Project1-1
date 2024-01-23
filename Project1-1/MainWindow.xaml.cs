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

namespace Project1_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

        }
        private void heightBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // int area = 200;
            double area = Rectangle.Height * Rectangle.Width;
            if (heightBox.Text.Length == 0)
            {
                return;
            }
            int height = int.Parse(heightBox.Text);
            
            if (height !=0 && height <= 450)
            {
                double width = area / height;
                if (width <= 800 && width > 0)
                {
                    Rectangle.Height = height;
                    Rectangle.Width = width;
                }
            } 
            else
            {
                return;
            }
        }

        private void heightBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !int.TryParse(e.Text, out int result);
        }

        private void areaBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (areaBox.Text.Length == 0)
            {
                return;
            }
            int areaText = int.Parse(areaBox.Text);
            double width = areaText / Rectangle.Height;
            if(width <= 800 && width > 0)
            {
                Rectangle.Width = width;

            }

        }
        private void areaBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !int.TryParse(e.Text, out int result);
        }
    }
}
