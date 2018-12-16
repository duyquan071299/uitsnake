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
    public class cSnake
    {
        public int direction { get; set; }

        public List<SnakePart> SNAKE;

        public int Score;

        public bool Alive;
        public void CreateSnake(int x, int y)
        {
            Alive = true;
            Score = 0;
            direction = -1;
            SNAKE = new List<SnakePart>();
          
            SnakePart head = new SnakePart(x, y);

            SnakePart defaultbody = new SnakePart(x - 1, y);

            SnakePart defaultbody1 = new SnakePart(x - 2, y);

            SnakePart tail = new SnakePart(x - 3, y);
           
            SNAKE.AddRange(new SnakePart[] {
               head,
               defaultbody,
               defaultbody1,
               tail,
           });

        }
        Point temp1;
        public int temp;
        //public int State=1;
        //public int LastDirection = -1;
        public void UpdateSnake(PictureBox PlayZone,Food food,Obstacle obstacles)
        {
           

            if (direction==-1)
            {
                return; 
            }
            for (int i = 0; i <SNAKE.Count; i++)
            {
               
                if (i == 0)
                {
                    temp1 = new Point(SNAKE[0].X, SNAKE[0].Y);
                   
                    switch (direction)
                    {
                        case 0: // Down
                            SNAKE[i].Y++;
                            break;
                        case 1: // Left
                            SNAKE[i].X--;
                            break;
                        case 2: // Right
                            SNAKE[i].X++;
                            break;
                        case 3: // Up
                            SNAKE[i].Y--;
                            break;
                        default:
                            break;
                    }
                    if (obstacles.rg.IsVisible(SNAKE[i].X * 16, SNAKE[i].Y * 16))
                    {
                        if (direction == 0)
                            SNAKE[i].Y--;
                        else if (direction == 1)
                            SNAKE[i].X++;
                        else if (direction == 2)
                            SNAKE[i].X--;
                        else if (direction == 3)
                            SNAKE[i].Y++;
                        Alive = false;
                        return;
                    }
 
                    int max_tile_w = PlayZone.Width / 16;
                    int max_tile_h = PlayZone.Height / 16;
                   // temp = max_tile_w;

                    if (SNAKE[i].X < 0 || SNAKE[i].X > max_tile_w-1 || SNAKE[i].Y < 0 || SNAKE[i].Y > max_tile_h-1 )
                    {
                        if (direction == 0)
                            SNAKE[i].Y--;
                        else if (direction == 1)
                            SNAKE[i].X++;
                        else if (direction == 2)
                            SNAKE[i].X--;
                        else if (direction == 3)
                            SNAKE[i].Y++;
                        Alive = false;
                        return;
                        //if (direction==1)
                        //{
                        //    SNAKE[i].X = max_tile_w - 1;
                        //    State = 2;
                        //}
                    }


                    for (int j = 1; j < SNAKE.Count; j++)
                        if (SNAKE[i].X == SNAKE[j].X && SNAKE[i].Y == SNAKE[j].Y)
                        {
                            while (j!= SNAKE.Count)
                            {
                                SNAKE.RemoveAt(SNAKE.Count-1);
                                Score--;
                            }

                        }
                    if (SNAKE[i].X == food.X && SNAKE[i].Y == food.Y)
                    {
                        food.isEaten = true;
                        SnakePart temp = new SnakePart();
                        temp.X = SNAKE[SNAKE.Count - 1].X;
                        temp.Y = SNAKE[SNAKE.Count - 1].Y;
                        SNAKE.Add(temp);
                        if (SNAKE[SNAKE.Count - 1].Y < SNAKE[SNAKE.Count - 3].Y)
                            SNAKE[SNAKE.Count - 1].Y--;
                        else if (SNAKE[SNAKE.Count - 1].X > SNAKE[SNAKE.Count - 3].X)
                            SNAKE[SNAKE.Count - 1].X++;
                        else if (SNAKE[SNAKE.Count - 1].X < SNAKE[SNAKE.Count - 3].X)
                            SNAKE[SNAKE.Count - 1].X--;
                        else if (SNAKE[SNAKE.Count - 1].Y > SNAKE[SNAKE.Count - 3].Y)
                            SNAKE[SNAKE.Count - 1].Y++;
                        food.GenerateFood(PlayZone);
                        for (int j = 0; j < SNAKE.Count - 1; j++)
                            while (SNAKE[i].X == food.X || SNAKE[i].Y == food.Y)
                            {
                                food.GenerateFood(PlayZone);
                            }
                       while(obstacles.rg.IsVisible(food.X * 16, food.Y * 16))
                            food.GenerateFood(PlayZone);
                        Score++;
                        
                    }
                 
                }
                else
                {
                    Point temp2 = new Point(temp1.X, temp1.Y);
                    temp1.X = SNAKE[i].X;
                    temp1.Y = SNAKE[i].Y;
                    SNAKE[i].X = temp2.X;
                    SNAKE[i].Y = temp2.Y;
                }
            
            }
        }
       
        public void DrawSnake(Graphics canvas,Bitmap Image)
        {
            //  Graphics canvas = Graphics.FromImage(g);
            for (int i = SNAKE.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {

                    if (SNAKE[i].X > SNAKE[i + 1].X )//right
                        canvas.DrawImage(Image, SNAKE[i].X * 16, SNAKE[i].Y * 16, new Rectangle(4 * 16, 0 * 16, 16, 16), GraphicsUnit.Pixel);
                    else if (SNAKE[i].Y > SNAKE[i + 1].Y)//down                             
                        canvas.DrawImage(Image, SNAKE[i].X * 16, SNAKE[i].Y * 16, new Rectangle(4 * 16, 1 * 16, 16, 16), GraphicsUnit.Pixel);
                    else if (SNAKE[i].X < SNAKE[i + 1].X )//left
                        canvas.DrawImage(Image, SNAKE[i].X * 16, SNAKE[i].Y * 16, new Rectangle(3 * 16, 1 * 16, 16, 16), GraphicsUnit.Pixel);
                    else if (SNAKE[i].Y < SNAKE[i + 1].Y)//up
                        canvas.DrawImage(Image, SNAKE[i].X * 16, SNAKE[i].Y * 16, new Rectangle(3 * 16, 0 * 16, 16, 16), GraphicsUnit.Pixel);

                }
                else if (i == SNAKE.Count - 1)
                {
                    if (SNAKE[i].X > SNAKE[i - 1].X )//left
                        canvas.DrawImage(Image, SNAKE[i].X * 16, SNAKE[i].Y * 16, new Rectangle(3 * 16, 3 * 16, 16, 16), GraphicsUnit.Pixel);
                    else if (SNAKE[i].Y > SNAKE[i - 1].Y)//down
                        canvas.DrawImage(Image, SNAKE[i].X * 16, SNAKE[i].Y * 16, new Rectangle(3 * 16, 2 * 16, 16, 16), GraphicsUnit.Pixel);
                    else if ((SNAKE[i].X < SNAKE[i - 1].X))//right
                        canvas.DrawImage(Image, SNAKE[i].X * 16, SNAKE[i].Y * 16, new Rectangle(4 * 16, 2 * 16, 16, 16), GraphicsUnit.Pixel);
                    else if (SNAKE[i].Y < SNAKE[i - 1].Y)//up
                        canvas.DrawImage(Image, SNAKE[i].X * 16, SNAKE[i].Y * 16, new Rectangle(4 * 16, 3 * 16, 16, 16), GraphicsUnit.Pixel);
                }
                else
                {
                    {
                        if ((SNAKE[i].X < SNAKE[i - 1].X && SNAKE[i].X > SNAKE[i + 1].X) || (SNAKE[i].X > SNAKE[i - 1].X && SNAKE[i].X < SNAKE[i + 1].X))
                            canvas.DrawImage(Image, SNAKE[i].X * 16, SNAKE[i].Y * 16, new Rectangle(1 * 16, 0 * 16, 16, 16), GraphicsUnit.Pixel);
                        else if ((SNAKE[i].Y > SNAKE[i - 1].Y && SNAKE[i].Y < SNAKE[i + 1].Y) || (SNAKE[i].Y < SNAKE[i - 1].Y && SNAKE[i].Y > SNAKE[i + 1].Y))
                            canvas.DrawImage(Image, SNAKE[i].X * 16, SNAKE[i].Y * 16, new Rectangle(2 * 16, 1 * 16, 16, 16), GraphicsUnit.Pixel);
                        else if ((SNAKE[i].X > SNAKE[i + 1].X && SNAKE[i].Y > SNAKE[i - 1].Y) || (SNAKE[i].X > SNAKE[i - 1].X && SNAKE[i].Y > SNAKE[i + 1].Y))
                            canvas.DrawImage(Image, SNAKE[i].X * 16, SNAKE[i].Y * 16, new Rectangle(2 * 16, 2 * 16, 16, 16), GraphicsUnit.Pixel);
                        else if ((SNAKE[i].X > SNAKE[i - 1].X && SNAKE[i].Y < SNAKE[i + 1].Y) || (SNAKE[i].Y < SNAKE[i - 1].Y && SNAKE[i].X > SNAKE[i + 1].X))
                            canvas.DrawImage(Image, SNAKE[i].X * 16, SNAKE[i].Y * 16, new Rectangle(2 * 16, 0 * 16, 16, 16), GraphicsUnit.Pixel);
                        else if ((SNAKE[i].X < SNAKE[i - 1].X && SNAKE[i].Y > SNAKE[i + 1].Y) || (SNAKE[i].X < SNAKE[i + 1].X && SNAKE[i].Y > SNAKE[i - 1].Y))
                            canvas.DrawImage(Image, SNAKE[i].X * 16, SNAKE[i].Y * 16, new Rectangle(0 * 16, 1 * 16, 16, 16), GraphicsUnit.Pixel);
                        else if ((SNAKE[i].X < SNAKE[i - 1].X && SNAKE[i].Y < SNAKE[i + 1].Y) || (SNAKE[i].X < SNAKE[i + 1].X && SNAKE[i].Y < SNAKE[i - 1].Y))
                            canvas.DrawImage(Image, SNAKE[i].X * 16, SNAKE[i].Y * 16, new Rectangle(0 * 16, 0 * 16, 16, 16), GraphicsUnit.Pixel);
                    }
                }
            }
        }
       
        public int SnakeFight(cSnake b)
        {
            for(int i=0;i<this.SNAKE.Count;i++)
            {

                if (b.SNAKE[0].X == this.SNAKE[i].X && b.SNAKE[0].Y == this.SNAKE[i].Y)
                {
                    if (i == 0)
                    {
                        if (b.SNAKE.Count == this.SNAKE.Count)
                            return 0;//tie
                        else if (b.SNAKE.Count > this.SNAKE.Count)
                            return 2;// b win
                    }
                    return 1;//a win
                }
                
            }
            for (int i = 0; i < b.SNAKE.Count; i++)
            {
                if (this.SNAKE[0].X == b.SNAKE[i].X && this.SNAKE[0].Y == b.SNAKE[i].Y)
                {
                    if (i == 0)
                    {
                        if (b.SNAKE.Count == this.SNAKE.Count)
                            return 0;//tie
                        else if (this.SNAKE.Count > b.SNAKE.Count)
                            return 1;// a win
                    }
                    return 2;//b win
                }
                   
            }
            return -1;
        }
    }


}
