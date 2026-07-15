namespace HastaTakipVeKlinik
{
    partial class FormDoktor
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblAd;
        private System.Windows.Forms.Label lblSoyad;
        private System.Windows.Forms.Label lblKlinik;
        private System.Windows.Forms.TextBox txtAd;
        private System.Windows.Forms.TextBox txtSoyad;
        private System.Windows.Forms.ComboBox cmbKlinik;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnTemizle;
        private System.Windows.Forms.DataGridView dgvDoktorlar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblAd = new System.Windows.Forms.Label();
            this.lblSoyad = new System.Windows.Forms.Label();
            this.lblKlinik = new System.Windows.Forms.Label();
            this.txtAd = new System.Windows.Forms.TextBox();
            this.txtSoyad = new System.Windows.Forms.TextBox();
            this.cmbKlinik = new System.Windows.Forms.ComboBox();
            this.btnEkle = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnTemizle = new System.Windows.Forms.Button();
            this.dgvDoktorlar = new System.Windows.Forms.DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.dgvDoktorlar)).BeginInit();
            this.SuspendLayout();

            // lblAd
            this.lblAd.AutoSize = true;
            this.lblAd.Location = new System.Drawing.Point(30, 30);
            this.lblAd.Name = "lblAd";
            this.lblAd.Size = new System.Drawing.Size(24, 17);
            this.lblAd.Text = "Ad";

            // txtAd
            this.txtAd.Location = new System.Drawing.Point(100, 27);
            this.txtAd.Name = "txtAd";
            this.txtAd.Size = new System.Drawing.Size(200, 22);

            // lblSoyad
            this.lblSoyad.AutoSize = true;
            this.lblSoyad.Location = new System.Drawing.Point(30, 70);
            this.lblSoyad.Name = "lblSoyad";
            this.lblSoyad.Size = new System.Drawing.Size(46, 17);
            this.lblSoyad.Text = "Soyad";

            // txtSoyad
            this.txtSoyad.Location = new System.Drawing.Point(100, 67);
            this.txtSoyad.Name = "txtSoyad";
            this.txtSoyad.Size = new System.Drawing.Size(200, 22);

            // lblKlinik
            this.lblKlinik.AutoSize = true;
            this.lblKlinik.Location = new System.Drawing.Point(30, 110);
            this.lblKlinik.Name = "lblKlinik";
            this.lblKlinik.Size = new System.Drawing.Size(41, 17);
            this.lblKlinik.Text = "Klinik";

            // cmbKlinik
            this.cmbKlinik.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKlinik.Location = new System.Drawing.Point(100, 107);
            this.cmbKlinik.Name = "cmbKlinik";
            this.cmbKlinik.Size = new System.Drawing.Size(200, 24);

            // btnEkle
            this.btnEkle.Location = new System.Drawing.Point(350, 27);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(100, 30);
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);

            // btnGuncelle
            this.btnGuncelle.Location = new System.Drawing.Point(350, 67);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(100, 30);
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);

            // btnSil
            this.btnSil.Location = new System.Drawing.Point(350, 107);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(100, 30);
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);

            // btnTemizle
            this.btnTemizle.Location = new System.Drawing.Point(350, 147);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(100, 30);
            this.btnTemizle.Text = "Temizle";
            this.btnTemizle.UseVisualStyleBackColor = true;
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);

            // dgvDoktorlar
            this.dgvDoktorlar.AllowUserToAddRows = false;
            this.dgvDoktorlar.AllowUserToDeleteRows = false;
            this.dgvDoktorlar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDoktorlar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDoktorlar.Location = new System.Drawing.Point(30, 200);
            this.dgvDoktorlar.MultiSelect = false;
            this.dgvDoktorlar.Name = "dgvDoktorlar";
            this.dgvDoktorlar.ReadOnly = true;
            this.dgvDoktorlar.RowTemplate.Height = 24;
            this.dgvDoktorlar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDoktorlar.Size = new System.Drawing.Size(600, 250);
            this.dgvDoktorlar.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDoktorlar_CellClick);

            // FormDoktor
            this.ClientSize = new System.Drawing.Size(680, 480);
            this.Controls.Add(this.lblAd);
            this.Controls.Add(this.txtAd);
            this.Controls.Add(this.lblSoyad);
            this.Controls.Add(this.txtSoyad);
            this.Controls.Add(this.lblKlinik);
            this.Controls.Add(this.cmbKlinik);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnTemizle);
            this.Controls.Add(this.dgvDoktorlar);
            this.Name = "FormDoktor";
            this.Text = "Doktor Yönetimi";
            this.Load += new System.EventHandler(this.FormDoktor_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvDoktorlar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
