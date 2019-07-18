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
        public const double Ratio = 50;
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
    }
}
