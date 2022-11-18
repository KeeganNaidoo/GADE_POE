using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Hero_Game
{
    public class Leader : Enemy
    {
        private int Target { get; set; } 
        private int Player { get; set; }    

        public Leader(int x, int y, int enemyArrayNum) : base(x, y, enemyArrayNum)
        {
            MaxHP = 20;
            HP = MaxHP;
            Damage = 2;
            EnemyType = TileType.Leader;
            Type = TileType.Leader;

        }

        public override Movement ReturnMove(Movement move = Movement.NoMovement)
        {
            int direction;
            for (int i = 0; i < 3; i++)
            {
                direction = random.Next(1, 5);
                move = (Movement)direction; // Cast the int value to its corresponding enum value
                if (CharactersVision[(int)move].Type == TileType.EmptyTile) // Checks if movement is valid
                {
                    return move;

                }
            }
            return Movement.NoMovement;
        }
    }
}
