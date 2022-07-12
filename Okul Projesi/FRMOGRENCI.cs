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
    public partial class FRMOGRENCI : Form
    {
        public FRMOGRENCI()
        {
            InitializeComponent();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-D0LP1EG;Initial Catalog=Okul_Projesi;Integrated Security=True");
        DataSet1TableAdapters.DataTable1TableAdapter ds=new DataSet1TableAdapters.DataTable1TableAdapter();

        private void FRMOGRENCI_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource=ds.OgrenciListesi();
            baglanti.Open();
            SqlCommand komut =new SqlCommand("Select * From TBLKULUPLER ", baglanti);
            SqlDataAdapter da=new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CmbKulup.DisplayMember = "KULUPAD";
            CmbKulup.ValueMember = "KULUPID";
            CmbKulup.DataSource = dt;
            baglanti.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void BtnEkle_Click(object sender, EventArgs e)
        {
            string cinsiyet = " ";
            if (Rdiokiz.Checked == true)
            {
                cinsiyet = "Kız";
            }
            if (Rdioerkek.Checked==true)
            {
                cinsiyet = "Erkek";
            }
            ds.OGRENCIEKLE(TxtAd.Text, TxtSoyad.Text, byte.Parse(CmbKulup.Text), cinsiyet);
            MessageBox.Show("Ders Kayıt Edildi");
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
        }

        private void CmbKulup_SelectedIndexChanged(object sender, EventArgs e)
        {
            Txtid.Text = CmbKulup.SelectedValue.ToString();
        }
    }
}
