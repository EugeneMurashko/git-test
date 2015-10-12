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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DrawingGroup drawingGroup = new DrawingGroup();
        List<Button> btnlist = new List<Button>();              // наше поле с кораблями
        List<Button> aibtnlist = new List<Button>();            // вражеское поле с кораблями
        Battlefiel AIBtlfl;

        public MainWindow()
        {
            InitializeComponent();

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
                AIBtlfl.ArrangeShips(45);
            }
            while (!AIBtlfl.flagGoodEmptyCount);

            btnlist.Add(btn00);
            btnlist.Add(btn01);
            btnlist.Add(btn02);
            btnlist.Add(btn03);
            btnlist.Add(btn04);
            btnlist.Add(btn05);
            btnlist.Add(btn06);
            btnlist.Add(btn07);
            btnlist.Add(btn08);
            btnlist.Add(btn09);

            btnlist.Add(btn10);
            btnlist.Add(btn11);
            btnlist.Add(btn12);
            btnlist.Add(btn13);
            btnlist.Add(btn14);
            btnlist.Add(btn15);
            btnlist.Add(btn16);
            btnlist.Add(btn17);
            btnlist.Add(btn18);
            btnlist.Add(btn19);

            btnlist.Add(btn20);
            btnlist.Add(btn21);
            btnlist.Add(btn22);
            btnlist.Add(btn23);
            btnlist.Add(btn24);
            btnlist.Add(btn25);
            btnlist.Add(btn26);
            btnlist.Add(btn27);
            btnlist.Add(btn28);
            btnlist.Add(btn29);

            btnlist.Add(btn30);
            btnlist.Add(btn31);
            btnlist.Add(btn32);
            btnlist.Add(btn33);
            btnlist.Add(btn34);
            btnlist.Add(btn35);
            btnlist.Add(btn36);
            btnlist.Add(btn37);
            btnlist.Add(btn38);
            btnlist.Add(btn39);

            btnlist.Add(btn40);
            btnlist.Add(btn41);
            btnlist.Add(btn42);
            btnlist.Add(btn43);
            btnlist.Add(btn44);
            btnlist.Add(btn45);
            btnlist.Add(btn46);
            btnlist.Add(btn47);
            btnlist.Add(btn48);
            btnlist.Add(btn49);

            btnlist.Add(btn50);
            btnlist.Add(btn51);
            btnlist.Add(btn52);
            btnlist.Add(btn53);
            btnlist.Add(btn54);
            btnlist.Add(btn55);
            btnlist.Add(btn56);
            btnlist.Add(btn57);
            btnlist.Add(btn58);
            btnlist.Add(btn59);

            btnlist.Add(btn60);
            btnlist.Add(btn61);
            btnlist.Add(btn62);
            btnlist.Add(btn63);
            btnlist.Add(btn64);
            btnlist.Add(btn65);
            btnlist.Add(btn66);
            btnlist.Add(btn67);
            btnlist.Add(btn68);
            btnlist.Add(btn69);

            btnlist.Add(btn70);
            btnlist.Add(btn71);
            btnlist.Add(btn72);
            btnlist.Add(btn73);
            btnlist.Add(btn74);
            btnlist.Add(btn75);
            btnlist.Add(btn76);
            btnlist.Add(btn77);
            btnlist.Add(btn78);
            btnlist.Add(btn79);

            btnlist.Add(btn80);
            btnlist.Add(btn81);
            btnlist.Add(btn82);
            btnlist.Add(btn83);
            btnlist.Add(btn84);
            btnlist.Add(btn85);
            btnlist.Add(btn86);
            btnlist.Add(btn87);
            btnlist.Add(btn88);
            btnlist.Add(btn89);

            btnlist.Add(btn90);
            btnlist.Add(btn91);
            btnlist.Add(btn92);
            btnlist.Add(btn93);
            btnlist.Add(btn94);
            btnlist.Add(btn95);
            btnlist.Add(btn96);
            btnlist.Add(btn97);
            btnlist.Add(btn98);
            btnlist.Add(btn99);




            aibtnlist.Add(Io_btn00);
            aibtnlist.Add(Io_btn01);
            aibtnlist.Add(Io_btn02);
            aibtnlist.Add(Io_btn03);
            aibtnlist.Add(Io_btn04);
            aibtnlist.Add(Io_btn05);
            aibtnlist.Add(Io_btn06);
            aibtnlist.Add(Io_btn07);
            aibtnlist.Add(Io_btn08);
            aibtnlist.Add(Io_btn09);

            aibtnlist.Add(Io_btn10);
            aibtnlist.Add(Io_btn11);
            aibtnlist.Add(Io_btn12);
            aibtnlist.Add(Io_btn13);
            aibtnlist.Add(Io_btn14);
            aibtnlist.Add(Io_btn15);
            aibtnlist.Add(Io_btn16);
            aibtnlist.Add(Io_btn17);
            aibtnlist.Add(Io_btn18);
            aibtnlist.Add(Io_btn19);

            aibtnlist.Add(Io_btn20);
            aibtnlist.Add(Io_btn21);
            aibtnlist.Add(Io_btn22);
            aibtnlist.Add(Io_btn23);
            aibtnlist.Add(Io_btn24);
            aibtnlist.Add(Io_btn25);
            aibtnlist.Add(Io_btn26);
            aibtnlist.Add(Io_btn27);
            aibtnlist.Add(Io_btn28);
            aibtnlist.Add(Io_btn29);

            aibtnlist.Add(Io_btn30);
            aibtnlist.Add(Io_btn31);
            aibtnlist.Add(Io_btn32);
            aibtnlist.Add(Io_btn33);
            aibtnlist.Add(Io_btn34);
            aibtnlist.Add(Io_btn35);
            aibtnlist.Add(Io_btn36);
            aibtnlist.Add(Io_btn37);
            aibtnlist.Add(Io_btn38);
            aibtnlist.Add(Io_btn39);

            aibtnlist.Add(Io_btn40);
            aibtnlist.Add(Io_btn41);
            aibtnlist.Add(Io_btn42);
            aibtnlist.Add(Io_btn43);
            aibtnlist.Add(Io_btn44);
            aibtnlist.Add(Io_btn45);
            aibtnlist.Add(Io_btn46);
            aibtnlist.Add(Io_btn47);
            aibtnlist.Add(Io_btn48);
            aibtnlist.Add(Io_btn49);

            aibtnlist.Add(Io_btn50);
            aibtnlist.Add(Io_btn51);
            aibtnlist.Add(Io_btn52);
            aibtnlist.Add(Io_btn53);
            aibtnlist.Add(Io_btn54);
            aibtnlist.Add(Io_btn55);
            aibtnlist.Add(Io_btn56);
            aibtnlist.Add(Io_btn57);
            aibtnlist.Add(Io_btn58);
            aibtnlist.Add(Io_btn59);

            aibtnlist.Add(Io_btn60);
            aibtnlist.Add(Io_btn61);
            aibtnlist.Add(Io_btn62);
            aibtnlist.Add(Io_btn63);
            aibtnlist.Add(Io_btn64);
            aibtnlist.Add(Io_btn65);
            aibtnlist.Add(Io_btn66);
            aibtnlist.Add(Io_btn67);
            aibtnlist.Add(Io_btn68);
            aibtnlist.Add(Io_btn69);

            aibtnlist.Add(Io_btn70);
            aibtnlist.Add(Io_btn71);
            aibtnlist.Add(Io_btn72);
            aibtnlist.Add(Io_btn73);
            aibtnlist.Add(Io_btn74);
            aibtnlist.Add(Io_btn75);
            aibtnlist.Add(Io_btn76);
            aibtnlist.Add(Io_btn77);
            aibtnlist.Add(Io_btn78);
            aibtnlist.Add(Io_btn79);

            aibtnlist.Add(Io_btn80);
            aibtnlist.Add(Io_btn81);
            aibtnlist.Add(Io_btn82);
            aibtnlist.Add(Io_btn83);
            aibtnlist.Add(Io_btn84);
            aibtnlist.Add(Io_btn85);
            aibtnlist.Add(Io_btn86);
            aibtnlist.Add(Io_btn87);
            aibtnlist.Add(Io_btn88);
            aibtnlist.Add(Io_btn89);

            aibtnlist.Add(Io_btn90);
            aibtnlist.Add(Io_btn91);
            aibtnlist.Add(Io_btn92);
            aibtnlist.Add(Io_btn93);
            aibtnlist.Add(Io_btn94);
            aibtnlist.Add(Io_btn95);
            aibtnlist.Add(Io_btn96);
            aibtnlist.Add(Io_btn97);
            aibtnlist.Add(Io_btn98);
            aibtnlist.Add(Io_btn99);
        }

        private void img_MouseUp(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Regex regex = new Regex(@"\d");
            int i = 0;
            int j = 0;

            try
            {
                i = Int32.Parse(regex.Matches(btn.Name.ToString())[0].ToString());
                j = Int32.Parse(regex.Matches(btn.Name.ToString())[1].ToString());

            }
            catch (FormatException)
            {
                MessageBox.Show("Регулярка не привелась в число.");
            }
                if (AIBtlfl.squareArr[i, j].nship != 0) // Координаты по которым мы стреляли
                {
                    aibtnlist[i * 10 + j].Background = new SolidColorBrush(Colors.Red);
                    AIBtlfl.squareArr[i, j].state = 1; // отмечаем, что среляли уже по этой точке
                     
                        // Отмечаем попадание по караблю
                    int count = 0;
                    for (int f = 0; f < AIBtlfl.shiplist.Count; f++ )
                    {
                        count = 0;
                        for (int g = 0; g < AIBtlfl.shiplist[f].coordinateslist.Count; g++)
                        {
                            if (AIBtlfl.shiplist[f].coordinateslist[g].x == i && AIBtlfl.shiplist[f].coordinateslist[g].y == j)
                            {
                                AIBtlfl.shiplist[f].coordinateslist[g] = new Square(AIBtlfl.squareArr[i, j].nship, ShipState.hit, i, j);
                            }
                            if (AIBtlfl.shiplist[f].coordinateslist[g].state == 1)
                                count++;

                            if (count == AIBtlfl.shiplist[f].coordinateslist.Count)
                            {
                                AIBtlfl.shiplist[f].ShipState = ShipState.hit;

                                foreach (var ddd in AIBtlfl.shiplist[f].coordinateslist)
                                {
                                    aibtnlist[ddd.x * 10 + ddd.y].Background = new SolidColorBrush(Colors.White);

                                    if (!((ddd.x - 1) < 0 || ddd.y < 0 || (ddd.x - 1) > 9 || ddd.y > 9))
                                        aibtnlist[(ddd.x - 1) * 10 + ddd.y].Background = new SolidColorBrush(Colors.White);
                                    if (!((ddd.x + 1) < 0 || ddd.y < 0 || (ddd.x + 1) > 9 || ddd.y > 9))
                                        aibtnlist[(ddd.x + 1) * 10 + ddd.y].Background = new SolidColorBrush(Colors.White);
                                    if (!(ddd.x < 0 || (ddd.y - 1) < 0 || ddd.x > 9 || (ddd.y - 1) > 9))
                                        aibtnlist[ddd.x * 10 + (ddd.y - 1)].Background = new SolidColorBrush(Colors.White);
                                    if (!(ddd.x < 0 || (ddd.y + 1) < 0 || ddd.x > 9 || (ddd.y + 1) > 9))
                                        aibtnlist[ddd.x * 10 + (ddd.y + 1)].Background = new SolidColorBrush(Colors.White);

                                    if (!((ddd.x - 1) < 0 || (ddd.y - 1) < 0 || (ddd.x - 1) > 9 || (ddd.y - 1) > 9))
                                        aibtnlist[(ddd.x - 1) * 10 + (ddd.y - 1)].Background = new SolidColorBrush(Colors.White);
                                    if (!((ddd.x + 1) < 0 || (ddd.y + 1) < 0 || (ddd.x + 1) > 9 || (ddd.y + 1) > 9))
                                        aibtnlist[(ddd.x + 1) * 10 + (ddd.y + 1)].Background = new SolidColorBrush(Colors.White);
                                    if (!((ddd.x + 1) < 0 || (ddd.y - 1) < 0 || (ddd.x + 1) > 9 || (ddd.y - 1) > 9))
                                        aibtnlist[(ddd.x + 1) * 10 + (ddd.y - 1)].Background = new SolidColorBrush(Colors.White);
                                    if (!((ddd.x - 1) < 0 || (ddd.y + 1) < 0 || (ddd.x - 1) > 9 || (ddd.y + 1) > 9))
                                        aibtnlist[(ddd.x - 1) * 10 + (ddd.y + 1)].Background = new SolidColorBrush(Colors.White);

                                }
                                foreach (var ddd in AIBtlfl.shiplist[f].coordinateslist)
                                    aibtnlist[ddd.x * 10 + ddd.y].Background = new SolidColorBrush(Colors.Gray);
                            }
                        }
                    }
                }
                else aibtnlist[i * 10 + j].Background = new SolidColorBrush(Colors.White); // Если мимо, то окрашиваем в белый
                bool flagGameOver = true;
                foreach (var value in AIBtlfl.shiplist)
                    if (value.ShipState == ShipState.clear)
                        flagGameOver = false;
                if (flagGameOver)
                    MessageBox.Show("Вы победили!");
        }
    }
}
