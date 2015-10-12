using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace lab8
{
    class Battlefiel
    {
        public Square[,] squareArr = new Square[10, 10];
        public List<Ship> shiplist;
        public bool flagGoodEmptyCount = false;

        public Battlefiel()
        {
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++) 
                {
                    squareArr[i, j] = new Square();
                    squareArr[i, j].x = i;
                    squareArr[i, j].y = j;
                }
                    

        }

        public void ArrangeShips(int complexity)
        {
            shiplist = new List<Ship>();// по делу оно не тут должно быть
            Random rnd = new Random();
            Ship shp;
                foreach (var value in Enum.GetValues(typeof(NumShip)))
                {
                    if ((NumShip)value == NumShip.empty)
                        break;
                    if ((NumShip)value == NumShip.single_ship_1)
                        EmptyCount(complexity);
                    while (true)
                    {
                        shp = new Ship((NumShip)value, (Direction)rnd.Next(4), new Square((NumShip)value, ShipState.clear, (int)rnd.Next(10), (int)rnd.Next(10)));
                        if (CheckingSpace(shp)) 
                        {
                            shiplist.Add(shp);
                            for (int i = 0; i < shp.coordinateslist.Count; i++)
                                squareArr[shp.coordinateslist[i].x, shp.coordinateslist[i].y] = shp.coordinateslist[i];
                                break;

                        }
                    }
                }
        }

        public bool CheckingSpace(Ship s)
        {
            int pre_x = -1;
            int pre_y = -1;
            foreach (var value in s.coordinateslist)
            {

                if (!(value.x < 0 || value.x > 9 || value.y < 0 || value.y > 9)) 
                {
                    if (squareArr[value.x, value.y].nship != 0)
                        return false;
                }
                else return false;

                if (!(value.x - 1 < 0 || value.x - 1 > 9 || value.y < 0 || value.y > 9))
                {
                    if (value.x - 1 != pre_x && value.y != pre_y)
                        if (squareArr[value.x - 1, value.y].nship != 0)
                            return false;
                }
                

                if (!(value.x + 1 < 0 || value.x + 1 > 9 || value.y < 0 || value.y > 9))
                { 
                    if (value.x + 1 != pre_x && value.y != pre_y)
                        if (squareArr[value.x + 1, value.y].nship != 0)
                            return false;
                }
                

                if (!(value.x < 0 || value.x > 9 || value.y + 1 < 0 || value.y + 1 > 9))
                { 
                    if (value.x != pre_x && value.y + 1 != pre_y)
                        if (squareArr[value.x, value.y + 1].nship != 0)
                            return false;
                }
                

                if (!(value.x < 0 || value.x > 9 || value.y - 1 < 0 || value.y - 1 > 9))
                { 
                    if (value.x != pre_x && value.y - 1 != pre_y)
                        if (squareArr[value.x, value.y - 1].nship != 0)
                            return false;
                }
                

                if (!(value.x - 1 < 0 || value.x - 1 > 9 || value.y - 1 < 0 || value.y - 1 > 9))
                { 
                    if (value.x - 1 != pre_x && value.y - 1 != pre_y)
                        if (squareArr[value.x - 1, value.y - 1].nship != 0)
                            return false;
                }
                

                if (!(value.x + 1 < 0 || value.x + 1 > 9 || value.y + 1 < 0 || value.y + 1 > 9))
                { 
                    if (value.x + 1 != pre_x && value.y + 1 != pre_y)
                        if (squareArr[value.x + 1, value.y + 1].nship != 0)
                            return false;
                }
                

                if (!(value.x - 1 < 0 || value.x - 1 > 9 || value.y + 1 < 0 || value.y + 1 > 9))
                { 
                    if (value.x - 1 != pre_x && value.y + 1 != pre_y)
                        if (squareArr[value.x - 1, value.y + 1].nship != 0)
                            return false;
                }
                

                if (!(value.x + 1 < 0 || value.x + 1 > 9 || value.y - 1 < 0 || value.y - 1 > 9))
                { 
                    if (value.x + 1 != pre_x && value.y - 1 != pre_y)
                        if (squareArr[value.x + 1, value.y - 1].nship != 0)
                            return false;
                }
                

                pre_x = value.x;
                pre_y = value.y;

            }
           return true;
        }

        public void Clear()
        {
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                {
                    squareArr[i, j] = new Square();
                    squareArr[i, j].x = i;
                    squareArr[i, j].y = j;
                }
        }

        internal void EmptyCount(int complexity)
        {
            int col = 0;
            foreach (var value in squareArr)
            {
                if (value.x < 0 || value.x > 9 || value.y < 0 || value.y > 9)
                    continue;

                if (squareArr[value.x, value.y].nship != 0)
                    continue;

                if (!(value.x - 1 < 0 || value.x - 1 > 9 || value.y < 0 || value.y > 9))
                    if (squareArr[value.x - 1, value.y].nship != 0)
                    continue;
                    
                if (!(value.x + 1 < 0 || value.x + 1 > 9 || value.y < 0 || value.y > 9))
                    if (squareArr[value.x + 1, value.y].nship != 0)
                    continue;

                if (!(value.x < 0 || value.x > 9 || value.y + 1 < 0 || value.y + 1 > 9))
                    if (squareArr[value.x, value.y + 1].nship != 0)
                    continue;

                if (!(value.x < 0 || value.x > 9 || value.y - 1 < 0 || value.y - 1 > 9))
                    if (squareArr[value.x, value.y - 1].nship != 0)
                    continue;

                if (!(value.x - 1 < 0 || value.x - 1 > 9 || value.y - 1 < 0 || value.y - 1 > 9))
                    if (squareArr[value.x - 1, value.y - 1].nship != 0)
                    continue;

                if (!(value.x + 1 < 0 || value.x + 1 > 9 || value.y + 1 < 0 || value.y + 1 > 9))
                    if (squareArr[value.x + 1, value.y + 1].nship != 0)
                    continue;

                if (!(value.x - 1 < 0 || value.x - 1 > 9 || value.y + 1 < 0 || value.y + 1 > 9))
                    if (squareArr[value.x - 1, value.y + 1].nship != 0)
                    continue;

                if (!(value.x + 1 < 0 || value.x + 1 > 9 || value.y - 1 < 0 || value.y - 1 > 9))
                    if (squareArr[value.x + 1, value.y - 1].nship != 0)
                    continue;

                col++;
            }
            if(col >= complexity)
                flagGoodEmptyCount = true;
        }
    }
}
