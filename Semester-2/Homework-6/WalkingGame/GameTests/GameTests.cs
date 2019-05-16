using System;
using WalkingGame;
using NUnit.Framework;

namespace GameTests
{
    [TestFixture]
    public class GameTests
    {
        Game game;
        EventLoop loop;

        [SetUp]
        public void InitializeGame()
        {
            game = new Game(@"..\..\map.txt", true);
            loop = new EventLoop();
        }


    }
}
