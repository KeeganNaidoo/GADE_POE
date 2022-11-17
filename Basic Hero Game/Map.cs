using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Basic_Hero_Game
{
    public class Map
    {
        private Enemy[] enemies;
        public Enemy[] Enemies
        {
            get { return enemies; }
            set { enemies = value; }
        }
        private Hero hero;
        public Hero Hero
        {
            get { return hero; }
            set { hero = value; }
        }

        private Gold gold;
        public Gold Gold
        {
            get { return gold; }
            set { gold = value; }
        }

        private Item[] items;
        public Item[] Items  //Q3.1 - create item array to store items from map
        {
            get { return items; }
            set { items = value; }
        }

        public Mage Mage { get; private set; }

        private int TotalGoldDrops;
        public int goldAmount;
        private Random random = new Random();
        public int mapHeight; // Y
        public int mapWidth; // X
        public int TotalEnemyAmount { get; set; }
        private int enemyCount; // For keeping track of the enemy number for the enemies array

        public static Tile[,] TileMap { get; set; }
        public Map(int minWidth, int maxWidth, int minHeight, int maxHeight, int enemyAmount)
        {
            mapWidth = random.Next(minWidth, maxWidth + 1);
            mapHeight = random.Next(minHeight, maxHeight + 1);
            TileMap = new Tile[mapHeight, mapWidth];

            TotalEnemyAmount = enemyAmount;
            Enemies = new Enemy[TotalEnemyAmount];

            // Create border and empty spaces
            for (int row = 0; row < TileMap.GetLength(0); row++) // Iterate through 2D array
            {
                for (int column = 0; column < TileMap.GetLength(1); column++)
                {
                    if (row == 0 || row == mapHeight - 1) // Set Bottom and Top edges to Obstacles
                    {
                        TileMap[row, column] = new Obstacle(column, row);
                    }
                    else if (column == 0 || column == mapWidth - 1) // Set Left and Right edges to Obstacles
                    {
                        TileMap[row, column] = new Obstacle(column, row);
                    }
                    else // Set anything else to empty spaces
                    {
                        TileMap[row, column] = new EmptyTile(column, row);
                    }
                }
            }

            for (enemyCount = 0; enemyCount < TotalEnemyAmount; enemyCount++) // Spawn all enemies
            {
                Create(Tile.TileType.SwampCreature);

                Create(Tile.TileType.Mage);
            }

            Create(Tile.TileType.Hero); // spawn hero

            UpdateVision();
        }

        public Map(int width, int height) // For loading from save file
        {
            mapWidth = width;
            mapHeight = height;
            TileMap = new Tile[mapHeight, mapWidth];

            // Create border and empty spaces
            for (int row = 0; row < TileMap.GetLength(0); row++) // Iterate through 2D array
            {
                for (int column = 0; column < TileMap.GetLength(1); column++)
                {
                    if (row == 0 || row == mapHeight - 1) // Set Bottom and Top edges to Obstacles
                    {
                        TileMap[row, column] = new Obstacle(column, row);
                    }
                    else if (column == 0 || column == mapWidth - 1) // Set Left and Right edges to Obstacles
                    {
                        TileMap[row, column] = new Obstacle(column, row);
                    }
                    else // Set anything else to empty spaces
                    {
                        TileMap[row, column] = new EmptyTile(column, row);
                    }
                }
            }
        }

        public Tile Create(Tile.TileType type)
        {
            int xPos;
            int yPos;

            do
            {
                xPos = random.Next(1, mapWidth - 1);
                yPos = random.Next(1, mapHeight - 1);
            }
            while (TileMap[yPos, xPos].Type != Tile.TileType.EmptyTile); // Don't spawn on a space that is not empty
            if (type == Tile.TileType.SwampCreature) // spawn swamp creature
            {
                Enemies[enemyCount] = new SwampCreature(xPos, yPos, enemyCount);
                TileMap[yPos, xPos] = Enemies[enemyCount];
            }
            else if (type == Tile.TileType.Mage) // spawn mage
            {
                Mage = new Mage(xPos, yPos, enemyCount);
                TileMap[yPos, xPos] = Mage;
            }
            else if (type == Tile.TileType.Hero) // spawn hero
            {
                Hero = new Hero(xPos, yPos, 15);
                TileMap[yPos, xPos] = Hero;
            }
            else if (type == Tile.TileType.Gold) // spawn gold
            {
                Gold = new Gold(xPos, yPos);
                TileMap[yPos, xPos] = Gold;

            }
            return TileMap[yPos, xPos];
        }

        public void UpdateVision()
        {
            Hero.CharactersVision[0] = TileMap[Hero.Y, Hero.X]; // No Move
            Hero.CharactersVision[1] = TileMap[Hero.Y - 1, Hero.X]; // Up
            Hero.CharactersVision[2] = TileMap[Hero.Y + 1, Hero.X]; // Down
            Hero.CharactersVision[3] = TileMap[Hero.Y, Hero.X - 1]; // Left
            Hero.CharactersVision[4] = TileMap[Hero.Y, Hero.X + 1]; // Right

            for (int i = 0; i < TotalEnemyAmount; i++)
            {
                Enemies[i].CharactersVision[1] = TileMap[Enemies[i].Y - 1, Enemies[i].X];
                Enemies[i].CharactersVision[2] = TileMap[Enemies[i].Y + 1, Enemies[i].X];
                Enemies[i].CharactersVision[3] = TileMap[Enemies[i].Y, Enemies[i].X - 1];
                Enemies[i].CharactersVision[4] = TileMap[Enemies[i].Y, Enemies[i].X + 1];
            }
        }

        public override string ToString() //To display the map
        {
            string mapString = "";
            for (int row = 0; row < TileMap.GetLength(0); row++)
            {
                for (int column = 0; column < TileMap.GetLength(1); column++)
                {
                    mapString += (char)TileMap[row, column].Type;
                }
                mapString += "\n";
            }
            return mapString;
        }

        public void GetItemAtPosition(int x, int y) //this method searches the Items array for an item that exists
        {
            return;
        }

    }


}
