namespace HastaTakipVeKlinik
{
    partial class FormTedavi
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dgvTedaviler;
        private System.Windows.Forms.ComboBox cmbHasta;
        private System.Windows.Forms.ComboBox cmbDoktor;
        private System.Windows.Forms.ComboBox cmbKlinik;
        private System.Windows.Forms.ComboBox cmbRandevu;     // Yeni eklendi
        private System.Windows.Forms.TextBox txtTedaviAdi;
        private System.Windows.Forms.TextBox txtUcret;
        private System.Windows.Forms.TextBox txtAciklama;      // Yeni eklendi
        private System.Windows.Forms.DateTimePicker dtpTarih;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.Label lblDoktor;
        private System.Windows.Forms.Label lblKlinik;
        private System.Windows.Forms.Label lblRandevu;          // Yeni eklendi
        private System.Windows.Forms.Label lblTedaviAdi;
        private System.Windows.Forms.Label lblTarih;
        private System.Windows.Forms.Label lblUcret;
        private System.Windows.Forms.Label lblAciklama;         // Yeni eklendi
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnTemizle;

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
            this.dgvTedaviler = new System.Windows.Forms.DataGridView();
            this.cmbHasta = new System.Windows.Forms.ComboBox();
            this.cmbDoktor = new System.Windows.Forms.ComboBox();
            this.cmbKlinik = new System.Windows.Forms.ComboBox();
            this.cmbRandevu = new System.Windows.Forms.ComboBox();
            this.txtTedaviAdi = new System.Windows.Forms.TextBox();
            this.txtUcret = new System.Windows.Forms.TextBox();
            this.txtAciklama = new System.Windows.Forms.TextBox();
            this.dtpTarih = new System.Windows.Forms.DateTimePicker();
            this.lblHasta = new System.Windows.Forms.Label();
            this.lblDoktor = new System.Windows.Forms.Label();
            this.lblKlinik = new System.Windows.Forms.Label();
            this.lblRandevu = new System.Windows.Forms.Label();
            this.lblTedaviAdi = new System.Windows.Forms.Label();
            this.lblTarih = new System.Windows.Forms.Label();
            this.lblUcret = new System.Windows.Forms.Label();
            this.lblAciklama = new System.Windows.Forms.Label();
            this.btnEkle = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnTemizle = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvTedaviler)).BeginInit();
            this.SuspendLayout();

            // dgvTedaviler
            this.dgvTedaviler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTedaviler.Location = new System.Drawing.Point(12, 310);
            this.dgvTedaviler.Name = "dgvTedaviler";
            this.dgvTedaviler.RowHeadersWidth = 51;
            this.dgvTedaviler.RowTemplate.Height = 24;
            this.dgvTedaviler.Size = new System.Drawing.Size(760, 160);
            this.dgvTedaviler.TabIndex = 0;
            this.dgvTedaviler.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTedaviler_CellClick);

            // cmbHasta
            this.cmbHasta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHasta.FormattingEnabled = true;
            this.cmbHasta.Location = new System.Drawing.Point(120, 20);
            this.cmbHasta.Name = "cmbHasta";
            this.cmbHasta.Size = new System.Drawing.Size(200, 24);
            this.cmbHasta.TabIndex = 1;

            // cmbDoktor
            this.cmbDoktor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDoktor.FormattingEnabled = true;
            this.cmbDoktor.Location = new System.Drawing.Point(120, 60);
            this.cmbDoktor.Name = "cmbDoktor";
            this.cmbDoktor.Size = new System.Drawing.Size(200, 24);
            this.cmbDoktor.TabIndex = 2;

            // cmbKlinik
            this.cmbKlinik.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKlinik.FormattingEnabled = true;
            this.cmbKlinik.Location = new System.Drawing.Point(120, 100);
            this.cmbKlinik.Name = "cmbKlinik";
            this.cmbKlinik.Size = new System.Drawing.Size(200, 24);
            this.cmbKlinik.TabIndex = 3;

            // cmbRandevu
            this.cmbRandevu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRandevu.FormattingEnabled = true;
            this.cmbRandevu.Location = new System.Drawing.Point(120, 140);
            this.cmbRandevu.Name = "cmbRandevu";
            this.cmbRandevu.Size = new System.Drawing.Size(200, 24);
            this.cmbRandevu.TabIndex = 4;

            // txtTedaviAdi
            this.txtTedaviAdi.Location = new System.Drawing.Point(460, 20);
            this.txtTedaviAdi.Name = "txtTedaviAdi";
            this.txtTedaviAdi.Size = new System.Drawing.Size(200, 22);
            this.txtTedaviAdi.TabIndex = 5;

            // txtUcret
            this.txtUcret.Location = new System.Drawing.Point(460, 60);
            this.txtUcret.Name = "txtUcret";
            this.txtUcret.Size = new System.Drawing.Size(200, 22);
            this.txtUcret.TabIndex = 6;

            // txtAciklama
            this.txtAciklama.Location = new System.Drawing.Point(460, 100);
            this.txtAciklama.Multiline = true;
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Size = new System.Drawing.Size(200, 60);
            this.txtAciklama.TabIndex = 7;

            // dtpTarih
            this.dtpTarih.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTarih.Location = new System.Drawing.Point(120, 180);
            this.dtpTarih.Name = "dtpTarih";
            this.dtpTarih.Size = new System.Drawing.Size(200, 22);
            this.dtpTarih.TabIndex = 8;

            // lblHasta
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(30, 23);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(44, 17);
            this.lblHasta.TabIndex = 9;
            this.lblHasta.Text = "Hasta:";

            // lblDoktor
            this.lblDoktor.AutoSize = true;
            this.lblDoktor.Location = new System.Drawing.Point(30, 63);
            this.lblDoktor.Name = "lblDoktor";
            this.lblDoktor.Size = new System.Drawing.Size(54, 17);
            this.lblDoktor.TabIndex = 10;
            this.lblDoktor.Text = "Doktor:";

            // lblKlinik
            this.lblKlinik.AutoSize = true;
            this.lblKlinik.Location = new System.Drawing.Point(30, 103);
            this.lblKlinik.Name = "lblKlinik";
            this.lblKlinik.Size = new System.Drawing.Size(46, 17);
            this.lblKlinik.TabIndex = 11;
            this.lblKlinik.Text = "Klinik:";

            // lblRandevu
            this.lblRandevu.AutoSize = true;
            this.lblRandevu.Location = new System.Drawing.Point(30, 143);
            this.lblRandevu.Name = "lblRandevu";
            this.lblRandevu.Size = new System.Drawing.Size(68, 17);
            this.lblRandevu.TabIndex = 12;
            this.lblRandevu.Text = "Randevu:";

            // lblTedaviAdi
            this.lblTedaviAdi.AutoSize = true;
            this.lblTedaviAdi.Location = new System.Drawing.Point(380, 23);
            this.lblTedaviAdi.Name = "lblTedaviAdi";
            this.lblTedaviAdi.Size = new System.Drawing.Size(72, 17);
            this.lblTedaviAdi.TabIndex = 13;
            this.lblTedaviAdi.Text = "Tedavi Adı:";

            // lblUcret
            this.lblUcret.AutoSize = true;
            this.lblUcret.Location = new System.Drawing.Point(380, 63);
            this.lblUcret.Name = "lblUcret";
            this.lblUcret.Size = new System.Drawing.Size(45, 17);
            this.lblUcret.TabIndex = 14;
            this.lblUcret.Text = "Ücret:";

            // lblAciklama
            this.lblAciklama.AutoSize = true;
            this.lblAciklama.Location = new System.Drawing.Point(380, 103);
            this.lblAciklama.Name = "lblAciklama";
            this.lblAciklama.Size = new System.Drawing.Size(68, 17);
            this.lblAciklama.TabIndex = 15;
            this.lblAciklama.Text = "Açıklama:";

            // btnEkle
            this.btnEkle.Location = new System.Drawing.Point(380, 180);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(90, 30);
            this.btnEkle.TabIndex = 16;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);

            // btnGuncelle
            this.btnGuncelle.Location = new System.Drawing.Point(490, 180);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(90, 30);
            this.btnGuncelle.TabIndex = 17;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);

            // btnSil
            this.btnSil.Location = new System.Drawing.Point(380, 220);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(90, 30);
            this.btnSil.TabIndex = 18;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);

            // btnTemizle
            this.btnTemizle.Location = new System.Drawing.Point(490, 220);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(90, 30);
            this.btnTemizle.TabIndex = 19;
            this.btnTemizle.Text = "Temizle";
            this.btnTemizle.UseVisualStyleBackColor = true;
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);

            // FormTedavi
            this.ClientSize = new System.Drawing.Size(784, 481);
            this.Controls.Add(this.btnTemizle);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.lblAciklama);
            this.Controls.Add(this.lblUcret);
            this.Controls.Add(this.lblTedaviAdi);
            this.Controls.Add(this.lblRandevu);
            this.Controls.Add(this.lblKlinik);
            this.Controls.Add(this.lblDoktor);
            this.Controls.Add(this.lblHasta);
            this.Controls.Add(this.dtpTarih);
            this.Controls.Add(this.txtAciklama);
            this.Controls.Add(this.txtUcret);
            this.Controls.Add(this.txtTedaviAdi);
            this.Controls.Add(this.cmbRandevu);
            this.Controls.Add(this.cmbKlinik);
            this.Controls.Add(this.cmbDoktor);
            this.Controls.Add(this.cmbHasta);
            this.Controls.Add(this.dgvTedaviler);
            this.Name = "FormTedavi";
            this.Text = "Tedavi İşlemleri";
            this.Load += new System.EventHandler(this.FormTedavi_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvTedaviler)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
