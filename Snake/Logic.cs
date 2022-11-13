using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    internal partial class Map
    {
        bool updatefood = false;
        int posX = 0;
        int posY = 0;
        public bool lose = false;
        public bool win = false;
        private void DrawMap()
        {
            Console.Clear();
            Console.WriteLine(new string('#', MyMap.GetLength(0)));
            for (int i = 0; i < MyMap.GetLength(0); i++)
            {
                Console.Write("#");
                for (int j = 0; j < MyMap.GetLength(1); j++)
                {
                    if (MyMap[i, j] == -1)
                        Console.Write("$");
                    if (MyMap[i, j] > 1 && MyMap[i, j] < length)
                        Console.Write("๏");
                    if (MyMap[i,j] == 1)
                    Console.Write("*");
                    if (MyMap[i, j] == length + 1 && MyMap[i, j] == 0)
                        Console.Write(" ");

                }
                Console.WriteLine("#");
            }
        }
        private void MoveSnake(string direction) 
        {
            if (direction == "right")
            {
                for (int i = 0; i < MyMap.GetLength(0); i++)
                {
                    for (int j = 0; j < MyMap.GetLength(1); j++)
                    {
                        if (MyMap[i, j] == 1 & (j >= MyMap.GetLength(1) - 1 || MyMap[i, j + 1] >= 1))
                        {
                            lose = true;
                            YouLose();
                        }
                        if (MyMap[i, j] == 1 & j < MyMap.GetLength(1)-1)
                        {
                            posY = i;
                            posX = j + 1;
                            if (MyMap[i, j + 1] == -1)
                            {
                                length += 1;
                                if (length == 100)
                                {
                                    win = true;
                                    YouWin();
                                }
                                updatefood = true;
                            }
                            MyMap[i, j + 1] = 1;
                        }
                    }
                }
            }
            if (direction == "left")
            {
                for (int i = 0; i < MyMap.GetLength(0); i++)
                {
                    for (int j = 0; j < MyMap.GetLength(1); j++)
                    {
                        if (MyMap[i, j] == 1 & (j == 0 || MyMap[i, j - 1] >= 1))
                        {
                            lose = true;
                            YouLose();
                        }
                        if (MyMap[i, j] == 1 & j > 0)
                        {
                            posY = i;
                            posX = j - 1;
                            if (MyMap[i, j - 1] == -1)
                            {
                                length += 1;
                                if (length == 100)
                                {
                                    win = true;
                                    YouWin();
                                }
                                updatefood = true;
                            }
                            MyMap[i, j - 1] = 1;
                        }
                    }
                }
            }
            if (direction == "top")
            {
                for (int i = 0; i < MyMap.GetLength(0); i++)
                {
                    for (int j = 0; j < MyMap.GetLength(1); j++)
                    {
                        if (MyMap[i, j] == 1 & (i == 0 || MyMap[i - 1, j] >= 1))
                        {
                            lose = true;
                            YouLose();
                        }
                        if (MyMap[i, j] == 1 & i > 0)
                        {
                            posY = i - 1;
                            posX = j;
                            if (MyMap[i - 1, j] == -1)
                            {
                                length += 1;
                                if (length == 100)
                                {
                                    win = true;
                                    YouWin();
                                }
                                updatefood = true;
                            }
                            MyMap[i - 1, j] = 1;
                        }
                    }
                }
            }
            if (direction == "bottom")
            {
                for (int i = 0; i < MyMap.GetLength(0); i++)
                {
                    for (int j = 0; j < MyMap.GetLength(1); j++)
                    {
                        if (MyMap[i, j] == 1 & (i >= MyMap.GetLength(1) - 1 || MyMap[i + 1, j] >= 1))
                        {
                            lose = true;
                            YouLose();
                        }
                        if (MyMap[i, j] == 1 & i < MyMap.GetLength(1) - 1)
                        {
                            posY = i + 1;
                            posX = j;
                            if (MyMap[i + 1, j] == -1)
                            {
                                length += 1;
                                if (length == 100)
                                {
                                    win = true;
                                    YouWin();
                                }
                                updatefood = true;
                            }
                            MyMap[i + 1, j] = 1;
                        }
                    }
                }
            }
        }
        public void UpdateMap(string direction)
        {
            MoveSnake(direction);
            if (!lose && !win)
            {
                for (int i = 0; i < MyMap.GetLength(0); i++)
                {
                    for (int j = 0; j < MyMap.GetLength(1); j++)
                    {
                        if (MyMap[i, j] >= 1 && i != posY && j != posX)
                        {
                            MyMap[i, j] += 1;
                        }
                    }
                }
                if (updatefood)
                {
                    CreateFood();
                    updatefood = false;
                }
                DrawMap();
            }
        }
        private void YouLose()
        {
            Console.Clear();
            Console.Write(
                "\r\n─────────────────────────────────────────────────────────────────────────────────────────────────────────────────\r\n─████████──████████─██████████████─██████──██████────██████─────────██████████████─██████████████─██████████████─\r\n─██░░░░██──██░░░░██─██░░░░░░░░░░██─██░░██──██░░██────██░░██─────────██░░░░░░░░░░██─██░░░░░░░░░░██─██░░░░░░░░░░██─\r\n─████░░██──██░░████─██░░██████░░██─██░░██──██░░██────██░░██─────────██░░██████░░██─██░░██████████─██░░██████████─\r\n───██░░░░██░░░░██───██░░██──██░░██─██░░██──██░░██────██░░██─────────██░░██──██░░██─██░░██─────────██░░██─────────\r\n───████░░░░░░████───██░░██──██░░██─██░░██──██░░██────██░░██─────────██░░██──██░░██─██░░██████████─██░░██████████─\r\n─────████░░████─────██░░██──██░░██─██░░██──██░░██────██░░██─────────██░░██──██░░██─██░░░░░░░░░░██─██░░░░░░░░░░██─\r\n───────██░░██───────██░░██──██░░██─██░░██──██░░██────██░░██─────────██░░██──██░░██─██████████░░██─██░░██████████─\r\n───────██░░██───────██░░██──██░░██─██░░██──██░░██────██░░██─────────██░░██──██░░██─────────██░░██─██░░██─────────\r\n───────██░░██───────██░░██████░░██─██░░██████░░██────██░░██████████─██░░██████░░██─██████████░░██─██░░██████████─\r\n───────██░░██───────██░░░░░░░░░░██─██░░░░░░░░░░██────██░░░░░░░░░░██─██░░░░░░░░░░██─██░░░░░░░░░░██─██░░░░░░░░░░██─\r\n───────██████───────██████████████─██████████████────██████████████─██████████████─██████████████─██████████████─\r\n─────────────────────────────────────────────────────────────────────────────────────────────────────────────────");
        }
        private void YouWin()
        {
            Console.Clear();
            Console.Write("░█████╗░░█████╗░███╗░░██╗░██████╗░██████╗░░█████╗░████████╗██╗░░░██╗██╗░░░░░░█████╗░████████╗██╗░█████╗░███╗░░██╗░██████╗██╗██╗\r\n██╔══██╗██╔══██╗████╗░██║██╔════╝░██╔══██╗██╔══██╗╚══██╔══╝██║░░░██║██║░░░░░██╔══██╗╚══██╔══╝██║██╔══██╗████╗░██║██╔════╝██║██║\r\n██║░░╚═╝██║░░██║██╔██╗██║██║░░██╗░██████╔╝███████║░░░██║░░░██║░░░██║██║░░░░░███████║░░░██║░░░██║██║░░██║██╔██╗██║╚█████╗░██║██║\r\n██║░░██╗██║░░██║██║╚████║██║░░╚██╗██╔══██╗██╔══██║░░░██║░░░██║░░░██║██║░░░░░██╔══██║░░░██║░░░██║██║░░██║██║╚████║░╚═══██╗╚═╝╚═╝\r\n╚█████╔╝╚█████╔╝██║░╚███║╚██████╔╝██║░░██║██║░░██║░░░██║░░░╚██████╔╝███████╗██║░░██║░░░██║░░░██║╚█████╔╝██║░╚███║██████╔╝██╗██╗\r\n░╚════╝░░╚════╝░╚═╝░░╚══╝░╚═════╝░╚═╝░░╚═╝╚═╝░░╚═╝░░░╚═╝░░░░╚═════╝░╚══════╝╚═╝░░╚═╝░░░╚═╝░░░╚═╝░╚════╝░╚═╝░░╚══╝╚═════╝░╚═╝╚═╝\r\n\r\n██╗░░░██╗░█████╗░██╗░░░██╗  ░██╗░░░░░░░██╗██╗███╗░░██╗\r\n╚██╗░██╔╝██╔══██╗██║░░░██║  ░██║░░██╗░░██║██║████╗░██║\r\n░╚████╔╝░██║░░██║██║░░░██║  ░╚██╗████╗██╔╝██║██╔██╗██║\r\n░░╚██╔╝░░██║░░██║██║░░░██║  ░░████╔═████║░██║██║╚████║\r\n░░░██║░░░╚█████╔╝╚██████╔╝  ░░╚██╔╝░╚██╔╝░██║██║░╚███║\r\n░░░╚═╝░░░░╚════╝░░╚═════╝░  ░░░╚═╝░░░╚═╝░░╚═╝╚═╝░░╚══╝");
        }
        private void CreateFood()
        {
            Random random = new Random();
            while (true)
            {
                int _x = random.Next(0, x);
                int _y = random.Next(0, y);
                if (MyMap[_y, _x] == 0)
                {
                    MyMap[_y, _x] = -1;
                    break;
                }
            }
        }
    }
}
