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
        private List<string> map;
        public Tuple<int, int> PlayerCoords { get; set; }

        public Game(string fileName)
        {
            map = new List<string>();
            var allStrings = File.ReadAllLines(fileName, System.Text.Encoding.UTF8);
            for (int i = 0; i < allStrings.GetLength(0); ++i)
            {
                if (FlagBadSymbolInString(allStrings[i]))
                {
                    throw new FormatException("Map has unacceptable symbols!");
                }

                map.Add(allStrings[i]);
            }
            PlayerCoords = FindStartPosition(allStrings);
            if (PlayerCoords.Item1 == -1)
            {
                throw new FormatException("Map does not have a start position!");
            }

            DrawMap();
        }

        private Tuple<int, int> FindStartPosition(string[] map)
        {
            for (int i = 0; i < map.GetLength(0); ++i)
            {
                for (int j = 0; j < map.GetLength(1); ++j)
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
                    return false;
                }
            }
            return true;
        }

        private bool IsWall(char symbol)
            => (symbol != ' ');

        private void DrawMap()
        {
            Console.Clear();
            for (int i = 0; i < map.Count; ++i)
            {
                Console.WriteLine(map[i]);
            }
            Console.CursorTop = PlayerCoords.Item1;
            Console.CursorLeft = PlayerCoords.Item2;
            Console.CursorVisible = false;
        }

        public void OnLeft(object sender, EventArgs args)
        {
            if (IsWall(map[PlayerCoords.Item1 - 1][PlayerCoords.Item2]))
            {
                return;
            }
            PlayerCoords = new Tuple<int, int>(PlayerCoords.Item1 - 1, PlayerCoords.Item2);
            // Redraw
        }

        public void OnRight(object sender, EventArgs args)
        {
            if (IsWall(map[PlayerCoords.Item1 + 1][PlayerCoords.Item2]))
            {
                return;
            }
            PlayerCoords = new Tuple<int, int>(PlayerCoords.Item1 + 1, PlayerCoords.Item2);
            // Redraw
        }

        public void OnUp(object sender, EventArgs args)
        {
            if (IsWall(map[PlayerCoords.Item1][PlayerCoords.Item2 - 1]))
            {
                return;
            }
            PlayerCoords = new Tuple<int, int>(PlayerCoords.Item1, PlayerCoords.Item2 - 1);
            // Redraw
        }

        public void OnDown(object sender, EventArgs args)
        {
            if (IsWall(map[PlayerCoords.Item1][PlayerCoords.Item2 + 1]))
            {
                return;
            }
            PlayerCoords = new Tuple<int, int>(PlayerCoords.Item1, PlayerCoords.Item2 + 1);
            // Redraw
        }
    }
}
