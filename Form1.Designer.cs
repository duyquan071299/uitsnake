namespace UIT_Snake
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.ClockLabel = new System.Windows.Forms.Label();
            this.timerClock = new System.Windows.Forms.Timer(this.components);
            this.menuGame1 = new UIT_Snake.MenuGame();
            this.highScore1 = new UIT_Snake.HighScore();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label1.Image = global::UIT_Snake.Properties.Resources.label_score;
            this.label1.Location = new System.Drawing.Point(855, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 71);
            this.label1.TabIndex = 2;
            this.label1.Text = "Snake1_Score:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label2.Image = global::UIT_Snake.Properties.Resources.label_score;
            this.label2.Location = new System.Drawing.Point(858, 273);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 71);
            this.label2.TabIndex = 3;
            this.label2.Text = "Snake2_Score:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.BackColor = System.Drawing.Color.LightGray;
            this.pictureBox1.Location = new System.Drawing.Point(12, 27);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(746, 572);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            // 
            // ClockLabel
            // 
            this.ClockLabel.BackColor = System.Drawing.Color.White;
            this.ClockLabel.Location = new System.Drawing.Point(861, 403);
            this.ClockLabel.Name = "ClockLabel";
            this.ClockLabel.Size = new System.Drawing.Size(144, 65);
            this.ClockLabel.TabIndex = 5;
            // 
            // timerClock
            // 
            this.timerClock.Interval = 1000;
            this.timerClock.Tick += new System.EventHandler(this.timerClock_Tick);
            // 
            // menuGame1
            // 
            this.menuGame1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.menuGame1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("menuGame1.BackgroundImage")));
            this.menuGame1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.menuGame1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuGame1.Location = new System.Drawing.Point(0, 0);
            this.menuGame1.Name = "menuGame1";
            this.menuGame1.ParentForm = null;
            this.menuGame1.Size = new System.Drawing.Size(1114, 625);
            this.menuGame1.TabIndex = 4;
            // 
            // highScore1
            // 
            this.highScore1.BackColor = System.Drawing.Color.Transparent;
            this.highScore1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("highScore1.BackgroundImage")));
            this.highScore1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.highScore1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.highScore1.Location = new System.Drawing.Point(0, 0);
            this.highScore1.Name = "highScore1";
            this.highScore1.ParentForm = null;
            this.highScore1.Size = new System.Drawing.Size(1114, 625);
            this.highScore1.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.BackgroundImage = global::UIT_Snake.Properties.Resources.Snake_main;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1114, 625);
            this.ControlBox = false;
            this.Controls.Add(this.menuGame1);
            this.Controls.Add(this.ClockLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.highScore1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label ClockLabel;
        private System.Windows.Forms.Timer timerClock;
        public MenuGame menuGame1;
        private HighScore highScore1;
    }
}

