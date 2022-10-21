using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Hero_Game
{
    public abstract class Tile
    {
        protected  int X; 
        protected  int Y; 

        public enum TileType  //Describes the type of tile
        {
            Hero = 'H',
            SwampCreature = 'C',
            Gold = '$', 
            Weapon = '|',
            Obstacle = 'X',
            EmptyTile = '.',
        }

        public Tile(int x, int y)
        {
            this.X = x;
            this.X = y;
        }
        struct Position 
        {
            public int x;
            public int y;

            public void SetPosition(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

    }


}






    





