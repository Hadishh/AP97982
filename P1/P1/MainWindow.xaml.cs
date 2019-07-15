using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using System.Threading;

namespace P1
{
    /// <summary>
    /// Interaction logic for xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Clock MainClock;
        public MainWindow()
        {
            InitializeComponent();
            ClockCanvas.Loaded += ClockCanvas_Loaded;
            this.Closed += MainWindow_Closed;
            EquationHandler = new EquationHandler(EquationStack);
            EquationHandler.DrawEquation += EquationHandler_Draw;
            EquationCanvas.Loaded += EquationCanvas_Loaded;
            MinX.TextChanged += UpdateBounds;
            MaxX.TextChanged += UpdateBounds;
            MinY.TextChanged += UpdateBounds;
            MaxY.TextChanged += UpdateBounds;
            PreviewMouseWheel += EquationCanvas_MouseWheel;
        }
 
        private void MainWindow_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        /// <summary>
        /// On Clock Canvas Loaded clock must start Working
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClockCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            MainClock = new Clock(ClockCanvas, 50);
            Thread t = new Thread(() =>
            {
                while (true)
                {
                    Dispatcher.Invoke(
                        (Action)(() =>{
                            
                            MainClock.RenderTime(DateTime.Now);
                    }));
                    Thread.Sleep(1000);
                }
            });
            t.IsBackground = true;
            t.Start();
        }
        public bool LeftMenuIsHidden = false;
        EquationHandler EquationHandler;
        
        PlottingSpace PlottingSpace;

        private void EquationCanvas_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            if (e.Delta < 0)
            {
                PlottingSpace.ZoomOut(5);
                PlottingSpace.DrawGrid();
                if (PlottingSpace.Accuracy < 0.1)
                {
                    PlottingSpace.Accuracy *= 2;
                }
                PlottingSpace.DrawAddedEquations();
            }
            if (e.Delta > 0)
            {
                PlottingSpace.ZoomIn(5);
                PlottingSpace.DrawGrid();
                if(PlottingSpace.Accuracy > 0.01)
                {
                    PlottingSpace.Accuracy /= 2;
                }
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
                PlottingSpace.XBounds = (double.Parse(MinX.Text), double.Parse(MaxX.Text));
                PlottingSpace.YBounds = (double.Parse(MinY.Text), double.Parse(MaxY.Text));
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
            PlottingSpace = new PlottingSpace((10, 20), (-10, 30), EquationCanvas, 10, 1, 0);
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
                Storyboard sb = Resources["CloseMenu"] as Storyboard;
                MenuButton.Margin = new Thickness(8, 0, 0, 0);
                LeftMenuIsHidden = true;
                MenuButton.Content = ">>";
                sb.Begin(DrawingPart);
                PlottingSpace.Margin = 220;
                PlottingSpace.DrawGrid();
                PlottingSpace.DrawAddedEquations();
            }
            else
            {
                Storyboard sb = Resources["OpenMenu"] as Storyboard;
                MenuButton.Margin = new Thickness(0, 0, 0, 0);
                sb.Begin(DrawingPart);
                MenuButton.Content = "<<";
                LeftMenuIsHidden = false;
                PlottingSpace.Margin = 0;
                PlottingSpace.DrawGrid();
                PlottingSpace.DrawAddedEquations();
            }
        }
    }
    }
