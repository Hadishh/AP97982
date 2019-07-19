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
        public static Clock SquareWithFourLinesWithoutLabel(Canvas clockCanvas)
                => new Clock (clockCanvas, Ratio, 
                    new Square(Ratio, clockCanvas, AroundPreviewFactory.Lines(clockCanvas, 4, 8)));
        public static Clock SquareWithTwelveLinesWithoutLabel(Canvas clockCanvas)
            => new Clock(clockCanvas, Ratio,
                    new Square(Ratio, clockCanvas, AroundPreviewFactory.Lines(clockCanvas, 12, 8)));
        public static Clock SquareWithSixtyLinesWithoutLabel(Canvas clockCanvas)
            => new Clock(clockCanvas, Ratio,
                    new Square(Ratio, clockCanvas, AroundPreviewFactory.LinesWithShortLines(clockCanvas ,4)));
        public static Clock SquareWithFourDotsWithoutLabel(Canvas clockCanvas)
            => new Clock(clockCanvas, Ratio,
                    new Square(Ratio, clockCanvas, AroundPreviewFactory.Dots(clockCanvas, 4, 4)));
        public static Clock SquareWithTwelveDotsWithoutLabel(Canvas clockCanvas)
            => new Clock(clockCanvas, Ratio,
                    new Square(Ratio, clockCanvas, AroundPreviewFactory.Dots(clockCanvas, 12, 4)));
        public static Clock SquareWithSixtyDotsWithoutLabel(Canvas clockCanvas)
            => new Clock(clockCanvas, Ratio,
                    new Square(Ratio, clockCanvas, AroundPreviewFactory.DotsWithSmallDots(clockCanvas, 2)));
        public static Clock CircleWithFourLinesWithoutLabel(Canvas clockCanvas)
                => new Clock(clockCanvas, Ratio,
                    new Circle(Ratio, clockCanvas, AroundPreviewFactory.Lines(clockCanvas, 4, 8)));
        public static Clock CircleWithTwelveLinesWithoutLabel(Canvas clockCanvas)
            => new Clock(clockCanvas, Ratio,
                    new Circle(Ratio, clockCanvas, AroundPreviewFactory.Lines(clockCanvas, 12, 8)));
        public static Clock CircleWithSixtyLinesWithoutLabel(Canvas clockCanvas)
            => new Clock(clockCanvas, Ratio,
                    new Circle(Ratio, clockCanvas, AroundPreviewFactory.LinesWithShortLines(clockCanvas, 4)));
        public static Clock CircleWithFourDotsWithoutLabel(Canvas clockCanvas)
            => new Clock(clockCanvas, Ratio,
                    new Circle(Ratio, clockCanvas, AroundPreviewFactory.Dots(clockCanvas, 4, 4)));
        public static Clock CircleWithTwelveDotsWithoutLabel(Canvas clockCanvas)
            => new Clock(clockCanvas, Ratio,
                    new Circle(Ratio, clockCanvas, AroundPreviewFactory.Dots(clockCanvas, 12, 4)));
        public static Clock CircleWithSixtyDotsWithoutLabel(Canvas clockCanvas)
            => new Clock(clockCanvas, Ratio,
                    new Circle(Ratio, clockCanvas, AroundPreviewFactory.DotsWithSmallDots(clockCanvas, 2)));
        public static Clock SquareWithFourLinesWithLabel(Canvas clockCanvas)
                => new Clock(clockCanvas, Ratio,
                    new Square(Ratio, clockCanvas, AroundPreviewFactory.Lines(clockCanvas, 4, 8), true));
        public static Clock SquareWithTwelveLinesWithLabel(Canvas clockCanvas)
            => new Clock(clockCanvas, Ratio,
                    new Square(Ratio, clockCanvas, AroundPreviewFactory.Lines(clockCanvas, 12, 8), true));
        public static Clock SquareWithSixtyLinesWithLabel(Canvas clockCanvas)
            => new Clock(clockCanvas, Ratio,
                    new Square(Ratio, clockCanvas, AroundPreviewFactory.LinesWithShortLines(clockCanvas, 4), true));
        public static Clock SquareWithFourDotsWithLabel(Canvas clockCanvas)
            => new Clock(clockCanvas, Ratio,
                    new Square(Ratio, clockCanvas, AroundPreviewFactory.Dots(clockCanvas, 4, 4), true));
        public static Clock SquareWithTwelveDotsWithLabel(Canvas clockCanvas)
            => new Clock(clockCanvas, Ratio,
                    new Square(Ratio, clockCanvas, AroundPreviewFactory.Dots(clockCanvas, 12, 4), true));
        public static Clock SquareWithSixtyDotsWithLabel(Canvas clockCanvas)
            => new Clock(clockCanvas, Ratio,
                    new Square(Ratio, clockCanvas, AroundPreviewFactory.DotsWithSmallDots(clockCanvas, 2), true));
        public static Clock CircleWithFourLinesWithLabel(Canvas clockCanvas)
                => new Clock(clockCanvas, Ratio,
                    new Circle(Ratio, clockCanvas, AroundPreviewFactory.Lines(clockCanvas, 4, 8), true));
        public static Clock CircleWithTwelveLinesWithLabel(Canvas clockCanvas)
            => new Clock(clockCanvas, Ratio,
                    new Circle(Ratio, clockCanvas, AroundPreviewFactory.Lines(clockCanvas, 12, 8), true));
        public static Clock CircleWithSixtyLinesWithLabel(Canvas clockCanvas)
            => new Clock(clockCanvas, Ratio,
                    new Circle(Ratio, clockCanvas, AroundPreviewFactory.LinesWithShortLines(clockCanvas, 4), true));
        public static Clock CircleWithFourDotsWithLabel(Canvas clockCanvas)
            => new Clock(clockCanvas, Ratio,
                    new Circle(Ratio, clockCanvas, AroundPreviewFactory.Dots(clockCanvas, 4, 4), true));
        public static Clock CircleWithTwelveDotsWithLabel(Canvas clockCanvas)
            => new Clock(clockCanvas, Ratio,
                    new Circle(Ratio, clockCanvas, AroundPreviewFactory.Dots(clockCanvas, 12, 4), true));
        public static Clock CircleWithSixtyDotsWithLabel(Canvas clockCanvas)
            => new Clock(clockCanvas, Ratio,
                    new Circle(Ratio, clockCanvas, AroundPreviewFactory.DotsWithSmallDots(clockCanvas, 2), true));
    }
}
