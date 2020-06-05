using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_2
{
    /// <summary>
    /// Tic-Tac-Toe MVVM Model
    /// </summary>
    public class Model
    {
        /// <summary>
        /// Current state of the game
        /// </summary>
        public enum GameState
        {
            Cross,
            Circle,
        }

        public GameState State { get; private set; }
        /// <summary>
        /// 0 - game goes on
        /// 1 - cross
        /// 2 - circle
        /// 3 - draw
        /// </summary>
        public char[,] Map { get; private set; }

        public Model()
        {
            State = GameState.Cross;
            Map = new char[,] { { '.', '.', '.' }, { '.', '.', '.' }, { '.', '.', '.' } };
        }

        /// <summary>
        /// Performs move
        /// </summary>
        /// <param name="row">Row of button</param>
        /// <param name="column">Column of button</param>
        /// <param name="state">Current symbol</param>
        /// <returns>Symbol to put on a button</returns>
        public string PerformMove(int row, int column)
        {
            if (Map[row, column] != '.')
            {
                return Map[row, column].ToString();
            }

            if (State == GameState.Cross)
            {
                Map[row, column] = 'X';
                State = GameState.Circle;
                return "X";
            }

            else
            {
                Map[row, column] = 'O';
                State = GameState.Cross;
                return "O";
            }
        }
        
        /// <summary>
        /// Checks if the game is over
        /// </summary>
        /// <returns>Answer to the question. 0 - nobody won; 1 - cross won; 2 - circle won; 3 - draw</returns>
        public int CheckForWin()
        {
            bool onlyDots = true;
            //Rows
            for (int i = 0; i < 3; ++i)
            {
                onlyDots = true;
                bool rowClosed = true;
                for (int j = 1; j < 3; ++j)
                {
                    if (Map[i, j] != Map[i, j - 1])
                    {
                        rowClosed = false;
                    }

                    else if (Map[i, j] != '.')
                    {
                        onlyDots = false;
                    }
                }

                if (rowClosed && !onlyDots)
                {
                    return Map[i, 0] == 'X' ? 1 : 2;
                }
            }

            //Columns
            for (int j = 0; j < 3; ++j)
            {
                onlyDots = true;
                bool columnClosed = true;
                for (int i = 1; i < 3; ++i)
                {
                    if (Map[i, j] != Map[i - 1, j])
                    {
                        columnClosed = false;
                    }

                    else if (Map[i, j] != '.')
                    {
                        onlyDots = false;
                    }
                }

                if (columnClosed && !onlyDots)
                {
                    return Map[0, j] == 'X' ? 1 : 2;
                }
            }

            //Diagonals
            bool OneDiagonalClosed = true;
            bool TwoDiagonalClosed = true;
            onlyDots = true;

            for (int i = 1; i < 3; ++i)
            {
                if (Map[i - 1, i - 1] != Map[i, i])
                {
                    OneDiagonalClosed = false;
                }

                else if (Map[i, i] != '.')
                {
                    onlyDots = false;
                }

                if (Map[2 - i + 1, i - 1] != Map[2 - i, i])
                {
                    TwoDiagonalClosed = false;
                }

                else if (Map[2 - i, i] != '.')
                {
                    onlyDots = false;
                }
            }

            if ((OneDiagonalClosed || TwoDiagonalClosed) && !onlyDots)
            {
                return Map[1, 1] == 'X' ? 1 : 2;
            }

            //Draw
            bool AreDotsThere = false;
            for (int i = 0; i < 3; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    if (Map[i, j] == '.')
                    {
                        AreDotsThere = true;
                    }
                }
            }

            if (!AreDotsThere)
            {
                return 3;
            }

            return 0;
        }
    }
}
