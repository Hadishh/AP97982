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
    class Taylor
    {
        PlottingSpace PlottingSpace { get; set; }
        TaylorEquation TaylorEquation { get; set; }
        Equation Equation { get; set; }
        MainWindow MainWindow { get; set; }
        public Taylor(int n, double x0, MainWindow mainWindow)
        {
            Equation = new Equation();
            Equation.Color = Brushes.Red;
            Equation.Function = Math.Sin;
            TaylorEquation = new TaylorEquation(n, x0, Equation.Function);
            MainWindow = mainWindow;
            MainWindow.TaylorDrawingCanvas.Loaded += TaylorDrawingCanvas_Loaded;
        }

        private void TaylorDrawingCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            SetPlottingSpace(MainWindow.TaylorDrawingCanvas);
        }

        private void SetPlottingSpace(Canvas drawingCanvas)
        {
            double x = FindXBound();
            PlottingSpace = new PlottingSpace((-x, x), (-2, 2), drawingCanvas, 1);
            PlottingSpace.DrawGrid();
            PlottingSpace.DrawEquation(Equation);
            PlottingSpace.DrawEquation(TaylorEquation);
        }
        private double FindXBound()
        {
            double x = 0;
            while (Math.Abs(TaylorEquation.Function(x) - Math.Sin(x)) < 0.01)
                x += 0.1;
            return 2*x;
        }
        public void Destroy()
        {
            PlottingSpace.Destroy();
            MainWindow.TaylorDrawingCanvas.Loaded -= TaylorDrawingCanvas_Loaded;
        }
    }
}
