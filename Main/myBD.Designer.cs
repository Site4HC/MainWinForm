namespace Biblio
{
    partial class myBD
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.таблиціБДToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.адмініструванняToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.калькуляторToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.проПрограмуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вихідToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenTableOsoba = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenTableKatalog = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenTableFormuliar = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.таблиціБДToolStripMenuItem,
            this.адмініструванняToolStripMenuItem,
            this.калькуляторToolStripMenuItem,
            this.проПрограмуToolStripMenuItem,
            this.вихідToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // таблиціБДToolStripMenuItem
            // 
            this.таблиціБДToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenTableOsoba,
            this.OpenTableKatalog,
            this.OpenTableFormuliar});
            this.таблиціБДToolStripMenuItem.Name = "таблиціБДToolStripMenuItem";
            this.таблиціБДToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.таблиціБДToolStripMenuItem.Text = "Таблиці БД";
            // 
            // адмініструванняToolStripMenuItem
            // 
            this.адмініструванняToolStripMenuItem.Name = "адмініструванняToolStripMenuItem";
            this.адмініструванняToolStripMenuItem.Size = new System.Drawing.Size(111, 20);
            this.адмініструванняToolStripMenuItem.Text = "Адміністрування";
            // 
            // калькуляторToolStripMenuItem
            // 
            this.калькуляторToolStripMenuItem.Name = "калькуляторToolStripMenuItem";
            this.калькуляторToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.калькуляторToolStripMenuItem.Text = "Калькулятор";
            this.калькуляторToolStripMenuItem.Click += new System.EventHandler(this.калькуляторToolStripMenuItem_Click);
            // 
            // проПрограмуToolStripMenuItem
            // 
            this.проПрограмуToolStripMenuItem.Name = "проПрограмуToolStripMenuItem";
            this.проПрограмуToolStripMenuItem.Size = new System.Drawing.Size(99, 20);
            this.проПрограмуToolStripMenuItem.Text = "Про програму";
            this.проПрограмуToolStripMenuItem.Click += new System.EventHandler(this.проПрограмуToolStripMenuItem_Click);
            // 
            // вихідToolStripMenuItem
            // 
            this.вихідToolStripMenuItem.Name = "вихідToolStripMenuItem";
            this.вихідToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.вихідToolStripMenuItem.Text = "Вихід";
            this.вихідToolStripMenuItem.Click += new System.EventHandler(this.вихідToolStripMenuItem_Click);
            // 
            // OpenTableOsoba
            // 
            this.OpenTableOsoba.Image = global::Main.Properties.Resources.Знімок_екрана_2025_04_02_062537;
            this.OpenTableOsoba.Name = "OpenTableOsoba";
            this.OpenTableOsoba.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1)));
            this.OpenTableOsoba.Size = new System.Drawing.Size(180, 22);
            this.OpenTableOsoba.Text = "Читачі";
            this.OpenTableOsoba.Click += new System.EventHandler(this.OpenTableOsoba_Click);
            // 
            // OpenTableKatalog
            // 
            this.OpenTableKatalog.Image = global::Main.Properties.Resources.Знімок_екрана_2025_05_18_163920;
            this.OpenTableKatalog.Name = "OpenTableKatalog";
            this.OpenTableKatalog.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D2)));
            this.OpenTableKatalog.Size = new System.Drawing.Size(180, 22);
            this.OpenTableKatalog.Text = "Каталог";
            // 
            // OpenTableFormuliar
            // 
            this.OpenTableFormuliar.Image = global::Main.Properties.Resources.Знімок_екрана_2025_04_02_062420;
            this.OpenTableFormuliar.Name = "OpenTableFormuliar";
            this.OpenTableFormuliar.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D3)));
            this.OpenTableFormuliar.Size = new System.Drawing.Size(180, 22);
            this.OpenTableFormuliar.Text = "Формуляр";
            // 
            // myBD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "myBD";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.myBD_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem таблиціБДToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem адмініструванняToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem калькуляторToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem проПрограмуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вихідToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenTableOsoba;
        private System.Windows.Forms.ToolStripMenuItem OpenTableKatalog;
        private System.Windows.Forms.ToolStripMenuItem OpenTableFormuliar;
    }
}

