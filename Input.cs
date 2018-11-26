using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace UIT_Snake
{
    class Input
    {
        public static Hashtable keys = new Hashtable();
        public static void ChangeState(Keys key, bool state)
        {
            keys[key] = state;
        }
        public static bool Pressed(Keys key)
        {
            if (keys[key] == null)
                return false;
            return (bool)keys[key];
        }
    }
}
