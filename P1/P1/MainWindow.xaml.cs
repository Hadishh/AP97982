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
        bool LeftMenuIsHidden = false;
        EquationHandler EquationHandler;
        Clock MainClock;
        public MainWindow()
        {
            InitializeComponent();
            EquationHandler = new EquationHandler(EquationStack);
            ClockCanvas.Loaded += ClockCanvas_Loaded;
            this.Closed += MainWindow_Closed;
            EquationCanvas.Loaded += EquationCanvas_Loaded;
        }

        private void EquationCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            X_Axis x = new X_Axis(EquationCanvas, -50, 50);
            Y_Axis y = new Y_Axis(EquationCanvas, -50, 50);
            x.DrawGrids();
            y.DrawGrids();
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
                    DispatcherOperation op = Dispatcher.BeginInvoke(
                        (Action)(() =>{
                            MainClock.RenderTime(DateTime.Now);
                    }));
                    Thread.Sleep(1000);
                }
            });
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
            }
            else
            {
                Storyboard sb = Resources["OpenMenu"] as Storyboard;
                MenuButton.Margin = new Thickness(0, 0, 0, 0);
                sb.Begin(DrawingPart);
                MenuButton.Content = "<<";
                LeftMenuIsHidden = false;
            }
        }

    }
}
