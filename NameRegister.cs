using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIT_Snake
{
    public partial class NameRegister : Form
    {
        MenuGame menuGame;
        public bool Cancle = false;
        public NameRegister(MenuGame frm)
        {
            InitializeComponent();
            menuGame = frm;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        
        public string GetTextBox()
        {
            if (textBox1.Text == "")
                return "Unknow";
            else
                return textBox1.Text;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Cancle = true;
            this.Hide();
        }
    }
}
