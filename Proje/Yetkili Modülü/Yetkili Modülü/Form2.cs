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

namespace Yetkili_Modülü
{
    public partial class Form2 : Form
    {
        public string baglantiYolu = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\emre\Desktop\DERSLER asıl\Seçim otomasyonu\secim.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
        public Form2()
        {
            InitializeComponent();
        }

        public DataSet PartiCek()
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = " select PartiAdi,OySayisi from PartiTablosu ";
            SqlCommand komut = new SqlCommand(sql, baglanti);


            SqlDataAdapter adaptor = new SqlDataAdapter(komut);


            DataSet PartiTablosu = new DataSet();
            baglanti.Open();
            adaptor.Fill(PartiTablosu);
            baglanti.Close();

            return PartiTablosu;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'secimDataSet.PartiTablosu' table. You can move, or remove it, as needed.
            this.partiTablosuTableAdapter.Fill(this.secimDataSet.PartiTablosu);
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            
            DataSet PartiTablosu = PartiCek();
            dataGridView1.DataSource = PartiTablosu.Tables[0];
        }
        
    }
}
