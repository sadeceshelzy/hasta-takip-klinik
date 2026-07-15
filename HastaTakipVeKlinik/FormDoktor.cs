using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HastaTakipVeKlinik
{
    public partial class FormDoktor : Form
    {
        private SqlConnection connectionString = new SqlConnection("Data Source=DESKTOP-VSLRSS5\\SQLEXPRESS01;Initial Catalog=Klinik;Integrated Security=True");

        public FormDoktor()
        {
            InitializeComponent();
        }

        private void FormDoktor_Load(object sender, EventArgs e)
        {
            LoadKlinikler();
            LoadDoktorlar();
            Temizle();
        }

        private void LoadKlinikler()
        {
            try
            {
                connectionString.Open();
                SqlCommand cmd = new SqlCommand("SELECT KlinikID, KlinikAdi FROM Klinikler", connectionString);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbKlinik.DataSource = dt;
                cmbKlinik.DisplayMember = "KlinikAdi";
                cmbKlinik.ValueMember = "KlinikID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Klinikler yüklenirken hata: " + ex.Message);
            }
            finally
            {
                connectionString.Close();
            }
        }

        private void LoadDoktorlar()
        {
            try
            {
                connectionString.Open();
                string query = @"SELECT d.DoktorID, d.Ad, d.Soyad, k.KlinikAdi 
                                 FROM Doktorlar d
                                 INNER JOIN Klinikler k ON d.KlinikID = k.KlinikID";
                SqlDataAdapter da = new SqlDataAdapter(query, connectionString);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvDoktorlar.DataSource = dt;
                dgvDoktorlar.Columns["DoktorID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Doktorlar yüklenirken hata: " + ex.Message);
            }
            finally
            {
                connectionString.Close();
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAd.Text) || string.IsNullOrWhiteSpace(txtSoyad.Text) || cmbKlinik.SelectedIndex < 0)
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
                return;
            }

            try
            {
                connectionString.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Doktorlar (Ad, Soyad, KlinikID) VALUES (@Ad, @Soyad, @KlinikID)", connectionString);
                cmd.Parameters.AddWithValue("@Ad", txtAd.Text.Trim());
                cmd.Parameters.AddWithValue("@Soyad", txtSoyad.Text.Trim());
                cmd.Parameters.AddWithValue("@KlinikID", cmbKlinik.SelectedValue);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Doktor eklendi.");
                LoadDoktorlar();
                Temizle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ekleme sırasında hata: " + ex.Message);
            }
            finally
            {
                connectionString.Close();
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dgvDoktorlar.SelectedRows.Count == 0)
            {
                MessageBox.Show("Güncellenecek doktoru seçin.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtAd.Text) || string.IsNullOrWhiteSpace(txtSoyad.Text) || cmbKlinik.SelectedIndex < 0)
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
                return;
            }

            try
            {
                int doktorId = Convert.ToInt32(dgvDoktorlar.SelectedRows[0].Cells["DoktorID"].Value);
                connectionString.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Doktorlar SET Ad=@Ad, Soyad=@Soyad, KlinikID=@KlinikID WHERE DoktorID=@DoktorID", connectionString);
                cmd.Parameters.AddWithValue("@Ad", txtAd.Text.Trim());
                cmd.Parameters.AddWithValue("@Soyad", txtSoyad.Text.Trim());
                cmd.Parameters.AddWithValue("@KlinikID", cmbKlinik.SelectedValue);
                cmd.Parameters.AddWithValue("@DoktorID", doktorId);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Doktor güncellendi.");
                LoadDoktorlar();
                Temizle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme sırasında hata: " + ex.Message);
            }
            finally
            {
                connectionString.Close();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dgvDoktorlar.SelectedRows.Count == 0)
            {
                MessageBox.Show("Silinecek doktoru seçin.");
                return;
            }

            try
            {
                int doktorId = Convert.ToInt32(dgvDoktorlar.SelectedRows[0].Cells["DoktorID"].Value);
                connectionString.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Doktorlar WHERE DoktorID=@DoktorID", connectionString);
                cmd.Parameters.AddWithValue("@DoktorID", doktorId);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Doktor silindi.");
                LoadDoktorlar();
                Temizle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silme sırasında hata: " + ex.Message);
            }
            finally
            {
                connectionString.Close();
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void Temizle()
        {
            txtAd.Clear();
            txtSoyad.Clear();
            cmbKlinik.SelectedIndex = -1;
            dgvDoktorlar.ClearSelection();
        }

        private void dgvDoktorlar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDoktorlar.Rows[e.RowIndex];
                txtAd.Text = row.Cells["Ad"].Value.ToString();
                txtSoyad.Text = row.Cells["Soyad"].Value.ToString();
                cmbKlinik.SelectedValue = Convert.ToInt32(row.Cells["KlinikID"].Value);  // Burada KlinikID kolonunun görünür olması gerekebilir.
            }
        }
    }
}
