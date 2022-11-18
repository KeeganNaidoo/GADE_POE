using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Hero_Game
{
    public abstract class Tile
    {
        protected int x;
        protected int y;

        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public enum TileType  //Describes the type of tile
        {
            Hero = 'H',
            SwampCreature = 'C',
            Gold = '$',
            Weapon = '|',
            Obstacle = 'X',
            EmptyTile = '.',
            Mage = 'M',
            MeleeWeapon = 'W',
            RangedWeapon = 'R',
            Leader = 'L'
        }

        public Tile(int x, int y)
        {
            X = x;
            Y = y;
        }

        public TileType Type { get; set; }

    }


}






    





