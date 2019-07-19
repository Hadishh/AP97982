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
        double X0 { get; set; }
        public Taylor(int n, double x0, MainWindow mainWindow)
        {
            Equation = new Equation();
            Equation.Color = Brushes.Red;
            Equation.Function = Math.Sin;
            X0 = x0;
            TaylorEquation = new TaylorEquation(n, X0, Equation.Function);
            MainWindow = mainWindow;
            SetPlottingSpace(MainWindow.TaylorDrawingCanvas);
        }
        /// <summary>
        /// creates a plotting space
        /// </summary>
        /// <param name="drawingCanvas"></param>
        public void SetPlottingSpace(Canvas drawingCanvas)
        {
            double x = FindXBound();
            PlottingSpace = new PlottingSpace((-x, x), (-10, 10), drawingCanvas, 1);
            PlottingSpace.DrawGrid();
            PlottingSpace.DrawEquation(Equation);
            PlottingSpace.DrawEquation(TaylorEquation);
        }
        /// <summary>
        /// find x bound as said in doc.
        /// </summary>
        /// <returns></returns>
        private double FindXBound()
        {
            double x = X0;
            while (Math.Abs(TaylorEquation.Function(x) - Math.Sin(x)) < 0.01)
                x += 0.1;
            return 2*x;
        }
        public void Destroy()
        {
            PlottingSpace.Destroy();
        }
    }
}
