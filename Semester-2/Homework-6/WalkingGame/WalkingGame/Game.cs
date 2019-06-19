using System;
using System.Collections.Generic;
using System.IO;

namespace WalkingGame
{
    /// <summary>
    /// Game logic class
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Directions in which a character can go
        /// </summary>
        private enum Directions
        {
            Left,
            Right,
            Up,
            Down,
            Still
        }

        private bool flagTesting;

        /// <summary>
        /// Flag that showws if the game is ready to be played
        /// </summary>
        public bool IsReadyToPlay { get; private set; }

        /// <summary>
        /// List of lines of the map
        /// </summary>
        public List<string> Map { get; private set; }

        /// <summary>
        /// Player coordinates subclass
        /// </summary>
        public struct Coords
        {
            public int X { get; private set; }
            public int Y { get; private set; }

            /*
            public void GoRight()
            {
                ChangeCoords(Directions.Right);
            }

            public void GoLeft()
            {
                ChangeCoords(Directions.Left);
            }

            public void GoUp()
            {
                ChangeCoords(Directions.Up);
            }

            public void GoDown()
            {
                ChangeCoords(Directions.Down);
            }*/

            public Coords(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }
            /*
            private void ChangeCoords(Directions d)
            {
                switch (d)
                {
                    case Directions.Left:
                        {
                            --Y;
                            break;
                        }
                    case Directions.Right:
                        {
                            ++Y;
                            break;
                        }
                    case Directions.Up:
                        {
                           --X;
                            break;
                        }
                    case Directions.Down:
                        {
                            ++X;
                            break;
                        }
                }
            }*/
        }

        /// <summary>
        /// Coordinates of the player
        /// </summary>
        public Coords Player { get; private set; }

        /// <summary>
        /// Reads the map and puts the player in control of a character
        /// </summary>
        /// <param name="fileName"></param>
        public Game(string fileName, bool FlagTesting)
        {
            flagTesting = FlagTesting;
            Map = new List<string>();
            var allStrings = File.ReadAllLines(fileName, System.Text.Encoding.UTF8);

            foreach(var str in allStrings)
            {
                if (FlagBadSymbolInString(str))
                {
                    throw new FormatException("Map has unacceptable symbols!");
                }

                Map.Add(str);
            }

            Player = FindStartPosition(allStrings);
            if (Player.X == -1)
            {
                throw new FormatException("Map does not have a start position!");
            }

            IsReadyToPlay = true;
        }

        /// <summary>
        /// Looks for '@' in the map
        /// </summary>
        /// <param name="map">Given map</param>
        /// <returns>Position of a character</returns>
        private Coords FindStartPosition(string[] map)
        {
            for (int i = 0; i < map.GetLength(0); ++i)
            {
                for (int j = 0; j < map[i].Length; ++j)
                {
                    if (map[i][j] == '@')
                    {
                        return new Coords(i, j);
                    }
                }
            }
            return new Coords(-1 ,-1);
        }

        /// <summary>
        /// Checks if the string contains unacceptable symbols
        /// </summary>
        /// <param name="str">Line of the map</param>
        /// <returns>Answer to the question</returns>
        private bool FlagBadSymbolInString(string str)
        {
            for (int i = 0; i < str.Length; ++i)
            {
                if ((str[i] != '@') && (str[i] != ' ') && (str[i] != '█'))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Checks if the symbol is a wall
        /// </summary>
        /// <param name="str">Character of the map</param>
        /// <returns>Answer to the question</returns>
        private bool IsWall(char symbol)
            => (symbol == '█');

        /// <summary>
        /// Changes character coordinates according to his inputs
        /// </summary>
        /// <param name="direction">Chosen movement direction</param>
        private void RenderMovement(Directions direction)
        {
            if (!flagTesting)
            {
                Console.SetCursorPosition(Player.Y, Player.X);
                Console.Write(" ");
            }

            switch(direction)
            {
                case Directions.Left:
                    {
                        Player = new Coords(Player.X, Player.Y - 1);
                        break;
                    }
                case Directions.Right:
                    {
                        Player = new Coords(Player.X, Player.Y + 1);
                        break;
                    }
                case Directions.Up:
                    {
                        Player = new Coords(Player.X - 1, Player.Y);
                        break;
                    }
                case Directions.Down:
                    {
                        Player = new Coords(Player.X + 1, Player.Y);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            if (!flagTesting)
            {
                Console.SetCursorPosition(Player.Y, Player.X);
                Console.Write("@");
            }
        }

        public void OnLeft(object sender, EventArgs args)
        {
            if (IsWall(Map[Player.X][Player.Y - 1]))
            {
                return;
            }
            RenderMovement(Directions.Left);
        }

        public void OnRight(object sender, EventArgs args)
        {
            if (IsWall(Map[Player.X][Player.Y + 1]))
            {
                return;
            }
            RenderMovement(Directions.Right);
        }

        public void OnUp(object sender, EventArgs args)
        {
            if (IsWall(Map[Player.X - 1][Player.Y]))
            {
                return;
            }
            RenderMovement(Directions.Up);
        }

        public void OnDown(object sender, EventArgs args)
        {
            if (IsWall(Map[Player.X + 1][Player.Y]))
            {
                return;
            }
            RenderMovement(Directions.Down);
        }
    }
}
