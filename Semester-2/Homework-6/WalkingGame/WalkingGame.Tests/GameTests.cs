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
            => Assert.IsTrue(game.IsReadyToPlay);

        [Test]
        public void CharacterIsInPlaceTest()
        {
            Assert.AreEqual(3, game.Player.X);
            Assert.AreEqual(7, game.Player.Y);
        }

        [Test]
        public void CharacterCanMoveDownTest()
        {
            loop.EmulatePress(ConsoleKey.DownArrow);
            Assert.AreEqual(4, game.Player.X);
            Assert.AreEqual(7, game.Player.Y);
        }

        [Test]
        public void CharacterCanMoveRightTest()
        {
            loop.EmulatePress(ConsoleKey.RightArrow);
            Assert.AreEqual(3, game.Player.X);
            Assert.AreEqual(8, game.Player.Y);
        }

        [Test]
        public void CharacterCanMoveUpTest()
        {
            loop.EmulatePress(ConsoleKey.UpArrow);
            Assert.AreEqual(2, game.Player.X);
            Assert.AreEqual(7, game.Player.Y);
        }

        [Test]
        public void CharacterCanMoveLeftTest()
        {
            loop.EmulatePress(ConsoleKey.LeftArrow);
            Assert.AreEqual(3, game.Player.X);
            Assert.AreEqual(6, game.Player.Y);
        }

        [Test]
        public void NothingDoneOnEnterTest()
        {
            loop.EmulatePress(ConsoleKey.Enter);
            Assert.AreEqual(3, game.Player.X);
            Assert.AreEqual(7, game.Player.Y);
        }

        [Test]
        public void DoesntGoThroughLeftWallTest()
        {
            for (int i = 0; i < 100; ++i)
            {
                loop.EmulatePress(ConsoleKey.LeftArrow);
            }
            Assert.AreEqual(1, game.Player.Y);
        }

        [Test]
        public void DoesntGoThroughRightWallTest()
        {
            for (int i = 0; i < 100; ++i)
            {
                loop.EmulatePress(ConsoleKey.RightArrow);
            }
            Assert.AreEqual(11, game.Player.Y);
        }

        [Test]
        public void DoesntGoThroughTopWallTest()
        {
            for (int i = 0; i < 100; ++i)
            {
                loop.EmulatePress(ConsoleKey.UpArrow);
            }
            Assert.AreEqual(1, game.Player.X);
        }

        [Test]
        public void DoesntGoThroughBottomWallTest()
        {
            for (int i = 0; i < 100; ++i)
            {
                loop.EmulatePress(ConsoleKey.DownArrow);
            }
            Assert.AreEqual(4, game.Player.X);
        }

        [Test]
        public void CharacterCanPerformManeuverTest()
        {
            loop.EmulatePress(ConsoleKey.DownArrow);
            loop.EmulatePress(ConsoleKey.RightArrow);
            loop.EmulatePress(ConsoleKey.UpArrow);
            loop.EmulatePress(ConsoleKey.LeftArrow);
            Assert.AreEqual(3, game.Player.X);
            Assert.AreEqual(7, game.Player.Y);
        }
    }
}