using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Hero_Game
{
    public class Obstacle : Tile       
    {
        public Obstacle(int x, int y) : base(x,y)    //calls the base class’s constructor with X and Y parameters.
        {
            Type = TileType.Obstacle;
        }
    }
}
