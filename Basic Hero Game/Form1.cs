using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Basic_Hero_Game
{
    public partial class Form1 : Form
    {
        private GameEngine gameEngine;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gameEngine = new GameEngine();
            lblAttackCheck.Text = "";
            UpdateScreen();
        }

        private void lblMap_Click(object sender, EventArgs e)
        {
            //not needed as it is a label
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            gameEngine.MovePlayer(Character.Movement.Up);
            EnemiesTurn();
            UpdateScreen();
            lblAttackCheck.Text = "";
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            gameEngine.MovePlayer(Character.Movement.Down);
            EnemiesTurn();
            UpdateScreen();
            lblAttackCheck.Text = "";
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            gameEngine.MovePlayer(Character.Movement.Left);
            EnemiesTurn();
            UpdateScreen();
            lblAttackCheck.Text = "";
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            gameEngine.MovePlayer(Character.Movement.Right);
            EnemiesTurn();
            UpdateScreen();
            lblAttackCheck.Text = "";
        }
        private void EnemiesTurn()
        {
            gameEngine.MoveEnemies();
            gameEngine.AttackPlayer();
        }
        private void UpdateScreen()
        {
            lblMap.Text = gameEngine.Map.ToString();
            lblPlayerStats.Text = gameEngine.Map.Hero.ToString();

            // Update Enemy listbox
            lbEnemyList.Items.Clear(); // Clear the list so that no copies get displayed every time UpdateScreen is called
            for (int enemy = 0; enemy < gameEngine.Map.TotalEnemyAmount; enemy++)
            {
                lbEnemyList.Items.Add(gameEngine.Map.Enemies[enemy].ToString());
            }
        }

        private void btnNoMove_Click(object sender, EventArgs e)
        {
            gameEngine.MovePlayer(Character.Movement.NoMovement);
            EnemiesTurn();
            UpdateScreen();
            lblAttackCheck.Text = "";
        }

        private void btnAttack_Click(object sender, EventArgs e)
        {
            Enemy enemy;

            try // Check if an enemy is selected
            {
                enemy = gameEngine.Map.Enemies[lbEnemyList.SelectedIndex];
            }
            catch
            {
                lblAttackCheck.Text = "Select an enemy from the list";
                return;
            }

            // Check if enemy is in range
            if (gameEngine.Map.Hero.CheckRange(enemy))
            {
                gameEngine.Map.Hero.Attack(enemy);
                gameEngine.CheckForDead(enemy);
                lblAttackCheck.Text = "Attack success";
                UpdateScreen();
            }
            else if (!gameEngine.Map.Hero.CheckRange(enemy))
            {
                lblAttackCheck.Text = "Enemy out of range";
            }
            else
            {
                lblAttackCheck.Text = "Wrong enemy";
            }
        }

        private void lblAttackCheck_Click(object sender, EventArgs e)
        {

        }

       private void button1_Click(object sender, EventArgs e)
        {
            gameEngine.Save();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                gameEngine.Load();
                UpdateScreen();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Save file does not exist");
            }
        }
    }
}
