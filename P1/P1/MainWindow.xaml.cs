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
        Draw_Diagram Drawer;
        EquationSolver EquationSolver;
        public MainWindow()
        {
            InitializeComponent();
            ClockCanvas.Loaded += ClockCanvas_Loaded;
            this.Closed += MainWindow_Closed;
            MainTabControl.SelectionChanged += MainTabControl_SelectionChanged;
        }

        private void MainTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DrawDiagram.IsSelected)
            {
                Drawer = new Draw_Diagram(this);
            }
            else if (EquatioSolver.IsSelected)
            {
                Drawer.Destroy();
                Drawer = null;
            }
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
    }
}
