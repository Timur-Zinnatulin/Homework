using System;
using System.Windows.Forms;

namespace TestGame
{
    /// <summary>
    /// Game form class
    /// </summary>
    public partial class Game : Form
    {
        public Game()
        {
            InitializeComponent();
            GameWinner.Enabled = false;
        }

        private GameLogic game = new GameLogic();

        /// <summary>
        /// Processes the game winner and ends the game if it is over
        /// </summary>
        private void ProcessGameWinner()
        {
            var gameProgress = game.CheckForWin();

            if (gameProgress == 0)
            {
                return;
            }

            if (gameProgress == 1 || gameProgress == 2)
            {
                if (game.State == GameLogic.GameState.Circle)
                {
                    GameWinner.Text = "CROSS WON!!! XXXXXXX";
                }
                else
                {
                    GameWinner.Text = "CIRCLE WON!!! OOOOOOO";
                }
            }
            else
            {
                GameWinner.Text = "!!!DRAW!!!";
            }
            TopLeft.Enabled = false;
            TopMid.Enabled = false;
            TopRight.Enabled = false;
            MidLeft.Enabled = false;
            TrueMid.Enabled = false;
            MidRight.Enabled = false;
            BottomLeft.Enabled = false;
            BottomMid.Enabled = false;
            BottomRight.Enabled = false;
        }

        private void TopLeft_Click(object sender, EventArgs e)
        {
            if (game.Map[0, 0] == '.')
            {
                TopLeft.Text = game.PerformMove(0, 0);
            }
            ProcessGameWinner();
        }

        private void TopMid_Click(object sender, EventArgs e)
        {
            if (game.Map[0, 1] == '.')
            {
                TopMid.Text = game.PerformMove(0, 1);
            }
            ProcessGameWinner();
        }

        private void TopRight_Click(object sender, EventArgs e)
        {
            if (game.Map[0, 2] == '.')
            {
                TopRight.Text = game.PerformMove(0, 2);
            }
            ProcessGameWinner();
        }

        private void MidLeft_Click(object sender, EventArgs e)
        {
            if (game.Map[1, 0] == '.')
            {
                MidLeft.Text = game.PerformMove(1, 0);
            }
            ProcessGameWinner();
        }

        private void TrueMid_Click(object sender, EventArgs e)
        {
            if (game.Map[1, 1] == '.')
            {
                TrueMid.Text = game.PerformMove(1, 1);
            }
            ProcessGameWinner();
        }

        private void MidRight_Click(object sender, EventArgs e)
        {
            if (game.Map[1, 2] == '.')
            {
                MidRight.Text = game.PerformMove(1, 2);
            }
            ProcessGameWinner();
        }

        private void BottomLeft_Click(object sender, EventArgs e)
        {
            if (game.Map[2, 0] == '.')
            {
                BottomLeft.Text = game.PerformMove(2, 0);
            }
            ProcessGameWinner();
        }

        private void BottomMid_Click(object sender, EventArgs e)
        {
            if (game.Map[2, 1] == '.')
            {
                BottomMid.Text = game.PerformMove(2, 1);
            }
        }

        private void BottomRight_Click(object sender, EventArgs e)
        {
            if (game.Map[2, 2] == '.')
            {
                BottomRight.Text = game.PerformMove(2, 2);
            }
            ProcessGameWinner();
        }
    }
}
