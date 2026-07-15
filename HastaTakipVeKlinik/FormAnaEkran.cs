using System;
using System.Windows.Forms;

namespace HastaTakipVeKlinik
{
    public partial class FormAnaEkran : Form
    {
        public FormAnaEkran()
        {
            InitializeComponent();
        }

        private void klinikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormKlinik frm = new FormKlinik();
            frm.MdiParent = this;  // Çoklu doküman arayüzü (MDI) için
            frm.Show();
        }

        private void doktorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDoktor frm = new FormDoktor();
            frm.MdiParent = this;
            frm.Show();
        }

        private void hastaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHasta frm = new FormHasta();
            frm.MdiParent = this;
            frm.Show();
        }

        private void randevuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRandevu frm = new FormRandevu();
            frm.MdiParent = this;
            frm.Show();
        }

        private void tedaviToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTedavi frm = new FormTedavi();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
