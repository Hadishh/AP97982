using System;
using System.Windows;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1
{
    public class Equation : IDrawable
    {
        (double Min, double Max)  XBounds = (0, 0);
        (double Min, double Max) YBounds = (0, 0);
        string EquationData { get; set; }
        public Func<double, double> Function { get; private set; }
        public Equation(string data, ValueTuple<double, double> xBounds, ValueTuple<double, double> yBounds)
        {
            XBounds = xBounds;
            YBounds = yBounds;
            try
            {
                Function = EquationParser.GetDelegate(EquationData);
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
        public void Draw()
        {
            
        }
    }
}
