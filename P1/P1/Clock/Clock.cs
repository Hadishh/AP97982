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
    public class Clock : IDrawable
    {
        public double Radius { get; set; }
        public Hand SecondHand { get; set; }
        public Hand MinutesHand { get; set; }
        public Hand HoursHand { get; set; }
        public Point Center { get; set; }
        public Shape Around { get; set; }
        private Canvas ParentCanvas { get; set; } 
        public Clock(Canvas parent, double radius, Shape shape)
        {
            Around = shape;
            ParentCanvas = parent;
            Radius = radius;
            Center = new Point(parent.ActualWidth / 2, parent.ActualHeight / 2);
        }
       /// <summary>
       /// renders time input.
       /// </summary>
       /// <param name="time"></param>
        public void RenderTime(DateTime time)
        {
            ParentCanvas.Children.Clear();
            SecondHand = new Hand(Center,PositionOnClock(time.Second, Radius));
            SecondHand.HandLine.Stroke = Brushes.Red;
            SecondHand.HandLine.StrokeThickness = 1;
            MinutesHand = new Hand(Center, PositionOnClock(time.Minute, Radius));
            HoursHand = new Hand(Center, PositionOnClock(time.Hour * 5  + time.Minute / 12.0, 3 * Radius / 4));
            Draw();
        }
        /// <summary>
        /// draw each element in canvas and shows the clock
        /// </summary>
        public void Draw()
        {
            ParentCanvas.Children.Add(SecondHand.GetUI());
            ParentCanvas.Children.Add(MinutesHand.GetUI());
            ParentCanvas.Children.Add(HoursHand.GetUI());
            Around.Draw();
        }
        /// <summary>
        /// returns positon on clock
        /// </summary>
        /// <param name="seconds"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        private Point PositionOnClock(double seconds, double length)
        {
            double teta = (seconds / 30.0) * Math.PI;
            double X = Center.X + length * Math.Sin(teta);
            double Y = Center.Y - length * Math.Cos(teta);
            return new Point(X, Y);
        }

    }
}
