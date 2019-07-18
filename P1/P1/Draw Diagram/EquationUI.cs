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
    public class EquationUI : Equation
    {
        //UI Elements 
        public TextBox DataTextBox { get; set; }
        public Button DeleteButton { get; set; }

        public event EventHandler<EquationUI> Delete;
        public event EventHandler<Equation> Draw;

        public EquationUI()
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
            DataTextBox.TextChanged += DataTextBox_Draw;
            Color = DataTextBox.Background;
            DataTextBox.TabIndex = 0;
            #endregion
        }
        /// <summary>
        /// when Text changed draw equation again by sendig event to equation handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataTextBox_Draw(object sender, TextChangedEventArgs e)
        {
            UpdateFunction();
            this.Color = DataTextBox.Background;
            Draw(sender, this);
        }

        #region UIMethods
        /// <summary>
        /// Calls DeleteEvent of this object.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Delete(sender, this);
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
        #endregion
        /// <summary>
        /// Finds new function for equation 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void UpdateFunction()
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
}
