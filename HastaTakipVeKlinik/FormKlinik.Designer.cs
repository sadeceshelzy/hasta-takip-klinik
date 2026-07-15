namespace HastaTakipVeKlinik
{
    partial class FormKlinik
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKlinikAd;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnTemizle;
        private System.Windows.Forms.DataGridView dgvKlinikler;

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
            this.label1 = new System.Windows.Forms.Label();
            this.txtKlinikAd = new System.Windows.Forms.TextBox();
            this.btnEkle = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnTemizle = new System.Windows.Forms.Button();
            this.dgvKlinikler = new System.Windows.Forms.DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.dgvKlinikler)).BeginInit();
            this.SuspendLayout();

            // label1
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Klinik Adı:";

            // txtKlinikAd
            this.txtKlinikAd.Location = new System.Drawing.Point(100, 22);
            this.txtKlinikAd.Name = "txtKlinikAd";
            this.txtKlinikAd.Size = new System.Drawing.Size(200, 23);
            this.txtKlinikAd.TabIndex = 1;

            // btnEkle
            this.btnEkle.Location = new System.Drawing.Point(320, 20);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(75, 27);
            this.btnEkle.TabIndex = 2;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);

            // btnGuncelle
            this.btnGuncelle.Location = new System.Drawing.Point(410, 20);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(75, 27);
            this.btnGuncelle.TabIndex = 3;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);

            // btnSil
            this.btnSil.Location = new System.Drawing.Point(500, 20);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(75, 27);
            this.btnSil.TabIndex = 4;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);

            // btnTemizle
            this.btnTemizle.Location = new System.Drawing.Point(590, 20);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(75, 27);
            this.btnTemizle.TabIndex = 5;
            this.btnTemizle.Text = "Temizle";
            this.btnTemizle.UseVisualStyleBackColor = true;
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);

            // dgvKlinikler
            this.dgvKlinikler.AllowUserToAddRows = false;
            this.dgvKlinikler.AllowUserToDeleteRows = false;
            this.dgvKlinikler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKlinikler.Location = new System.Drawing.Point(25, 70);
            this.dgvKlinikler.Name = "dgvKlinikler";
            this.dgvKlinikler.ReadOnly = true;
            this.dgvKlinikler.RowTemplate.Height = 25;
            this.dgvKlinikler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKlinikler.Size = new System.Drawing.Size(640, 300);
            this.dgvKlinikler.TabIndex = 6;
            this.dgvKlinikler.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKlinikler_CellClick);

            // FormKlinik
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 400);
            this.Controls.Add(this.dgvKlinikler);
            this.Controls.Add(this.btnTemizle);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.txtKlinikAd);
            this.Controls.Add(this.label1);
            this.Name = "FormKlinik";
            this.Text = "Klinik Yönetimi";
            this.Load += new System.EventHandler(this.FormKlinik_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvKlinikler)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
