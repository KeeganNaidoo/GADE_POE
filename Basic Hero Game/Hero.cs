using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Hero_Game
{
    public class Hero : Character
    {
        public Hero(int x, int y, int hp, int damage) : base(x, y)
        {
            
        }

        public Hero()
        {

        }

        public override ReturnMove()
        {
            
        }

        public override string ToString()
        {
            return base.ToString("Player Stats: " +
                                 "HP:" HP / Max HP +
                                 "Damage" + Damage +
                                 "position" + [X,Y]
                );
        }
    }
}
