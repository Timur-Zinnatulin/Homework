using System;
using WalkingGame;
using NUnit.Framework;

namespace GameTests
{
    [TestFixture]
    public class GameTests
    {
        private Game game;
        private EventLoop loop;

        [SetUp]
        public void InitializeGame()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            path += "testmap.txt";
            loop = new EventLoop();
            game = new Game(path, true);

            loop.DownHandler += game.OnDown;
            loop.UpHandler += game.OnUp;
            loop.LeftHandler += game.OnLeft;
            loop.RightHandler += game.OnRight;
        }

        [Test]
        public void GameConstructorSucceedsTest()
            => Assert.IsTrue(game.FlagReadyToPlay);

        [Test]
        public void CharacterIsInPlaceTest()
        {
            Assert.AreEqual(1, game.Player.x);
            Assert.AreEqual(1, game.Player.y);
        }

        [Test]
        public void CharacterCanMoveTest()
        {
            loop.EmulatePress(ConsoleKey.DownArrow);
            Assert.AreEqual(2, game.Player.x);
            Assert.AreEqual(1, game.Player.y);
        }

        [Test]
        public void CharacterCanPerformManeuverTest()
        {
            loop.EmulatePress(ConsoleKey.DownArrow);
            loop.EmulatePress(ConsoleKey.RightArrow);
            loop.EmulatePress(ConsoleKey.UpArrow);
            loop.EmulatePress(ConsoleKey.LeftArrow);
            Assert.AreEqual(1, game.Player.x);
            Assert.AreEqual(1, game.Player.y);
        }
    }
}