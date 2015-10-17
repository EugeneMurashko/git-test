using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;

namespace lab8.v3
{
    class Square
    {
        public int x;
        public int y;
        public StateSquare statesquare;
        public string whatshipiam = "not";

        public Square(int x, int y)
        {
            this.x = x;
            this.y = y;
            statesquare = StateSquare.clear;
        }
        
        public void Draw(List<Button> blist)
        {
            if(statesquare == StateSquare.clear)
                blist[x * 10 + y].Background = new SolidColorBrush(Colors.LightBlue);
            else
                blist[x * 10 + y].Background = new SolidColorBrush(Colors.White);
        }


        public void Draw(List<Button> blist, SolidColorBrush SCBrush) // перегруженный метод для отрисовки караблей
        {
            blist[x * 10 + y].Background = SCBrush;
        }

        public void Move(int i, Direction direction)
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
