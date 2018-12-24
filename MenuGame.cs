using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIT_Snake
{
    public partial class MenuGame : UserControl
    {
        public Form1 ParentForm { get; set; }
        public MenuGame()
        {
            InitializeComponent();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            NameRegister a = new NameRegister(this);
            a.ShowDialog();
            if (a.Cancle == false)
            {
                ParentForm.NewName = a.GetTextBox();
                Input.keys.Clear();
                if (ParentForm == null)
                    return;
                Label label2 = (ParentForm.Controls["label2"] as Label);
                label2.Hide();
                ParentForm.Screen = new GameScreen(ParentForm.pictureBox1, 1,ParentForm.MapMode,ParentForm.Skin);
                ParentForm.Gamemode = 1;
                ParentForm.startTimer(1);
                this.Enabled = false;
                this.Hide();
                ParentForm.PauseBackMusic(1);
                ParentForm.PauseSound();
                ParentForm.Controls["ClockLabel"].Hide();
                a.Dispose();
            }
            else
            {
                a.Dispose();
                return;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ParentForm.Controls["ClockLabel"].Show();
            Label label2 = (ParentForm.Controls["label2"] as Label);
            label2.Show();
            Input.keys.Clear();
            if (ParentForm == null)
                return;
            ParentForm.PauseBackMusic(1);
            ParentForm.Screen = new GameScreen(ParentForm.pictureBox1, 2,ParentForm.MapMode,ParentForm.Skin);
            ParentForm.Gamemode = 2;
            ParentForm.startTimer(2);
            ParentForm.startTimer(3);
            ParentForm.PauseSound();
            this.Enabled = false;
            this.Hide();
        }


        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ParentForm.LoadHighScore();
            ParentForm.ShowHighScore();
            this.Visible = false;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            ParentForm.OptionShow();       
        }
    }
}
