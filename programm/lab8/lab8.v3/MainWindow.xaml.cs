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

namespace lab8.v3
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public SortedList<int, string> hullship = new SortedList<int, string>();
        List<Button> aibtnlist = new List<Button>();
        List<Button> ourbtnlist = new List<Button>();
        Battlefiel AIBtlfl;
        Battlefiel OurBtlfl;
        public MainWindow()
        {
            InitializeComponent();
            createBattlePlaces(); // создаем поле битвы наше и противника
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AIBtlfl = new Battlefiel(45, "AI");
        }

        public void aifield_MouseUp (object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            
        }

        public void createBattlePlaces()
        {
            int tag = 0;
            AIBattlefieldGreed.Children.Clear();

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    tag = i * 10 + j;
                    var button = new Button { VerticalAlignment = VerticalAlignment.Stretch, Tag = tag, Name = "aibtn" + i + "" + j };
                    button.Click += new RoutedEventHandler(aifield_MouseUp);
                    button.Background = Brushes.LightSeaGreen;

                    Grid.SetRow(button, i);
                    Grid.SetColumn(button, j);
                    AIBattlefieldGreed.Children.Add(button);
                    aibtnlist.Add(button);
                }
            }

            tag = 0;
            OurBattlefieldGreed.Children.Clear();

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    tag = i * 10 + j;
                    var button = new Button { VerticalAlignment = VerticalAlignment.Stretch, Tag = tag, Name = "ourbtn" + i + "" + j };
                    button.Background = Brushes.LightBlue;

                    Grid.SetRow(button, i);
                    Grid.SetColumn(button, j);
                    OurBattlefieldGreed.Children.Add(button);
                    ourbtnlist.Add(button);
                }
            }
        }
        
    }
}

/*
foreach (var ship in AIBtlfl.shiplist) // убивает все корабли и отображает их на экран
            {
                foreach (var hull in ship.Value.hullship)
                    hull.Value.statesquare = StateSquare.shot;
                ship.Value.Draw(aibtnlist);
            }

/*
            // проверим отрисовку
            Square sq = new Square((int)button.Tag / 10, (int)button.Tag % 10);
            sq.Draw(aibtnlist);

            Ship fourhullship = new Ship(ShipNumber.four_ship, Direction.right, (int)button.Tag / 10, (int)button.Tag % 10, "IO");
            fourhullship.hullship[button.Tag.ToString()].statesquare = StateSquare.shot;
            fourhullship.Draw(aibtnlist);

            fourhullship = new Ship(ShipNumber.four_ship, Direction.right, (int)button.Tag / 10, (int)button.Tag % 10, "Our");
            fourhullship.hullship[button.Tag.ToString()].statesquare = StateSquare.shot;
            fourhullship.Draw(ourbtnlist);
*/
/*MessageBox.Show(AIBtlfl.squareArr[(int)button.Tag / 10, (int)button.Tag % 10].whatshipiam + "\n" +
    AIBtlfl.shiplist[AIBtlfl.squareArr[(int)button.Tag / 10, (int)button.Tag % 10].whatshipiam].d);*/