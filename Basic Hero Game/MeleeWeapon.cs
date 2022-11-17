using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Basic_Hero_Game
{
   
   
    public class MeleeWeapon : Weapon
   {
        public enum Types
        {
            Dagger,
            Longsword,
        }

        public MeleeWeapon(int x, int y, Types types) : base(x, y)
        {
            switch (types)
            {
                case Types.Dagger:
                    Durability = 10;
                    Damage = 3;
                    Cost = 3;
                    break;
                case Types.Longsword:
                    Durability = 6;
                    Damage = 4;
                    Cost = 5;
                    break;
                
            }
        }

        protected int Range 
        {
            get { return 1; }
            
        }
    }
    
}
