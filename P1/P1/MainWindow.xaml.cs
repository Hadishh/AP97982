using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using System.Collections.Generic;
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
        Taylor TaylorDrawer;
        
        public MainWindow()
        {
            InitializeComponent();
            ClockCanvas.Loaded += ClockCanvas_Loaded;
            this.Closed += MainWindow_Closed;
            MainTabControl.SelectionChanged += MainTabControl_SelectionChanged;
            CalculateLinearEquation.Click += CalculateLinearEquation_Click;
            ClearLinearEquation.Click += ClearLinearEquation_Click;
        }
        private void MainTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DrawDiagram.IsSelected)
            {
                Drawer = new Draw_Diagram(this);
                if (TaylorDrawer != null)
                {
                    TaylorDrawer.Destroy();
                    TaylorDrawer = null;
                }
            }
            else if (EquatioSolver.IsSelected)
            {
                if (Drawer != null)
                {
                    Drawer.Destroy();
                    Drawer = null;
                }
                if (TaylorDrawer != null)
                {
                    TaylorDrawer.Destroy();
                    TaylorDrawer = null;
                }
            }
            else if (Taylor.IsSelected)
            {
                if (Drawer != null)
                {
                    Drawer.Destroy();
                    Drawer = null;
                }
            }
        }
        private void MainWindow_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        #region EquationSolverEvents
        private void ClearLinearEquation_Click(object sender, RoutedEventArgs e)
        {
          Answers.Text = string.Empty;
            EquationsText.Text = string.Empty;
        }

        private void CalculateLinearEquation_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EquationSolver = new EquationSolver(EquationsText.Text);
                Answers.Text = EquationSolver.Answer();
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Can't Solve This Equations!", "Error");
            }
        }
        #endregion
        #region ClockEvents
        /// <summary>
        /// On clock canvas loaded clock must start Working
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClockCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            MainClock = ClockFactory.CircleWithTwelveLinesWithoutLabel(this.ClockCanvas);
            Thread t = new Thread(() =>
            {
                while (true)
                {
                    Dispatcher.Invoke(
                        (Action)(() =>
                        {
                            MainClock.RenderTime(DateTime.Now);
                        }));
                    Thread.Sleep(1000);
                }
            });
            t.IsBackground = true;
            t.Start();
        }
        #endregion
        #region TaylorEvents
        private void DrawTaylor_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int n = int.Parse(NText.Text);
                double x0 = double.Parse(X0Text.Text);
                if (TaylorDrawer != null)
                    TaylorDrawer.Destroy();
                TaylorDrawer = new Taylor(n, x0, this);
            }
            catch(FormatException)
            {
                MessageBox.Show("Please enter Correct Entries!", "Error!");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TaylorDrawer.Destroy();
            TaylorDrawer = null;
        }
        #endregion
    }
}
