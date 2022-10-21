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
        private Map map;
        public Map Map
        {
            get { return map; }
            set { map = value; }
        }
        public GameEngine()
        {
            Map = new Map(10, 15, 6, 12, 4);
        }

        public void MovePlayer(Character.Movement direction) 
        {
            // The previous space get replaced by empty tile
            Map.TileMap[Map.Hero.Y, Map.Hero.X] = new EmptyTile(Map.Hero.X, Map.Hero.Y);

            Map.Hero.Move(Map.Hero.ReturnMove(direction));

            Map.TileMap[Map.Hero.Y, Map.Hero.X] = Map.Hero; // The new space changes to Hero after their coordinates gets changed

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
                // The previous space get replaced by an empty tile
                Map.TileMap[Map.Enemies[enemyCount].Y, Map.Enemies[enemyCount].X] = new EmptyTile(Map.Enemies[enemyCount].X, Map.Enemies[enemyCount].Y);

                Map.Enemies[enemyCount].Move(Map.Enemies[enemyCount].ReturnMove());

                Map.TileMap[Map.Enemies[enemyCount].Y, Map.Enemies[enemyCount].X] = Map.Enemies[enemyCount]; // The new space changes to Enemy after their coordinates gets changed

                Map.UpdateVision(); // Vision updates every time something on the map moves
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

        public void Save() //method to save map class
        {
            FileStream fs = new FileStream("Save.Map", FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);

           //bw.Write();
         


            bw.Close();
            fs.Close();

        }

        static void Load() //method to load map class
        {
            FileStream fs = new FileStream("Load.Map", FileMode.Open);
            BinaryReader br = new BinaryReader(fs);

        }

        public void EnemyAttacks() //method thats allows enemies to attack
        {

        }

        
    }
}
