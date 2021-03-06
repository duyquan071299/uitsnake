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

        public Obstacle obstacle;

        public bool GameOver;
        //timer của trò chơi
        public GameScreen() { }
        public GameScreen(PictureBox PlayZone,int Gamemode)
        {
            GameMode = Gamemode;
            obstacle = new Obstacle(1);
            snake = new cSnake();
            snake.CreateSnake(9, 9);
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

            if (snake.Alive == false)
            {
                GameOver = (!snake.Alive);
                Winner = 2;
            }
            else if (snake2 != null && snake.Alive == true)
            {
                if (snake.SnakeFight(snake2) == 1 && snake.Alive == true)
                {
                    GameOver = true;
                    Winner = 1;
                }
                else if(snake.SnakeFight(snake2)==2 && snake.Alive == true)
                {
                    GameOver = true;
                    Winner = 2;
                }
                else if(snake.SnakeFight(snake2)==0 && snake.Alive == true)
                {
                    GameOver = true;
                    Winner = 0;
                }
                else
                {
                    GameOver = (!snake2.Alive);
                    Winner = 1;
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
