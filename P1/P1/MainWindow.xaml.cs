using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using System.Threading;

namespace P1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool LeftMenuIsHidden = false;
        EquationHandler EquationHandler;
        Clock MainClock;
        PlottingSpace PlottingSpace;
        public MainWindow()
        {
            InitializeComponent();
            EquationHandler = new EquationHandler(EquationStack);
            EquationHandler.DrawEquation += EquationHandler_Draw;
            ClockCanvas.Loaded += ClockCanvas_Loaded;
            this.Closed += MainWindow_Closed;
            EquationCanvas.Loaded += EquationCanvas_Loaded;
            MinX.TextChanged += UpdateBounds;
            MaxX.TextChanged += UpdateBounds;
            MinY.TextChanged += UpdateBounds;
            MaxY.TextChanged += UpdateBounds;
        }

        private void EquationHandler_Draw(object sender, Equation e)
        {
            PlottingSpace.DrawEquation(e);
        }

        private void UpdateBounds(object sender, TextChangedEventArgs e)
        {
            try
            {
                PlottingSpace.XBounds = (double.Parse(MaxX.Text), double.Parse(MinX.Text));
                PlottingSpace.YBounds = (double.Parse(MaxY.Text), double.Parse(MinY.Text));
                //PlottingSpace.DrawGrid();
            }
            catch(FormatException)
            {
                PlottingSpace.YBounds = (0, 0);
                PlottingSpace.XBounds = (0, 0);
            }
        }

        private void EquationCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            PlottingSpace = new PlottingSpace((10,20), (-10, 30), EquationCanvas, 10, 1, 0);
            PlottingSpace.Accuracy = 0.1;
            PlottingSpace.DrawGrid();
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        /// <summary>
        /// On Clock Canvas Loaded ock must start Working
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
            }
        }
    }
}
