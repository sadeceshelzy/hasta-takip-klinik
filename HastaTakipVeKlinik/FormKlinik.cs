using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HastaTakipVeKlinik
{
    public partial class FormKlinik : Form
    {
        private SqlConnection conn = new SqlConnection("Data Source=DESKTOP-VSLRSS5\\SQLEXPRESS01;Initial Catalog=Klinik;Integrated Security=True");
        private int secilenKlinikId = -1;

        public FormKlinik()
        {
            InitializeComponent();
        }

        private void FormKlinik_Load(object sender, EventArgs e)
        {
            KlinikleriGetir();
        }

        private void KlinikleriGetir()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT KlinikID, KlinikAdi FROM Klinikler", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvKlinikler.DataSource = dt;
                dgvKlinikler.Columns["KlinikID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Klinikleri getirirken hata oluştu: " + ex.Message);
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKlinikAd.Text))
            {
                MessageBox.Show("Lütfen klinik adını giriniz.");
                return;
            }

            try
            {
                string sorgu = "INSERT INTO Klinikler (KlinikAdi) VALUES (@KlinikAd)";
                SqlCommand cmd = new SqlCommand(sorgu, conn);
                cmd.Parameters.AddWithValue("@KlinikAd", txtKlinikAd.Text.Trim());

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Klinik eklendi.");
                KlinikleriGetir();
                Temizle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Klinik eklenirken hata oluştu: " + ex.Message);
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (secilenKlinikId == -1)
            {
                MessageBox.Show("Lütfen güncellenecek kliniği seçiniz.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtKlinikAd.Text))
            {
                MessageBox.Show("Lütfen klinik adını giriniz.");
                return;
            }

            try
            {
                string sorgu = "UPDATE Klinikler SET KlinikAdi = @KlinikAd WHERE KlinikID = @KlinikID";
                SqlCommand cmd = new SqlCommand(sorgu, conn);
                cmd.Parameters.AddWithValue("@KlinikAd", txtKlinikAd.Text.Trim());
                cmd.Parameters.AddWithValue("@KlinikID", secilenKlinikId);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Klinik güncellendi.");
                KlinikleriGetir();
                Temizle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Klinik güncellenirken hata oluştu: " + ex.Message);
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (secilenKlinikId == -1)
            {
                MessageBox.Show("Lütfen silinecek kliniği seçiniz.");
                return;
            }

            if (KlinikKullaniliyor(secilenKlinikId))
            {
                MessageBox.Show("Bu klinikte doktor olduğu için silme işlemi yapılamıyor. Önce doktorları siliniz veya kliniklerini değiştiriniz.");
                return;
            }

            var confirmResult = MessageBox.Show("Bu klinik silinecek, emin misiniz?", "Onay", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.No) return;

            try
            {
                string sorgu = "DELETE FROM Klinikler WHERE KlinikID = @KlinikID";
                SqlCommand cmd = new SqlCommand(sorgu, conn);
                cmd.Parameters.AddWithValue("@KlinikID", secilenKlinikId);

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Klinik silindi.");
                KlinikleriGetir();
                Temizle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Klinik silinirken hata oluştu: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void Temizle()
        {
            txtKlinikAd.Clear();
            secilenKlinikId = -1;
            dgvKlinikler.ClearSelection();
        }

        private void dgvKlinikler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow satir = dgvKlinikler.Rows[e.RowIndex];
                secilenKlinikId = Convert.ToInt32(satir.Cells["KlinikID"].Value);
                txtKlinikAd.Text = satir.Cells["KlinikAdi"].Value.ToString();
            }
        }
        private bool KlinikKullaniliyor(int klinikId)
        {
            try
            {
                string sorgu = "SELECT COUNT(*) FROM Doktorlar WHERE KlinikID = @KlinikID";
                SqlCommand cmd = new SqlCommand(sorgu, conn);
                cmd.Parameters.AddWithValue("@KlinikID", klinikId);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }
    }
}
