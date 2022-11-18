using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Hero_Game
{
    public class Mage : Enemy
    {
       // private Mage mage;
        public Mage(int x, int y, int enemyArrayNum) : base(x, y, enemyArrayNum)
        {
            MaxHP = 5;
            HP = MaxHP;
            Damage = 5;
            EnemyType = TileType.Mage;
            Type = TileType.Mage;

        }
        public Mage(int x, int y, int enemyArrayNum, int hp) : base(x, y, enemyArrayNum) // For loading from save file
        {
            MaxHP = 5;
            HP = hp;      // The game could be saved at a point where a Mage doesn't have full health
            Damage = 5;
            EnemyType = TileType.Mage;
            Type = TileType.Mage;
        }

        public override Movement ReturnMove(Movement move = 0)
        {
            return Movement.NoMovement;
        }

        public override bool CheckRange(Character target)  //Checks if a target is inrange of the mage
        {
            /*double distance = Math.Pow(target.X - X, 2) + Math.Pow(target.Y - Y, 2); 
            distance = Math.Sqrt(distance);

            return distance <= 1.5;*/

            // Use regular distance formula
            double distance = Math.Pow(target.X - X, 2) + Math.Pow(target.Y - Y, 2);

            //distance = Math.Sqrt(distance);
            distance = Math.Abs(distance);
            //return distance <= 1.5 && distance > 0; // alternative value if square root is used 

            // Without square root because square root is CPU intensive
            return distance <= 2 && distance > 0;
        }                           // distance > 0 so that Mages don't attack themselves when attacking other enemies

    }
    }
}
