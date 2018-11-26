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
    public partial class EndGame : Form
    {
        Form1 form1;
       
        public EndGame(Form1 frm)
        {
            
            InitializeComponent();
            form1 = frm;
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            Input.keys.Clear();
            form1.Screen = new GameScreen(form1.pictureBox1, 1);
            form1.startTimer();
            this.Close();
        }
    }
}
