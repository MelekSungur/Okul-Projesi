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
    public partial class FRMKLUPLER : Form
    {
        public FRMKLUPLER()
        {
            InitializeComponent();
        }
        SqlConnection baglanti=new SqlConnection("Data Source=DESKTOP-D0LP1EG;Initial Catalog=Okul_Projesi;Integrated Security=True");
       public  void listele()
        {

            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM  TBLKULUPLER", baglanti);
        DataTable dt = new DataTable();
        da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void FRMKLUPLER_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {

        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand kaydet = new SqlCommand("insert into TBLKULUPLER (KULUPAD) VALUES (@P2)", baglanti);
           
            kaydet.Parameters.AddWithValue("@P2", txtkulupad.Text);
            kaydet.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kulüp Kaydı Yapılmıştır", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Red;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Transparent;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtkulupid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtkulupad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand Sil = new SqlCommand("delete from TBLKULUPLER where KULUPID=@p1", baglanti);
            Sil.Parameters.AddWithValue("@p1", txtkulupid.Text);
            Sil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Seçtiğiniz Kayıt Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();

           

        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand guncelle = new SqlCommand("update TBLKULUPLER set KULUPAD=@P2 where KULUPID=@P1", baglanti);
            guncelle.Parameters.AddWithValue("@P1",txtkulupid.Text);
            guncelle.Parameters.AddWithValue("@P2", txtkulupad.Text);
            guncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Seçtiğiniz Kayıt Guncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
