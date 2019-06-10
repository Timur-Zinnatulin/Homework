using System;
using TestGame;
using NUnit.Framework;

namespace GameLogicTests
{
    [TestFixture]
    public class GameTests
    {
        private GameLogic game;

        [SetUp]
        public void SetUp()
        {
            game = new GameLogic();
        }

        [Test]
        public void NobodyWinsAtStart()
        {
            Assert.AreEqual(0, game.CheckForWin());
        }

        [Test]
        public void CrossStartsTest()
        {
            Assert.AreEqual(GameLogic.GameState.Cross, game.State);
        }

        [Test]
        public void CanPerformFirstMove()
        {
            game.PerformMove(0, 1);
            Assert.AreEqual('X', game.Map[0, 1]);
        }

        [Test]
        public void CircleMovesAfterCross()
        {
            game.PerformMove(0, 1);
            Assert.AreEqual(GameLogic.GameState.Circle, game.State);
        }

        [Test]
        public void CannotPresSameButtonTwiceTest()
        {
            game.PerformMove(0, 1);
            game.PerformMove(0, 1);
            Assert.AreEqual(GameLogic.GameState.Circle, game.State);
        }

        [Test]
        public void CrossMovesAfterCircle()
        {
            game.PerformMove(0, 1);
            game.PerformMove(0, 2);
            Assert.AreEqual(GameLogic.GameState.Cross, game.State);
        }

        [Test]
        public void RowCanWin()
        {
            game.PerformMove(0, 0);
            game.PerformMove(1, 0);
            game.PerformMove(0, 1);
            game.PerformMove(1, 1);
            game.PerformMove(0, 2);
            Assert.AreEqual(1, game.CheckForWin());
        }

        [Test]
        public void ColumnCanWin()
        {
            game.PerformMove(0, 0);
            game.PerformMove(0, 1);
            game.PerformMove(1, 0);
            game.PerformMove(1, 1);
            game.PerformMove(2, 0);
            Assert.AreEqual(1, game.CheckForWin());
        }

        [Test]
        public void DiagonalCanWin()
        {
            game.PerformMove(1, 1);
            game.PerformMove(0, 1);
            game.PerformMove(0, 0);
            game.PerformMove(0, 2);
            game.PerformMove(2, 2);
            Assert.AreEqual(1, game.CheckForWin());
        }

        [Test]
        public void CanGetDraw()
        {
            game.PerformMove(0, 0);
            Assert.AreEqual(0, game.CheckForWin());
            game.PerformMove(1, 1);
            Assert.AreEqual(0, game.CheckForWin());
            game.PerformMove(1, 0);
            Assert.AreEqual(0, game.CheckForWin());
            game.PerformMove(0, 1);
            Assert.AreEqual(0, game.CheckForWin());
            game.PerformMove(2, 1);
            Assert.AreEqual(0, game.CheckForWin());
            game.PerformMove(2, 0);
            Assert.AreEqual(0, game.CheckForWin());
            game.PerformMove(0, 2);
            Assert.AreEqual(0, game.CheckForWin());
            game.PerformMove(2, 2);
            Assert.AreEqual(0, game.CheckForWin());
            game.PerformMove(1, 2);
            Assert.AreEqual(3, game.CheckForWin());
        }
    }
}
