using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Hero_Game
{

    public class SwampCreature : Enemy // swamp creature class that inherits from enemy

    

    {
        public SwampCreature(int x, int y, int enemyArrayNum) : base(x, y, enemyArrayNum)
        {
            MaxHP = 10;
            HP = MaxHP;
            Damage = 1;
            EnemyType = TileType.SwampCreature;
            Type = TileType.SwampCreature;

        }
        public SwampCreature(int x, int y, int enemyArrayNum, int hp) : base(x, y, enemyArrayNum) // For loading from save file
        {
            MaxHP = 10;
            HP = hp;
            Damage = 1;
            EnemyType = TileType.SwampCreature;
            Type = TileType.SwampCreature;
        }

        public override Movement ReturnMove(Movement move = 0) // Chooses a random direction to move to and checks if it's valid
        {
            int direction;
            for (int i = 0; i < 4; i++) // checks 4 times if the space in a different random direction is empty.
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

        /*public SwampCreature (int HP, int Damage)
        {
            this.HP = HP;
            this.Damage = Damage;
        }

        public override void ReturnMove()
        {
            Random random = new Random(); // randomises a direction to move in
            //returns only a valid movement

        }*/

        
    }
}
