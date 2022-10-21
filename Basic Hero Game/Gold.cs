using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Hero_Game
{
    public class Gold : Item
    {
        private Random random = new Random();
        private int goldAmount;
        public int GoldAmount 
        {
            get { return GoldAmount; }
            set { goldAmount = value; }
        }

        //gold amount is in the item class because it cant be seen by the pickup() method in Character class if it is declared in the gold class
        public Gold(int x, int y) : base(x, y)
        {
            goldAmount = random.Next(1,6);


        }

        public override string ToString()
        {
            return goldAmount.ToString();
        }
    }
}
