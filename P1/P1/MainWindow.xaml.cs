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

namespace P1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool LeftMenuIsHidden = false;
        EquationHandler EquationHandler;
        public MainWindow()
        {
            InitializeComponent();
            EquationHandler = new EquationHandler(EquationStack);
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

        private void ShowButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
