using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;

namespace P1
{
    public class EquationUI 
    {
        public TextBox DataTextBox { get; set; }
        public Button DeleteButton { get; set; }

        public event EventHandler<EquationUI> DeleteEvent;
        public EquationUI()
        {
            DeleteButton = new Button();
            DeleteButton.Margin = new Thickness(3);
            DeleteButton.Content = new Image() {
                Source = new BitmapImage(new Uri(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + @"\Images\CrossIcon.png", UriKind.RelativeOrAbsolute))
            };
            DeleteButton.Click += DeleteButton_Click;
            DataTextBox = new TextBox();
            DataTextBox.Foreground = Brushes.Yellow;
            DataTextBox.Margin = new Thickness(3);
            DataTextBox.TextChanged += OnTextChanged_DrawEquation;
            DataTextBox.TabIndex = 0;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteEvent(sender, this);
        }

        public Grid GetGrid()
        {
            Grid classGrid = new Grid();
            classGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(6, GridUnitType.Star) });
            classGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            Grid.SetColumn(DataTextBox, 0);
            Grid.SetColumn(DeleteButton, 1);
            classGrid.Children.Add(DataTextBox);
            classGrid.Children.Add(DeleteButton);
            return classGrid;
        }
        /// <summary>
        /// Gives the list of separated functions for converting to delegate
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static List<string> GetSeparatedEquations(string text)
        {
            List<string> results = new List<string>();
            foreach (var item in text.Split(new char[] { '+', '-' }))
                results.Add(item.Replace(" ", string.Empty));
            return results;
        }
        private void OnTextChanged_DrawEquation(object sender, TextChangedEventArgs e)
        {
            //Draw
            if (sender is TextBox)
                return;
        }
    }
}
