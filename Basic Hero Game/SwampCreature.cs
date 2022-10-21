using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Hero_Game
{

    public class SwampCreature : Enemy // swamp creature class that inherits from enemy

    

    {
        public SwampCreature(int x, int y) : base(x, y)
        {


        }



        public SwampCreature (int HP, int Damage)
        {
            this.HP = HP;
            this.Damage = Damage;
        }

        public override void ReturnMove()
        {
            Random random = new Random(); // randomises a direction to move in
            //returns only a valid movement

        }

        
    }
}
