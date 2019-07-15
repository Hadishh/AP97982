using System;
using System.Windows;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.IO;

namespace P1
{
    public class Equation
    {
        /// <summary>
        /// Color on drawing plot.
        ///  Default color is background of DataTetBox.
        /// </summary>
        public Brush Color { get; }
        public Func<double, double> Function { get;  set; }

        //UI Elements 
        public TextBox DataTextBox { get; set; }
        public Button DeleteButton { get; set; }

        public event EventHandler<Equation> DeleteEvent;

        public Equation()
        { 
            #region UI
            DeleteButton = new Button();
            DeleteButton.Margin = new Thickness(3);
            DeleteButton.Content = new Image()
            {
                Source = new BitmapImage(new Uri(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + @"\Images\CrossIcon.png", UriKind.RelativeOrAbsolute))
            };
            DeleteButton.Click += DeleteButton_Click;
            DataTextBox = new TextBox();
            DataTextBox.Foreground = Brushes.Yellow;
            DataTextBox.Margin = new Thickness(3);
            Color = DataTextBox.Background;
            DataTextBox.TextChanged += OnTextChanged_FindFunction;
            DataTextBox.TabIndex = 0;
            #endregion
        }

        #region UIMethods
        /// <summary>
        /// Calls DeleteEvent of this object.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteEvent(sender, this);
        }

        public Grid GetGrid()
        {
            Grid grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(6, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            Grid.SetColumn(DataTextBox, 0);
            Grid.SetColumn(DeleteButton, 1);
            grid.Children.Add(DataTextBox);
            grid.Children.Add(DeleteButton);
            return grid;
        }
        /// <summary>
        /// Find new Function for Equation 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTextChanged_FindFunction(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox)
            {
                try
                {
                    Function = EquationParser.GetDelegate(DataTextBox.Text);
                }
                catch (ArgumentException)
                {
                    Function = null;
                }
                catch
                {
                    throw;
                }
            }
        }
        #endregion
    }
}
