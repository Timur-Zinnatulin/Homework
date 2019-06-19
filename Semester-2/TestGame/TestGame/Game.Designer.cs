namespace TestGame
{
    partial class Game
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
            this.TopLeft = new System.Windows.Forms.Button();
            this.TopMid = new System.Windows.Forms.Button();
            this.TopRight = new System.Windows.Forms.Button();
            this.MidLeft = new System.Windows.Forms.Button();
            this.TrueMid = new System.Windows.Forms.Button();
            this.MidRight = new System.Windows.Forms.Button();
            this.BottomLeft = new System.Windows.Forms.Button();
            this.BottomMid = new System.Windows.Forms.Button();
            this.BottomRight = new System.Windows.Forms.Button();
            this.GameWinner = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TopLeft
            // 
            this.TopLeft.Location = new System.Drawing.Point(228, 75);
            this.TopLeft.Name = "TopLeft";
            this.TopLeft.Size = new System.Drawing.Size(101, 93);
            this.TopLeft.TabIndex = 0;
            this.TopLeft.Text = ".";
            this.TopLeft.UseVisualStyleBackColor = true;
            this.TopLeft.Click += new System.EventHandler(this.TopLeft_Click);
            // 
            // TopMid
            // 
            this.TopMid.Location = new System.Drawing.Point(335, 75);
            this.TopMid.Name = "TopMid";
            this.TopMid.Size = new System.Drawing.Size(101, 93);
            this.TopMid.TabIndex = 1;
            this.TopMid.Text = ".";
            this.TopMid.UseVisualStyleBackColor = true;
            this.TopMid.Click += new System.EventHandler(this.TopMid_Click);
            // 
            // TopRight
            // 
            this.TopRight.Location = new System.Drawing.Point(442, 75);
            this.TopRight.Name = "TopRight";
            this.TopRight.Size = new System.Drawing.Size(101, 93);
            this.TopRight.TabIndex = 2;
            this.TopRight.Text = ".";
            this.TopRight.UseVisualStyleBackColor = true;
            this.TopRight.Click += new System.EventHandler(this.TopRight_Click);
            // 
            // MidLeft
            // 
            this.MidLeft.Location = new System.Drawing.Point(228, 174);
            this.MidLeft.Name = "MidLeft";
            this.MidLeft.Size = new System.Drawing.Size(101, 93);
            this.MidLeft.TabIndex = 3;
            this.MidLeft.Text = ".";
            this.MidLeft.UseVisualStyleBackColor = true;
            this.MidLeft.Click += new System.EventHandler(this.MidLeft_Click);
            // 
            // TrueMid
            // 
            this.TrueMid.Location = new System.Drawing.Point(335, 174);
            this.TrueMid.Name = "TrueMid";
            this.TrueMid.Size = new System.Drawing.Size(101, 93);
            this.TrueMid.TabIndex = 4;
            this.TrueMid.Text = ".";
            this.TrueMid.UseVisualStyleBackColor = true;
            this.TrueMid.Click += new System.EventHandler(this.TrueMid_Click);
            // 
            // MidRight
            // 
            this.MidRight.Location = new System.Drawing.Point(442, 174);
            this.MidRight.Name = "MidRight";
            this.MidRight.Size = new System.Drawing.Size(101, 93);
            this.MidRight.TabIndex = 5;
            this.MidRight.Text = ".";
            this.MidRight.UseVisualStyleBackColor = true;
            this.MidRight.Click += new System.EventHandler(this.MidRight_Click);
            // 
            // BottomLeft
            // 
            this.BottomLeft.Location = new System.Drawing.Point(228, 273);
            this.BottomLeft.Name = "BottomLeft";
            this.BottomLeft.Size = new System.Drawing.Size(101, 93);
            this.BottomLeft.TabIndex = 6;
            this.BottomLeft.Text = ".";
            this.BottomLeft.UseVisualStyleBackColor = true;
            this.BottomLeft.Click += new System.EventHandler(this.BottomLeft_Click);
            // 
            // BottomMid
            // 
            this.BottomMid.Location = new System.Drawing.Point(335, 273);
            this.BottomMid.Name = "BottomMid";
            this.BottomMid.Size = new System.Drawing.Size(101, 93);
            this.BottomMid.TabIndex = 7;
            this.BottomMid.Text = ".";
            this.BottomMid.UseVisualStyleBackColor = true;
            this.BottomMid.Click += new System.EventHandler(this.BottomMid_Click);
            // 
            // BottomRight
            // 
            this.BottomRight.Location = new System.Drawing.Point(442, 273);
            this.BottomRight.Name = "BottomRight";
            this.BottomRight.Size = new System.Drawing.Size(101, 93);
            this.BottomRight.TabIndex = 8;
            this.BottomRight.Text = ".";
            this.BottomRight.UseVisualStyleBackColor = true;
            this.BottomRight.Click += new System.EventHandler(this.BottomRight_Click);
            // 
            // GameWinner
            // 
            this.GameWinner.Location = new System.Drawing.Point(228, 389);
            this.GameWinner.Name = "GameWinner";
            this.GameWinner.Size = new System.Drawing.Size(314, 26);
            this.GameWinner.TabIndex = 9;
            this.GameWinner.Text = "Game In Progress";
            this.GameWinner.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.GameWinner);
            this.Controls.Add(this.BottomRight);
            this.Controls.Add(this.BottomMid);
            this.Controls.Add(this.BottomLeft);
            this.Controls.Add(this.MidRight);
            this.Controls.Add(this.TrueMid);
            this.Controls.Add(this.MidLeft);
            this.Controls.Add(this.TopRight);
            this.Controls.Add(this.TopMid);
            this.Controls.Add(this.TopLeft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Game";
            this.Text = "Tic Tac Toe";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button TopLeft;
        private System.Windows.Forms.Button TopMid;
        private System.Windows.Forms.Button TopRight;
        private System.Windows.Forms.Button MidLeft;
        private System.Windows.Forms.Button TrueMid;
        private System.Windows.Forms.Button MidRight;
        private System.Windows.Forms.Button BottomLeft;
        private System.Windows.Forms.Button BottomMid;
        private System.Windows.Forms.Button BottomRight;
        private System.Windows.Forms.TextBox GameWinner;
    }
}

