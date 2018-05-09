namespace Buscaminas
{
    partial class PantallaBuscaminas
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PantallaBuscaminas));
            this.tmrTiempo = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.nivelFácilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.intermedioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expertoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personalizadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblBombs = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmrTiempo
            // 
            this.tmrTiempo.Interval = 1000;
            this.tmrTiempo.Tick += new System.EventHandler(this.tmrTiempo_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(308, 24);
            this.menuStrip1.TabIndex = 44;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nivelFácilToolStripMenuItem,
            this.intermedioToolStripMenuItem,
            this.expertoToolStripMenuItem,
            this.personalizadoToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(50, 20);
            this.toolStripMenuItem1.Text = "Juego";
            // 
            // nivelFácilToolStripMenuItem
            // 
            this.nivelFácilToolStripMenuItem.Name = "nivelFácilToolStripMenuItem";
            this.nivelFácilToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.nivelFácilToolStripMenuItem.Text = "Principiante";
            this.nivelFácilToolStripMenuItem.Click += new System.EventHandler(this.nivelFácilToolStripMenuItem_Click);
            // 
            // intermedioToolStripMenuItem
            // 
            this.intermedioToolStripMenuItem.Name = "intermedioToolStripMenuItem";
            this.intermedioToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.intermedioToolStripMenuItem.Text = "Intermedio";
            this.intermedioToolStripMenuItem.Click += new System.EventHandler(this.intermedioToolStripMenuItem_Click);
            // 
            // expertoToolStripMenuItem
            // 
            this.expertoToolStripMenuItem.Name = "expertoToolStripMenuItem";
            this.expertoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.expertoToolStripMenuItem.Text = "Experto";
            this.expertoToolStripMenuItem.Click += new System.EventHandler(this.expertoToolStripMenuItem_Click);
            // 
            // personalizadoToolStripMenuItem
            // 
            this.personalizadoToolStripMenuItem.Name = "personalizadoToolStripMenuItem";
            this.personalizadoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.personalizadoToolStripMenuItem.Text = "Personalizado";
            this.personalizadoToolStripMenuItem.Click += new System.EventHandler(this.personalizadoToolStripMenuItem_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.White;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Location = new System.Drawing.Point(192, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(24, 24);
            this.btnExit.TabIndex = 45;
            this.btnExit.Text = "X";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblBombs
            // 
            this.lblBombs.AutoSize = true;
            this.lblBombs.BackColor = System.Drawing.Color.Gray;
            this.lblBombs.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBombs.Location = new System.Drawing.Point(12, 42);
            this.lblBombs.Name = "lblBombs";
            this.lblBombs.Size = new System.Drawing.Size(71, 37);
            this.lblBombs.TabIndex = 46;
            this.lblBombs.Text = "000";
            this.lblBombs.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblBombs_MouseDown);
            this.lblBombs.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblBombs_MouseUp);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.BackColor = System.Drawing.Color.Gray;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(153, 47);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(71, 37);
            this.lblTime.TabIndex = 47;
            this.lblTime.Text = "000";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnReset
            // 
            this.btnReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnReset.Image = ((System.Drawing.Image)(resources.GetObject("btnReset.Image")));
            this.btnReset.Location = new System.Drawing.Point(97, 40);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(40, 40);
            this.btnReset.TabIndex = 1;
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // PantallaBuscaminas
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(308, 348);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblBombs);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PantallaBuscaminas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sexminas";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Timer tmrTiempo;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem nivelFácilToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem intermedioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expertoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem personalizadoToolStripMenuItem;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblBombs;
        private System.Windows.Forms.Label lblTime;
    }
}

