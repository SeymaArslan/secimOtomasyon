using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Configuration;
using System.Data.SqlClient;

namespace Kullanıcı_Modülü
{
    public partial class Form2 : Form
    {
        public string baglantiYolu = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\emre\Desktop\DERSLER asıl\Seçim otomasyonu\secim.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
        string Secmen;
        public string SecmenID;
        public Form2(string kullanici)
        {
            Secmen = kullanici;
            InitializeComponent();
        }

        public void bilgiler()
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM KullaniciTablosu WHERE TcNo='" + Secmen + "' ", baglanti);
            komut.ExecuteScalar();

            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {

                label2.Text = oku["KullaniciAdi"].ToString();
                textBox1.Text = oku["KullaniciID"].ToString();


            }
            baglanti.Close();


        }

        private void Form2_Load(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            comboBox1.DisplayMember = "PartiAdi";
            comboBox1.ValueMember = "PartiID";
            DataSet PartiTablosu = PartiCek();
            comboBox1.DataSource = PartiTablosu.Tables[0];

            bilgiler();
        }

        public DataSet PartiCek()
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = "select * from PartiTablosu";
            SqlCommand komut = new SqlCommand(sql, baglanti);


            SqlDataAdapter adaptor = new SqlDataAdapter(komut);


            DataSet PartiTablosu = new DataSet();
            baglanti.Open();
            adaptor.Fill(PartiTablosu);
            baglanti.Close();

            return PartiTablosu;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int secilenParti = Convert.ToInt32(comboBox1.SelectedValue);
            SecmenID = Convert.ToString(textBox1.Text);

            SqlConnection baglanti = new SqlConnection(baglantiYolu);

            string sql = "update PartiTablosu set OySayisi=OySayisi+1 where PartiID=" + secilenParti;
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@ppartiID", secilenParti);
            DataSet ds = new DataSet();
            SqlDataAdapter adaptor = new SqlDataAdapter(komut);
            baglanti.Open();
            adaptor.Fill(ds);



            this.Close();
            MessageBox.Show("Oyunuz başarılı bir şekilde kullanılmıştır.");

            Form3 frm = new Form3(SecmenID);
            frm.Show();
            baglanti.Close();
            }
        

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
        
        
    }
}
