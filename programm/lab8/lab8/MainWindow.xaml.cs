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
        List<Button> btnlist = new List<Button>();            // здесь будем хранить все наши кнопки, чтобы проще было к ним обращаться
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


            /*int i = 0;
            foreach (var value in AIBtlfl.squareArr)
            {
                if (value.nship != 0)
                    btnlist[i].Background = new SolidColorBrush(Colors.Red);
                i++;
            }*/

            
                
                
        }



        private void img_MouseUp(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Regex regex = new Regex(@"\d");

            try
            {
                int i = Int32.Parse(regex.Matches(btn.Name.ToString())[0].ToString());
                int j = Int32.Parse(regex.Matches(btn.Name.ToString())[1].ToString());

                if (AIBtlfl.squareArr[i, j].nship != 0) // Координаты по которым мы стреляли
                {
                    btnlist[i * 10 + j].Background = new SolidColorBrush(Colors.Red);
                    AIBtlfl.squareArr[i, j].state = 1;
                     
                    /*int x = Int32.Parse(regex.Matches(AIBtlfl.squareArr[i, j].nship.ToString())[0].ToString()); // Здесь мы нашли номер корабля
                    int y = Int32.Parse(regex.Matches(AIBtlfl.squareArr[i, j].nship.ToString())[1].ToString());*/

                    /*if (AIBtlfl.squareArr[i, j].nship == 41)
                        //AIBtlfl.shiplist[0].coordinateslist[i * 10 + j].state = 1;
                        for (int g = 0; g < AIBtlfl.shiplist[0].coordinateslist.Count; g++)
                            if (AIBtlfl.shiplist[0].coordinateslist[g].x == i && AIBtlfl.shiplist[0].coordinateslist[g].y == j)
                                AIBtlfl.shiplist[0].coordinateslist[g].state = 1;
                         */                    
                    /*
                    bool flag = true;
                    foreach (var ship in AIBtlfl.shiplist)
                        foreach (var square in ship.coordinateslist)
                            if (square.x == i && square.y == j) // Нашли корабль.
                            {
                                foreach (var ddd in ship.coordinateslist) // тут мы перебираем все координаты нашего корабля
                                    if (ddd.state != 1)
                                        flag = false;
                            }
                    if (flag)
                        MessageBox.Show("Полностью убит!");

                    /*
                     foreach (var ddd in ship.coordinateslist)
                        btnlist[ddd.x * 10 + ddd.y].Background = new SolidColorBrush(Colors.Red);
                     */

                }
                    
                
            }
            catch (FormatException)
            {
                MessageBox.Show("Регулярка не привелась в число.");
            }
            
          

            


        }
        


    }
}
