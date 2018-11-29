using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

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
                timer1.Interval = 1000 / 20;
                timer1.Start();
            }
            else if(Timer==2)
            {
                timer2.Interval = 1000 / 20;
                timer2.Start();
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

                //// Giấu các thuộc tính của Screen
                //this.label1.Hide();
                //Screen.PlayZone.Hide();
                //this.BackgroundImage = null;
                //this.BackColor = Color.White;
                ////Tạo nút Play Again
                //Button PlayAgain = new Button();
                //PlayAgain = button1;
                //PlayAgain.Text = "Play again";
                //Controls.Add(PlayAgain);
                ////Tạo sự kiện Click để chơi lại từ đầu
                //PlayAgain.Click += PlayAgain_Click;
                //button1.Enabled = true;
                //// Set thuộc tính GameOver = false

                Screen.GameOver = false;
               new EndGame(this).ShowDialog();
            }
            else
            {
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

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, true);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, false);
        }

        //    private Bitmap BackBuffer;
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

            //   BackBuffer = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Screen.Draw(e.Graphics, Image);
            //     e.Graphics.DrawImageUnscaled(BackBuffer, pictureBox1.Location.X, pictureBox1.Location.Y);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer2.Interval = 1000 / 10;
            timer2.Start();

            //MenuGame.Enabled = false;
            //MenuGame.Hide();
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
 
        
    }
}
