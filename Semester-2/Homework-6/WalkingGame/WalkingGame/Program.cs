using System;
using System.Collections.Generic;

namespace WalkingGame
{
    /// <summary>
    /// Main part of the program where it all happens
    /// </summary>
    public class Program
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

        public static void Main(string[] args)
        {
            var loop = new EventLoop();
            var game = new Game(@"..\..\map.txt", false);
            DrawMap(game.Map);

            loop.DownHandler += game.OnDown;
            loop.UpHandler += game.OnUp;
            loop.LeftHandler += game.OnLeft;
            loop.RightHandler += game.OnRight;
            
            loop.Run();
        }
    }
}

