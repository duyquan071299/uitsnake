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
        public int Gamemode, MapMode =1 ;
        public string NewName;
        public int SnakeSpeed;
        public int Levelflag = 0;
        public PlayerInfo[] List;
        public int count = 0;
        public int SoundOption;
        Bitmap Image;
        public static string FileLocation = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        
        SoundEffect BackgroundMusic = new SoundEffect( FileLocation + "\\sound\\background.mp3");
        Option _option = new Option();


        public Form1()
        {
            InitializeComponent();
            //Lưu ảnh các bộ phận và đồ ăn của rắn vào bitmap Image
            Image = new Bitmap(UIT_Snake.Properties.Resources.snake_yellow);
            this.menuGame1.ParentForm = this;
            this.highScore1.ParentForm = this;
            this._option.ParentForm = this;
            highScore1.Visible = false;
            LoadData();
            this.Controls.Add(_option);
            _option.Visible = false;
        }
        public void ChangeMap(int Select)
        {
            switch (Select)
            {
                case 1:
                    MapMode = 1;
                    break;
                case 2:
                    MapMode = 2;
                    break;
                case 3:
                    MapMode = 3;
                    break;
            }
        }
        public void OptionShow ()
        {
            _option.Show();
            _option.BringToFront();
            
        }
        public void OptionBack()
        {
            _option.Hide();
        }
        
        public void PauseBackMusic(int option)
        {
            if (option == 1)
                BackgroundMusic.PauseSound();
            else
                BackgroundMusic.PlaySound();
            
        }
        public void PauseSound()
        {
            if (SoundOption == 0)
            {
                Screen.snake.SoundOn = true;
                if (Screen.snake2 != null)
                    Screen.snake2.SoundOn = true;
                return;
            }
            else
            {
                Screen.snake.SoundOn = false;
                if (Screen.snake2 != null)
                    Screen.snake2.SoundOn = false;
                return;
            }

        }
        public void ShowHighScore()
        {
            highScore1.Visible = true;
            highScore1.BringToFront();
        }
        public void LoadHighScore()
        {
            highScore1.LoadHighScore();
        }

       
        public void LoadData()
        {
            List = new PlayerInfo[5] ;
            string[] lines = System.IO.File.ReadAllLines(FileLocation + "\\HighScore.txt");
            
            StreamReader sr = new StreamReader(FileLocation + "\\HighScore.txt");
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] Values = line.Split('|');
           
                List[count++] = new PlayerInfo(Values[0], int.Parse(Values[1]), int.Parse(Values[2]));
                
            }
            sr.Close();
            for (int i = 0; i < count-1; i++)
                for (int j = 0; j < count - i-1; j++)
                    if (List[j].Score < List[j + 1].Score)
                    {
                        PlayerInfo temp = List[j];
                        List[j] = List[j + 1];
                        List[j + 1] = temp;
                    }
        }

        public void SaveData(PlayerInfo[] List)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(FileLocation + "\\HighScore.txt"))
            {
                for (int i = 0; i < count; i++)
                    file.WriteLine(List[i].Name + "|" + List[i].Score + "|" + List[i].Rank);
            }
        }

        public void startTimer(int Timer)
        {
            if (Timer == 1)
            {
                timer1.Interval = SnakeSpeed= 100;
                timer1.Start();
            }
            else if (Timer == 2)
            {
                timer2.Interval = SnakeSpeed = 100;
                timer2.Start();
            }
            else if (Timer == 3)
            {
                minute = 0;
                second = 29;
                Screen.TimeOver = false;
                timerClock.Start();
                ClockLabel.Text = minute.ToString() + " : " + (second+1).ToString();
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
                new EndGame(this).ShowDialog();
                if (count < 5)
                {
                    List[count++] = new PlayerInfo(NewName, Screen.snake.Score, count + 1);
                    SaveData(List);
                }
                else
                {
                    if (Screen.snake.Score > List[count - 1].Score)
                    {
                        List[count - 1].Score = Screen.snake.Score;
                        List[count - 1].Name = NewName;
                        SaveData(List);
                    }
                    for (int i = 0; i < count - 1; i++)
                        for (int j = 0; j < count - i - 1; j++)
                            if (List[j].Score < List[j + 1].Score)
                            {
                                PlayerInfo temp = List[j];
                                List[j] = List[j + 1];
                                List[j + 1] = temp;
                            }
                    Screen.GameOver = false;
                }
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
        int Press = 0;
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, true);
            if (e.KeyCode == Keys.P && Press == 0)
            {
                if (Gamemode == 1)
                {
                    timer1.Stop();
                }
                else
                    timer2.Stop();
                Press = 1;
            }
            else if (e.KeyCode == Keys.P && Press == 1)
            {
                if (Gamemode == 1)
                {
                    timer1.Start();
                }
                else
                    timer2.Start();
                Press = 0;
            }
            else if (e.KeyCode == Keys.Escape )
            {
                Application.Exit();
            }
            else if (e.KeyCode == Keys.Space)
            {
                timer1.Interval = SnakeSpeed-40;
            }
            e.SuppressKeyPress = true;
        }
        public static int minute = -1;
        public static int second = -1;
        

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, false);
            if (e.KeyCode == Keys.Space)
            {
                timer1.Interval = SnakeSpeed;
            }
            e.SuppressKeyPress = true;

        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                Screen.Draw(e.Graphics, Image);
            }
            catch { }

        }
        private void SetLevelOfSnake()
        {
            if(Screen.snake.Score<5)
            {
                if (Levelflag != 1)
                {
                    timer1.Interval = SnakeSpeed = 100;
                    Levelflag = 1;
                }
            }
            else if(Screen.snake.Score>=5 && Screen.snake.Score<10)
            {
                if (Levelflag != 2)
                {
                    timer1.Interval = SnakeSpeed = 80;
                    Levelflag = 2;
                }
            }
            else if(Screen.snake.Score>=10 && Screen.snake.Score<30)
            {
                if (Levelflag != 3)
                {
                    timer1.Interval = SnakeSpeed = 60;
                    Levelflag = 3;
                }
            }
            else if (Screen.snake.Score >=30)
            {
                if (Levelflag != 4)
                {
                    timer1.Interval = SnakeSpeed = 50;
                    Levelflag = 4;
                }
            }

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
               
        private void timerClock_Tick(object sender, EventArgs e)
        {
            if (minute == 0 && second == 0)
            {
                timerClock.Stop();
                Screen.TimeOver = true;
                ClockLabel.Text = minute.ToString() + " : " + second.ToString();
                return;
            }
            ClockLabel.Text = minute.ToString() + " : " + second.ToString();
            second--;
            if (second == 0&&minute!=0)
            {
                second = 59;
                minute--;
            }
        }

    }
}
