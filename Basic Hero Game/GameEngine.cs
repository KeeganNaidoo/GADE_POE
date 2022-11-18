using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace Basic_Hero_Game
{
    public class GameEngine
    {
        Shop myShop = new Shop();

        private Map map;
        public Map Map
        {
            get { return map; }
            set { map = value; }
        }
        public GameEngine()
        {
            Map = new Map(10, 15, 6, 12, 4, 3);
        }

        public void MovePlayer(Character.Movement direction) 
        {
            // The previous space get replaced by empty tile
            //Map.TileMap[Map.Hero.Y, Map.Hero.X] = new EmptyTile(Map.Hero.X, Map.Hero.Y);

            //Map.Hero.Move(Map.Hero.ReturnMove(direction));

            //Map.TileMap[Map.Hero.Y, Map.Hero.X] = Map.Hero; // The new space changes to Hero after their coordinates gets changed

            //Map.UpdateVision();

            Map.Hero.Move(Map.Hero.ReturnMove(direction), Map.Hero);
            if (Map.Hero.HeroOnGold)
            {
                Map.Hero.PickUp(Map.GetItemAtPosition(Map.Hero.X, Map.Hero.Y));
                map.Hero.HeroOnGold = false;
            }
            Map.UpdateVision();
        }

        public void CheckForDead(Enemy enemy)
        {
            if (enemy.IsDead())
            {
                // remove target array element
                for (int i = enemy.EnemyArrayNum; i < Map.TotalEnemyAmount - 1; i++)
                {
                    Map.Enemies[i] = Map.Enemies[i + 1];
                    Map.Enemies[i].EnemyArrayNum--;
                }
                Map.TotalEnemyAmount--;

                // Replace the enemy with an EmptyTile
                Map.TileMap[enemy.Y, enemy.X] = new EmptyTile(enemy.X, enemy.Y);
            }
        }

        public void CheckForDead(Hero hero)
        {
            if (hero.IsDead())
            {
                // Replace the hero with an EmptyTile
                Map.TileMap[hero.Y, hero.X] = new EmptyTile(hero.X, hero.Y);
            }
        }

        public void MoveEnemies()
        {
            for (int enemyCount = 0; enemyCount < Map.TotalEnemyAmount; enemyCount++)
            {
                Map.Enemies[enemyCount].Move(Map.Enemies[enemyCount].ReturnMove(), Map.Enemies[enemyCount]);
                Map.UpdateVision();
            }
        }

        public void AttackPlayer()
        {
            for (int enemyCount = 0; enemyCount < Map.TotalEnemyAmount; enemyCount++)
            {
                if (Map.Enemies[enemyCount].CheckRange(Map.Hero))
                {
                    Map.Enemies[enemyCount].Attack(Map.Hero);
                }
            }
            CheckForDead(Map.Hero);
        }

        public void EnemiesAttack()
        {
            for (int enemyCount = 0; enemyCount < Map.TotalEnemyAmount; enemyCount++)
            {
                if (Map.Enemies[enemyCount].CheckRange(Map.Hero))
                {
                    Map.Enemies[enemyCount].Attack(Map.Hero);
                }
                if (Map.Enemies[enemyCount].Type == Tile.TileType.Mage) // Mage attack on other enemies
                {
                    for (int targetEnemy = 0; targetEnemy < Map.TotalEnemyAmount; targetEnemy++)
                    {
                        if (Map.Enemies[enemyCount].CheckRange(Map.Enemies[targetEnemy])) // Check if all other enemies are in range of the current enemy which is a Mage
                        {
                            Map.Enemies[enemyCount].Attack(Map.Enemies[targetEnemy]);
                            CheckForDead(Map.Enemies[targetEnemy]);
                        }
                    }
                }
            }
            CheckForDead(Map.Hero);
        }


        public void Save() //method to save map class
        {
            FileStream fs = new FileStream("SaveFile.bin", FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);

            bw.Write(Map.TileMap.GetLength(1)); // Map width
            bw.Write(Map.TileMap.GetLength(0)); // Map height

            // Write Hero
            bw.Write(Map.Hero.X);
            bw.Write(Map.Hero.Y);
            bw.Write(Map.Hero.PublicHP);      // HP needs to be public
            bw.Write(Map.Hero.PublicMaxHP);   // MaxHp needs to be public
            bw.Write(Map.Hero.GoldPurse);

            // Write Enemies
            bw.Write(Map.TotalEnemyAmount);
            for (int i = 0; i < Map.TotalEnemyAmount; i++)
            {
                bw.Write(Map.Enemies[i].X);
                bw.Write(Map.Enemies[i].Y);
                bw.Write((char)Map.Enemies[i].Type); // To determine what type of enemy to spawn
                bw.Write(Map.Enemies[i].PublicHP);
            }

            // Write Items
            bw.Write(Map.Items.Length);
            for (int i = 0; i < Map.Items.Length; i++)
            {
                if (Map.Items[i] == null)
                {
                    bw.Write(true); // IsNull 
                    // You must have some way of indicating to the load method that some items could be null.
                    // This is so that you don't end up reading null properties and creating gold objects with null properties.
                }
                else
                {
                    bw.Write(false); // !IsNull
                    bw.Write(Map.Items[i].X);
                    bw.Write(Map.Items[i].Y);
                    bw.Write((Map.Items[i] as Gold).GoldAmount);
                }
            }

            bw.Close();
            fs.Close();
        }

        internal void Load()
        {
            FileStream fs = new FileStream("SaveFile.bin", FileMode.Open);
            BinaryReader br = new BinaryReader(fs);

            // Read data in same order that they were written

            // Read Map
            int mapWidth = br.ReadInt32();
            int mapHeight = br.ReadInt32();

            Map = new Map(mapWidth, mapHeight); // Create plain map


            // Read Hero
            int heroX = br.ReadInt32();
            int heroY = br.ReadInt32();
            int heroHP = br.ReadInt32();
            int heroMaxHP = br.ReadInt32();
            int goldPurse = br.ReadInt32();
            // Create New Hero
            Map.Hero = new Hero(heroX, heroY, heroHP, heroMaxHP, goldPurse);
            Map.TileMap[heroY, heroX] = Map.Hero; // Place Hero on map


            // Read Enemies
            int enemyX, enemyY, enemyHP;
            char enemySymbol;

            Map.TotalEnemyAmount = br.ReadInt32(); // Read the amount of enemies there are

            Map.Enemies = new Enemy[Map.TotalEnemyAmount];

            for (int i = 0; i < Map.TotalEnemyAmount; i++)
            {
                enemyX = br.ReadInt32();
                enemyY = br.ReadInt32();
                enemySymbol = br.ReadChar();
                enemyHP = br.ReadInt32();

                if (enemySymbol == (char)Tile.TileType.SwampCreature) // Create SwampCreature
                {
                    Map.Enemies[i] = new SwampCreature(enemyX, enemyY, i, enemyHP);
                    Map.TileMap[enemyY, enemyX] = Map.Enemies[i];
                }
                else // Create Mage
                {
                    Map.Enemies[i] = new Mage(enemyX, enemyY, i, enemyHP);
                    Map.TileMap[enemyY, enemyX] = Map.Enemies[i];
                }
            }

            // Read Items
            int itemsLength = br.ReadInt32();
            Map.Items = new Item[itemsLength];

            bool isNull;
            int itemX;
            int itemY;
            int goldAmount;

            for (int i = 0; i < itemsLength; i++)
            {
                isNull = br.ReadBoolean();  // Check if each item is null or not null
                if (!isNull)
                {                           // Assign values to non-null objects
                    itemX = br.ReadInt32();
                    itemY = br.ReadInt32();
                    goldAmount = br.ReadInt32();
                    Map.Items[i] = new Gold(itemX, itemY, goldAmount);
                    Map.TileMap[itemY, itemX] = Map.Items[i];
                }
            }

            br.Close();
            fs.Close();

            Map.UpdateVision();
        }
    }
    }

        
      

      
        
    

