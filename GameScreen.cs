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
    //Class màn hình của game chứa các thuộc tính cơ bản như là rắn, đồ ăn, timer của trò chơi, khu vực di chuyển của rắn,..
   public class GameScreen : Form1
    {
        //rắn thứ 1
        public cSnake snake;
        //rắm thứ 2
        public cSnake snake2;
        //khu vực di chuyển của rắn
        public PictureBox PlayZone;
        //đồ ăn của rắn
        public Food food;
        //người thắng trong chế độ hai người chơi
        public int Winner;

        public int GameMode;

        public Obstacle obstacle;

        public bool GameOver =false;
        //timer của trò chơi
        public GameScreen() { }
        public GameScreen(PictureBox PlayZone,int Gamemode)
        {
            GameMode = Gamemode;
            obstacle = new Obstacle(2);
            snake = new cSnake();
            snake.CreateSnake(9, 10);
            this.PlayZone = PlayZone;
            this.food = new Food();
            food.GenerateFood(PlayZone);
            while (CheckAppear(snake.SNAKE)==1)
                food.GenerateFood(PlayZone);
            while (obstacle.rg.IsVisible(food.X * 16, food.Y * 16))
                food.GenerateFood(PlayZone);
            if (GameMode == 2)
            {
                snake2 = new cSnake();
                snake2.CreateSnake(17, 17);
                while (CheckAppear(snake2.SNAKE) == 1)
                    food.GenerateFood(PlayZone);
                while (obstacle.rg.IsVisible(food.X * 16, food.Y * 16))
                    food.GenerateFood(PlayZone);
            }
            this.snake.Alive = true;
            this.GameOver =false;
        }
        
        public int CheckAppear(List<SnakePart> a)
        {
            for (int i = 0; i < a.Count - 1; i++)
                if (a[i].X == food.X || a[i].Y == food.Y)
                {
                    return 1; 
                }
            return 0;
        }
        public void Update()
        {
            if (snake2 != null)
                snake2.UpdateSnake(PlayZone,food,obstacle);
            snake.UpdateSnake(PlayZone ,food,obstacle);
            if (GameMode == 1)
            {
                if (snake.Alive == false)
                {
                    GameOver = (!snake.Alive);
                    Winner = -1;
                    return;
                }
            }
            if (GameMode == 2)
            {
                if (TimeOver == true)
                {
                    GameOver = true;
                    if (snake.Score > snake2.Score)
                        Winner = 1;
                    else if (snake.Score < snake2.Score)
                        Winner = 2;
                    else
                        Winner = 0;
                    return;
                }
                if (snake.Alive == false)
                {
                    GameOver = true;
                    Winner = 2;
                    return;
                }
                else if (snake2 != null)
                {
                    if (snake.SnakeFight(snake2) == 1 )
                    {
                        GameOver = true;
                        Winner = 1;
                    }
                    else if (snake.SnakeFight(snake2) == 2)
                    {
                        GameOver = true;
                        Winner = 2;
                    }
                    else if (snake.SnakeFight(snake2) == 0 )
                    {
                        GameOver = true;
                        Winner = 0;
                    }
                    else if (!snake2.Alive)
                    {
                        GameOver = true;
                        Winner = 1;
                        return;    
                    }
                    
                    

                }
            }
        }

        public void Draw(Graphics g, Bitmap Image)
        {
                snake.DrawSnake(g, Image);

                if (snake2 != null)
                    snake2.DrawSnake(g, Image);
               food.DrawFood(g, Image);
             obstacle.DrawObstacle(g);
        }
    }
}
