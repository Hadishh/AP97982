using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace P1
{
    class EquationHandler
    {
        private StackPanel MainStack { get; }
        public List<TextBox> Equations { get; }
        private List<Brush> AvailableColors = new List<Brush> {
            new SolidColorBrush(Colors.Black) {Opacity = 0.5 },
            new SolidColorBrush(Colors.Blue) { Opacity = 0.5 },
            new SolidColorBrush(Colors.Red) { Opacity = 0.5 },
            new SolidColorBrush(Colors.Green) {Opacity = 0.5 },
            new SolidColorBrush(Colors.Magenta) {Opacity = 0.5 }
        };
        private int CurrentColorIndex;
        public EquationHandler(StackPanel mainStack)
        {
            MainStack = mainStack;
            Equations = new List<TextBox>();
            AddEquation();
            CurrentColorIndex = 1;
        }
        public void AddEquation()
        {
            Grid newGrid = new Grid();
            newGrid.ColumnDefinitions.Add(new ColumnDefinition());
            TextBox newText = new TextBox();
            newText.TextChanged += OnTextChanged; 
            newText.Background = AvailableColors[CurrentColorIndex];

            newText.Foreground = Brushes.Yellow;
            newText.Margin = new Thickness(3);
            MainStack.Children.Add(newText);
            Equations.Add(newText);
            CurrentColorIndex = ++CurrentColorIndex >= AvailableColors.Count ? 0 : CurrentColorIndex;
        }
        /// <summary>
        /// This event fo making another text box and drawing new graph if equation changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox)
            {
                TextBox changedTextBox = sender as TextBox;
                //Draw Equation
            }
            if (Equations.Last().Text != string.Empty)
                AddEquation();
        }

    }
}
