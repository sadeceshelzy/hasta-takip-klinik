using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using System.Windows.Forms;

namespace HastaTakipVeKlinik
{
    public partial class Form1 : Form
    {
        public static string connectionString = "Server=DESKTOP-VSLRSS5\\SQLEXPRESS01;Database=Klinik;Trusted_Connection=True;";

        public Form1()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Kullanici WHERE KullaniciAdi = @adi AND Sifre = @sifre";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@adi", txtKullaniciAdi.Text);
                cmd.Parameters.AddWithValue("@sifre", txtSifre.Text);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    MessageBox.Show("Giriş başarılı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FormAnaEkran anaForm = new FormAnaEkran(); // Ana formunuzun adı neyse onu kullan
                    anaForm.Show();

                    // Giriş formunu gizle veya kapat
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Hatalı kullanıcı adı veya şifre!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
