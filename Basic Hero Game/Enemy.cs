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
        public TileType EnemyType { get; set; } // For the ToString() method below

        public int EnemyArrayNum { get; set; } // For finding out which enemy to remove when it dies
        public Enemy(int x, int y, int enemyArrayNum) : base(x, y)
        {
            EnemyArrayNum = enemyArrayNum;
        }

        public override string ToString()
        {
            return $"{EnemyType} HP: {HP}/{MaxHP} Damage: {Damage} [{X},{Y}]";
        }

    }
}
