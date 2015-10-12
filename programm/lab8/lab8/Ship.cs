using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab8
{
    class Ship
    {
        public List<Square> coordinateslist = new List<Square>();
        public ShipState ShipState = ShipState.clear;
        public Square square;

        public Ship(NumShip ship, Direction direction, Square coord) 
        {
            square = coord;
            int length;
            if (ship == NumShip.four_ship)
                length = 4;
            else if (ship == NumShip.three_ship_1)
                length = 3;
            else if (ship == NumShip.three_ship_2)
                length = 3;
            else if (ship == NumShip.double_ship_1)
                length = 2;
            else if (ship == NumShip.double_ship_2)
                length = 2;
            else if (ship == NumShip.double_ship_3)
                length = 2;
            else if (ship == NumShip.single_ship_1)
                length = 1;
            else if (ship == NumShip.single_ship_2)
                length = 1;
            else if (ship == NumShip.single_ship_3)
                length = 1;
            else if (ship == NumShip.single_ship_4)
                length = 1;
            else length = 0; // NumShip.empty

            for(int i = 0; i < length; i++)
            {
                Square s = new Square(coord.nship, coord.state, coord.x, coord.y);
                s.Move(i, direction);
                coordinateslist.Add(s);
            }
        }


    }
}
