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
    public class EquationHandler
    {
        private StackPanel MainStack { get; }
        public List<Equation> Equations { get; }
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
            Equations = new List<Equation>();
            AddEquation();
            CurrentColorIndex = 1;
        }
        /// <summary>
        /// Creats an equation and add it to equation list
        /// add Grid of Equation to stack panel
        /// </summary>
        public void AddEquation()
        {
            Grid newGrid = new Grid();
            newGrid.ColumnDefinitions.Add(new ColumnDefinition());
            Equation newEquation = new Equation();
            newEquation.DataTextBox.TextChanged += OnTextChanged_AddEquation;
            newEquation.DataTextBox.Background = AvailableColors[CurrentColorIndex];
            MainStack.Children.Add(newEquation.GetGrid());
            Equations.Add(newEquation);
            CurrentColorIndex = ++CurrentColorIndex >= AvailableColors.Count ? 0 : CurrentColorIndex;
        }
        /// <summary>
        /// This event fo making another text box and drawing new graph if equation changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTextChanged_AddEquation(object sender, TextChangedEventArgs e)
        {
            if (Equations.Last().DataTextBox.Text != string.Empty)
                AddEquation();
        }

    }
}
