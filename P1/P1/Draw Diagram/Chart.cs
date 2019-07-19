using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace P1
{
    public class Chart
    {
        public List<Ellipse> Ellipses { get; set; }
        public Polyline Polyline { get; set; }
        public Chart(double thickness, Brush color) {
            Ellipses = new List<Ellipse>();
            Polyline = new Polyline()
            {
                Stroke = color,
                StrokeThickness = thickness                
            };
            Polyline.Points = new PointCollection();
        }
        /// <summary>
        /// Deletes chart from canvas with ellipses.
        /// </summary>
        /// <param name="parentCanvas"></param>
        public void Delete(Canvas parentCanvas)
        {
            foreach (var item in Ellipses)
                parentCanvas.Children.Remove(item);
            parentCanvas.Children.Remove(Polyline);
        }
        /// <summary>
        /// Draws chart pn canvas with ellipses.
        /// </summary>
        /// <param name="parentCanvas"></param>
        public void Draw(Canvas parentCanvas)
        {
            foreach (var item in Ellipses)
                parentCanvas.Children.Add(item);
            parentCanvas.Children.Add(Polyline);
        }
    }
}
