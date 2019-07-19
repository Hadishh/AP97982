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
        private StackPanel EquationListStack { get; set; }


        private List<Brush> AvailableColors = new List<Brush> {
            new SolidColorBrush(Colors.Black) {Opacity = 0.5 },
            new SolidColorBrush(Colors.Blue) { Opacity = 0.5 },
            new SolidColorBrush(Colors.Red) { Opacity = 0.5 },
            new SolidColorBrush(Colors.Green) {Opacity = 0.5 },
            new SolidColorBrush(Colors.Magenta) {Opacity = 0.5 }
        };
        private int CurrentColorIndex;
        public List<EquationUI> Equations { get; private set; }
        public event EventHandler<Equation> DrawChart;
        public event EventHandler<Equation> DeleteChart;
        /// <summary>
        /// EquationHandler handles adding and removing equations,
        /// </summary>
        /// <param name="eqationListStack"></param>
        public EquationHandler(StackPanel eqationListStack)
        {
            EquationListStack = eqationListStack;
            EquationListStack.Children.Clear();
            Equations = new List<EquationUI>();
            AddEquation();
            CurrentColorIndex = 1;
        }
        /// <summary>
        /// Creats an equation and add it to equation list.
        /// Adds grid of Equation to stack panel.
        /// </summary>
        public void AddEquation()
        {
            EquationUI newEquation = new EquationUI();
            //TextBox Properties
            newEquation.DataTextBox.TextChanged += OnTextChanged_AddEquation;
            newEquation.DataTextBox.Background = AvailableColors[CurrentColorIndex];
            //Event Properties
            newEquation.Delete += Equation_DeleteEvent;
            newEquation.Draw += NewEquation_Draw;
            EquationListStack.Children.Add(newEquation.GetGrid());
            Equations.Add(newEquation);
            CurrentColorIndex = ++CurrentColorIndex >= AvailableColors.Count ? 0 : CurrentColorIndex;
        }
        /// <summary>
        /// Calls draw event to send event to draw diagram for drawing new equation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewEquation_Draw(object sender, Equation e)
        {
            DrawChart(sender, e);
        }

        /// <summary>
        /// If conditions satisfies then remove equation from list and calls DeleteChart event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ChoosedClass"></param>
        private void Equation_DeleteEvent(object sender, EquationUI ChoosedClass)
        {
            if (!(sender is Button))
                throw new ArgumentException();
            Grid myGrid = new Grid();
            UIElementCollection allElements = EquationListStack.Children;
            foreach(var grid in allElements)
            {
                if (grid is Grid)
                    if ((grid as Grid).Children.Contains(sender as Button))
                        myGrid = grid as Grid;
            }
            if (EquationListStack.Children.Count < 2  || allElements.IndexOf(myGrid) == allElements.Count - 1)
                MessageBox.Show("Cannot Delete This Field!", "Error");
            else
            {
                EquationListStack.Children.Remove(myGrid);
                Equations.Remove(ChoosedClass);
                DeleteChart(this, ChoosedClass);
            }
        }

        /// <summary>
        /// Makes new text box on equation list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTextChanged_AddEquation(object sender, TextChangedEventArgs e)
        {
            if (Equations.Last().DataTextBox.Text != string.Empty)
                AddEquation();
        }
        /// <summary>
        /// Destroy every thing in main stack.
        /// </summary>
        public void Destroy()
        {
            EquationListStack.Children.Clear();
            Equations.Clear();
            Equations = null;
            EquationListStack = null;
        }
    }
}
