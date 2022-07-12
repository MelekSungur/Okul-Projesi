using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Okul_Projesi
{
    public partial class FRMDERSLER : Form
    {
        public FRMDERSLER()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.TBLDERSLERTableAdapter DS = new DataSet1TableAdapters.TBLDERSLERTableAdapter();

        private void FRMDERSLER_Load(object sender, EventArgs e)
        {
          
            dataGridView1.DataSource = DS.DersListesi();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            DS.DersEkle(txtkulupad.Text);
            MessageBox.Show("Kayıt Eklendi", "Bilgi");
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DS.DersListesi();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            DS.DersSil(byte.Parse(txtkulupid.Text));
            MessageBox.Show("Kayıt Silindi", "Bilgi");

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtkulupid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtkulupad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            DS.DersGuncelle(txtkulupad.Text,byte.Parse(txtkulupid.Text));
            MessageBox.Show("Ders Kaydı Güncellendi", "Bilgi");


        }
    }
}
