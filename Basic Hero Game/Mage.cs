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

        public override Movement ReturnMove(Movement move = 0)
        {
            return Movement.NoMovement;
        }

        public override bool CheckRange(Character target)  //Checks if a target is inrange of the mage
        {
            double distance = Math.Pow(target.X - X, 2) + Math.Pow(target.Y - Y, 2); 
            distance = Math.Sqrt(distance);

            return distance <= 1.5; 
            

        }
    }
}
