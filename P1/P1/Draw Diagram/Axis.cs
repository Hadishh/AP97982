﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace P1
{
    public abstract class Axis : IGrid
    {
        public Label Label { get; set; }
        protected Canvas ParentCanvas { get; set; }
        protected Line MainLine { get; set; } 
        protected Point Center { get; set; }
        protected double LengthOfEachPart { get; set; }
        protected (double X, double Y) Delta { get; set; }
        protected int Scale { get; set; }
        protected double Margin { get; set; }
        protected bool IsDestroyed { get; set; }
        public Axis(Canvas parentCanvas, (double X, double Y) delta, double lengthOfEachPart, int scale, double margin = 0)
        {
            ParentCanvas = parentCanvas;
            Margin = margin;
            Delta = delta;
            Center = new Point();
            LengthOfEachPart = lengthOfEachPart;
            Scale = scale;
            IsDestroyed = false;
        }
        protected List<int> SetNewNumbers(List<int> numbers, int v)
        {
            int multiple = numbers.Count / v;
            return numbers.Select(d => d * multiple).ToList();
        }
        public void Destroy()
        {
            IsDestroyed = true;
            ParentCanvas.Children.Clear();
            ParentCanvas = null;
        }
        public abstract void DrawGrid();
    }
}