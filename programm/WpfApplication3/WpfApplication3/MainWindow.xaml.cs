using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        bool isMoved = false;
        Point startMP;
        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                isMoved = true;
                startMP = e.GetPosition(this);

            }
            
        }
        private void Rectangle_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Released)
            {
                isMoved = false;
            }
        }
        private void Rectangle_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMoved)
            {
                Point currentPoint = e.GetPosition(this);
                double dY = currentPoint.Y - startMovePosition.Y;
                double dX = currentPoint.X - startMovePosition.X;
                Rectangle rect = sender as Rectangle;
                rect.Margin = new Thickness(0, 0, -dX, -dY);
            }
        }
    }
}
