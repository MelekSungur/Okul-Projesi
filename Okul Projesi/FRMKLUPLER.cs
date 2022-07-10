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

            SqlDataAdapter da = new SqlDataAdapter("Select * from  TBLKULUPLER ", baglanti);
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
    }
}
