using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Hero_Game
{
    public class Map
    {
        public Tile[] TileArray;

        public Hero Hero { get; set; }

        //enemy array
        public Enemy Enemies { get; set; }

        public int mapWidth;
        public int mapHeight;

        Random random = new Random();

        public Map(int minWidth, int maxWidth, int minHeight, int maxHeight, int enemyCount) 
        {
            mapWidth = random.Next(minWidth, maxWidth+1);
            mapHeight = random.Next(maxHeight, maxHeight+1);

        }

        Public void UpdateVision()
        {

        }

        Private Tile Create(TileEnum type)
        {

        }


    }

    
}
