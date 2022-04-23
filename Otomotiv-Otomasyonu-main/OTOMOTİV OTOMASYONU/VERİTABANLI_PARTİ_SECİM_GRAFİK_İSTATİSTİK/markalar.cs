using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;//BUNU EKLEMESEN OLMAZ VERİ TABANINA BAĞLANAMAZSIN
namespace VERİTABANLI_PARTİ_SECİM_GRAFİK_İSTATİSTİK
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-O9RRR03;Initial Catalog=OTOMOTİV OTOMASYON;Integrated Security=True");//bağlantı nesnesi oluşturduk
        private void BTNOYGİRİŞ_Click(object sender, EventArgs e)
        {
            baglanti.Open();// Tarafından belirtilen özellik ayarlarına sahip bir veritabanı bağlantısı açar 
            SqlCommand komut = new SqlCommand("insert into tblsehirler (sehirad,wolksvagen,opel,skoda,toyota,ford)values(@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            // burda komut nesnesi ile eklemeler yapıyoruz sonra bu parametreler ile cağracaz 
            komut.Parameters.AddWithValue("@p1", TEXTİLCEAD.Text);// BURDA İSE NAME İSİMLERİNİ KULANIYORUZ 
            komut.Parameters.AddWithValue("@p2", TEXTA.Text);
            komut.Parameters.AddWithValue("@p3", TEXTB.Text);
            komut.Parameters.AddWithValue("@p4", TEXTC.Text);
            komut.Parameters.AddWithValue("@p5", TEXTD.Text);
            komut.Parameters.AddWithValue("@p6", TEXTE.Text);
            komut.ExecuteNonQuery();// sorguyu gerçekleştirir 
            baglanti.Close();// bağlantıyı kapatır 
            MessageBox.Show("KAYDEDİLDİ");// BUDA MESAJ GÖSTERİR 
            // bi hata olduğunda aşahıda direk hatanın üstüne bas kırmızı carpı seni direk hattaya götürüryor 


        }

        private void BTNGRAFİK_Click(object sender, EventArgs e)
        {
            FRMGRAFİKLER fr = new FRMGRAFİKLER();//frmgarfikler bir sınıf olarak düşün fr de sınıf içinden bir nesne üretik 
            fr.Show();// bu nesnemizi göstermek istedik 
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BTNCIKIŞYAP_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
