using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace P1
{
    public static class AroundPreviewFactory
    {
        const double Ratio = ClockFactory.Ratio;
        public static List<AroundPoint> LinesWithShortLines(MainWindow mainWindow, double length)
        {
            List<AroundPoint> aroundPoints = new List<AroundPoint>();
            Point Center = new Point(mainWindow.ClockCanvas.ActualWidth / 2, mainWindow.ClockCanvas.ActualHeight / 2);
            for (double teta = 0; teta < 2 * Math.PI; teta += Math.PI / 6)
            {
                aroundPoints.Add(new Lines(new Point(Center.X + Ratio * Math.Sin(teta), Center.Y - Ratio * Math.Cos(teta)), 2, teta, length * 2));
                for (int i = 1; i <= 4; i++)
                    aroundPoints.Add(new Lines(new Point(Center.X + Ratio * Math.Sin(teta + i * Math.PI / 30), Center.Y - Ratio * Math.Cos(teta + i * Math.PI / 30)),
                        2, teta + i * Math.PI / 30, length));
            }
            return aroundPoints;
        }
        public static List<AroundPoint> Lines(MainWindow mainWindow, int size, double length)
        {
            List<AroundPoint> aroundPoints = new List<AroundPoint>();
            Point Center = new Point(mainWindow.ClockCanvas.ActualWidth / 2, mainWindow.ClockCanvas.ActualHeight / 2);
            for (double teta = 0; teta < 2 * Math.PI; teta += 2 * Math.PI / size)
                aroundPoints.Add(new Lines(new Point(Center.X + Ratio * Math.Sin(teta), Center.Y - Ratio * Math.Cos(teta)), 2, teta, length));
            return aroundPoints;
        }
        public static List<AroundPoint> Dots(MainWindow mainWindow, int size, double radius)
        {
            List<AroundPoint> aroundPoints = new List<AroundPoint>();
            Point Center = new Point(mainWindow.ClockCanvas.ActualWidth / 2, mainWindow.ClockCanvas.ActualHeight / 2);
            for (double teta = 0; teta < 2 * Math.PI; teta += 2 * Math.PI / size)
                aroundPoints.Add(new Dots(new Point(Center.X + Ratio * Math.Sin(teta), Center.Y - Ratio * Math.Cos(teta)), radius, teta));
            return aroundPoints;
        }
        public static List<AroundPoint> DotsWithSmallDots(MainWindow mainWindow, double radius)
        {
            List<AroundPoint> aroundPoints = new List<AroundPoint>();
            Point Center = new Point(mainWindow.ClockCanvas.ActualWidth / 2, mainWindow.ClockCanvas.ActualHeight / 2);
            for (double teta = 0; teta < 2 * Math.PI; teta += Math.PI / 6)
            {
                aroundPoints.Add(new Dots(new Point(Center.X + Ratio * Math.Sin(teta), Center.Y - Ratio * Math.Cos(teta)), 2*radius, teta));
                for (int i = 1; i <= 4; i++)
                    aroundPoints.Add(new Lines(new Point(Center.X + Ratio * Math.Sin(teta + i * Math.PI / 30), Center.Y - Ratio * Math.Cos(teta + i * Math.PI / 30)),
                        2, teta + i * Math.PI / 30, radius));
            }
            return aroundPoints;
        }
    }
}
