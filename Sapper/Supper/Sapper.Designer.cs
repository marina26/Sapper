namespace Supper
{
    partial class Sapper
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sapper));
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.beginnerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.amateurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.professionalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crazyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.soundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GameField = new System.Windows.Forms.Panel();
            this.MinetextBox = new System.Windows.Forms.TextBox();
            this.TimetextBox = new System.Windows.Forms.TextBox();
            this.SmileBox = new System.Windows.Forms.PictureBox();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.MenuStrip.SuspendLayout();
            this.GameField.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SmileBox)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.MenuStrip.Size = new System.Drawing.Size(292, 24);
            this.MenuStrip.TabIndex = 0;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.toolStripSeparator1,
            this.beginnerToolStripMenuItem,
            this.amateurToolStripMenuItem,
            this.professionalToolStripMenuItem,
            this.crazyToolStripMenuItem,
            this.soundToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.newGameToolStripMenuItem.Text = "New Game";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(140, 6);
            // 
            // beginnerToolStripMenuItem
            // 
            this.beginnerToolStripMenuItem.Checked = true;
            this.beginnerToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.beginnerToolStripMenuItem.Name = "beginnerToolStripMenuItem";
            this.beginnerToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.beginnerToolStripMenuItem.Text = "Beginner";
            this.beginnerToolStripMenuItem.Click += new System.EventHandler(this.beginnerToolStripMenuItem_Click);
            // 
            // amateurToolStripMenuItem
            // 
            this.amateurToolStripMenuItem.Name = "amateurToolStripMenuItem";
            this.amateurToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.amateurToolStripMenuItem.Text = "Amateur";
            this.amateurToolStripMenuItem.Click += new System.EventHandler(this.amateurToolStripMenuItem_Click);
            // 
            // professionalToolStripMenuItem
            // 
            this.professionalToolStripMenuItem.Name = "professionalToolStripMenuItem";
            this.professionalToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.professionalToolStripMenuItem.Text = "Professional";
            this.professionalToolStripMenuItem.Click += new System.EventHandler(this.professionalToolStripMenuItem_Click);
            // 
            // crazyToolStripMenuItem
            // 
            this.crazyToolStripMenuItem.Name = "crazyToolStripMenuItem";
            this.crazyToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.crazyToolStripMenuItem.Text = "Crazy";
            this.crazyToolStripMenuItem.Click += new System.EventHandler(this.crezyToolStripMenuItem_Click);
            // 
            // soundToolStripMenuItem
            // 
            this.soundToolStripMenuItem.CheckOnClick = true;
            this.soundToolStripMenuItem.Name = "soundToolStripMenuItem";
            this.soundToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.soundToolStripMenuItem.Text = "Sound";
            this.soundToolStripMenuItem.Click += new System.EventHandler(this.soundToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // GameField
            // 
            this.GameField.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.GameField.Controls.Add(this.MinetextBox);
            this.GameField.Controls.Add(this.TimetextBox);
            this.GameField.Controls.Add(this.SmileBox);
            this.GameField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GameField.Location = new System.Drawing.Point(0, 24);
            this.GameField.Name = "GameField";
            this.GameField.Size = new System.Drawing.Size(292, 242);
            this.GameField.TabIndex = 1;
            this.GameField.Paint += new System.Windows.Forms.PaintEventHandler(this.GameField_Paint_1);
            this.GameField.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GameField_MouseClick_1);
            this.GameField.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameField_MouseDown);
            this.GameField.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GameField_MouseUp);
            // 
            // MinetextBox
            // 
            this.MinetextBox.BackColor = System.Drawing.SystemColors.InfoText;
            this.MinetextBox.Enabled = false;
            this.MinetextBox.ForeColor = System.Drawing.SystemColors.Menu;
            this.MinetextBox.Location = new System.Drawing.Point(12, 210);
            this.MinetextBox.Name = "MinetextBox";
            this.MinetextBox.Size = new System.Drawing.Size(87, 20);
            this.MinetextBox.TabIndex = 2;
            this.MinetextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TimetextBox
            // 
            this.TimetextBox.BackColor = System.Drawing.SystemColors.InfoText;
            this.TimetextBox.Enabled = false;
            this.TimetextBox.ForeColor = System.Drawing.SystemColors.Menu;
            this.TimetextBox.Location = new System.Drawing.Point(185, 210);
            this.TimetextBox.Name = "TimetextBox";
            this.TimetextBox.Size = new System.Drawing.Size(85, 20);
            this.TimetextBox.TabIndex = 3;
            // 
            // SmileBox
            // 
            this.SmileBox.Location = new System.Drawing.Point(115, 175);
            this.SmileBox.Name = "SmileBox";
            this.SmileBox.Size = new System.Drawing.Size(50, 38);
            this.SmileBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SmileBox.TabIndex = 0;
            this.SmileBox.TabStop = false;
            this.SmileBox.Click += new System.EventHandler(this.SmileBox_Click);
            // 
            // Timer
            // 
            this.Timer.Interval = 1000;
            this.Timer.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // Sapper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.GameField);
            this.Controls.Add(this.MenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuStrip;
            this.MaximizeBox = false;
            this.Name = "Sapper";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sapper";
            this.Resize += new System.EventHandler(this.Supper_Resize);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.GameField.ResumeLayout(false);
            this.GameField.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SmileBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.Panel GameField;
        private System.Windows.Forms.PictureBox SmileBox;
        private System.Windows.Forms.TextBox MinetextBox;
        private System.Windows.Forms.TextBox TimetextBox;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        public System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem beginnerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem amateurToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem professionalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crazyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem soundToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

