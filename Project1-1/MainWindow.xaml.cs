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

        /* Created two instance variables; Resource: https://www.geeksforgeeks.org/c-sharp-types-of-variables/ */
        int rectHeight; // Created an instance variable 'rectHeight' to use in multiple methods
        int rectArea; // Created an instance variable 'rectArea' to use in multiple methods

        /* Method heightBox_TextChanged will make sure that the inputted height is an integer and it's length is greater than 0 */
        private void HeightBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (HeightBox.Text.Length == 0) // This to make sure that there won't be any errors when the textbox is empty
            {
                return;
            }

            int heightCheck = int.Parse(HeightBox.Text); // This is to make sure that the height/text inputted will be an integer
            if(heightCheck > 0) // If the inputted height is greater than 0, variable rectHeight will hold the inputted height
            {
                rectHeight = heightCheck;
            }
        }
       /* Method heightBox_PreviewTextInput will make sure that the inputted height will take only numbers */
        private void HeightBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !int.TryParse(e.Text, out int result); // Resource: TextBook page 9
        }

        /* Method areaBox_TextChanged will make sure that the inputted area is an integer and it's length is greater than 0 */
        private void AreaBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (AreaBox.Text.Length == 0) // This is to make sure that there won't be any errors when the textbox is empty
            {
                return;
            }
            rectArea = int.Parse(AreaBox.Text); 
        }

        /* Method areaBox_PreviewTextInput will make sure that the inputted area will take only numbers */
        private void AreaBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !int.TryParse(e.Text, out int result);
        }

        /* Method Button_Click creates the rectangle */
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (rectHeight == 0) // If the user makes height 0, this message will come out
            {
                Text1.Text = "Please put something higher than a 0";
                return;
            }
            double rectWidth = rectArea / rectHeight; // This is the formula for the rectangle width

            if(rectHeight > 0 && rectHeight <=356 && rectWidth > 0 && rectWidth <=784) // This is to make sure that the rectangle is not too small and doesn't grow bigger than the main window; 356 and 784 are the largest height and width can be in the main window that pops out on my macbook
            {
                Text1.Text = "Congratulations, you made a rectangle!"; // If the rectangle has inputted area and heights that are within the boundaries, this text will show
                Rectangle.Height = rectHeight; // The rectangle height will change to the inputted height
                Rectangle.Width = rectWidth; // The rectangle width will change to the inputted width
            }
            else
            {
                Text1.Text = "ERROR: Area or height may be too large"; // If the rectangle is too big for the main window, this message will show
            }
        }

        private void ComboBoxShape_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox senderComboBox = (ComboBox)sender;
        }
    }
}
