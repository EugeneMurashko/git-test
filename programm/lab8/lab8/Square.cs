using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab8
{
    public struct Square
    {
        public int nship;
        public int state;
        public int[][] coordinates;

        public Square(NumShip ship, ShipState s, int[][] _coordinates)
        {
            coordinates = _coordinates;

            if (s == ShipState.clear)
                state = 0;
            else if (s == ShipState.miss)
                state = -1;
            else state = 1; // ShipState.hit

            if (ship == NumShip.four_ship)
                nship = 4;
            else if (ship == NumShip.three_ship_1)
                nship = 31;
            else if (ship == NumShip.three_ship_2)
                nship = 32;
            else if (ship == NumShip.double_ship_1)
                nship = 21;
            else if (ship == NumShip.double_ship_2)
                nship = 22;
            else if (ship == NumShip.double_ship_3)
                nship = 23;
            else if (ship == NumShip.single_ship_1)
                nship = 11;
            else if (ship == NumShip.single_ship_2)
                nship = 12;
            else if (ship == NumShip.single_ship_3)
                nship = 13;
            else if (ship == NumShip.single_ship_4)
                nship = 14;
            else nship = 0; // NumShip.empty
        }
        
        public Square(Square s)
        {
            nship = s.nship;
            state = s.state;
            coordinates = s.coordinates;
        }


        internal void Move(int i, Direction _direction)
        {
            
        }
    }

}
