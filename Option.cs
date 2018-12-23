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
    public partial class Option : UserControl
    {
        public Option()
        {
            InitializeComponent();
        }
        public Form1 ParentForm { get; set; }
     

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.SoundEffectCheck.Checked)
            {
                ParentForm.SoundOption = 0;
            }
            else
                ParentForm.SoundOption = 1;
        }
        
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.BackGroundSoundCheck.Checked)
            {
                ParentForm.PauseBackMusic(0);
            }
            else
                ParentForm.PauseBackMusic(1);


        }

    

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ParentForm.OptionBack();

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.MapRadio1.Checked)
            {
                ParentForm.ChangeMap(1);
            }
            
        }

        private void MapRadio2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.MapRadio2.Checked)
            {
                ParentForm.ChangeMap(2);
            }
        }

        private void Hard_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Hard.Checked)
            {
                ParentForm.ChangeMap(3);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
