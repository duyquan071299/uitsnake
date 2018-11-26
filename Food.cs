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

    
    public class Food
    {
        public bool isEaten=false;
        public int X;
        public  int Y;

        public Food(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public Food() { }

       
        public void GenerateFood(PictureBox PlayZone)
        {
            int max_tile_w = PlayZone.Width / 16;
            int max_tile_h = PlayZone.Height / 16;
            Random random = new Random();
          
            X = random.Next(0, max_tile_w);
            Y = random.Next(0, max_tile_h);
        }
        int foodtype = 0;
        public void DrawFood(Graphics canvas,Bitmap Image)
        {
       
            if (isEaten == true)
            {
                Random r = new Random();
                foodtype= r.Next(0, 10000);
                isEaten = false;
                
            }
            if (foodtype % 2 == 0)
                canvas.DrawImage(Image, X * 16, Y * 16, new Rectangle(0 * 16, 3 * 16, 16, 16), GraphicsUnit.Pixel);
            else
                canvas.DrawImage(UIT_Snake.Properties.Resources.food_berry, 16 * X, 16 * Y, 16, 16);

        }
    }
}
