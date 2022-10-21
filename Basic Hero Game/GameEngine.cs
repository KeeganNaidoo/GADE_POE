using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Hero_Game
{
    public class GameEngine
    {



        public void MovePlayer(Character.Movement direction)
        {
            
        }

        public override string ToString()
        {
            mapString += (char)TileMap[row, column].Type;
        }
    }
}
