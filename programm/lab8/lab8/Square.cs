using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab8
{
    // вся информация о квадрате. Есть ли тут корабль. Какой он имеенно. Ранен или потоплен.
    public struct Square
    {
        public int nship;
        public int state;
        public int x;
        public int y;

        public Square(NumShip ship, ShipState s, int x, int y)
        {
            this.x = x;
            this.y = y;

            if (s == ShipState.clear)
                state = 0;
            else if (s == ShipState.miss)
                state = -1;
            else state = 1; // ShipState.hit
            
            if (ship == NumShip.four_ship)
                nship = 41;
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

        public Square(int nship, ShipState s, int x, int y)
        {
            this.x = x;
            this.y = y;

            if (s == ShipState.clear)
                state = 0;
            else if (s == ShipState.miss)
                state = -1;
            else state = 1; // ShipState.hit

            this.nship = nship;
        }

        public Square(int nship, int state, int x, int y)
        {
            this.nship = nship;
            this.state = state;
            this.x = x;
            this.y = y;
        }
        
        internal void Move(int i, Direction direction)
        {
                if (direction == Direction.left)
                    x -= i;
                else if (direction == Direction.right)
                    x += i;
                else if (direction == Direction.up)
                    y += i;
                else // Direction.down
                   y -= i;
        }
    }

}
