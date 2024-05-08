namespace Pong
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.p1ScoreLabel = new System.Windows.Forms.Label();
            this.p2ScoreLabel = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.winLabel = new System.Windows.Forms.Label();
            this.freeze = new System.Windows.Forms.Timer(this.components);
            this.infoLabel = new System.Windows.Forms.Label();
            this.speedOrbLabel = new System.Windows.Forms.Label();
            this.slowOrbLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SpeedPictureBox = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // p1ScoreLabel
            // 
            this.p1ScoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.p1ScoreLabel.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p1ScoreLabel.ForeColor = System.Drawing.Color.White;
            this.p1ScoreLabel.Location = new System.Drawing.Point(183, 9);
            this.p1ScoreLabel.Name = "p1ScoreLabel";
            this.p1ScoreLabel.Size = new System.Drawing.Size(100, 23);
            this.p1ScoreLabel.TabIndex = 0;
            this.p1ScoreLabel.Text = "0";
            this.p1ScoreLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // p2ScoreLabel
            // 
            this.p2ScoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.p2ScoreLabel.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p2ScoreLabel.ForeColor = System.Drawing.Color.White;
            this.p2ScoreLabel.Location = new System.Drawing.Point(309, 9);
            this.p2ScoreLabel.Name = "p2ScoreLabel";
            this.p2ScoreLabel.Size = new System.Drawing.Size(100, 23);
            this.p2ScoreLabel.TabIndex = 1;
            this.p2ScoreLabel.Text = "0";
            this.p2ScoreLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // winLabel
            // 
            this.winLabel.BackColor = System.Drawing.Color.Transparent;
            this.winLabel.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.winLabel.ForeColor = System.Drawing.Color.Gold;
            this.winLabel.Location = new System.Drawing.Point(154, 256);
            this.winLabel.Name = "winLabel";
            this.winLabel.Size = new System.Drawing.Size(301, 23);
            this.winLabel.TabIndex = 2;
            this.winLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // freeze
            // 
            this.freeze.Interval = 1000;
            this.freeze.Tick += new System.EventHandler(this.freeze_Tick);
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.BackColor = System.Drawing.Color.Transparent;
            this.infoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoLabel.ForeColor = System.Drawing.Color.White;
            this.infoLabel.Location = new System.Drawing.Point(577, 44);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(247, 25);
            this.infoLabel.TabIndex = 3;
            this.infoLabel.Text = "You need 5 coins to win.";
            // 
            // speedOrbLabel
            // 
            this.speedOrbLabel.AutoSize = true;
            this.speedOrbLabel.BackColor = System.Drawing.Color.Transparent;
            this.speedOrbLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.speedOrbLabel.ForeColor = System.Drawing.Color.White;
            this.speedOrbLabel.Location = new System.Drawing.Point(667, 111);
            this.speedOrbLabel.Name = "speedOrbLabel";
            this.speedOrbLabel.Size = new System.Drawing.Size(117, 25);
            this.speedOrbLabel.TabIndex = 4;
            this.speedOrbLabel.Text = "Speed Orb";
            // 
            // slowOrbLabel
            // 
            this.slowOrbLabel.AutoSize = true;
            this.slowOrbLabel.BackColor = System.Drawing.Color.Transparent;
            this.slowOrbLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slowOrbLabel.ForeColor = System.Drawing.Color.White;
            this.slowOrbLabel.Location = new System.Drawing.Point(667, 181);
            this.slowOrbLabel.Name = "slowOrbLabel";
            this.slowOrbLabel.Size = new System.Drawing.Size(101, 25);
            this.slowOrbLabel.TabIndex = 5;
            this.slowOrbLabel.Text = "Slow Orb";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(667, 254);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Coins";
            // 
            // SpeedPictureBox
            // 
            this.SpeedPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.SpeedPictureBox.BackgroundImage = global::Pong.Properties.Resources.speed;
            this.SpeedPictureBox.Image = global::Pong.Properties.Resources.speed;
            this.SpeedPictureBox.InitialImage = null;
            this.SpeedPictureBox.Location = new System.Drawing.Point(582, 111);
            this.SpeedPictureBox.Name = "SpeedPictureBox";
            this.SpeedPictureBox.Size = new System.Drawing.Size(45, 39);
            this.SpeedPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SpeedPictureBox.TabIndex = 8;
            this.SpeedPictureBox.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Pong.Properties.Resources.slow;
            this.pictureBox1.Location = new System.Drawing.Point(582, 181);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(45, 39);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Pong.Properties.Resources.coin;
            this.pictureBox3.Location = new System.Drawing.Point(582, 254);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(45, 39);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 10;
            this.pictureBox3.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(863, 500);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.SpeedPictureBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.slowOrbLabel);
            this.Controls.Add(this.speedOrbLabel);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.winLabel);
            this.Controls.Add(this.p2ScoreLabel);
            this.Controls.Add(this.p1ScoreLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.SpeedPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label p1ScoreLabel;
        private System.Windows.Forms.Label p2ScoreLabel;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label winLabel;
        private System.Windows.Forms.Timer freeze;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.Label speedOrbLabel;
        private System.Windows.Forms.Label slowOrbLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox SpeedPictureBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}

