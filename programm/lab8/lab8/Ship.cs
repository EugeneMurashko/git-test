using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab8
{
    class Ship
    {
        public List<Square> coordinateslist;
        //int length;
        int direction;

        public Ship(int _length, Direction _direction, Square _coordinates) 
        { 
            for(int i = 0; i < _length; i++)
            {
                Square s = new Square(_coordinates);
                s.Move(i, _direction);
                coordinateslist.Add(s);
            }
        }

    }
}
