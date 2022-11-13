using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Snake
{
    internal static class Direction
    {
        public static string MyDirection { get; set; } = "right";
        public static void SetDirection()
        {
            Thread thread = new Thread(() =>
            {
                while(true)
                {
                    string key = Console.ReadKey().Key.ToString();
                    if (key == "UpArrow")
                    {
                        MyDirection = "top";
                    }
                    else if (key == "DownArrow")
                    {
                        MyDirection = "bottom";
                    }
                    else if (key == "RightArrow")
                    {
                        MyDirection = "right";
                    }
                    else if (key == "LeftArrow")
                    {
                        MyDirection = "left";
                    }
                }
            });
            thread.Start();
        }
    }
}
