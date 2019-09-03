using System;
using System.Windows.Forms;

namespace WinFormsClock
{
    /// <summary>
    /// Clock form
    /// </summary>
    public partial class ClockForm : Form
    {
        public ClockForm()
        {
            InitializeComponent();
            TimeDisplay.Text = DateTime.Now.ToString("T");
        }

        /// <summary>
        /// Starts the timer on form load
        /// </summary>
        private void ClockForm_Load(object sender, EventArgs e)
        {
            ClockTimer.Start();
        }

        /// <summary>
        /// Updates the clock every tick
        /// </summary>
        private void ClockTimer_Tick(object sender, EventArgs e)
        {
            TimeDisplay.Text = DateTime.Now.ToString("T");
        }
    }
}
