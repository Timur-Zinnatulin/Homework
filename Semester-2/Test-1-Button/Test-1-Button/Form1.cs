using System;
using System.Windows.Forms;

namespace Test_1_Button
{
    public partial class ButtonChaseForm : Form
    {
        public ButtonChaseForm()
        {
            InitializeComponent();
        }
        private PositionRandomizer random = new PositionRandomizer();

        //Exits the program on button press
        private void TargetButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Teleports the button with every timer tick
        private void ButtonTimer_Tick(object sender, EventArgs e)
        {
            TargetButton.Location = new System.Drawing.Point(random.RandomLocation(454), random.RandomLocation(228));
        }
    }
}
