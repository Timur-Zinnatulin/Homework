using System;
using System.IO;
using System.Collections.Generic;

namespace WalkingGame
{
    class Program
    {
        /// <summary>
        /// Render map function
        /// </summary>
        private static void DrawMap(List<string> map)
        {
            Console.Clear();
            for (int i = 0; i < map.Count; ++i)
            {
                Console.WriteLine(map[i]);
            }
            Console.CursorVisible = false;
        }


        static void Main(string[] args)
        {
            var loop = new EventLoop();
            var game = new Game(@"..\..\map.txt", false);
            var map = game.Map;
            DrawMap(map);

            loop.DownHandler += game.OnDown;
            loop.UpHandler += game.OnUp;
            loop.LeftHandler += game.OnLeft;
            loop.RightHandler += game.OnRight;

            loop.Run();
        }
    }
}
