using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Hero_Game
{
    public class RangedWeapon : Weapon
    {
        public enum Types
        {
            Rifle,
            Longbow

        }
        
        public override int Range 
        {
            get { return base.Range; } 
            set { base.Range = value; }
            
        }

        public RangedWeapon (int x, int y, Types types) : base(x, y)
        {
            switch (types)
            {
                case Types.Rifle:
                    Durability = 3;
                    Damage = 5;
                    Range = 3;
                    Cost = 7;
                    break;
                case Types.Longbow:
                    Durability = 4;
                    Damage = 2;
                    Range = 4;
                    Cost = 6;
                    break;

            }
        }

        public RangedWeapon (int x, int y, int durability, Types types) : base (x, y)
        {

        }
        
    }
}
