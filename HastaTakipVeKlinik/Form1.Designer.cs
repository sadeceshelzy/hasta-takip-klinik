namespace HastaTakipVeKlinik
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtKullaniciAdi = new System.Windows.Forms.TextBox();
            this.txtSifre = new System.Windows.Forms.TextBox();
            this.btnGiris = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 30);
            this.label1.Text = "Kullanıcı Adı:";
            // 
            // label2
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 70);
            this.label2.Text = "Şifre:";
            // 
            // txtKullaniciAdi
            this.txtKullaniciAdi.Location = new System.Drawing.Point(120, 27);
            this.txtKullaniciAdi.Size = new System.Drawing.Size(150, 20);
            // 
            // txtSifre
            this.txtSifre.Location = new System.Drawing.Point(120, 67);
            this.txtSifre.Size = new System.Drawing.Size(150, 20);
            this.txtSifre.PasswordChar = '*';
            // 
            // btnGiris
            this.btnGiris.Location = new System.Drawing.Point(120, 110);
            this.btnGiris.Size = new System.Drawing.Size(150, 30);
            this.btnGiris.Text = "Giriş Yap";
            this.btnGiris.Click += new System.EventHandler(this.btnGiris_Click);
            // 
            // Form1
            this.AcceptButton = this.btnGiris;
            this.ClientSize = new System.Drawing.Size(320, 180);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtKullaniciAdi);
            this.Controls.Add(this.txtSifre);
            this.Controls.Add(this.btnGiris);
            this.Name = "Form1";
            this.Text = "Kullanıcı Giriş";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtKullaniciAdi;
        private System.Windows.Forms.TextBox txtSifre;
        private System.Windows.Forms.Button btnGiris;
    }
}
