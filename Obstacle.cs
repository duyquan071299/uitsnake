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
    public class Obstacle
    {
        public int MapMode;
        public List<Rectangle> ob = new List<Rectangle>();
        public Region rg;
        public Obstacle() { }
        public Obstacle(int option)
        {
            MapMode = option;
            if (MapMode == 1)
            {
                Rectangle ob1 = new Rectangle(5*16 , 6*16 , 400, 16);
                ob.Add(ob1);
                ob1 = new Rectangle(5 * 16, 22 * 16, 400, 16);
                ob.Add(ob1);
                ob1 = new Rectangle(5 * 16, 11 * 16, 16, 112);
                ob.Add(ob1);
                ob1 = new Rectangle(29 * 16, 11 * 16, 16, 112);
                ob.Add(ob1);
                rg = new Region(ob[0]);
                Region rg1 = new Region(ob[1]);
                Region rg2 = new Region(ob[2]);
                Region rg3 = new Region(ob[3]);
                rg.Union(rg1);
                rg.Union(rg2);
                rg.Union(rg3);
            }
            else if(MapMode==2)
            {
            


            }
        }
        public void DrawObstacle(Graphics canvas)
        {

            canvas.DrawImage(UIT_Snake.Properties.Resources.ob1, ob[0]);
            canvas.DrawImage(UIT_Snake.Properties.Resources.ob1, ob[1]);
            canvas.DrawImage(UIT_Snake.Properties.Resources.ob2, ob[2]);
            canvas.DrawImage(UIT_Snake.Properties.Resources.ob2, ob[3]);


            //for(int i=0;i<a.Count;i++)
            //{
            //    canvas.DrawImage(Image,a[i].X*16, a[i].Y*16,16,16);
            //}
        }


    }
}
