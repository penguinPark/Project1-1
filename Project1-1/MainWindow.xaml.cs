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
        int shapeHeight; // Created an instance variable 'shapeHeight' to use in multiple methods
        int defaultArea; // Created an instance variable 'defaultArea' to use in multiple methods
        int shapeArea; // Created an instance variable 'shapeArea' to use in multiple methods
        string shape; // Created an instance variable 'shape' to use in multiple methods
        string color; // Created an instance variable 'color' to use in multiple methods


        /* Method heightBox_TextChanged will make sure that the inputted height is an integer and it's length is greater than 0 */
        private void HeightBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (HeightBox.Text.Length == 0) // This to make sure that there won't be any errors when the textbox is empty
            {
                return;
            }

            int heightCheck = int.Parse(HeightBox.Text); // This is to make sure that the height/text inputted will be an integer
            if (heightCheck > 0) // If the inputted height is greater than 0, variable rectHeight will hold the inputted height
            {
                shapeHeight = heightCheck;
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
            shapeArea = int.Parse(AreaBox.Text); // This is to make sure that the height/text/ inputted will be an integer
        }

        /* Method areaBox_PreviewTextInput will make sure that the inputted area will take only numbers */
        private void AreaBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !int.TryParse(e.Text, out int result);
        }

        /* Method HeightButton_Click creates the shape when inputting height value */
        private void HeightButton_Click(object sender, RoutedEventArgs e)
        {
            if (shape == "rectangle")
            {
                Circle1.Visibility = Visibility.Hidden; // if rectangle is chosen, the circle will disappear. Resource: https://learn.microsoft.com/en-us/dotnet/api/system.windows.uielement.visibility?view=windowsdesktop-8.0
                if (shapeHeight == 0) // If the user makes height 0, this message will come out
                {
                    Text1.Text = "Please put something higher than a 0";
                    return;
                }
                defaultArea = 10000; // preserved area for rectangle
                double rectWidth = defaultArea / shapeHeight; // This is the formula for the rectangle width

                if (shapeHeight > 0 && shapeHeight <= 393 && rectWidth > 0 && rectWidth <= 526) // This is to make sure that the rectangle is not too small and doesn't grow bigger than the main window; 393 and 526 are the largest height and width can be in the main window that pops out on my macbook
                {
                    Text1.Text = "Congratulations, you made a rectangle!"; // If the rectangle has inputted area and heights that are within the boundaries, this text will show
                    Rectangle.Height = shapeHeight; // The rectangle height will change to the inputted height
                    Rectangle.Width = rectWidth; // The rectangle width will change to the inputted width
                    Rectangle.Visibility = Visibility; // This will allow the rectangle to become visible
                }
                else
                {
                    Text1.Text = "ERROR: Area or height may be too large"; // If the rectangle is too big for the main window, this message will show
                }

                if (color == "red")
                {
                    Rectangle.Fill = System.Windows.Media.Brushes.Red; // This changes the color to Red. Resource: https://learn.microsoft.com/en-us/dotnet/api/system.windows.media.brushes?view=windowsdesktop-8.0               
                }
                else if (color == "yellow")
                {
                    Rectangle.Fill = System.Windows.Media.Brushes.Yellow; // color changes to Yellow                  
                }
                else if (color == "blue")
                {
                    Rectangle.Fill = System.Windows.Media.Brushes.Blue; // color changes to blue                  
                }
                else if (color == "purple")
                {
                    Rectangle.Fill = System.Windows.Media.Brushes.Purple; // color changes to purple                  
                }
                else if (color == "black")
                {
                    Rectangle.Fill = System.Windows.Media.Brushes.Black; // color changes to black               
                }
                else if (color == "pink")
                {
                    Rectangle.Fill = System.Windows.Media.Brushes.Pink; // color changes to pink               
                }
            }
            else if (shape == "circle")
            {
                Rectangle.Visibility = Visibility.Hidden;
                if (shapeHeight == 0) // If the user makes height 0, this message will come out
                {
                    Text1.Text = "Please put something higher than a 0";
                    return;
                }
                defaultArea = 1000; // preserved area for the circle
                double shapeWidth = 2 * (Math.Sqrt(defaultArea / 3.141592653589793)); // equation to find 'r'
                if (shapeHeight > 0 && shapeHeight <= 393 && shapeWidth > 0 && shapeWidth < 526)
                {
                    Text1.Text = "Congratulations! A circle";
                    Circle1.Visibility = Visibility;
                    Circle1.Height = shapeHeight;
                    Circle1.Width = shapeWidth;
                }
                else
                {
                    {
                        Text1.Text = "ERROR: Area or height may be too large";
                    }
                }

                if (color == "red")
                {
                    Circle1.Fill = System.Windows.Media.Brushes.Red; // filling in the color red
                }
                else if (color == "yellow")
                {
                    Circle1.Fill = System.Windows.Media.Brushes.Yellow; // filling in the color yellow
                }
                else if (color == "blue")
                {
                    Circle1.Fill = System.Windows.Media.Brushes.Blue; // color changes to blue                  
                }
                else if (color == "purple")
                {
                    Circle1.Fill = System.Windows.Media.Brushes.Purple; // color changes to purple                  
                }
                else if (color == "black")
                {
                   Circle1.Fill = System.Windows.Media.Brushes.Black; // color changes to black               
                }
                else if (color == "pink")
                {
                    Circle1.Fill = System.Windows.Media.Brushes.Pink; // color changes to pink               
                }
            }
            else if (shape == "square")
            {
                Circle1.Visibility = Visibility.Hidden;
                if (shapeHeight == 0) // If the user makes height 0, this message will come out
                {
                    Text1.Text = "Please put something higher than a 0";
                    return;
                }

                if (shapeHeight > 0 && shapeHeight <= 393) // This is to make sure that the square is not too small and doesn't grow bigger than the main window; 393 is the largest the height and width can be in the main window that pops out on my macbook
                {
                    Text1.Text = "Congratulations, you made a square!";
                    Rectangle.Height = shapeHeight; // The square height will change to the inputted height
                    Rectangle.Width = Rectangle.Height; // The square width will change to the inputted width
                    Rectangle.Visibility = Visibility; // allows the square to be visible
                }
                else
                {
                    Text1.Text = "ERROR: Area or height may be too large";
                }

                if (color == "red")
                {
                    Rectangle.Fill = System.Windows.Media.Brushes.Red; // filling in the color Red                 
                }
                else if (color == "yellow")
                {
                    Rectangle.Fill = System.Windows.Media.Brushes.Yellow; // filling in the color Yellow
                }
                else if (color == "blue")
                {
                    Rectangle.Fill = System.Windows.Media.Brushes.Blue; // color changes to blue                  
                }
                else if (color == "purple")
                {
                    Rectangle.Fill = System.Windows.Media.Brushes.Purple; // color changes to purple                  
                }
                else if (color == "black")
                {
                    Rectangle.Fill = System.Windows.Media.Brushes.Black; // color changes to black               
                }
                else if (color == "pink")
                {
                    Rectangle.Fill = System.Windows.Media.Brushes.Pink; // color changes to pink               
                }
            }
        }
        /* Method AreaButton2_Click creates the shape when inputting area value*/
        private void AreaButton2_Click(object sender, RoutedEventArgs e)
        {
            if (shape == "rectangle")
            {
                Circle1.Visibility = Visibility.Hidden; // makes the circle invisible when forming a rectangle
                if (shapeArea == 0) // If the user makes the area 0, this message will come out
                {
                    Text1.Text = "Please put something higher than a 0";
                }

                double rectWidth = shapeArea / shapeHeight;
                if (shapeHeight > 0 && shapeHeight <= 393 && rectWidth > 0 && rectWidth <= 526) // This is to make sure that the rectangle is not too small and doesn't grow bigger than the main window; 393 and 526 are the largest height and width can be in the main window that pops out on my macbook
                {
                    Text1.Text = "Congratulations, you made a rectangle!"; // If the rectangle has inputted area and heights that are within the boundaries, this text will show
                    Rectangle.Height = shapeHeight; // The rectangle height will change to the inputted height
                    Rectangle.Width = rectWidth; // The rectangle width will change to the inputted width
                }
                else
                {
                    Text1.Text = "ERROR: Area or height may be too large"; // If the rectangle is too big for the main window, this message will show
                }

                if (color == "red")
                {
                    Rectangle.Fill = System.Windows.Media.Brushes.Red; // Color the rectangle red                 
                }
                else if (color == "yellow")
                {
                    Rectangle.Fill = System.Windows.Media.Brushes.Yellow; // Color the rectangle yellow                  
                }
                else if (color == "blue")
                {
                    Rectangle.Fill = System.Windows.Media.Brushes.Blue; // color changes to blue                  
                }
                else if (color == "purple")
                {
                    Rectangle.Fill = System.Windows.Media.Brushes.Purple; // color changes to purple                  
                }
                else if (color == "black")
                {
                    Rectangle.Fill = System.Windows.Media.Brushes.Black; // color changes to black               
                }
                else if (color == "pink")
                {
                    Rectangle.Fill = System.Windows.Media.Brushes.Pink; // color changes to pink               
                }
            }
            else if (shape == "circle")
            {
                Rectangle.Visibility = Visibility.Hidden;
                if (shapeArea == 0) // If the user makes the area 0, this message will come out
                {
                    Text1.Text = "Please put something higher than a 0";
                }
                double shapeWidth = 2 * (Math.Sqrt(shapeArea / 3.141592653589793));
                if (shapeHeight > 0 && shapeHeight <= 393 && shapeWidth > 0 && shapeWidth < 526)
                {
                    Text1.Text = "Congratulations! A circle";
                    Circle1.Visibility = Visibility;
                    Circle1.Height = shapeHeight;
                    Circle1.Width = shapeWidth;
                }
                else
                {
                    Text1.Text = "ERROR: Area or height may be too large";
                }

                if (color == "red")
                {
                    Circle1.Fill = System.Windows.Media.Brushes.Red; // Color the rectangle red
                }
                else if (color == "yellow")
                {
                    Circle1.Fill = System.Windows.Media.Brushes.Yellow; // Color the rectangle yellow
                }
                else if (color == "blue")
                {
                    Circle1.Fill = System.Windows.Media.Brushes.Blue; // color changes to blue                  
                }
                else if (color == "purple")
                {
                    Circle1.Fill = System.Windows.Media.Brushes.Purple; // color changes to purple                  
                }
                else if (color == "black")
                {
                    Circle1.Fill = System.Windows.Media.Brushes.Black; // color changes to black               
                }
                else if (color == "pink")
                {
                    Circle1.Fill = System.Windows.Media.Brushes.Pink; // color changes to pink               
                }
            }
            else if (shape == "square")
            {
                Circle1.Visibility = Visibility.Hidden;
                if (shapeHeight == 0)
                {
                    Text1.Text = "Please put something higher than a 0";
                    return;
                }
                double height = Math.Sqrt(shapeArea); // creating variable height in relation to the square's area
                if (shapeArea > 0 && shapeArea <= 393*393) // This is to make sure that the square is not too small and doesn't grow bigger than the main window; 393 is the largest the height and width can be in the main window that pops out on my macbook
                {
                    Text1.Text = "Congratulations, you made a square!";
                    Rectangle.Height = height; // height will be the square root of the square's height
                    Rectangle.Width = Rectangle.Height; // width is equal to height
                    Rectangle.Visibility = Visibility;
                }
                else
                {
                    Text1.Text = "ERROR: Area or height may be too large";
                }

                if (color == "red")
                {
                    Rectangle.Fill = System.Windows.Media.Brushes.Red; // filling in the color Red                 
                }
                else if (color == "yellow")
                {
                    Rectangle.Fill = System.Windows.Media.Brushes.Yellow; // filling in the color Yellow
                }
                else if (color == "blue")
                {
                    Rectangle.Fill = System.Windows.Media.Brushes.Blue; // color changes to blue                  
                }
                else if (color == "purple")
                {
                    Rectangle.Fill = System.Windows.Media.Brushes.Purple; // color changes to purple                  
                }
                else if (color == "black")
                {
                    Rectangle.Fill = System.Windows.Media.Brushes.Black; // color changes to black               
                }
                else if (color == "pink")
                {
                    Rectangle.Fill = System.Windows.Media.Brushes.Pink; // color changes to pink               
                }
            }

        }

        /* method Rect_Click allows you to choose a rectangle */
        private void Rect_Click(object sender, RoutedEventArgs e)
        {
            shape = "rectangle";
        }

        /* method Circle_Click allows you to choose a circle */
        private void Circle_Click(object sender, RoutedEventArgs e)
        {
            shape = "circle";
        }

        /* method Square_Click allows you to choose a sqaure */
        private void Square_Click(object sender, RoutedEventArgs e)
        {
            shape = "square";
        }

        /* method Red_Click allows you to fill the shape red */
        private void Red_Click(object sender, RoutedEventArgs e)
        {
            color = "red";
        }

        /* method Yellow_Click allows you to fill the shape yellow */
        private void Yellow_Click(object sender, RoutedEventArgs e)
        {
            color = "yellow";
        }

        /* method Blue_Click allows you to fill the shape blue */
        private void Blue_Click(object sender, RoutedEventArgs e)
        {
            color = "blue";
        }

        /* method Purple_Click allows you to fill the shape purple */
        private void Purple_Click(object sender, RoutedEventArgs e)
        {
            color = "purple";
        }

        /* method Black_Click allows you to fill the shape black */
        private void Black_Click(object sender, RoutedEventArgs e)
        {
            color = "black";
        }

        /* method Pink_Click allows you to fill the shape pink */
        private void Pink_Click(object sender, RoutedEventArgs e)
        {
            color = "pink";
        }
    }
}
