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
    public partial class Form3 : Form
    {
        public string baglantiYolu = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\emre\Desktop\DERSLER asıl\Seçim otomasyonu\secim.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
        string insan;
        public string insanID;
        public Form3(string varlik)
        {
            insan = varlik;
            InitializeComponent();
        }
        public void bilgiler()
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM KullaniciTablosu WHERE KullaniciID='" + insan + "' ", baglanti);
            komut.ExecuteScalar();

            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {

                label1.Text = oku["KullaniciAdi"].ToString();
                textBox1.Text = oku["KullaniciID"].ToString();


            }
            baglanti.Close();


        }

        private void Form3_Load(object sender, EventArgs e)
        {
            bilgiler();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            insanID = Convert.ToString(textBox1.Text);

            SqlConnection baglanti = new SqlConnection(baglantiYolu);

            
            
            string sql = "delete from KullaniciTablosu where KullaniciID="+insanID;
            SqlCommand komut = new SqlCommand(sql, baglanti);


            

            komut.Parameters.AddWithValue("@pKullaniciID", insanID);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            this.Close();

            Form1 frm = new Form1();
            frm.Show();
        }
    }
}
