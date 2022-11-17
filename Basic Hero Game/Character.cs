using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Hero_Game
{
    public abstract class Character : Tile    //abstract base class called Character that inherits from Tile
    {
        public int HP { get; set; } //current hit points

        public int MaxHP { get; set; } //max hit points

        protected int Damage { get; set; } //attack damage

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

        public Character(int x, int y) : base(x, y)
        {

        }

        
       
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

        public void Move(Movement move) //Edits a unit’s X and Y values to move it up/down/left/right based on the identifier from the enum
        {
            if (move == Movement.NoMovement)
            {

            }
            else if (move == Movement.Up)
            {
                Y -= 1; // edit characters coordinates
            }
            else if (move == Movement.Down)
            {
                Y += 1;
            }
            else if (move == Movement.Left)
            {
                X -= 1;
            }
            else if (move == Movement.Right)
            {
                X += 1;
            }

        }

        public abstract Movement ReturnMove(Movement move = 0);



        public abstract override string ToString();

        public void Pickup(Item item) //checks the type of item passed in as a parameter
        {
            return;
        }

    }
    
}
