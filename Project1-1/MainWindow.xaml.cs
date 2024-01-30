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


        /// <summary>
        ///  Method HeightBox_TextChanged will make sure that the inputted height is an integer and it's length is greater than 0
        /// </summary>
        /// <param name="sender"> Instance of object that raised the event </param> resource: https://learn.microsoft.com/en-us/dotnet/api/system.eventargs?view=net-8.0&redirectedfrom=MSDN
        /// <param name="e"> Event data </param>
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

        /// <summary>
        /// Method HeightBox_PreviewTextInput will make sure that the inputted height will take only numbers
        /// </summary>
        /// <param name="sender"> Instance of object that raised the event </param>
        /// <param name="e"> Event data </param>
        private void HeightBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !int.TryParse(e.Text, out int result); // Makes sure that inputted height will only take numbers. Resource: TextBook page 9
        }

        /// <summary>
        /// Method AreaBox_TextChanged will make sure that the inputted area is an integer and it's length is greater than 0
        /// </summary>
        /// <param name="sender"> Instance of object that raised the event </param>
        /// <param name="e"> Event data </param>
        private void AreaBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (AreaBox.Text.Length == 0) // This is to make sure that there won't be any errors when the textbox is empty
            {
                return;
            }
            shapeArea = int.Parse(AreaBox.Text); // This is to make sure that the height/text inputted will be an integer
        }

        /// <summary>
        ///  Method AreaBox_PreviewTextInput will make sure that the inputted area will take only numbers
        /// </summary>
        /// <param name="sender"> Instance of object that raised the event </param>
        /// <param name="e"> Event data </param>
        private void AreaBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !int.TryParse(e.Text, out int result); // Makes sure that inputted area will only take numbers. Resource: Textbook page 9
        }

        /// <summary>
        /// Method HeightButton_Click creates the shape when inputting height value
        /// </summary>
        /// <param name="sender"> Instance of object that raised the event </param>
        /// <param name="e"> Event data </param>
        private void HeightButton_Click(object sender, RoutedEventArgs e)
        {
            if (shape == "rectangle")
            {
                Circle1.Visibility = Visibility.Hidden; // If rectangle is chosen, the circle will disappear. Resource: https://learn.microsoft.com/en-us/dotnet/api/system.windows.uielement.visibility?view=windowsdesktop-8.0
                if (shapeHeight == 0) // If the user makes height 0, this message will come out
                {
                    Text1.Text = "Please put something higher than a 0";
                    return;
                }
                defaultArea = 10000; // Preserved area for rectangle
                double rectWidth = defaultArea / shapeHeight; // This is the formula for the rectangle width

                if (shapeHeight > 0 && shapeHeight <= 393 && rectWidth > 0 && rectWidth <= 526) // This is to make sure that the rectangle is not too small and doesn't grow bigger than the main window; 393 and 526 are the largest height and width can be in the main window that pops out on my macbook
                {
                    Text1.Text = "Congratulations, you made a rectangle!"; // If the rectangle has inputted area and heights that are within the boundaries, this text will show
                    Rectangle.Height = shapeHeight; // The rectangle height will change to the inputted height
                    Rectangle.Width = rectWidth; // The rectangle width will change to the calculated width
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
                    Rectangle.Fill = System.Windows.Media.Brushes.Yellow; // Color changes to Yellow                  
                }
                else if (color == "blue")
                {
                    Rectangle.Fill = System.Windows.Media.Brushes.Blue; // Color changes to blue                  
                }
                else if (color == "purple")
                {
                    Rectangle.Fill = System.Windows.Media.Brushes.Purple; // Color changes to purple                  
                }
                else if (color == "black")
                {
                    Rectangle.Fill = System.Windows.Media.Brushes.Black; // Color changes to black               
                }
                else if (color == "pink")
                {
                    Rectangle.Fill = System.Windows.Media.Brushes.Pink; // Color changes to pink               
                }
            }
            else if (shape == "circle")
            {
                Rectangle.Visibility = Visibility.Hidden; // Hides the rectangle when making a circle
                if (shapeHeight == 0) // If the user makes height 0, this message will come out
                {
                    Text1.Text = "Please put something higher than a 0";
                    return;
                }
                defaultArea = 1000; // Preserved area for the circle
                double shapeWidth = 2 * (Math.Sqrt(defaultArea / 3.141592653589793)); // The equation to find 'r'
                if (shapeHeight > 0 && shapeHeight <= 393 && shapeWidth > 0 && shapeWidth < 526) // See line 109, same guidelines for circle
                {
                    Text1.Text = "Congratulations! A circle"; 
                    Circle1.Visibility = Visibility; // Makes the circle visible
                    Circle1.Height = shapeHeight; // The circle height will change to inputted height
                    Circle1.Width = shapeWidth; // The circle width will change to the calculated width
                }
                else
                {
                    {
                        Text1.Text = "ERROR: Area or height may be too large";
                    }
                }

                if (color == "red")
                {
                    Circle1.Fill = System.Windows.Media.Brushes.Red; // Filling in the color red
                }
                else if (color == "yellow")
                {
                    Circle1.Fill = System.Windows.Media.Brushes.Yellow; // Filling in the color yellow
                }
                else if (color == "blue")
                {
                    Circle1.Fill = System.Windows.Media.Brushes.Blue; // Color changes to blue                  
                }
                else if (color == "purple")
                {
                    Circle1.Fill = System.Windows.Media.Brushes.Purple; // Color changes to purple                  
                }
                else if (color == "black")
                {
                   Circle1.Fill = System.Windows.Media.Brushes.Black; // Color changes to black               
                }
                else if (color == "pink")
                {
                    Circle1.Fill = System.Windows.Media.Brushes.Pink; // Color changes to pink               
                }
            }
            else if (shape == "square")
            {
                Circle1.Visibility = Visibility.Hidden; // Hides the circle 
                if (shapeHeight == 0) // If the user makes height 0, this message will come out
                {
                    Text1.Text = "Please put something higher than a 0";
                    return;
                }

                if (shapeHeight > 0 && shapeHeight <= 393) // This is to make sure that the square is not too small and doesn't grow bigger than the main window; 393 is the largest the height and width can be in the main window that pops out on my macbook
                {
                    Text1.Text = "Congratulations, you made a square!";
                    Rectangle.Height = shapeHeight; // The square height will change to the inputted height
                    Rectangle.Width = Rectangle.Height; // The square width will change to the inputted height
                    Rectangle.Visibility = Visibility; // Allows the square to be visible
                }
                else
                {
                    Text1.Text = "ERROR: Area or height may be too large";
                }

                if (color == "red")
                {
                    Rectangle.Fill = System.Windows.Media.Brushes.Red; // Filling in the color Red                 
                }
                else if (color == "yellow")
                {
                    Rectangle.Fill = System.Windows.Media.Brushes.Yellow; // Filling in the color Yellow
                }
                else if (color == "blue")
                {
                    Rectangle.Fill = System.Windows.Media.Brushes.Blue; // Color changes to blue                  
                }
                else if (color == "purple")
                {
                    Rectangle.Fill = System.Windows.Media.Brushes.Purple; // Color changes to purple                  
                }
                else if (color == "black")
                {
                    Rectangle.Fill = System.Windows.Media.Brushes.Black; // Color changes to black               
                }
                else if (color == "pink")
                {
                    Rectangle.Fill = System.Windows.Media.Brushes.Pink; // Color changes to pink               
                }
            }
        }

        /// <summary>
        ///  Method AreaButton2_Click creates the shape when inputting area value
        /// </summary>
        /// <param name="sender"> Instance of object that raised the event </param>
        /// <param name="e"> Event data </param>
        private void AreaButton2_Click(object sender, RoutedEventArgs e)
        {
            if (shape == "rectangle")
            {
                Circle1.Visibility = Visibility.Hidden; // M akes the circle invisible when forming a rectangle
                if (shapeArea == 0) // If the user makes the area 0, this message will come out
                {
                    Text1.Text = "Please put something higher than a 0";
                }

                double rectWidth = shapeArea / shapeHeight;
                if (shapeHeight > 0 && shapeHeight <= 393 && rectWidth > 0 && rectWidth <= 526) // This is to make sure that the rectangle is not too small and doesn't grow bigger than the main window; 393 and 526 are the largest height and width can be in the main window that pops out on my macbook
                {
                    Text1.Text = "Congratulations, you made a rectangle!"; // If the rectangle has inputted area and heights that are within the boundaries, this text will show
                    Rectangle.Height = shapeHeight; // The rectangle height will change to the inputted height
                    Rectangle.Width = rectWidth; // The rectangle width will change to the calculated width
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
                    Rectangle.Fill = System.Windows.Media.Brushes.Blue; // Color changes to blue                  
                }
                else if (color == "purple")
                {
                    Rectangle.Fill = System.Windows.Media.Brushes.Purple; // Color changes to purple                  
                }
                else if (color == "black")
                {
                    Rectangle.Fill = System.Windows.Media.Brushes.Black; // Color changes to black               
                }
                else if (color == "pink")
                {
                    Rectangle.Fill = System.Windows.Media.Brushes.Pink; // Color changes to pink               
                }
            }
            else if (shape == "circle")
            {
                Rectangle.Visibility = Visibility.Hidden;
                if (shapeArea == 0) // If the user makes the area 0, this message will come out
                {
                    Text1.Text = "Please put something higher than a 0";
                }
                double shapeWidth = 2 * (Math.Sqrt(shapeArea / 3.141592653589793)); // The equation for 'r'
                if (shapeHeight > 0 && shapeHeight <= 393 && shapeWidth > 0 && shapeWidth < 526) // // See line 109, same guidelines for circle
                {
                    Text1.Text = "Congratulations! A circle";
                    Circle1.Visibility = Visibility; // Allows the circle to become visible
                    Circle1.Height = shapeHeight; // Circle height becomes the inputted height
                    Circle1.Width = shapeWidth; // Circle width becomes the calculated width
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
                    Circle1.Fill = System.Windows.Media.Brushes.Blue; // Color changes to blue                  
                }
                else if (color == "purple")
                {
                    Circle1.Fill = System.Windows.Media.Brushes.Purple; // Color changes to purple                  
                }
                else if (color == "black")
                {
                    Circle1.Fill = System.Windows.Media.Brushes.Black; // Color changes to black               
                }
                else if (color == "pink")
                {
                    Circle1.Fill = System.Windows.Media.Brushes.Pink; // Color changes to pink               
                }
            }
            else if (shape == "square")
            {
                Circle1.Visibility = Visibility.Hidden; // Hides the circle
                if (shapeHeight == 0)
                {
                    Text1.Text = "Please put something higher than a 0";
                    return;
                }
                double height = Math.Sqrt(shapeArea); // Creating variable height in relation to the square's area
                if (shapeArea > 0 && shapeArea <= 393*393) // This is to make sure that the square is not too small and doesn't grow bigger than the main window; 393 is the largest the height and width can be in the main window that pops out on my macbook
                {
                    Text1.Text = "Congratulations, you made a square!";
                    Rectangle.Height = height; // Height will be the square root of the square's height
                    Rectangle.Width = Rectangle.Height; // Width is equal to height
                    Rectangle.Visibility = Visibility; // Rectangle becomes visible
                }
                else
                {
                    Text1.Text = "ERROR: Area or height may be too large";
                }

                if (color == "red")
                {
                    Rectangle.Fill = System.Windows.Media.Brushes.Red; // Filling in the color Red                 
                }
                else if (color == "yellow")
                {
                    Rectangle.Fill = System.Windows.Media.Brushes.Yellow; // Filling in the color Yellow
                }
                else if (color == "blue")
                {
                    Rectangle.Fill = System.Windows.Media.Brushes.Blue; // Color changes to blue                  
                }
                else if (color == "purple")
                {
                    Rectangle.Fill = System.Windows.Media.Brushes.Purple; // Color changes to purple                  
                }
                else if (color == "black")
                {
                    Rectangle.Fill = System.Windows.Media.Brushes.Black; // Color changes to black               
                }
                else if (color == "pink")
                {
                    Rectangle.Fill = System.Windows.Media.Brushes.Pink; // Color changes to pink               
                }
            }

        }

        /// <summary>
        /// Method Rect_Click allows you to choose a rectangle
        /// </summary>
        /// <param name="sender"> Instance of object that raised the event </param>
        /// <param name="e"> Event data </param>
        private void Rect_Click(object sender, RoutedEventArgs e)
        {
            shape = "rectangle";
        }

        /// <summary>
        /// Method Circle_Click allows you to choose a circle
        /// </summary>
        /// <param name="sender"> Instance of object that raised the event </param>
        /// <param name="e"> Event data </param>
        private void Circle_Click(object sender, RoutedEventArgs e)
        {
            shape = "circle";
        }

        /// <summary>
        /// Method Square_Click allows you to choose a sqaure
        /// </summary>
        /// <param name="sender"> Instance of object that raised the event </param>
        /// <param name="e"> Event data </param>
        private void Square_Click(object sender, RoutedEventArgs e)
        {
            shape = "square";
        }

        /// <summary>
        /// Method Red_Click allows you to fill the shape red
        /// </summary>
        /// <param name="sender"> Instance of object that raised the event </param>
        /// <param name="e"> Event data </param>
        private void Red_Click(object sender, RoutedEventArgs e)
        {
            color = "red";
        }

        /// <summary>
        /// Method Yellow_Click allows you to fill the shape yellow
        /// </summary>
        /// <param name="sender"> Instance of object that raised the event </param>
        /// <param name="e"> Event data </param>
        private void Yellow_Click(object sender, RoutedEventArgs e)
        {
            color = "yellow";
        }

        /// <summary>
        /// Method Blue_Click allows you to fill the shape blue
        /// </summary>
        /// <param name="sender"> Instance of object that raised the event </param>
        /// <param name="e"> Event data </param>
        private void Blue_Click(object sender, RoutedEventArgs e)
        {
            color = "blue";
        }

        /// <summary>
        /// Method Purple_Click allows you to fill the shape purple
        /// </summary>
        /// <param name="sender"> Instance of object that raised the event </param>
        /// <param name="e"> Event data </param>
        private void Purple_Click(object sender, RoutedEventArgs e)
        {
            color = "purple";
        }

        /// <summary>
        /// Method Black_Click allows you to fill the shape black
        /// </summary>
        /// <param name="sender"> Instance of object that raised the event </param>
        /// <param name="e"> Event data </param>
        private void Black_Click(object sender, RoutedEventArgs e)
        {
            color = "black";
        }

        /// <summary>
        /// Method Pink_Click allows you to fill the shape pink
        /// </summary>
        /// <param name="sender"> Instance of object that raised the event </param>
        /// <param name="e"> Event data </param>
        private void Pink_Click(object sender, RoutedEventArgs e)
        {
            color = "pink";
        }
    }
}
