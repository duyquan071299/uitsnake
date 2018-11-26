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
    public class SnakePart
    {
        public int X { get; set; }
        public int Y { get; set; }

        public SnakePart()
        {
            X = 0;
            Y = 0;
        }
        public SnakePart(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
