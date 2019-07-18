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
    public static class ClockFactory
    {
        public const double Ratio = 80;
        public static Clock SquareWithFourLinesWithoutLabel(MainWindow mainWindow)
                => new Clock (mainWindow.ClockCanvas, Ratio, 
                    new Square(Ratio, mainWindow.ClockCanvas, AroundPreviewFactory.Lines(mainWindow,4, 8)));
        public static Clock SquareWithTwelveLinesWithoutLabel(MainWindow mainWindow)
            => new Clock(mainWindow.ClockCanvas, Ratio,
                    new Square(Ratio, mainWindow.ClockCanvas, AroundPreviewFactory.Lines(mainWindow, 12, 8)));
        public static Clock SquareWithSixtyLinesWithoutLabel(MainWindow mainWindow)
            => new Clock(mainWindow.ClockCanvas, Ratio,
                    new Square(Ratio, mainWindow.ClockCanvas, AroundPreviewFactory.LinesWithShortLines(mainWindow, 4)));
        public static Clock SquareWithFourDotsWithoutLabel(MainWindow mainWindow)
            => new Clock(mainWindow.ClockCanvas, Ratio,
                    new Square(Ratio, mainWindow.ClockCanvas, AroundPreviewFactory.Dots(mainWindow, 4, 4)));
        public static Clock SquareWithTwelveDotsWithoutLabel(MainWindow mainWindow)
            => new Clock(mainWindow.ClockCanvas, Ratio,
                    new Square(Ratio, mainWindow.ClockCanvas, AroundPreviewFactory.Dots(mainWindow, 12, 4)));
        public static Clock SquareWithSixtyDotsWithoutLabel(MainWindow mainWindow)
            => new Clock(mainWindow.ClockCanvas, Ratio,
                    new Square(Ratio, mainWindow.ClockCanvas, AroundPreviewFactory.DotsWithSmallDots(mainWindow, 2)));
        public static Clock CircleWithFourLinesWithoutLabel(MainWindow mainWindow)
                => new Clock(mainWindow.ClockCanvas, Ratio,
                    new Circle(Ratio, mainWindow.ClockCanvas, AroundPreviewFactory.Lines(mainWindow, 4, 8)));
        public static Clock CircleWithTwelveLinesWithoutLabel(MainWindow mainWindow)
            => new Clock(mainWindow.ClockCanvas, Ratio,
                    new Circle(Ratio, mainWindow.ClockCanvas, AroundPreviewFactory.Lines(mainWindow, 12, 8)));
        public static Clock CircleWithSixtyLinesWithoutLabel(MainWindow mainWindow)
            => new Clock(mainWindow.ClockCanvas, Ratio,
                    new Circle(Ratio, mainWindow.ClockCanvas, AroundPreviewFactory.LinesWithShortLines(mainWindow, 4)));
        public static Clock CircleWithFourDotsWithoutLabel(MainWindow mainWindow)
            => new Clock(mainWindow.ClockCanvas, Ratio,
                    new Circle(Ratio, mainWindow.ClockCanvas, AroundPreviewFactory.Dots(mainWindow, 4, 4)));
        public static Clock CircleWithTwelveDotsWithoutLabel(MainWindow mainWindow)
            => new Clock(mainWindow.ClockCanvas, Ratio,
                    new Circle(Ratio, mainWindow.ClockCanvas, AroundPreviewFactory.Dots(mainWindow, 12, 4)));
        public static Clock CircleWithSixtyDotsWithoutLabel(MainWindow mainWindow)
            => new Clock(mainWindow.ClockCanvas, Ratio,
                    new Circle(Ratio, mainWindow.ClockCanvas, AroundPreviewFactory.DotsWithSmallDots(mainWindow, 2)));
        public static Clock SquareWithFourLinesWithLabel(MainWindow mainWindow)
                => new Clock(mainWindow.ClockCanvas, Ratio,
                    new Square(Ratio, mainWindow.ClockCanvas, AroundPreviewFactory.Lines(mainWindow, 4, 8), true));
        public static Clock SquareWithTwelveLinesWithLabel(MainWindow mainWindow)
            => new Clock(mainWindow.ClockCanvas, Ratio,
                    new Square(Ratio, mainWindow.ClockCanvas, AroundPreviewFactory.Lines(mainWindow, 12, 8), true));
        public static Clock SquareWithSixtyLinesWithLabel(MainWindow mainWindow)
            => new Clock(mainWindow.ClockCanvas, Ratio,
                    new Square(Ratio, mainWindow.ClockCanvas, AroundPreviewFactory.LinesWithShortLines(mainWindow, 4), true));
        public static Clock SquareWithFourDotsWithLabel(MainWindow mainWindow)
            => new Clock(mainWindow.ClockCanvas, Ratio,
                    new Square(Ratio, mainWindow.ClockCanvas, AroundPreviewFactory.Dots(mainWindow, 4, 4), true));
        public static Clock SquareWithTwelveDotsWithLabel(MainWindow mainWindow)
            => new Clock(mainWindow.ClockCanvas, Ratio,
                    new Square(Ratio, mainWindow.ClockCanvas, AroundPreviewFactory.Dots(mainWindow, 12, 4), true));
        public static Clock SquareWithSixtyDotsWithLabel(MainWindow mainWindow)
            => new Clock(mainWindow.ClockCanvas, Ratio,
                    new Square(Ratio, mainWindow.ClockCanvas, AroundPreviewFactory.DotsWithSmallDots(mainWindow, 2), true));
        public static Clock CircleWithFourLinesWithLabel(MainWindow mainWindow)
                => new Clock(mainWindow.ClockCanvas, Ratio,
                    new Circle(Ratio, mainWindow.ClockCanvas, AroundPreviewFactory.Lines(mainWindow, 4, 8), true));
        public static Clock CircleWithTwelveLinesWithLabel(MainWindow mainWindow)
            => new Clock(mainWindow.ClockCanvas, Ratio,
                    new Circle(Ratio, mainWindow.ClockCanvas, AroundPreviewFactory.Lines(mainWindow, 12, 8), true));
        public static Clock CircleWithSixtyLinesWithLabel(MainWindow mainWindow)
            => new Clock(mainWindow.ClockCanvas, Ratio,
                    new Circle(Ratio, mainWindow.ClockCanvas, AroundPreviewFactory.LinesWithShortLines(mainWindow, 4), true));
        public static Clock CircleWithFourDotsWithLabel(MainWindow mainWindow)
            => new Clock(mainWindow.ClockCanvas, Ratio,
                    new Circle(Ratio, mainWindow.ClockCanvas, AroundPreviewFactory.Dots(mainWindow, 4, 4), true));
        public static Clock CircleWithTwelveDotsWithLabel(MainWindow mainWindow)
            => new Clock(mainWindow.ClockCanvas, Ratio,
                    new Circle(Ratio, mainWindow.ClockCanvas, AroundPreviewFactory.Dots(mainWindow, 12, 4), true));
        public static Clock CircleWithSixtyDotsWithLabel(MainWindow mainWindow)
            => new Clock(mainWindow.ClockCanvas, Ratio,
                    new Circle(Ratio, mainWindow.ClockCanvas, AroundPreviewFactory.DotsWithSmallDots(mainWindow, 2), true));
    }
}
