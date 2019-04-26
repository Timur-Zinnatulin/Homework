namespace Test_1_Button
{
    partial class ButtonChaseForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.TargetButton = new System.Windows.Forms.Button();
            this.ButtonTeleportTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // TargetButton
            // 
            this.TargetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TargetButton.Location = new System.Drawing.Point(671, 383);
            this.TargetButton.Name = "TargetButton";
            this.TargetButton.Size = new System.Drawing.Size(117, 55);
            this.TargetButton.TabIndex = 0;
            this.TargetButton.Text = "Press me!";
            this.TargetButton.UseVisualStyleBackColor = true;
            this.TargetButton.Click += new System.EventHandler(this.TargetButton_Click);
            // 
            // ButtonTeleportTimer
            // 
            this.ButtonTeleportTimer.Enabled = true;
            this.ButtonTeleportTimer.Interval = 1000;
            this.ButtonTeleportTimer.Tick += new System.EventHandler(this.ButtonTimer_Tick);
            // 
            // ButtonChaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TargetButton);
            this.Name = "ButtonChaseForm";
            this.Text = "Button Chase";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button TargetButton;
        private System.Windows.Forms.Timer ButtonTeleportTimer;
    }
}

