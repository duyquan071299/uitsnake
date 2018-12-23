namespace UIT_Snake
{
    partial class Option
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BackGroundSoundCheck = new System.Windows.Forms.CheckBox();
            this.SoundEffectCheck = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.MapRadio2 = new System.Windows.Forms.RadioButton();
            this.MapRadio1 = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Hard = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // BackGroundSoundCheck
            // 
            this.BackGroundSoundCheck.AutoSize = true;
            this.BackGroundSoundCheck.BackColor = System.Drawing.Color.Transparent;
            this.BackGroundSoundCheck.Checked = true;
            this.BackGroundSoundCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.BackGroundSoundCheck.Font = new System.Drawing.Font("Showcard Gothic", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackGroundSoundCheck.Location = new System.Drawing.Point(309, 59);
            this.BackGroundSoundCheck.Name = "BackGroundSoundCheck";
            this.BackGroundSoundCheck.Size = new System.Drawing.Size(232, 27);
            this.BackGroundSoundCheck.TabIndex = 0;
            this.BackGroundSoundCheck.Text = "Back Ground Sound";
            this.BackGroundSoundCheck.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.BackGroundSoundCheck.UseVisualStyleBackColor = false;
            this.BackGroundSoundCheck.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // SoundEffectCheck
            // 
            this.SoundEffectCheck.AutoSize = true;
            this.SoundEffectCheck.BackColor = System.Drawing.Color.Transparent;
            this.SoundEffectCheck.Checked = true;
            this.SoundEffectCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SoundEffectCheck.Font = new System.Drawing.Font("Showcard Gothic", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SoundEffectCheck.Location = new System.Drawing.Point(106, 59);
            this.SoundEffectCheck.Name = "SoundEffectCheck";
            this.SoundEffectCheck.Size = new System.Drawing.Size(165, 27);
            this.SoundEffectCheck.TabIndex = 1;
            this.SoundEffectCheck.Text = "Sound Effect";
            this.SoundEffectCheck.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.SoundEffectCheck.UseVisualStyleBackColor = false;
            this.SoundEffectCheck.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::UIT_Snake.Properties.Resources.map_1;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.Hard);
            this.panel1.Controls.Add(this.MapRadio2);
            this.panel1.Controls.Add(this.MapRadio1);
            this.panel1.Location = new System.Drawing.Point(240, 121);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(637, 133);
            this.panel1.TabIndex = 5;
            // 
            // MapRadio2
            // 
            this.MapRadio2.AutoSize = true;
            this.MapRadio2.Location = new System.Drawing.Point(213, 57);
            this.MapRadio2.Name = "MapRadio2";
            this.MapRadio2.Size = new System.Drawing.Size(78, 21);
            this.MapRadio2.TabIndex = 1;
            this.MapRadio2.Text = "Medium";
            this.MapRadio2.UseVisualStyleBackColor = true;
            this.MapRadio2.CheckedChanged += new System.EventHandler(this.MapRadio2_CheckedChanged);
            // 
            // MapRadio1
            // 
            this.MapRadio1.AutoSize = true;
            this.MapRadio1.Checked = true;
            this.MapRadio1.Location = new System.Drawing.Point(47, 57);
            this.MapRadio1.Name = "MapRadio1";
            this.MapRadio1.Size = new System.Drawing.Size(60, 21);
            this.MapRadio1.TabIndex = 0;
            this.MapRadio1.TabStop = true;
            this.MapRadio1.Text = "Easy";
            this.MapRadio1.UseVisualStyleBackColor = true;
            this.MapRadio1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BackgroundImage = global::UIT_Snake.Properties.Resources.skin_1;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.radioButton4);
            this.panel2.Controls.Add(this.radioButton3);
            this.panel2.Location = new System.Drawing.Point(240, 274);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(637, 133);
            this.panel2.TabIndex = 5;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(213, 68);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(110, 21);
            this.radioButton4.TabIndex = 1;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "radioButton4";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(47, 68);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(110, 21);
            this.radioButton3.TabIndex = 0;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "radioButton3";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BackgroundImage = global::UIT_Snake.Properties.Resources.sound_1;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Controls.Add(this.SoundEffectCheck);
            this.panel3.Controls.Add(this.BackGroundSoundCheck);
            this.panel3.Location = new System.Drawing.Point(240, 433);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(637, 133);
            this.panel3.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::UIT_Snake.Properties.Resources.Asset_15;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(487, 572);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(149, 44);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Hard
            // 
            this.Hard.AutoSize = true;
            this.Hard.Location = new System.Drawing.Point(386, 57);
            this.Hard.Name = "Hard";
            this.Hard.Size = new System.Drawing.Size(60, 21);
            this.Hard.TabIndex = 2;
            this.Hard.Text = "Hard";
            this.Hard.UseVisualStyleBackColor = true;
            this.Hard.CheckedChanged += new System.EventHandler(this.Hard_CheckedChanged);
            // 
            // Option
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::UIT_Snake.Properties.Resources.option;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "Option";
            this.Size = new System.Drawing.Size(1114, 625);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox BackGroundSoundCheck;
        private System.Windows.Forms.CheckBox SoundEffectCheck;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RadioButton MapRadio2;
        private System.Windows.Forms.RadioButton MapRadio1;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton Hard;
    }
}
