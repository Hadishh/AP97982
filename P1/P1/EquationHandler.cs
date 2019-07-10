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
            Brushes.Black,
            Brushes.Blue,
            Brushes.Red,
            Brushes.Green,
            Brushes.Magenta
        };
        private int CurrentColorIndex;
        public EquationHandler(StackPanel mainStack)
        {
            MainStack = mainStack;
            AddEquation();
            CurrentColorIndex = 1;
        }
        public void AddEquation()
        {
            TextBox newText = new TextBox();
            newText.Background = AvailableColors[CurrentColorIndex];
            MainStack.Children.Add(newText);
            CurrentColorIndex = ++CurrentColorIndex > 4 ? 0 : CurrentColorIndex;
        }
    }
}
