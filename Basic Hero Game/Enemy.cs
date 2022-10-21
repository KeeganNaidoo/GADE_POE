using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Hero_Game
{
    public abstract class Enemy : Character
    {
       
        protected Random random = new Random();

        public Enemy(int x, int y, int damage, int hp, int maxhp) : base(x, y)
        {
            
        }

        public override string ToString() 
        {
            return string "Enemy: " + [X, Y] + (Amount DMG)
        }

    }
}
