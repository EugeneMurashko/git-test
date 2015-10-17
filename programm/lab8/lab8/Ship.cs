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
        public int hitpoint;

        public Ship(NumShip ship, Direction direction, Square coord) 
        {
            square = coord;
            int length;
            if ((int)ship == 1)
            {
                length = 4;
                hitpoint = 4;
            }
            else if ((int)ship > 1 && (int)ship <= 3)
            {
                length = 3;
                hitpoint = 3;
            }
            else if ((int)ship > 3 && (int)ship <= 6)
            {
                length = 2;
                hitpoint = 2;
            }
            else if ((int)ship > 6 && (int)ship <= 10)
            {
                length = 1;
                hitpoint = 1;
            }
            else
            {
                length = 0;
                hitpoint = 0;
            }
            
            
            for(int i = 0; i < length; i++)
            {
                Square s = new Square(coord.nship, coord.state, coord.x, coord.y);
                s.Move(i, direction);
                coordinateslist.Add(s);
            }
        }


    }
}
