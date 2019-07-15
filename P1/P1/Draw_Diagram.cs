using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace P1
{
   public class Draw_Diagram
    {
        public bool LeftMenuIsHidden = false;
        EquationHandler EquationHandler;
        
        PlottingSpace PlottingSpace;
        private MainWindow MainWindow { get; set; }
        public Draw_Diagram(MainWindow mainWindow)
        {
            MainWindow = mainWindow;
            EquationHandler = new EquationHandler(MainWindow.EquationStack);
            EquationHandler.DrawEquation += EquationHandler_Draw;
            MainWindow.EquationCanvas.Loaded += EquationCanvas_Loaded;
            MainWindow.MinX.TextChanged += UpdateBounds;
            MainWindow.MaxX.TextChanged += UpdateBounds;
            MainWindow.MinY.TextChanged += UpdateBounds;
            MainWindow.MaxY.TextChanged += UpdateBounds;
            MainWindow.PreviewMouseWheel += EquationCanvas_MouseWheel;
        }
        private void EquationCanvas_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            if (e.Delta < 0)
            {
                PlottingSpace.ZoomOut(5);
                PlottingSpace.DrawGrid();
                PlottingSpace.DrawAddedEquations();
            }
            if (e.Delta > 0)
            {
                PlottingSpace.ZoomIn(5);
                PlottingSpace.DrawGrid();
                PlottingSpace.DrawAddedEquations();
            }
        }

        private void EquationHandler_Draw(object sender, Equation e)
        {
            PlottingSpace.DrawEquation(e);
        }
        /// <summary>
        /// Update Bounderies 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateBounds(object sender, TextChangedEventArgs e)
        {
            try
            {
                PlottingSpace.XBounds = (double.Parse(MainWindow.MinX.Text), double.Parse(MainWindow.MaxX.Text));
                PlottingSpace.YBounds = (double.Parse(MainWindow.MinY.Text), double.Parse(MainWindow.MaxY.Text));
                PlottingSpace.DrawAddedEquations();
            }
            catch (FormatException)
            {
                PlottingSpace.YBounds = (0, 0);
                PlottingSpace.XBounds = (0, 0);
            }
        }
        /// <summary>
        /// Initialize PlottingSpace Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EquationCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            PlottingSpace = new PlottingSpace((10, 20), (-10, 30), MainWindow.EquationCanvas, 10, 1, 0);
            PlottingSpace.Accuracy = 0.1;
            PlottingSpace.DrawGrid();

        }
        /// <summary>
        /// Closing and opening equations menu and reforming grids of plotting space
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {

            if (!LeftMenuIsHidden)
            {
                Storyboard sb = MainWindow.Resources["CloseMenu"] as Storyboard;
                MainWindow.MenuButton.Margin = new Thickness(8, 0, 0, 0);
                LeftMenuIsHidden = true;
                MainWindow.MenuButton.Content = ">>";
                sb.Begin(MainWindow.DrawingPart);
                PlottingSpace.Margin = 220;
                PlottingSpace.DrawGrid();
                PlottingSpace.DrawAddedEquations();
            }
            else
            {
                Storyboard sb = MainWindow.Resources["OpenMenu"] as Storyboard;
                MainWindow.MenuButton.Margin = new Thickness(0, 0, 0, 0);
                sb.Begin(MainWindow.DrawingPart);
                MainWindow.MenuButton.Content = "<<";
                LeftMenuIsHidden = false;
                PlottingSpace.Margin = 0;
                PlottingSpace.DrawGrid();
                PlottingSpace.DrawAddedEquations();
            }
        }
    }
}
