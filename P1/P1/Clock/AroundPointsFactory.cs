using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace P1
{
    /// <summary>
    /// Around Points Factory Pattern
    /// </summary>
    public static class AroundPreviewFactory
    {
        const double Ratio = ClockFactory.Ratio;
        public static List<AroundPoint> LinesWithShortLines(Canvas clockCanvas, double length)
        {
            List<AroundPoint> aroundPoints = new List<AroundPoint>();
            Point Center = new Point(clockCanvas.ActualWidth / 2, clockCanvas.ActualHeight / 2);
            int j = 1;
            for (double teta = Math.PI / 6; teta <= 2 * Math.PI + Math.PI / 6; teta += Math.PI / 6, j++)
            {
                aroundPoints.Add(new Lines(new Point(Center.X + Ratio * Math.Sin(teta), Center.Y - Ratio * Math.Cos(teta)), 2, teta, length * 2, j.ToString()));
                for (int i = 1; i <= 4; i++)
                    aroundPoints.Add(new Lines(new Point(Center.X + Ratio * Math.Sin(teta + i * Math.PI / 30), Center.Y - Ratio * Math.Cos(teta + i * Math.PI / 30)),
                        2, teta + i * Math.PI / 30, length));
            }
            return aroundPoints;
        }
        public static List<AroundPoint> Lines(Canvas clockCanvas, int size, double length)
        {
            List<AroundPoint> aroundPoints = new List<AroundPoint>();
            Point Center = new Point(clockCanvas.ActualWidth / 2, clockCanvas.ActualHeight / 2);
            int j = 12 / size;
            for (double teta = 2 * Math.PI / size; teta < 2 * Math.PI + 2 * Math.PI / size; teta += 2 * Math.PI / size, j += 12 / size)
                aroundPoints.Add(new Lines(new Point(Center.X + Ratio * Math.Sin(teta), Center.Y - Ratio * Math.Cos(teta)), 2, teta, length, j.ToString()));
            return aroundPoints;
        }
        public static List<AroundPoint> Dots(Canvas clockCanvas, int size, double radius)
        {
            List<AroundPoint> aroundPoints = new List<AroundPoint>();
            Point Center = new Point(clockCanvas.ActualWidth / 2, clockCanvas.ActualHeight / 2);
            int j = 12 / size;
            for (double teta =  2 * Math.PI / size; teta < 2 * Math.PI + 2 * Math.PI / size; teta += 2 * Math.PI / size, j += 12 / size)
                aroundPoints.Add(new Dots(new Point(Center.X + Ratio * Math.Sin(teta), Center.Y - Ratio * Math.Cos(teta)), radius, teta, j.ToString()));
            return aroundPoints;
        }
        public static List<AroundPoint> DotsWithSmallDots(Canvas clockCanvas, double radius)
        {
            List<AroundPoint> aroundPoints = new List<AroundPoint>();
            Point Center = new Point(clockCanvas.ActualWidth / 2, clockCanvas.ActualHeight / 2);
            int j = 1;
            for (double teta = Math.PI / 6; teta <= 2 * Math.PI + Math.PI / 6; teta += Math.PI / 6, j++)
            {
                aroundPoints.Add(new Dots(new Point(Center.X + Ratio * Math.Sin(teta), Center.Y - Ratio * Math.Cos(teta)), 2*radius, teta, j.ToString()));
                for (int i = 1; i <= 4; i++)
                    aroundPoints.Add(new Lines(new Point(Center.X + Ratio * Math.Sin(teta + i * Math.PI / 30), Center.Y - Ratio * Math.Cos(teta + i * Math.PI / 30)),
                        2, teta + i * Math.PI / 30, radius));
            }
            return aroundPoints;
        }
    }
}
