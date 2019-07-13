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
        public List<AroundPoint> Dots { get; set; }
        private Canvas ParentCanvas { get; set; } 
        public Clock(Canvas parent, double radius)
        {
            ParentCanvas = parent;
            Radius = radius;
            Center = new Point(parent.ActualWidth / 2, parent.ActualHeight / 2);
            Dots = new List<AroundPoint>();
            for(int i = 0; i < 60; i += 5)
            {
                Dots.Add(new AroundPoint(PositionOnClock(i, Radius), 5));
            }
        }

        public void RenderTime(DateTime time)
        {
            ParentCanvas.Children.Clear();
            SecondHand = new Hand(Center,PositionOnClock(time.Second, Radius));
            SecondHand.HandLine.Stroke = Brushes.Red;
            MinutesHand = new Hand(Center, PositionOnClock(time.Minute, Radius));
            HoursHand = new Hand(Center, PositionOnClock(time.Hour * 5  + time.Minute / 12.0, 3 * Radius / 4));
            Draw();
        }

        public void Draw()
        {
            ParentCanvas.Children.Add(SecondHand.GetUI());
            ParentCanvas.Children.Add(MinutesHand.GetUI());
            ParentCanvas.Children.Add(HoursHand.GetUI());
            foreach(IUserInterface item in Dots)
            {
                ParentCanvas.Children.Add(item.GetUI());
            }
        }
        private Point PositionOnClock(double seconds, double length)
        {
            double teta = (seconds / 30.0) * Math.PI;
            double X = Center.X + length * Math.Sin(teta);
            double Y = Center.Y - length * Math.Cos(teta);
            return new Point(X, Y);
        }

    }
}
