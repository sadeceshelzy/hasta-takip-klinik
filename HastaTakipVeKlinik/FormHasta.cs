using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HastaTakipVeKlinik
{
    public partial class FormHasta : Form
    {
        // Veritabanın adını KlinikDB olarak değiştirdim
        private string connectionString = "Data Source=DESKTOP-VSLRSS5\\SQLEXPRESS01;Initial Catalog=Klinik;Integrated Security=True";

        public FormHasta()
        {
            InitializeComponent();
            LoadHastalar();
        }

        private void LoadHastalar()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Hastalar";  // Tablo adı Hastalar
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvHastalar.DataSource = dt;
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAd.Text) || string.IsNullOrWhiteSpace(txtSoyad.Text) ||
                string.IsNullOrWhiteSpace(txtTC.Text) || cmbCinsiyet.SelectedIndex < 0)
            {
                MessageBox.Show("Lütfen tüm zorunlu alanları doldurun!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Hastalar (Ad, Soyad, TC, Telefon, Cinsiyet, DogumTarihi) 
                                 VALUES (@Ad, @Soyad, @TC, @Telefon, @Cinsiyet, @DogumTarihi)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Ad", txtAd.Text);
                    cmd.Parameters.AddWithValue("@Soyad", txtSoyad.Text);
                    cmd.Parameters.AddWithValue("@TC", txtTC.Text);
                    cmd.Parameters.AddWithValue("@Telefon", txtTelefon.Text);
                    cmd.Parameters.AddWithValue("@Cinsiyet", cmbCinsiyet.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@DogumTarihi", dtpDogum.Value.Date);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Hasta eklendi.");
                    LoadHastalar();
                    ClearInputs();
                }
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dgvHastalar.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen güncellenecek hastayı seçin.");
                return;
            }

            DataGridViewRow row = dgvHastalar.SelectedRows[0];
            int hastaID = Convert.ToInt32(row.Cells["HastaID"].Value);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Hastalar SET Ad=@Ad, Soyad=@Soyad, TC=@TC, Telefon=@Telefon, Cinsiyet=@Cinsiyet, DogumTarihi=@DogumTarihi
                                 WHERE HastaID=@HastaID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Ad", txtAd.Text);
                    cmd.Parameters.AddWithValue("@Soyad", txtSoyad.Text);
                    cmd.Parameters.AddWithValue("@TC", txtTC.Text);
                    cmd.Parameters.AddWithValue("@Telefon", txtTelefon.Text);
                    cmd.Parameters.AddWithValue("@Cinsiyet", cmbCinsiyet.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@DogumTarihi", dtpDogum.Value.Date);
                    cmd.Parameters.AddWithValue("@HastaID", hastaID);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Hasta güncellendi.");
                    LoadHastalar();
                    ClearInputs();
                }
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dgvHastalar.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silinecek hastayı seçin.");
                return;
            }

            DialogResult dr = MessageBox.Show("Seçili hastayı silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo);
            if (dr == DialogResult.No) return;

            DataGridViewRow row = dgvHastalar.SelectedRows[0];
            int hastaID = Convert.ToInt32(row.Cells["HastaID"].Value);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Hastalar WHERE HastaID=@HastaID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@HastaID", hastaID);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Hasta silindi.");
                    LoadHastalar();
                    ClearInputs();
                }
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void ClearInputs()
        {
            txtAd.Clear();
            txtSoyad.Clear();
            txtTC.Clear();
            txtTelefon.Clear();
            cmbCinsiyet.SelectedIndex = -1;
            dtpDogum.Value = DateTime.Now;
            dgvHastalar.ClearSelection();
        }

        private void dgvHastalar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvHastalar.Rows[e.RowIndex];
                txtAd.Text = row.Cells["Ad"].Value?.ToString();
                txtSoyad.Text = row.Cells["Soyad"].Value?.ToString();
                txtTC.Text = row.Cells["TC"].Value?.ToString();
                txtTelefon.Text = row.Cells["Telefon"].Value?.ToString();
                cmbCinsiyet.SelectedItem = row.Cells["Cinsiyet"].Value?.ToString();
                DateTime dogum;
                if (DateTime.TryParse(row.Cells["DogumTarihi"].Value?.ToString(), out dogum))
                    dtpDogum.Value = dogum;
            }
        }
    }
}
