using System;
using System.Timers;

namespace Snake
{
    internal class Program
    {
        static Map map;
        static void Main(string[] args)
        {
            Timer timer= new Timer();
            timer.Interval = 500;
            timer.Elapsed += StartGame;
            if(Console.ReadKey().Key == ConsoleKey.Spacebar) 
            {
                map = new Map(Direction.MyDirection);
                Direction.SetDirection();
                timer.Start();
            }
        }

        private static void StartGame(object sender, ElapsedEventArgs e)
        {
            if (!map.lose && !map.win)
                map.UpdateMap(Direction.MyDirection);
        }
    }
}
