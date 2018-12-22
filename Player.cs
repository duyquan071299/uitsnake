using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UIT_Snake
{
    public class PlayerInfo
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public int Rank { get; set; }
       

        public PlayerInfo() { }
        public PlayerInfo(string name, int score,int rank)
        {
            this.Name = name;
            this.Score = score;
            this.Rank = rank;
        }
    }
}
