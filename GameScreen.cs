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
   public class GameScreen
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

        public int SnakeSkin;
        public Obstacle obstacle;

        //Clock count
        public bool TimeOver = false;
        public bool GameOver =false;
        //timer của trò chơi
        public GameScreen() { }
        public GameScreen(PictureBox PlayZone,int Gamemode,int MapMode,int Skin)
        {
            GameMode = Gamemode;
            obstacle = new Obstacle(MapMode);
            snake = new cSnake();
            this.SnakeSkin = Skin;
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
        public void Draw(Graphics g)
        {
            if (SnakeSkin == 1)
                snake.DrawSnake(g, UIT_Snake.Properties.Resources.snake_default);
            else if(SnakeSkin==2)
                snake.DrawSnake(g, UIT_Snake.Properties.Resources.blue_tint_snake);
            else if(SnakeSkin==3)
                snake.DrawSnake(g, UIT_Snake.Properties.Resources.snake_yellow);
            if (snake2 != null)
                snake2.DrawSnake(g, UIT_Snake.Properties.Resources.snake_pale);
            food.DrawFood(g,UIT_Snake.Properties.Resources.snake_default);
            obstacle.DrawObstacle(g);
        }
    }
}
