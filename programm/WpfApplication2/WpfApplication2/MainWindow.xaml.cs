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

namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }
 
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (DynamicGrid == null)
                return;
            int n = 10;
            DynamicGrid.Children.Clear();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    var button = new Button {VerticalAlignment = VerticalAlignment.Stretch};
                    button.Click += delegate { MessageBox.Show(string.Format("Button [{0};{1}]!", i, j)); };
                    Grid.SetRow(button, i);
                    Grid.SetColumn(button, j);
                    DynamicGrid.Children.Add(button);
                }
            }
        }
    }
}
