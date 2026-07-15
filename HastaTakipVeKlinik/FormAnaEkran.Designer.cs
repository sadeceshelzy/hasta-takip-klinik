using System.Windows.Forms;

namespace HastaTakipVeKlinik
{
    partial class FormAnaEkran
    {
        private System.ComponentModel.IContainer components = null;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem klinikToolStripMenuItem;
        private ToolStripMenuItem doktorToolStripMenuItem;
        private ToolStripMenuItem hastaToolStripMenuItem;
        private ToolStripMenuItem randevuToolStripMenuItem;
        private ToolStripMenuItem tedaviToolStripMenuItem;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.klinikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doktorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hastaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.randevuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tedaviToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.klinikToolStripMenuItem,
            this.doktorToolStripMenuItem,
            this.hastaToolStripMenuItem,
            this.randevuToolStripMenuItem,
            this.tedaviToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // klinikToolStripMenuItem
            // 
            this.klinikToolStripMenuItem.Name = "klinikToolStripMenuItem";
            this.klinikToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.klinikToolStripMenuItem.Text = "Klinik";
            this.klinikToolStripMenuItem.Click += new System.EventHandler(this.klinikToolStripMenuItem_Click);
            // 
            // doktorToolStripMenuItem
            // 
            this.doktorToolStripMenuItem.Name = "doktorToolStripMenuItem";
            this.doktorToolStripMenuItem.Size = new System.Drawing.Size(66, 24);
            this.doktorToolStripMenuItem.Text = "Doktor";
            this.doktorToolStripMenuItem.Click += new System.EventHandler(this.doktorToolStripMenuItem_Click);
            // 
            // hastaToolStripMenuItem
            // 
            this.hastaToolStripMenuItem.Name = "hastaToolStripMenuItem";
            this.hastaToolStripMenuItem.Size = new System.Drawing.Size(56, 24);
            this.hastaToolStripMenuItem.Text = "Hasta";
            this.hastaToolStripMenuItem.Click += new System.EventHandler(this.hastaToolStripMenuItem_Click);
            // 
            // randevuToolStripMenuItem
            // 
            this.randevuToolStripMenuItem.Name = "randevuToolStripMenuItem";
            this.randevuToolStripMenuItem.Size = new System.Drawing.Size(79, 24);
            this.randevuToolStripMenuItem.Text = "Randevu";
            this.randevuToolStripMenuItem.Click += new System.EventHandler(this.randevuToolStripMenuItem_Click);
            // 
            // tedaviToolStripMenuItem
            // 
            this.tedaviToolStripMenuItem.Name = "tedaviToolStripMenuItem";
            this.tedaviToolStripMenuItem.Size = new System.Drawing.Size(63, 24);
            this.tedaviToolStripMenuItem.Text = "Tedavi";
            this.tedaviToolStripMenuItem.Click += new System.EventHandler(this.tedaviToolStripMenuItem_Click);
            // 
            // FormAnaEkran
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;  // Çoklu form içinde form açma
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormAnaEkran";
            this.Text = "Hasta Takip ve Klinik Yönetimi";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
