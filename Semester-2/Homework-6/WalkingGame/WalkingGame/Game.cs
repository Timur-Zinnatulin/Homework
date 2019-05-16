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
            Down
        }

        private List<string> map;
        public Tuple<int, int> PlayerCoords { get; set; }

        /// <summary>
        /// Draws the map and puts the player in control of a character
        /// </summary>
        /// <param name="fileName"></param>
        public Game(string fileName)
        {
            map = new List<string>();
            var allStrings = File.ReadAllLines(fileName, System.Text.Encoding.UTF8);

            foreach(var str in allStrings)
            {
                if (FlagBadSymbolInString(str))
                {
                    throw new FormatException("Map has unacceptable symbols!");
                }

                map.Add(str);
            }

            PlayerCoords = FindStartPosition(allStrings);
            if (PlayerCoords.Item1 == -1)
            {
                throw new FormatException("Map does not have a start position!");
            }

            DrawMap();
        }

        /// <summary>
        /// Looks for '@' in the map
        /// </summary>
        /// <param name="map">Given map</param>
        /// <returns>Position of a character</returns>
        private Tuple<int, int> FindStartPosition(string[] map)
        {
            for (int i = 0; i < map.GetLength(0); ++i)
            {
                for (int j = 0; j < map[i].Length; ++j)
                {
                    if (map[i][j] == '@')
                    {
                        return new Tuple<int, int>(i, j);
                    }
                }
            }
            return new Tuple<int, int>(-1, -1);
        }

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

        private bool IsWall(char symbol)
            => (symbol == '█');

        /// <summary>
        /// Render map function
        /// </summary>
        private void DrawMap()
        {
            Console.Clear();
            for (int i = 0; i < map.Count; ++i)
            {
                Console.WriteLine(map[i]);
            }
            Console.CursorVisible = false;
        }

        /// <summary>
        /// Changes character coordinates according to his inputs
        /// </summary>
        /// <param name="direction">Chosen movement direction</param>
        private void RenderMovement(Directions direction)
        {
            Console.SetCursorPosition(PlayerCoords.Item2, PlayerCoords.Item1);
            Console.Write(" ");
            switch(direction)
            {
                case Directions.Left:
                    {
                        PlayerCoords = new Tuple<int, int>(PlayerCoords.Item1, PlayerCoords.Item2 - 1);
                        break;
                    }
                case Directions.Right:
                    {
                        PlayerCoords = new Tuple<int, int>(PlayerCoords.Item1, PlayerCoords.Item2 + 1);
                        break;
                    }
                case Directions.Up:
                    {
                        PlayerCoords = new Tuple<int, int>(PlayerCoords.Item1 - 1, PlayerCoords.Item2);
                        break;
                    }
                case Directions.Down:
                    {
                        PlayerCoords = new Tuple<int, int>(PlayerCoords.Item1 + 1, PlayerCoords.Item2);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            Console.SetCursorPosition(PlayerCoords.Item2, PlayerCoords.Item1);
            Console.Write("@");
        }

        public void OnLeft(object sender, EventArgs args)
        {
            if (IsWall(map[PlayerCoords.Item1][PlayerCoords.Item2 - 1]))
            {
                return;
            }
            RenderMovement(Directions.Left);
        }

        public void OnRight(object sender, EventArgs args)
        {
            if (IsWall(map[PlayerCoords.Item1][PlayerCoords.Item2 + 1]))
            {
                return;
            }
            RenderMovement(Directions.Right);
        }

        public void OnUp(object sender, EventArgs args)
        {
            if (IsWall(map[PlayerCoords.Item1 - 1][PlayerCoords.Item2]))
            {
                return;
            }
            RenderMovement(Directions.Up);
        }

        public void OnDown(object sender, EventArgs args)
        {
            if (IsWall(map[PlayerCoords.Item1 + 1][PlayerCoords.Item2]))
            {
                return;
            }
            RenderMovement(Directions.Down);
        }
    }
}
