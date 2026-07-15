using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HastaTakipVeKlinik
{
    public partial class FormRandevu : Form
    {
        private readonly string connectionString = @"Server=DESKTOP-VSLRSS5\SQLEXPRESS01;Database=Klinik;Trusted_Connection=True;";
        private int secilenRandevuId = -1;

        public FormRandevu()
        {
            InitializeComponent();
        }

        private void FormRandevu_Load(object sender, EventArgs e)
        {
            DoldurComboBoxlar();
            RandevulariGetir();
        }

        private void DoldurComboBoxlar()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Hastalar
                SqlDataAdapter daHasta = new SqlDataAdapter("SELECT HastaID, Ad + ' ' + Soyad AS AdSoyad FROM Hastalar", conn);
                DataTable dtHasta = new DataTable();
                daHasta.Fill(dtHasta);
                cmbHasta.DataSource = dtHasta;
                cmbHasta.ValueMember = "HastaID";
                cmbHasta.DisplayMember = "AdSoyad";
                cmbHasta.SelectedIndex = -1;

                // Doktorlar
                SqlDataAdapter daDoktor = new SqlDataAdapter("SELECT DoktorID, Ad + ' ' + Soyad AS AdSoyad FROM Doktorlar", conn);
                DataTable dtDoktor = new DataTable();
                daDoktor.Fill(dtDoktor);
                cmbDoktor.DataSource = dtDoktor;
                cmbDoktor.ValueMember = "DoktorID";
                cmbDoktor.DisplayMember = "AdSoyad";
                cmbDoktor.SelectedIndex = -1;

                // Klinikler
                SqlDataAdapter daKlinik = new SqlDataAdapter("SELECT KlinikID, KlinikAdi FROM Klinikler", conn);
                DataTable dtKlinik = new DataTable();
                daKlinik.Fill(dtKlinik);
                cmbKlinik.DataSource = dtKlinik;
                cmbKlinik.ValueMember = "KlinikID";
                cmbKlinik.DisplayMember = "KlinikAdi";
                cmbKlinik.SelectedIndex = -1;
            }
        }

        private void RandevulariGetir()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sorgu = @"
                SELECT 
                    R.RandevuID,
                    H.Ad + ' ' + H.Soyad AS Hasta,
                    D.Ad + ' ' + D.Soyad AS Doktor,
                    K.KlinikAdi,
                    R.Tarih AS RandevuTarihi
                FROM Randevular R
                INNER JOIN Hastalar H ON R.HastaID = H.HastaID
                INNER JOIN Doktorlar D ON R.DoktorID = D.DoktorID
                INNER JOIN Klinikler K ON R.KlinikID = K.KlinikID";

                SqlDataAdapter da = new SqlDataAdapter(sorgu, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvRandevular.DataSource = dt;

                if (dgvRandevular.Columns["RandevuID"] != null)
                    dgvRandevular.Columns["RandevuID"].Visible = false;
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (cmbHasta.SelectedIndex == -1 || cmbDoktor.SelectedIndex == -1 || cmbKlinik.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen tüm alanları seçiniz.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string insertSorgu = "INSERT INTO Randevular (HastaID, DoktorID, KlinikID, Tarih) VALUES (@HastaID, @DoktorID, @KlinikID, @Tarih)";
                SqlCommand cmd = new SqlCommand(insertSorgu, conn);
                cmd.Parameters.AddWithValue("@HastaID", cmbHasta.SelectedValue);
                cmd.Parameters.AddWithValue("@DoktorID", cmbDoktor.SelectedValue);
                cmd.Parameters.AddWithValue("@KlinikID", cmbKlinik.SelectedValue);
                cmd.Parameters.AddWithValue("@Tarih", dtpTarih.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Randevu başarıyla eklendi.");
            Temizle();
            RandevulariGetir();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (secilenRandevuId == -1)
            {
                MessageBox.Show("Lütfen güncellenecek bir randevu seçiniz.");
                return;
            }

            if (cmbHasta.SelectedIndex == -1 || cmbDoktor.SelectedIndex == -1 || cmbKlinik.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen tüm alanları seçiniz.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string updateSorgu = @"UPDATE Randevular 
                                       SET HastaID = @HastaID, DoktorID = @DoktorID, KlinikID = @KlinikID, Tarih = @Tarih 
                                       WHERE RandevuID = @RandevuID";
                SqlCommand cmd = new SqlCommand(updateSorgu, conn);
                cmd.Parameters.AddWithValue("@HastaID", cmbHasta.SelectedValue);
                cmd.Parameters.AddWithValue("@DoktorID", cmbDoktor.SelectedValue);
                cmd.Parameters.AddWithValue("@KlinikID", cmbKlinik.SelectedValue);
                cmd.Parameters.AddWithValue("@Tarih", dtpTarih.Value);
                cmd.Parameters.AddWithValue("@RandevuID", secilenRandevuId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Randevu başarıyla güncellendi.");
            Temizle();
            RandevulariGetir();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (secilenRandevuId == -1)
            {
                MessageBox.Show("Lütfen silinecek bir randevu seçiniz.");
                return;
            }

            DialogResult dr = MessageBox.Show("Seçilen randevuyu silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo);
            if (dr == DialogResult.No)
                return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string deleteSorgu = "DELETE FROM Randevular WHERE RandevuID = @RandevuID";
                SqlCommand cmd = new SqlCommand(deleteSorgu, conn);
                cmd.Parameters.AddWithValue("@RandevuID", secilenRandevuId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Randevu başarıyla silindi.");
            Temizle();
            RandevulariGetir();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void Temizle()
        {
            cmbHasta.SelectedIndex = -1;
            cmbDoktor.SelectedIndex = -1;
            cmbKlinik.SelectedIndex = -1;
            dtpTarih.Value = DateTime.Now;
            secilenRandevuId = -1;
            dgvRandevular.ClearSelection();
        }

        private void dgvRandevular_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvRandevular.Rows[e.RowIndex];
            secilenRandevuId = Convert.ToInt32(row.Cells["RandevuID"].Value);

            // Burada cmb'lerin SelectedValue'sini doğrudan atıyoruz, çünkü sorguda ID'ler yok, sadece isimler var.
            // Bu yüzden id'leri de sorguya eklemeliyiz.

            // Güncellenmiş sorguda id'leri de ekleyelim:
            // Hastalar.HastaID AS HastaID, Doktorlar.DoktorID AS DoktorID, Klinikler.KlinikID AS KlinikID

            cmbHasta.SelectedValue = GetIntCellValue(row, "HastaID");
            cmbDoktor.SelectedValue = GetIntCellValue(row, "DoktorID");
            cmbKlinik.SelectedValue = GetIntCellValue(row, "KlinikID");

            dtpTarih.Value = Convert.ToDateTime(row.Cells["RandevuTarihi"].Value);
        }

        private int GetIntCellValue(DataGridViewRow row, string columnName)
        {
            if (row.Cells[columnName] != null && row.Cells[columnName].Value != null)
            {
                int.TryParse(row.Cells[columnName].Value.ToString(), out int val);
                return val;
            }
            return -1;
        }
    }
}
