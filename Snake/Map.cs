using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    internal partial class Map
    {
        const int x = 10;
        const int y = 10;
        int length;
        public int[,] MyMap { get; set; }
        public Map(string direction) { 
            MyMap = new int[y, x];
            length = 2;
            if(direction == "right") 
            {
                MyMap[5, 5] = 1;
                MyMap[5, 4] = 2;
                MyMap[5, 3] = 3;
            }
            else if (direction == "left") 
            {
                MyMap[4, 4] = 1;
                MyMap[4, 5] = 2;
                MyMap[4, 6] = 3;
            }
            else if (direction == "top") 
            {
                MyMap[5, 5] = 1;
                MyMap[4, 5] = 2;
                MyMap[3, 5] = 3;
            }
            else if (direction == "bottom") 
            {
                MyMap[4, 4] = 1;
                MyMap[5, 4] = 2;
                MyMap[6, 4] = 3;
            }
        }
    }
}
