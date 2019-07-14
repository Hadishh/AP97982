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
            Equation newEquation = new Equation();
            //TextBox Properties
            newEquation.DataTextBox.TextChanged += OnTextChanged_AddEquation;
            newEquation.DataTextBox.Background = AvailableColors[CurrentColorIndex];
            //Event Properties
            newEquation.DeleteEvent += Equation_DeleteEvent;
            MainStack.Children.Add(newEquation.GetGrid());
            Equations.Add(newEquation);
            CurrentColorIndex = ++CurrentColorIndex >= AvailableColors.Count ? 0 : CurrentColorIndex;
        }
        
        /// <summary>
        /// this event show us which class send event and if conditions satisfies then delete it 
        /// in this case we don't need to implement Equal for EquationUI Because we need refrence
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ChoosedClass"></param>
        private void Equation_DeleteEvent(object sender, Equation ChoosedClass)
        {
            if (!(sender is Button))
                throw new ArgumentException();
            Grid myGrid = new Grid();
            UIElementCollection allElements = MainStack.Children;
            foreach(var grid in allElements)
            {
                if (grid is Grid)
                    if ((grid as Grid).Children.Contains(sender as Button))
                        myGrid = grid as Grid;
            }
            if (MainStack.Children.Count < 2  || allElements.IndexOf(myGrid) == allElements.Count - 1)
                MessageBox.Show("Cannot Delete This Field!", "Error");
            else
            {
                MainStack.Children.Remove(myGrid);
                Equations.Remove(ChoosedClass);
            }
        }

        /// <summary>
        /// This event fo making another new textbox 
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
