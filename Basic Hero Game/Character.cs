using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Hero_Game
{
    public abstract class Character : Tile    //abstract base class called Character that inherits from Tile
    {
        public Character(int x, int y) : base(x, y)
        {

        }
        public int HP { get; set; } //current hit points

        public int MaxHP { get; set; } //max hit points

        protected int Damage { get; set; } //attack damage

        public int PublicHP
        {
            get { return HP; }
            set { HP = value; }
        }
        public int PublicMaxHP
        {
            get { return MaxHP; }
            set { MaxHP = value; }
        }


        public enum Movement
        {
            NoMovement,
            Up,
            Down,
            Left,
            Right,
        }

        public int GoldPurse { get; set; }

        public Tile[] CharactersVision { get; set; } = new Tile[5];

        
        public virtual void Attack(Character target) // Attacks a target and decreases its health by the attacking character’s damage
        {
            target.HP = target.HP - Damage;

            //MaxHP = MaxHP - HP;(old code)

        }

        public bool IsDead() //Checks if the character is dead
        {
           if (HP <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
           //return HP <= 0; this is shorter version of the above code.
        }

        public virtual bool CheckRange(Character target)  //Checks if a target is inrange of a character
        {
            return DistanceTo(target) == 1;
            
        }

        private int DistanceTo(Character target) //: Determines the absolute distance between a character and its target
        {
            return Math.Abs(target.X - X) + Math.Abs(target.Y - Y);    
        }

        public void Move(Movement move, Tile characterTile) //Edits a unit’s X and Y values to move it up/down/left/right based on the identifier from the enum
        {
            Map.TileMap[Y, X] = new EmptyTile(X, Y);
            switch (move)
            {
                case Movement.NoMovement:
                    break;
                case Movement.Up:
                    Y -= 1; // Edit Character's coordinates
                    break;
                case Movement.Down:
                    Y += 1;
                    break;
                case Movement.Left:
                    X -= 1;
                    break;
                case Movement.Right:
                    X += 1;
                    break;
            }
            Map.TileMap[Y, X] = characterTile; // The new space changes to Character

        }

        public void PickUp(Item i)
        {
            if (i.Type == TileType.Gold)
            {
                Gold gold = i as Gold; // You need to cast from Item to Gold to be able to access GoldAmount in the Gold class
                GoldPurse += gold.GoldAmount;
            }
        }

        public abstract Movement ReturnMove(Movement move = 0);



        public abstract override string ToString();

        

    }
    
}
