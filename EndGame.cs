﻿using System;
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
            label2.Text += ("\n  Score:" + form1.Screen.snake.Score.ToString());
        }


      
        private void button1_Click(object sender, EventArgs e)
        {
            Input.keys.Clear();
            if (form1.Screen.GameMode == 1)
            {
                form1.Screen = new GameScreen(form1.pictureBox1, 1);
                form1.startTimer(1);
            }
            else if(form1.Screen.GameMode==2)
            {
                form1.Screen = new GameScreen(form1.pictureBox1, 2);
                form1.startTimer(2);
            }
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            form1.menuGame1.Enabled = true;
            form1.menuGame1.Show();
            this.Close();
        }
    }
}
