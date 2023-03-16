using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        public string baglantiYolu = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\emre\Desktop\DERSLER asıl\Seçim otomasyonu\secim.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int SicilNo;
            SicilNo = Convert.ToInt32(textBox1.Text);
            Ekle(textBox6.Text, SicilNo, textBox2.Text);
            MessageBox.Show("Eklendi");
            textBox6.Clear();
            textBox1.Clear();
            textBox2.Clear();
        }
        public void Ekle(string YetkiliAdi, int SicilNo,string Sifre)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = "insert into YetkiliTablosu values (@pYetkiliAdi,@pYetkiliSicilNo,@pYetkiliSifre)";
            SqlCommand komut = new SqlCommand(sql, baglanti);

            SqlParameter p1 = new SqlParameter("@pYetkiliAdi", YetkiliAdi);
            komut.Parameters.Add(p1);
            SqlParameter p2 = new SqlParameter("@pYetkiliSicilNo", SicilNo);
            komut.Parameters.Add(p2);
            SqlParameter p3 = new SqlParameter("@pYetkiliSifre", Sifre);
            komut.Parameters.Add(p3);

            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        public DataSet Bul(string YetkiliAdi)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = " select * from YetkiliTablosu where YetkiliAdi like @pYetkiliAdi+'%' ";
            SqlCommand komut = new SqlCommand(sql, baglanti);


            SqlParameter p1 = new SqlParameter("@pYetkiliAdi", YetkiliAdi);
            komut.Parameters.Add(p1);

            SqlDataAdapter adaptor = new SqlDataAdapter(komut);


            DataSet bulunanlar = new DataSet();
            baglanti.Open();
            adaptor.Fill(bulunanlar);
            baglanti.Close();

            return bulunanlar;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = "update YetkiliTablosu set YetkiliAdi=@pYetkiliAdi, YetkiliSicilNo=@pYetkiliSicilNo,YetkiliSifre=@pYetkiliSifre where YetkiliID=@pYetkiliID";
            SqlCommand komut = new SqlCommand(sql, baglanti);

            komut.Parameters.AddWithValue("@pYetkiliAdi", textBox7.Text);
            komut.Parameters.AddWithValue("@pYetkiliSicilNo", textBox3.Text);
            komut.Parameters.AddWithValue("@pYetkiliSifre", textBox4.Text);

            int YetkiliID = (int)dataGridView1.SelectedRows[0].Cells[0].Value;

            komut.Parameters.AddWithValue("@pYetkiliID", YetkiliID);

            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Düzenlendi");
            textBox7.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = "delete from YetkiliTablosu where YetkiliID=@pYetkiliID";
            SqlCommand komut = new SqlCommand(sql, baglanti);


            int YetkiliID = (int)dataGridView1.SelectedRows[0].Cells[0].Value;

            komut.Parameters.AddWithValue("@pYetkiliID", YetkiliID);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Silindi");
            textBox7.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow secilenSatir = dataGridView1.SelectedRows[0];
                int YetkiliID = (int)secilenSatir.Cells[0].Value;

                textBox7.Text = secilenSatir.Cells[1].Value.ToString();
                textBox3.Text = secilenSatir.Cells[2].Value.ToString();
                textBox4.Text = secilenSatir.Cells[3].Value.ToString();

            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            DataSet bulunanlar = new DataSet();
            bulunanlar = Bul(textBox5.Text);
            dataGridView1.DataSource = bulunanlar.Tables[0];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int TcNo;
            TcNo = Convert.ToInt32(textBox9.Text);
            Ekle2(textBox8.Text, TcNo, textBox10.Text);
            MessageBox.Show("Eklendi");
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
        }
        public void Ekle2(string KullaniciAdi, int TcNo, string Sifre)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = "insert into KullaniciTablosu values (@pKullaniciAdi,@pTcNo,@pEdevletSifre)";
            SqlCommand komut = new SqlCommand(sql, baglanti);

            SqlParameter p1 = new SqlParameter("@pKullaniciAdi", KullaniciAdi);
            komut.Parameters.Add(p1);
            SqlParameter p2 = new SqlParameter("@pTcNo", TcNo);
            komut.Parameters.Add(p2);
            SqlParameter p3 = new SqlParameter("@pEdevletSifre", Sifre);
            komut.Parameters.Add(p3);

            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        public DataSet Bul2(string KullaniciAdi)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = " select * from KullaniciTablosu where KullaniciAdi like @pKullaniciAdi+'%' ";
            SqlCommand komut = new SqlCommand(sql, baglanti);


            SqlParameter p1 = new SqlParameter("@pKullaniciAdi", KullaniciAdi);
            komut.Parameters.Add(p1);

            SqlDataAdapter adaptor = new SqlDataAdapter(komut);


            DataSet bulunanlar2 = new DataSet();
            baglanti.Open();
            adaptor.Fill(bulunanlar2);
            baglanti.Close();

            return bulunanlar2;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = "update KullaniciTablosu set KullaniciAdi=@pKullaniciAdi, TcNo=@pTcNo, EdevletSifre=@pEdevletSifre where KullaniciID=@pKullaniciID";
            SqlCommand komut = new SqlCommand(sql, baglanti);

            komut.Parameters.AddWithValue("@pKullaniciAdi", textBox11.Text);
            komut.Parameters.AddWithValue("@pTcNo", textBox12.Text);
            komut.Parameters.AddWithValue("@pEdevletSifre", textBox13.Text);

            int KullaniciID = (int)dataGridView2.SelectedRows[0].Cells[0].Value;

            komut.Parameters.AddWithValue("@pKullaniciID", KullaniciID);

            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Düzenlendi");
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = "delete from KullaniciTablosu where KullaniciID=@pKullaniciID";
            SqlCommand komut = new SqlCommand(sql, baglanti);


            int KullaniciID = (int)dataGridView2.SelectedRows[0].Cells[0].Value;

            komut.Parameters.AddWithValue("@pKullaniciID", KullaniciID);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Silindi");
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {

            if (dataGridView2.SelectedRows.Count > 0)
            {
                DataGridViewRow secilenSatir = dataGridView2.SelectedRows[0];
                int KullaniciID = (int)secilenSatir.Cells[0].Value;

                textBox11.Text = secilenSatir.Cells[1].Value.ToString();
                textBox12.Text = secilenSatir.Cells[2].Value.ToString();
                textBox13.Text = secilenSatir.Cells[3].Value.ToString();

            }
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            DataSet bulunanlar2 = new DataSet();
            bulunanlar2 = Bul2(textBox14.Text);
            dataGridView2.DataSource = bulunanlar2.Tables[0];
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int OySayisi;
            OySayisi = Convert.ToInt32(null);
            Ekle3(textBox15.Text, 0);
            MessageBox.Show("Eklendi");
            textBox15.Clear();
        }
        public void Ekle3(string PartiAdi, int OySayisi)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = "insert into PartiTablosu values (@pPartiAdi,@pOySayisi)";
            SqlCommand komut = new SqlCommand(sql, baglanti);

            SqlParameter p1 = new SqlParameter("@pPartiAdi", PartiAdi);
            komut.Parameters.Add(p1);
            SqlParameter p2 = new SqlParameter("@pOySayisi", OySayisi);
            komut.Parameters.Add(p2);

            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        public DataSet Bul3(string PartiAdi)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            //string sql = " select PartiAdi from PartiTablosu where PartiAdi like @pPartiAdi+'%' ";
            string sql = " select * from PartiTablosu where PartiAdi like @pPartiAdi+'%' ";
            SqlCommand komut = new SqlCommand(sql, baglanti);


            SqlParameter p1 = new SqlParameter("@pPartiAdi", PartiAdi);
            komut.Parameters.Add(p1);

            SqlDataAdapter adaptor = new SqlDataAdapter(komut);


            DataSet bulunanlar3 = new DataSet();
            baglanti.Open();
            adaptor.Fill(bulunanlar3);
            baglanti.Close();

            return bulunanlar3;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = "update PartiTablosu set PartiAdi=@pPartiAdi where PartiID=@pPartiID";
            SqlCommand komut = new SqlCommand(sql, baglanti);

            komut.Parameters.AddWithValue("@pPartiAdi", textBox16.Text);

            int PartiID = (int)dataGridView3.SelectedRows[0].Cells[0].Value;

            komut.Parameters.AddWithValue("@pPartiID", PartiID);

            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Düzenlendi");
            textBox16.Clear();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = "delete from PartiTablosu where PartiID=@pPartiID";
            SqlCommand komut = new SqlCommand(sql, baglanti);


            int PartiID = (int)dataGridView3.SelectedRows[0].Cells[0].Value;

            komut.Parameters.AddWithValue("@pPartiID", PartiID);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Silindi");
            textBox16.Clear();
        }

        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedRows.Count > 0)
            {
                DataGridViewRow secilenSatir = dataGridView3.SelectedRows[0];
                int PartiID = (int)secilenSatir.Cells[0].Value;

                textBox16.Text = secilenSatir.Cells[1].Value.ToString();

            }
        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            DataSet bulunanlar3 = new DataSet();
            bulunanlar3 = Bul3(textBox17.Text);
            dataGridView3.DataSource = bulunanlar3.Tables[0];
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
           

        }
    }
}
