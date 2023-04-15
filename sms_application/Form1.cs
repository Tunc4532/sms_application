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

namespace sms_application
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglntı = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=smsapp;Integrated Security=True");

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            baglntı.Open();
            SqlCommand komut = new SqlCommand("Select * from tbl_kullanıcı where AD=@p1 and NUMARA=@p2 ", baglntı);
            komut.Parameters.AddWithValue("@p1", bunifuTextBox1.Text);
            komut.Parameters.AddWithValue("@p2", txtsifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                Form2 frm = new Form2();
                frm.numaara = txtsifre.Text;
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Şifreniz veya Adınız yanlış ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            baglntı.Close();
            
        }

        private void bunifuGradientPanel2_Click(object sender, EventArgs e)
        {

        }
    }
}
