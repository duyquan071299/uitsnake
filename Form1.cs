﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;

namespace UIT_Snake
{

    public partial class Form1 : Form
    {
        //Tạo màn hình chơi của game
        public GameScreen Screen;
        //Tạo bitmap để lưu ảnh
        Bitmap Image;
        public Form1()
        {

            InitializeComponent();
            //Lưu ảnh các bộ phận và đồ ăn của rắn vào bitmap Image
            Image = new Bitmap(UIT_Snake.Properties.Resources.snake_graphics_1);
            this.menuGame1.ParentForm = this;

        }

        public void startTimer(int Timer)
        {
            if (Timer == 1)
            {
                timer1.Interval = 1000 / 10;
                timer1.Start();
            }
            else if(Timer==2)
            {
                timer2.Interval = 1000 / 10;
                timer2.Start();
            }
            else if (Timer==3)
            {
                minute = 1;
                second = 30;
                timerClock.Start();
            }
        }

        public void Sort(string[] a)
        {
            for (int i = 0; i < a.Length-1; i++)
            {
                if (a[i] == "")
                    continue;
                for (int j = i+1; j < a.Length ; j++)
                {
                    if (int.Parse(a[i]) > int.Parse(a[j]))
                    {
                        string temp = a[i];
                        a[i] = a[j];
                        a[j] = temp;
                    }
                }
            }

        }
     

        //Timer của chế độ một người chơi
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            //Label lưu điểm
            label1.Text = "Score: " + Screen.snake.Score;
            //Logic của game
            //Nếu GameOver thì vẽ menu endgame
            if (Screen.GameOver == true)
            {
                timer1.Stop();

                
                string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\HighScore.txt";

                string[] lines = System.IO.File.ReadAllLines(path);
              
                if (lines.Length <= 5)
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(path, true))
                    {
                        file.WriteLine(Screen.snake.Score.ToString());
                    }
                }
                else
                {
                    Sort(lines);
                    for (int i=0;i<lines.Length;i++)
                    {
                        if (lines[i] == "")
                            continue;
                        if(Screen.snake.Score>int.Parse(lines[i]))
                        {
                            lines[i] = Screen.snake.Score.ToString();
                            break;
                        }
                    }
                    Sort(lines);
                    System.IO.File.WriteAllLines(path, lines);
                 
                }
          
                Screen.GameOver = false;
               new EndGame(this).ShowDialog();
            }
            else
            {
                SetLevelOfSnake();
                //Input là hàm lưu trạng thái của nút bấm
                //Nếu S thì hướng đi sẽ là 0(đi xuống) 
                if (Input.Pressed(Keys.S))
                {
                    //Hướng đi được chỉnh là đi xuống chỉ trong trường hợp rắn di chuyển ngang, tức là tọa độ y của ĐẦU và THÂN bằng nhau theo trục tọa độ. 
                    if (Screen.snake.SNAKE[0].Y == Screen.snake.SNAKE[1].Y)
                        Screen.snake.direction = 0;
                }
                //Tương tự trên
                else if (Input.Pressed(Keys.A))
                {
                    if (Screen.snake.SNAKE[0].X == Screen.snake.SNAKE[1].X)
                        Screen.snake.direction = 1;
                }
                //Tương tự trên
                else if (Input.Pressed(Keys.D))
                {
                    if (Screen.snake.direction == -1 || Screen.snake.SNAKE[0].X == Screen.snake.SNAKE[1].X)

                        Screen.snake.direction = 2;
                }
                //Tương tự trên
                else if (Input.Pressed(Keys.W))
                {
                    if (Screen.snake.SNAKE[0].Y == Screen.snake.SNAKE[1].Y)
                        Screen.snake.direction = 3;
                }
               
                //Sau khi thay đổi hướng Update lại màn hình chơi
                Screen.Update();
            }
            //Invalidate trigger sự kiện paint của form
            pictureBox1.Invalidate();


        }

        private void PlayAgain_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = UIT_Snake.Properties.Resources.Snake_main;
            this.label1.Show();
            Screen = new GameScreen(pictureBox1, 1);
            Screen.PlayZone.Show();
            timer1.Interval = 150;
            timer1.Start();
            button1.Enabled = false;

        }
        int Press = 0;
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, true);
            if (e.KeyCode == Keys.P && Press==0)
            {
                timer1.Stop();
                Press = 1;
            }
            else if(e.KeyCode == Keys.P && Press == 1)
            {
                timer1.Start();
                Press = 0;
            }
            else if(e.KeyCode==Keys.Q)
            {
                Application.Exit();
            }
            else if (e.KeyCode== Keys.K)
            {

                timer1.Interval = 100 / 2;
            }
            e.SuppressKeyPress = true;


        }
        
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, false);
            if (e.KeyCode == Keys.K)
            {
                timer1.Interval = 100 / 1;
            }
            e.SuppressKeyPress = true;

        }

        //    private Bitmap BackBuffer;
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

            Screen.Draw(e.Graphics, Image);

        }
        private void SetLevelOfSnake()
        {
            switch (Screen.snake.Score)
            {
                case 5:
                    timer1.Interval = 50;
            
                    break;
                case 10:
                    timer1.Interval = 60;
                    break;
                case 30:
                    timer1.Interval = 70;
                    break;

            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            timer2.Interval = 1000 / 10;
            timer2.Start();
            timerClock.Start();
            
            Screen = new GameScreen(pictureBox1, 2);
        }
        Label a = new Label();
        private void timer2_Tick(object sender, EventArgs e)
        {
            label1.Text = "Snake 1 Score :" + Screen.snake.Score;
            label2.Text = "Snake 2 Score: " + Screen.snake2.Score;
            if (Screen.GameOver == true)
            {
                timer2.Stop();
                Screen.GameOver = false;
                new EndGame(this).ShowDialog();
            }
            else
            {
                if (Input.Pressed(Keys.S))
                {
                    if (Screen.snake.SNAKE[0].Y == Screen.snake.SNAKE[1].Y)
                        Screen.snake.direction = 0;
                }
                else if (Input.Pressed(Keys.A))
                {
                    if (Screen.snake.SNAKE[0].X == Screen.snake.SNAKE[1].X)
                        Screen.snake.direction = 1;
                }
                else if (Input.Pressed(Keys.D))
                {
                    if (Screen.snake.direction == -1 || Screen.snake.SNAKE[0].X == Screen.snake.SNAKE[1].X)

                        Screen.snake.direction = 2;
                }
                else if (Input.Pressed(Keys.W))
                {
                    if (Screen.snake.SNAKE[0].Y == Screen.snake.SNAKE[1].Y)
                        Screen.snake.direction = 3;
                }

                if (Input.Pressed(Keys.Down))
                {
                    if (Screen.snake2.SNAKE[0].Y == Screen.snake2.SNAKE[1].Y)
                        Screen.snake2.direction = 0;
                }
                else if (Input.Pressed(Keys.Left))
                {
                    if (Screen.snake2.SNAKE[0].X == Screen.snake2.SNAKE[1].X)
                        Screen.snake2.direction = 1;
                }
                else if (Input.Pressed(Keys.Right))
                {
                    if (Screen.snake2.direction == -1 || Screen.snake2.SNAKE[0].X == Screen.snake2.SNAKE[1].X)

                        Screen.snake2.direction = 2;


                }
                else if (Input.Pressed(Keys.Up))
                {
                    if (Screen.snake2.SNAKE[0].Y == Screen.snake2.SNAKE[1].Y)
                        Screen.snake2.direction = 3;
                }
                Screen.Update();
            }

            pictureBox1.Invalidate();
        }

        private void ClockLabel_Click(object sender, EventArgs e)
        {

            //timerClock.Enabled = true;
        }
        int minute = 1;
        int second = 30;
        private void timerClock_Tick(object sender, EventArgs e)
        {
            
            second--;
            ClockLabel.Text = minute.ToString() + " : " + second.ToString();
            if (second == 0)
            {
                second = 59;
                minute--;
            }

        }
        
    }
}
