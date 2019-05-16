using System;

namespace WalkingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var loop = new EventLoop();
            var game = new Game(@"..\..\map.txt");

            loop.DownHandler += game.OnDown;
            loop.UpHandler += game.OnUp;
            loop.LeftHandler += game.OnLeft;
            loop.RightHandler += game.OnRight;

            loop.Run();
        }
    }
}
