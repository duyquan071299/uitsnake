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

        private void button1_Click(object sender, EventArgs e)
        {
            Input.keys.Clear();
            if (ParentForm == null)
                return;
            Label label2 = (ParentForm.Controls["label2"] as Label);
            label2.Hide();
            ParentForm.Screen = new GameScreen(ParentForm.pictureBox1, 1);

            ParentForm.startTimer(1);

            this.Enabled = false;
            this.Hide();
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Input.keys.Clear();
            if (ParentForm == null)
                return;
            ParentForm.Screen = new GameScreen(ParentForm.pictureBox1, 2);

            ParentForm.startTimer(2);

            this.Enabled = false;
            this.Hide();
        }
    }
}
