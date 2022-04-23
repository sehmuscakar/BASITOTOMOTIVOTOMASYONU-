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
namespace VERİTABANLI_PARTİ_SECİM_GRAFİK_İSTATİSTİK
{
    public partial class FRMGRAFİKLER : Form
    {
        public FRMGRAFİKLER()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-O9RRR03;Initial Catalog=OTOMOTİV OTOMASYON;Integrated Security=True");
        private void FRMGRAFİKLER_Load(object sender, EventArgs e)
        {
            // ilçe adlarını comboboxa çekme
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select sehirad from tblsehirler", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {

                comboBox1.Items.Add(dr[0]);// bir tane sutun olduğu için 0 ci index tek olur 

            }
            baglanti.Close();// bağlantıyı kapat 

            // GRAFİĞE TOPLAM SONUÇLARI GETİRME 
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select sum(wolksvagen),sum(opel),sum(skoda),sum(toyota),sum(ford) FROM tblsehirler", baglanti);
            SqlDataReader dr2 = komut.ExecuteReader();
            while (dr2.Read())
            {


              //  chart1.Series["partiler"].Points.AddXY("A PARTİ",dr2[0]);//1 x oluyor 2 ye oluyor ,partiler kısmı da chart ta name de yazılan 
      

            }
            baglanti.Close();// bağlantıyı kapat 
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from tblsehirler where sehirad=@P1", baglanti);
            komut.Parameters.AddWithValue("@p1", comboBox1.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {

                progressBar1.Value=int.Parse(dr[2].ToString());// ilk önce inte cevir sonra stringe çevir 
                progressBar2.Value = int.Parse(dr[3].ToString());
                progressBar3.Value = int.Parse(dr[4].ToString());
                progressBar4.Value = int.Parse(dr[5].ToString());
                progressBar5.Value = int.Parse(dr[6].ToString());

                LBLA.Text = dr[2].ToString();
                LBLB.Text = dr[3].ToString();
                LBLC.Text = dr[4].ToString();
                LBLD.Text = dr[5].ToString();
                LBLE.Text = dr[6].ToString();
            }
            baglanti.Close();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
