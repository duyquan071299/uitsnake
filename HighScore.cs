using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIT_Snake
{
    public partial class HighScore : UserControl
    {
        public Form1 ParentForm { get; set; }
        public List<Label> labels1 = new List<Label>();
        public List<Label> labels2 = new List<Label>();
        public HighScore()
        {
            InitializeComponent();
            labels1.AddRange(new Label[]
            {
                label1,
                label2,
                label3,
                label4,
                label5
            });
            labels2.AddRange(new Label[]
              {
                label6,
                label8,
                label9,
                label10,
                label11,
              });
        }

       
        public void LoadHighScore()
        {
            for (int i = 0; i < ParentForm.List.Count(); i++)
            {
                try
                {
                    labels1[i].Text = ParentForm.List[i].Name;
                    labels2[i].Text = ParentForm.List[i].Score.ToString();
                }
                catch { }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            ParentForm.menuGame1.Visible = true;
        }
    }
}
