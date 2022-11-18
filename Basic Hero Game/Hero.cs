using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Hero_Game
{
    public class Hero : Character
    {
        public Hero(int x, int y, int maxHP) : base(x, y)
        {
            MaxHP = maxHP;
            HP = MaxHP;
            Damage = 2;
            Type = TileType.Hero;
        }

        public Hero(int x, int y, int hp, int maxHP, int gold) : base(x, y) // For loading from save file
        {
            HP = hp;
            MaxHP = maxHP;
            Damage = 2;
            Type = TileType.Hero;
            GoldPurse = gold;
        }
        public bool HeroOnGold { get; set; } = false;
        public override Movement ReturnMove(Movement move)
        {
            if (CharactersVision[(int)move].Type == TileType.EmptyTile)
            {
                return move;
            }
            else if (CharactersVision[(int)move].Type == TileType.Gold) // this is needed to be able to move onto a gold Tile
            {
                HeroOnGold = true;
                return move;
            }
            else return Movement.NoMovement; // returned if the movement is not valid
        }

        public override string ToString()
        {
            return $"Player Stats:\nHP: {HP}/{MaxHP}\nDamage: {Damage}\n[{X},{Y}]"; 
        }
    }
}
