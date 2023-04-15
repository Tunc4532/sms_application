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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        SqlConnection baglntı = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=smsapp;Integrated Security=True"); 

        public string numaara;

        //void gelenkutusu()
        //{
        //    SqlDataAdapter dts = new SqlDataAdapter("select * from tbl_mesajlar where ALICI=" + numaara, baglntı);
        //    DataTable dt1 = new DataTable();
        //    dts.Fill(dt1);
        //    bunifuDataGridView3.DataSource = dts;
        //}
        //void gidenkutusu()
        //{
        //    SqlDataAdapter dtfe = new SqlDataAdapter("select * from tbl_mesajlar where GONDEREN=" + numaara, baglntı);
        //    DataTable dt2 = new DataTable();
        //    dtfe.Fill(dt2);
        //    bunifuDataGridView4.DataSource = dtfe;
        //}

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            lblno.Text = numaara;
            Form1 der = new Form1();
            der.Show();
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'smsappDataSet.tbl_mesajlar' table. You can move, or remove it, as needed.
            this.tbl_mesajlarTableAdapter.Fill(this.smsappDataSet.tbl_mesajlar);
            //gelenkutusu();
            //gidenkutusu();
        }

        //sms göndderme işlemi 
        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            
            DialogResult onay;
            onay=MessageBox.Show("Mesajınız Gönderilsin mi ?","Bilgi",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(onay == DialogResult.Yes)
            {
                baglntı.Open();
                SqlCommand komut6 = new SqlCommand("insert into tbl_mesajlar (GONDEREN,ALICI,BASLIK,ICERIK) values (@e1,@E2,@e3,@e4) ", baglntı);
                komut6.Parameters.AddWithValue("@e1", bunifuTextBox3.Text);
                komut6.Parameters.AddWithValue("@E2", bunifuTextBox2.Text);
                komut6.Parameters.AddWithValue("@e3", bunifuTextBox1.Text);
                komut6.Parameters.AddWithValue("@e4", richTextBox1.Text);
                komut6.ExecuteNonQuery();
                baglntı.Close();
            }
            else
            {
                MessageBox.Show("sms işleminiz iptal edilmiştir","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Question);
            }

        }
    }
}
