using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab8.v3
{
    class Battlefiel
    {
        public Square[,] squareArr = new Square[10, 10];
        public SortedList<string, Ship> shiplist = new SortedList<string, Ship>();
        private bool flagGoodEmptyCount = false;
        private string whose;

        public Battlefiel(int difficulty, string whose)
        {
            this.whose = whose;
            do
            {
                // обновляем доску пустыми клетками
                Clear();
                // размещаем корабли
                ArrangeShips(difficulty);
            }
            while (!flagGoodEmptyCount);
        }

        private void ArrangeShips(int difficulty)
        {
            flagGoodEmptyCount = false;
            Random rnd = new Random();
            Ship shp;

            foreach (var value in Enum.GetValues(typeof(ShipNumber)))
            {
                if ((ShipNumber)value == ShipNumber.single_ship_1)
                {
                    EmptyCount(difficulty);
                    if (flagGoodEmptyCount == false)
                        return; // вернуться если не достаточно свободного места
                }
                while (true)
                {
                    shp = new Ship((ShipNumber)value, (Direction)rnd.Next(4), (int)rnd.Next(10), (int)rnd.Next(10), whose);
                    if (CheckingSpace(shp))
                    {
                        shiplist.Add(value.ToString(), shp);
                        foreach (var hull in shp.hullship)
                        {
                            squareArr[hull.Value.x, hull.Value.y] = hull.Value; // связали квадраты в карабле и в списке поля. Тем самым они оба указывают на одни и те же данные
                            squareArr[hull.Value.x, hull.Value.y].whatshipiam = value.ToString();
                        }
                            
                        break;

                    }
                }
            }

        }

        private bool CheckingSpace(Ship shp)
        {
            foreach (var hull in shp.hullship)
            {
                // x y
                if (hull.Value.x >= 0 && hull.Value.x < 10 && hull.Value.y >= 0 && hull.Value.y < 10)
                {
                        if (squareArr[hull.Value.x, hull.Value.y].whatshipiam != "not")
                            return false;
                }
                else return false;

                // x-1 y
                if (hull.Value.x - 1 >= 0 && hull.Value.x - 1 < 10 && hull.Value.y >= 0 && hull.Value.y < 10)
                {
                        if (squareArr[hull.Value.x - 1, hull.Value.y].whatshipiam != "not")
                            return false;
                }

                // x+1 y
                if (hull.Value.x + 1 >= 0 && hull.Value.x + 1 < 10 && hull.Value.y >= 0 && hull.Value.y < 10)
                {
                        if (squareArr[hull.Value.x + 1, hull.Value.y].whatshipiam != "not")
                            return false;
                }

                // x y-1
                if (hull.Value.x >= 0 && hull.Value.x < 10 && hull.Value.y - 1 >= 0 && hull.Value.y - 1 < 10)
                {
                        if (squareArr[hull.Value.x, hull.Value.y - 1].whatshipiam != "not")
                            return false;
                }

                // x y+1
                if (hull.Value.x >= 0 && hull.Value.x < 10 && hull.Value.y + 1 >= 0 && hull.Value.y + 1 < 10)
                {
                        if (squareArr[hull.Value.x, hull.Value.y + 1].whatshipiam != "not")
                            return false;
                }

                // x+1 y+1
                if (hull.Value.x + 1 >= 0 && hull.Value.x + 1 < 10 && hull.Value.y + 1 >= 0 && hull.Value.y + 1 < 10)
                {
                        if (squareArr[hull.Value.x + 1, hull.Value.y + 1].whatshipiam != "not")
                            return false;
                }

                // x+1 y-1
                if (hull.Value.x + 1 >= 0 && hull.Value.x + 1 < 10 && hull.Value.y - 1 >= 0 && hull.Value.y - 1 < 10)
                {
                        if (squareArr[hull.Value.x + 1, hull.Value.y - 1].whatshipiam != "not")
                            return false;
                }

                // x-1 y+1
                if (hull.Value.x - 1 >= 0 && hull.Value.x - 1 < 10 && hull.Value.y + 1 >= 0 && hull.Value.y + 1 < 10)
                {
                        if (squareArr[hull.Value.x - 1, hull.Value.y + 1].whatshipiam != "not")
                            return false;
                }

                // x-1 y-1
                if (hull.Value.x - 1 >= 0 && hull.Value.x - 1 < 10 && hull.Value.y - 1 >= 0 && hull.Value.y - 1 < 10)
                {
                        if (squareArr[hull.Value.x - 1, hull.Value.y - 1].whatshipiam != "not")
                            return false;
                }
            }
            return true;
        }

        private void EmptyCount(int difficulty)
        {
            int col = 0;
            foreach (var square in squareArr)
            {
                // x y
                if (square.x < 0 || square.x > 9 || square.y < 0 || square.y > 9)
                    continue;

                if (squareArr[square.x, square.y].whatshipiam != "not")
                    continue;

                // x-1 y
                if (square.x - 1 >= 0 && square.x - 1 < 10 && square.y >= 0 && square.y < 10)
                    if (squareArr[square.x - 1, square.y].whatshipiam != "not")
                        continue;

                // x+1 y
                if (square.x + 1 >= 0 && square.x + 1 < 10 && square.y >= 0 && square.y < 10)
                    if (squareArr[square.x + 1, square.y].whatshipiam != "not")
                        continue;

                // x y-1
                if (square.x >= 0 && square.x < 10 && square.y - 1 >= 0 && square.y - 1 < 10)
                    if (squareArr[square.x, square.y - 1].whatshipiam != "not")
                        continue;

                // x y+1
                if (square.x >= 0 && square.x < 10 && square.y + 1 >= 0 && square.y + 1 < 10)
                    if (squareArr[square.x, square.y + 1].whatshipiam != "not")
                        continue;

                // x-1 y-1
                if (square.x - 1 >= 0 && square.x - 1 < 10 && square.y - 1 >= 0 && square.y - 1 < 10)
                    if (squareArr[square.x - 1, square.y - 1].whatshipiam != "not")
                        continue;

                // x-1 y+1
                if (square.x - 1 >= 0 && square.x - 1 < 10 && square.y + 1 >= 0 && square.y + 1 < 10)
                    if (squareArr[square.x - 1, square.y + 1].whatshipiam != "not")
                        continue;

                // x+1 y-1
                if (square.x + 1 >= 0 && square.x + 1 < 10 && square.y - 1 >= 0 && square.y - 1 < 10)
                    if (squareArr[square.x + 1, square.y - 1].whatshipiam != "not")
                        continue;

                // x+1 y+1
                if (square.x + 1 >= 0 && square.x + 1 < 10 && square.y + 1 >= 0 && square.y + 1 < 10)
                    if (squareArr[square.x + 1, square.y + 1].whatshipiam != "not")
                        continue;

                col++;
            }
            if (col >= difficulty)
                flagGoodEmptyCount = true;
        }

        private void Clear()
        {
            shiplist.Clear();
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                {
                    squareArr[i, j] = new Square(i, j);
                }
        }



    }
}
