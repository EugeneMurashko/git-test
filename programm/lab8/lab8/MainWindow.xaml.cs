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
using System.Text.RegularExpressions;

namespace lab8
{
    public delegate void Startdelegate();
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DrawingGroup drawingGroup = new DrawingGroup();
        //List<Button> btnlist = new List<Button>();              // наше поле с кораблями
        List<Button> aibtnlist = new List<Button>();            // вражеское поле с кораблями
        List<Button> ourbtnlist = new List<Button>();
        Battlefiel AIBtlfl;
        Battlefiel OurBtlfl;
        bool flagGameOverW = false;

        public MainWindow()
        {
            InitializeComponent();

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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            // создаем поле боя
            AIBtlfl = new Battlefiel();
            do
            {
                // очищаем доску
                AIBtlfl.Clear();
                // размещаем корабли
                AIBtlfl.ArrangeShips(20);
            }
            while (!AIBtlfl.flagGoodEmptyCount);

            // создаем поле боя
            OurBtlfl = new Battlefiel();
            do
            {
                // очищаем доску
                OurBtlfl.Clear();
                // размещаем корабли
                OurBtlfl.ArrangeShips(45);
            }
            while (!OurBtlfl.flagGoodEmptyCount);

            foreach(var ship in OurBtlfl.shiplist)
            {
                foreach(var square in ship.coordinateslist)
                {
                    if(square.state == 0)
                    {
                        ourbtnlist[square.x * 10 + square.y].Background = new SolidColorBrush(Colors.Red);
                    }
                }
            }

                computerturn();
        }

        private void aifield_MouseUp(object sender, RoutedEventArgs e)
        {
            if (!flagGameOverW)
            {
                Button btn = sender as Button;

                int i = (int)btn.Tag / 10;
                int j = (int)btn.Tag % 10;


                if (AIBtlfl.squareArr[i, j].nship != 0) // Координаты по которым мы стреляли
                {
                    aibtnlist[i * 10 + j].Background = new SolidColorBrush(Colors.Red);
                    AIBtlfl.squareArr[i, j].state = 1; // отмечаем, что среляли уже по этой точке

                    // Отмечаем попадание по караблю
                    int count = 0;
                    for (int f = 0; f < AIBtlfl.shiplist.Count; f++)
                    {
                        count = 0;
                        for (int g = 0; g < AIBtlfl.shiplist[f].coordinateslist.Count; g++)
                        {
                            if (AIBtlfl.shiplist[f].coordinateslist[g].x == i && AIBtlfl.shiplist[f].coordinateslist[g].y == j)
                            {
                                AIBtlfl.shiplist[f].coordinateslist[g] = new Square(AIBtlfl.squareArr[i, j].nship, ShipState.killed, i, j);
                            }
                            if (AIBtlfl.shiplist[f].coordinateslist[g].state == 1)
                                count++;

                            if (count == AIBtlfl.shiplist[f].coordinateslist.Count)
                            {
                                AIBtlfl.shiplist[f].ShipState = ShipState.killed;

                                foreach (var square in AIBtlfl.shiplist[f].coordinateslist)
                                {
                                    aibtnlist[square.x * 10 + square.y].Background = new SolidColorBrush(Colors.White);

                                    if (!((square.x - 1) < 0 || square.y < 0 || (square.x - 1) > 9 || square.y > 9))
                                        aibtnlist[(square.x - 1) * 10 + square.y].Background = new SolidColorBrush(Colors.White);
                                    if (!((square.x + 1) < 0 || square.y < 0 || (square.x + 1) > 9 || square.y > 9))
                                        aibtnlist[(square.x + 1) * 10 + square.y].Background = new SolidColorBrush(Colors.White);
                                    if (!(square.x < 0 || (square.y - 1) < 0 || square.x > 9 || (square.y - 1) > 9))
                                        aibtnlist[square.x * 10 + (square.y - 1)].Background = new SolidColorBrush(Colors.White);
                                    if (!(square.x < 0 || (square.y + 1) < 0 || square.x > 9 || (square.y + 1) > 9))
                                        aibtnlist[square.x * 10 + (square.y + 1)].Background = new SolidColorBrush(Colors.White);

                                    if (!((square.x - 1) < 0 || (square.y - 1) < 0 || (square.x - 1) > 9 || (square.y - 1) > 9))
                                        aibtnlist[(square.x - 1) * 10 + (square.y - 1)].Background = new SolidColorBrush(Colors.White);
                                    if (!((square.x + 1) < 0 || (square.y + 1) < 0 || (square.x + 1) > 9 || (square.y + 1) > 9))
                                        aibtnlist[(square.x + 1) * 10 + (square.y + 1)].Background = new SolidColorBrush(Colors.White);
                                    if (!((square.x + 1) < 0 || (square.y - 1) < 0 || (square.x + 1) > 9 || (square.y - 1) > 9))
                                        aibtnlist[(square.x + 1) * 10 + (square.y - 1)].Background = new SolidColorBrush(Colors.White);
                                    if (!((square.x - 1) < 0 || (square.y + 1) < 0 || (square.x - 1) > 9 || (square.y + 1) > 9))
                                        aibtnlist[(square.x - 1) * 10 + (square.y + 1)].Background = new SolidColorBrush(Colors.White);

                                }
                                foreach (var ddd in AIBtlfl.shiplist[f].coordinateslist)
                                    aibtnlist[ddd.x * 10 + ddd.y].Background = new SolidColorBrush(Colors.Gray);
                            }
                        }
                    }
                }
                else
                {
                    
                    aibtnlist[i * 10 + j].Background = new SolidColorBrush(Colors.White); // Если мимо, то окрашиваем в белый
                    
                    if (AIBtlfl.squareArr[i, j].state != 1)
                        computerturn();
                    AIBtlfl.squareArr[i, j].state = 1;
                }


                bool flagGameOver = true;
                foreach (var value in AIBtlfl.shiplist)
                    if (value.ShipState == ShipState.clear)
                        flagGameOver = false;
                if (flagGameOver)
                {
                    MessageBox.Show("Вы победили!");
                    flagGameOverW = true;
                }


            }   
        }



        /*int[,] grille = { 
        {0,0,0,1,0,0,0,1,0,0 }, 
        {0,0,1,0,0,0,1,0,0,0 }, 
        {0,1,0,0,0,1,0,0,0,1 }, 
        {1,0,0,0,1,0,0,0,1,0 },
        {0,0,0,1,0,0,0,1,0,0 }, 
        {0,0,1,0,0,0,1,0,0,0 }, 
        {0,1,0,0,0,1,0,0,0,1 }, 
        {1,0,0,0,1,0,0,0,1,0 }, 
        {0,1,0,0,0,1,0,0,0,1 }, 
        {1,0,0,0,1,0,0,0,1,0 }
                        };*/

        int[,] grille = { 
        {1,1,1,1,1,1,1,1,1,1 }, 
        {1,1,1,1,1,1,1,1,1,1 },
        {1,1,1,1,1,1,1,1,1,1 },
        {1,1,1,1,1,1,1,1,1,1 },
        {1,1,1,1,1,1,1,1,1,1 },
        {1,1,1,1,1,1,1,1,1,1 },
        {1,1,1,1,1,1,1,1,1,1 },
        {1,1,1,1,1,1,1,1,1,1 },
        {1,1,1,1,1,1,1,1,1,1 },
        {1,1,1,1,1,1,1,1,1,1 }        
                        };


        int[,] grilleSmall = { 
        {0,1,0,1,0,1,0,1,0,1 }, 
        {1,0,1,0,1,0,1,0,1,0 }, 
        {0,1,0,1,0,1,0,1,0,1 }, 
        {1,0,1,0,1,0,1,0,1,0 },
        {0,1,0,1,0,1,0,1,0,1 }, 
        {1,0,1,0,1,0,1,0,1,0 },
        {0,1,0,1,0,1,0,1,0,1 }, 
        {1,0,1,0,1,0,1,0,1,0 },
        {0,1,0,1,0,1,0,1,0,1 }, 
        {1,0,1,0,1,0,1,0,1,0 },
                             };
        Random rnd = new Random();
        bool flagShot = false;

        // 1 куда стрелять можно!!
        // -1 куда уже срелял
        // -11 ранненый корабль
        // -2 отмечаем убитый корабль
        private void computerturn()
        {
            do
            {
                int x = rnd.Next(10);
                int y = rnd.Next(10);

                if (!(grille[x, y] == 1)) // сразу проверяем выстрел ли по сетке
                    continue;
                if (OurBtlfl.squareArr[x, y].nship != 0) // затем проверяем наличие нетронутого корпуса корабля
                {
                    grille[x, y] = -11; // помечаем в сетке, что он ранен



                    foreach (var ship in OurBtlfl.shiplist)
                        if (ship.square.nship == OurBtlfl.squareArr[x, y].nship)
                        {
                            ship.hitpoint--;


                            if (ship.hitpoint == 0)
                            {
                                ship.ShipState = ShipState.killed;
                                GoOverShip(ship, ref grille);
                            }
                            else
                            {
                                ourbtnlist[x * 10 + y].Background = new SolidColorBrush(Colors.Yellow);
                                ship.ShipState = ShipState.shot;
                                //GoFindHierShip(ship, ref grille);
                            }

                        }



                    
                    flagShot = false;

                }
                else
                {
                    grille[x, y] = -1; // пометили что уже стреляли сюда и корабля тут нет.
                    ourbtnlist[x * 10 + y].Background = new SolidColorBrush(Colors.White);
                    flagShot = true;
                }

            } while (!flagShot);


            flagShot = false;

            bool flagGameOver = true;
            foreach (var value in OurBtlfl.shiplist)
                if (value.ShipState != ShipState.killed)
                    flagGameOver = false;
            if (flagGameOver)
            {
                MessageBox.Show("Вы проиграли!");
                flagGameOverW = true;
            }
        }

        private void GoFindHierShip(Ship ship, ref int[,] grille)
        {
            throw new NotImplementedException();
        }

        private void GoOverShip(Ship ship, ref int[,] grille)
        {
            foreach (var square in ship.coordinateslist)
            {
                ourbtnlist[square.x * 10 + square.y].Background = new SolidColorBrush(Colors.White);

                if (!((square.x - 1) < 0 || square.y < 0 || (square.x - 1) > 9 || square.y > 9))
                    ourbtnlist[(square.x - 1) * 10 + square.y].Background = new SolidColorBrush(Colors.White);
                if (!((square.x + 1) < 0 || square.y < 0 || (square.x + 1) > 9 || square.y > 9))
                    ourbtnlist[(square.x + 1) * 10 + square.y].Background = new SolidColorBrush(Colors.White);
                if (!(square.x < 0 || (square.y - 1) < 0 || square.x > 9 || (square.y - 1) > 9))
                    ourbtnlist[square.x * 10 + (square.y - 1)].Background = new SolidColorBrush(Colors.White);
                if (!(square.x < 0 || (square.y + 1) < 0 || square.x > 9 || (square.y + 1) > 9))
                    ourbtnlist[square.x * 10 + (square.y + 1)].Background = new SolidColorBrush(Colors.White);

                if (!((square.x - 1) < 0 || (square.y - 1) < 0 || (square.x - 1) > 9 || (square.y - 1) > 9))
                    ourbtnlist[(square.x - 1) * 10 + (square.y - 1)].Background = new SolidColorBrush(Colors.White);
                if (!((square.x + 1) < 0 || (square.y + 1) < 0 || (square.x + 1) > 9 || (square.y + 1) > 9))
                    ourbtnlist[(square.x + 1) * 10 + (square.y + 1)].Background = new SolidColorBrush(Colors.White);
                if (!((square.x + 1) < 0 || (square.y - 1) < 0 || (square.x + 1) > 9 || (square.y - 1) > 9))
                    ourbtnlist[(square.x + 1) * 10 + (square.y - 1)].Background = new SolidColorBrush(Colors.White);
                if (!((square.x - 1) < 0 || (square.y + 1) < 0 || (square.x - 1) > 9 || (square.y + 1) > 9))
                    ourbtnlist[(square.x - 1) * 10 + (square.y + 1)].Background = new SolidColorBrush(Colors.White);

            }
            foreach (var ddd in ship.coordinateslist)
                ourbtnlist[ddd.x * 10 + ddd.y].Background = new SolidColorBrush(Colors.Gray);

            /*foreach (var ourbtn in ourbtnlist)
                if(ourbtn.Background == )*/
        }
    }
}
