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
    public partial class Form6 : Form
    {
        SqlConnection baglantı = new SqlConnection("Data Source=DESKTOP-IL5URS6\\SQLEXPRESS;Initial Catalog=ogrenci;Integrated Security=True");
        SqlCommand komut;
        SqlDataAdapter adp;

        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
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
                textBox1.DataBindings.Clear(); textBox1.DataBindings.Add("text", ds, "Table_1.no");
                textBox2.DataBindings.Clear(); textBox2.DataBindings.Add("text", ds, "Table_1.ad");
                textBox3.DataBindings.Clear(); textBox3.DataBindings.Add("text", ds, "Table_1.soyad");
                textBox4.DataBindings.Clear(); textBox4.DataBindings.Add("text", ds, "Table_1.bolum");
                textBox5.DataBindings.Clear(); textBox5.DataBindings.Add("text", ds, "Table_1.ortalama");
                textBox6.DataBindings.Clear(); textBox6.DataBindings.Add("text", ds, "Table_1.bilgi");
                MessageBox.Show("Aranan Öğrenciye Ait Bilgiler Listelendi");
                textBox1.Enabled = false;

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

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            komut = new SqlCommand("update Table_1 set ad=@ad,soyad=@soyad," + "bolum=@bol,ortalama=@ort,bilgi=@bilgi where no=@no", baglantı);
            komut.Parameters.AddWithValue("@no", Convert.ToInt32(textBox1.Text));
            komut.Parameters.AddWithValue("@ad", textBox2.Text);
            komut.Parameters.AddWithValue("@soyad", textBox3.Text);
            komut.Parameters.AddWithValue("@bol", textBox4.Text);
            komut.Parameters.AddWithValue("@ort", Convert.ToDouble(textBox5.Text));
            komut.Parameters.AddWithValue("@bilgi", textBox6.Text);
            komut.ExecuteNonQuery();
            baglantı.Close();
            
            MessageBox.Show(textBox1.Text+"numaralı öğrenciye ait bilgiler güncellendi");    
        }
    }
}
