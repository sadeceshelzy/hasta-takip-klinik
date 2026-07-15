using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HastaTakipVeKlinik
{
    public partial class FormTedavi : Form
    {
        private readonly string connectionString = @"Server=DESKTOP-VSLRSS5\SQLEXPRESS01;Database=Klinik;Trusted_Connection=True;";
        private int secilenTedaviId = -1;

        public FormTedavi()
        {
            InitializeComponent();
        }

        private void FormTedavi_Load(object sender, EventArgs e)
        {
            RandevulariGetir();
            TedavileriGetir();
        }

        private void RandevulariGetir()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sorgu = @"
                    SELECT R.RandevuID, 
                           H.Ad + ' ' + H.Soyad AS HastaAdi, 
                           D.Ad + ' ' + D.Soyad AS DoktorAdi,
                           R.Tarih
                    FROM Randevular R
                    INNER JOIN Hastalar H ON R.HastaID = H.HastaID
                    INNER JOIN Doktorlar D ON R.DoktorID = D.DoktorID
                    WHERE R.Durum = 'Bekliyor'";

                SqlDataAdapter da = new SqlDataAdapter(sorgu, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbRandevu.DataSource = dt;
                cmbRandevu.DisplayMember = "HastaAdi"; // Dilersen Doktor ve Tarihi de gösterebilirsin
                cmbRandevu.ValueMember = "RandevuID";
                cmbRandevu.SelectedIndex = -1;
            }
        }

        private void TedavileriGetir()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sorgu = @"
                    SELECT T.TedaviID, 
                           R.RandevuID,
                           H.Ad + ' ' + H.Soyad AS HastaAdi,
                           D.Ad + ' ' + D.Soyad AS DoktorAdi,
                           T.Aciklama,
                           T.Tarih
                    FROM Tedaviler T
                    INNER JOIN Randevular R ON T.RandevuID = R.RandevuID
                    INNER JOIN Hastalar H ON R.HastaID = H.HastaID
                    INNER JOIN Doktorlar D ON R.DoktorID = D.DoktorID";

                SqlDataAdapter da = new SqlDataAdapter(sorgu, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvTedaviler.DataSource = dt;

                if (dgvTedaviler.Columns["TedaviID"] != null)
                    dgvTedaviler.Columns["TedaviID"].Visible = false;
                if (dgvTedaviler.Columns["RandevuID"] != null)
                    dgvTedaviler.Columns["RandevuID"].Visible = false;
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (cmbRandevu.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txtAciklama.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string insertSorgu = @"INSERT INTO Tedaviler (RandevuID, Aciklama, Tarih) 
                                       VALUES (@RandevuID, @Aciklama, @Tarih)";
                SqlCommand cmd = new SqlCommand(insertSorgu, conn);
                cmd.Parameters.AddWithValue("@RandevuID", cmbRandevu.SelectedValue);
                cmd.Parameters.AddWithValue("@Aciklama", txtAciklama.Text);
                cmd.Parameters.AddWithValue("@Tarih", dtpTarih.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Tedavi başarıyla eklendi.");
            Temizle();
            TedavileriGetir();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (secilenTedaviId == -1)
            {
                MessageBox.Show("Lütfen güncellenecek tedaviyi seçin.");
                return;
            }

            if (cmbRandevu.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txtAciklama.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string updateSorgu = @"UPDATE Tedaviler SET RandevuID = @RandevuID, Aciklama = @Aciklama, Tarih = @Tarih WHERE TedaviID = @TedaviID";
                SqlCommand cmd = new SqlCommand(updateSorgu, conn);
                cmd.Parameters.AddWithValue("@RandevuID", cmbRandevu.SelectedValue);
                cmd.Parameters.AddWithValue("@Aciklama", txtAciklama.Text);
                cmd.Parameters.AddWithValue("@Tarih", dtpTarih.Value);
                cmd.Parameters.AddWithValue("@TedaviID", secilenTedaviId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Tedavi başarıyla güncellendi.");
            Temizle();
            TedavileriGetir();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (secilenTedaviId == -1)
            {
                MessageBox.Show("Lütfen silinecek tedaviyi seçin.");
                return;
            }

            DialogResult dr = MessageBox.Show("Seçilen tedaviyi silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo);
            if (dr == DialogResult.No)
                return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string deleteSorgu = "DELETE FROM Tedaviler WHERE TedaviID = @TedaviID";
                SqlCommand cmd = new SqlCommand(deleteSorgu, conn);
                cmd.Parameters.AddWithValue("@TedaviID", secilenTedaviId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Tedavi başarıyla silindi.");
            Temizle();
            TedavileriGetir();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void Temizle()
        {
            cmbRandevu.SelectedIndex = -1;
            txtAciklama.Clear();
            dtpTarih.Value = DateTime.Now;
            secilenTedaviId = -1;
            dgvTedaviler.ClearSelection();
        }

        private void dgvTedaviler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvTedaviler.Rows[e.RowIndex];
            secilenTedaviId = Convert.ToInt32(row.Cells["TedaviID"].Value);
            cmbRandevu.SelectedValue = row.Cells["RandevuID"].Value;
            txtAciklama.Text = row.Cells["Aciklama"].Value.ToString();
            dtpTarih.Value = Convert.ToDateTime(row.Cells["Tarih"].Value);
        }
    }
}
