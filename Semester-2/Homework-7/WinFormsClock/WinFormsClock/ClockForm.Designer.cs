namespace WinFormsClock
{
    partial class ClockForm
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
            this.TimeDisplay = new System.Windows.Forms.TextBox();
            this.ClockTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // TimeDisplay
            // 
            this.TimeDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TimeDisplay.Location = new System.Drawing.Point(12, 12);
            this.TimeDisplay.Multiline = true;
            this.TimeDisplay.Name = "TimeDisplay";
            this.TimeDisplay.ReadOnly = true;
            this.TimeDisplay.Size = new System.Drawing.Size(386, 119);
            this.TimeDisplay.TabIndex = 0;
            this.TimeDisplay.TabStop = false;
            // 
            // ClockTimer
            // 
            this.ClockTimer.Tick += new System.EventHandler(this.ClockTimer_Tick);
            // 
            // ClockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 143);
            this.Controls.Add(this.TimeDisplay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ClockForm";
            this.Text = "ClockForm";
            this.Load += new System.EventHandler(this.ClockForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TimeDisplay;
        private System.Windows.Forms.Timer ClockTimer;
    }
}

