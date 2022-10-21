namespace Basic_Hero_Game
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblAttackCheck = new System.Windows.Forms.Label();
            this.btnAttack = new System.Windows.Forms.Button();
            this.lbEnemyList = new System.Windows.Forms.ListBox();
            this.btnNoMove = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.lblPlayerStats = new System.Windows.Forms.Label();
            this.lblMap = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblAttackCheck
            // 
            this.lblAttackCheck.AutoSize = true;
            this.lblAttackCheck.Font = new System.Drawing.Font("Segoe UI", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblAttackCheck.Location = new System.Drawing.Point(436, 570);
            this.lblAttackCheck.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAttackCheck.Name = "lblAttackCheck";
            this.lblAttackCheck.Size = new System.Drawing.Size(115, 25);
            this.lblAttackCheck.TabIndex = 24;
            this.lblAttackCheck.Text = "AttackCheck";
            this.lblAttackCheck.Click += new System.EventHandler(this.lblAttackCheck_Click);
            // 
            // btnAttack
            // 
            this.btnAttack.Location = new System.Drawing.Point(436, 526);
            this.btnAttack.Margin = new System.Windows.Forms.Padding(2);
            this.btnAttack.Name = "btnAttack";
            this.btnAttack.Size = new System.Drawing.Size(92, 29);
            this.btnAttack.TabIndex = 23;
            this.btnAttack.Text = "Attack";
            this.btnAttack.UseVisualStyleBackColor = true;
            this.btnAttack.Click += new System.EventHandler(this.btnAttack_Click);
            // 
            // lbEnemyList
            // 
            this.lbEnemyList.FormattingEnabled = true;
            this.lbEnemyList.ItemHeight = 20;
            this.lbEnemyList.Location = new System.Drawing.Point(436, 410);
            this.lbEnemyList.Margin = new System.Windows.Forms.Padding(2);
            this.lbEnemyList.Name = "lbEnemyList";
            this.lbEnemyList.Size = new System.Drawing.Size(301, 104);
            this.lbEnemyList.TabIndex = 22;
            // 
            // btnNoMove
            // 
            this.btnNoMove.Location = new System.Drawing.Point(211, 482);
            this.btnNoMove.Margin = new System.Windows.Forms.Padding(2);
            this.btnNoMove.Name = "btnNoMove";
            this.btnNoMove.Size = new System.Drawing.Size(78, 55);
            this.btnNoMove.TabIndex = 21;
            this.btnNoMove.Text = "No Move";
            this.btnNoMove.UseVisualStyleBackColor = true;
            this.btnNoMove.Click += new System.EventHandler(this.btnNoMove_Click);
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(301, 476);
            this.btnRight.Margin = new System.Windows.Forms.Padding(2);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(92, 70);
            this.btnRight.TabIndex = 20;
            this.btnRight.Text = "Right";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(204, 548);
            this.btnDown.Margin = new System.Windows.Forms.Padding(2);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(92, 66);
            this.btnDown.TabIndex = 19;
            this.btnDown.Text = "Down";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(107, 475);
            this.btnLeft.Margin = new System.Windows.Forms.Padding(2);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(92, 70);
            this.btnLeft.TabIndex = 18;
            this.btnLeft.Text = "Left";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(204, 410);
            this.btnUp.Margin = new System.Windows.Forms.Padding(2);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(92, 62);
            this.btnUp.TabIndex = 17;
            this.btnUp.Text = "Up";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // lblPlayerStats
            // 
            this.lblPlayerStats.AutoSize = true;
            this.lblPlayerStats.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPlayerStats.Location = new System.Drawing.Point(539, 17);
            this.lblPlayerStats.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPlayerStats.Name = "lblPlayerStats";
            this.lblPlayerStats.Size = new System.Drawing.Size(112, 28);
            this.lblPlayerStats.TabIndex = 16;
            this.lblPlayerStats.Text = "Player Stats";
            // 
            // lblMap
            // 
            this.lblMap.AutoSize = true;
            this.lblMap.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMap.Location = new System.Drawing.Point(178, 87);
            this.lblMap.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMap.Name = "lblMap";
            this.lblMap.Size = new System.Drawing.Size(63, 36);
            this.lblMap.TabIndex = 15;
            this.lblMap.Text = "Map";
            this.lblMap.Click += new System.EventHandler(this.lblMap_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 633);
            this.Controls.Add(this.lblAttackCheck);
            this.Controls.Add(this.btnAttack);
            this.Controls.Add(this.lbEnemyList);
            this.Controls.Add(this.btnNoMove);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.lblPlayerStats);
            this.Controls.Add(this.lblMap);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAttackCheck;
        private System.Windows.Forms.Button btnAttack;
        private System.Windows.Forms.ListBox lbEnemyList;
        private System.Windows.Forms.Button btnNoMove;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Label lblPlayerStats;
        private System.Windows.Forms.Label lblMap;
    }
}
