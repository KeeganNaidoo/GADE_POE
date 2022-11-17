using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Hero_Game
{
    public abstract class Weapon : Tile /// abtract class that inherits from tile class
    {
        protected int Damage { get; set; } //current damage to target

        protected int Range { get; set; } //how many spaces between target

        protected int Durability { get; set; } //how many hit will the weapon last

        protected int Cost { get; set; } //how many gold to buy item

        protected string WeaponType { get; set; } //type of weapon you are picking up

        public Weapon(int x, int y) : base(x, y)         //constructor with x, y positions
        {
            return;
        }
    }
}
