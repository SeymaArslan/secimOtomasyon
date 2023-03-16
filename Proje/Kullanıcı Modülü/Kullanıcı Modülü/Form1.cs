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
    public partial class Form1 : Form
    {
        public string baglantiYolu = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\emre\Desktop\DERSLER asıl\Seçim otomasyonu\secim.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
        public Form1()
        {
            InitializeComponent();
        }
        public string girilen;

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);


            girilen = Convert.ToString(textBox1.Text);

            string gparola = Convert.ToString(textBox2.Text);


            try
            {
                baglanti.Open();
                string sorgu = ("select EdevletSifre from KullaniciTablosu where TcNo ='" + girilen + "' and EdevletSifre='" + gparola + "'");
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                int Count = Convert.ToInt32(komut.ExecuteScalar());
                if (Count != 0)
                {
                    this.Hide();
                    Form2 frm2 = new Form2(girilen);
                    frm2.Show();

                }


                else
                {
                    MessageBox.Show("Hatalı Giriş");
                }

                baglanti.Close();
            }
            catch (Exception)
            {


            }

        }
    }
}
