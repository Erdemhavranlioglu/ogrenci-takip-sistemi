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

namespace mertilesql
{
    public partial class Form4 : Form
    {
        SqlConnection baglantı = new SqlConnection("Data Source=DESKTOP-IL5URS6\\SQLEXPRESS;Initial Catalog=ogrenci;Integrated Security=True");
        SqlCommand komut;
        SqlDataAdapter adp;
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;

            textBox2.Enabled = false;

            textBox3.Enabled = false;

            textBox4.Enabled = false;

            textBox5.Enabled = false;

            textBox6.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            baglantı.Open();
            komut = new SqlCommand("select * from Table_1 where no=@no", baglantı);
            komut.Parameters.AddWithValue("@no", textBox7.Text);
            adp = new SqlDataAdapter(komut);
            adp.Fill(ds, "Table_1");
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                textBox1.DataBindings.Clear();textBox1.DataBindings.Add("text", ds, "Table_1.no");
                textBox2.DataBindings.Clear(); textBox2.DataBindings.Add("text", ds, "Table_1.ad");
                textBox3.DataBindings.Clear(); textBox3.DataBindings.Add("text", ds, "Table_1.soyad");
                textBox4.DataBindings.Clear(); textBox4.DataBindings.Add("text", ds, "Table_1.bolum");
                textBox5.DataBindings.Clear(); textBox5.DataBindings.Add("text", ds, "Table_1.ortalama");
                textBox6.DataBindings.Clear(); textBox6.DataBindings.Add("text", ds, "Table_1.bilgi");
                MessageBox.Show("Aranan Öğrenciye Ait Bilgiler Listelendi");

            }
            else
            {
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                MessageBox.Show("bu öğrenci Numarası sahip bir öğrenci kayıtlı değil");
            }
            baglantı.Close();

        }
    }
}
