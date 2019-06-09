using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsCalculator
{
    /// <summary>
    /// Calculator form class
    /// </summary>
    public partial class Calculator : Form
    {
        public ExpressionLogic logic;

        public Calculator()
        {
            InitializeComponent();
            logic = new ExpressionLogic();
        }

        /// <summary>
        /// This method is called whenever a number button is pressed
        /// </summary>
        private void NumberClick(object sender, EventArgs e)
        {
            var button = (Button)sender;
            ExpressionTextBox.Text = logic.ClickNumber(button.Text);
        }

        /// <summary>
        /// This method is called whenever the comma button is pressed
        /// </summary>
        private void CommaClick(object sender, EventArgs e)
            => ExpressionTextBox.Text = logic.ClickComma();

        /// <summary>
        /// This method is called whenever an operation button is pressed
        /// </summary>
        private void OperationClick(object sender, EventArgs e)
        {
            var button = (Button)sender;
            ExpressionTextBox.Text = logic.ClickOperation(button.Text);
        }

        /// <summary>
        /// This method is called whenever the left bracket button is pressed
        /// </summary>
        private void LeftBracketClick(object sender, EventArgs e)
            => ExpressionTextBox.Text = logic.ClickLeftBracket();

        /// <summary>
        /// This method is called whenever the right bracket button is pressed
        /// </summary>
        private void RightBracketClick(object sender, EventArgs e)
            => ExpressionTextBox.Text = logic.ClickRightBracket();

        /// <summary>
        /// This method is called whenever an erase button is pressed
        /// </summary>
        private void EraseClick(object sender, EventArgs e)
            => ExpressionTextBox.Text = logic.ClickErase();

        /// <summary>
        /// This method is called whenever the clear button is pressed
        /// </summary>
        private void ClearClick(object sender, EventArgs e)
        {
            ExpressionTextBox.Text = "";
            logic = new ExpressionLogic();
        }

        /// <summary>
        /// This method is called whenever the result button is pressed
        /// </summary>
        private void ResultClick(object sender, EventArgs e)
        {

        }
    }
}
