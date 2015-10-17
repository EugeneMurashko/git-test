using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows.Controls;

namespace lab8.v3
{
    class Ship
    {
        public SortedList<string, Square> hullship = new SortedList<string, Square>();
        public StateShip stateship;
        public int hitpoint;
        private string whose;

        public Direction d; // kill me

        public Ship(ShipNumber shipnumber, Direction direction, int x, int y, string whose)
        {
            d = direction; // kill me
            this.whose = whose;
            stateship = StateShip.clear;
            if (shipnumber == ShipNumber.four_ship)
                hitpoint = 4;
            else if (shipnumber == ShipNumber.three_ship_1 || shipnumber == ShipNumber.three_ship_2)
                hitpoint = 3;
            else if (shipnumber == ShipNumber.double_ship_1 || shipnumber == ShipNumber.double_ship_2 || shipnumber == ShipNumber.double_ship_3)
                hitpoint = 2;
            else if (shipnumber == ShipNumber.single_ship_1 || shipnumber == ShipNumber.single_ship_2 || shipnumber == ShipNumber.single_ship_3 || shipnumber == ShipNumber.single_ship_4)
                hitpoint = 1;
            for (int i = 0; i < hitpoint; i++)
            {
                Square s = new Square(x, y);
                s.Move(i, direction);
                hullship.Add("" + s.x + s.y, s);
            }
        }

        public void Draw(List<Button> btlist) // отрисует только в том случае, если корабль повредили. // не знаю как этот метод расширить еще и для нашего поля.
        {
            if(whose == "AI")
                foreach(var hull in hullship)
                {
                    if(hull.Value.statesquare == StateSquare.shot)
                        hull.Value.Draw(btlist, new SolidColorBrush(Colors.Red));
                }
            else if (whose == "Our")
                foreach (var hull in hullship)
                {
                    if (hull.Value.statesquare == StateSquare.clear)
                        hull.Value.Draw(btlist, new SolidColorBrush(Colors.Blue));
                    else if (hull.Value.statesquare == StateSquare.shot)
                        hull.Value.Draw(btlist, new SolidColorBrush(Colors.Red));
                }
        }
    }
}
