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
    public partial class Form3 : Form
    {
        SqlConnection baglantı = new SqlConnection("Data Source=DESKTOP-IL5URS6\\SQLEXPRESS;Initial Catalog=ogrenci;Integrated Security=True");
        SqlCommand komut;
        SqlDataAdapter adp;
        DataSet ds = new DataSet();
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            verigoster();
        }
        void verigoster()
        {
            komut = new SqlCommand("select * from Table_1", baglantı);
            adp = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            adp.Fill(ds, "Table_1");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Table_1";
            dataGridView1.Columns[0].HeaderText = "Numara";
            dataGridView1.Columns[1].HeaderText = "Adı";
            dataGridView1.Columns[2].HeaderText = "Soyadı";
            dataGridView1.Columns[3].HeaderText = "Bölüm";
            dataGridView1.Columns[4].HeaderText = "Gano";
            dataGridView1.Columns[5].HeaderText = "Öğrenci Hakkında Not";
            dataGridView1.Columns[5].MinimumWidth = 180;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                baglantı.Open();
                komut = new SqlCommand("insert into Table_1(no,ad,soyad,bolum,ortalama,bilgi) values (@no,@ad,@soyad,@bol,@ort,@bilgi)", baglantı);
                komut.Parameters.AddWithValue("@no", Convert.ToInt32(textBox1.Text));
                komut.Parameters.AddWithValue("@ad", textBox2.Text);
                komut.Parameters.AddWithValue("@soyad", textBox3.Text);
                komut.Parameters.AddWithValue("@bol", textBox4.Text);
                komut.Parameters.AddWithValue("@ort", Convert.ToDouble(textBox5.Text));
                komut.Parameters.AddWithValue("@bilgi", textBox6.Text);
                komut.ExecuteNonQuery();
                baglantı.Close();
                verigoster();
                MessageBox.Show("Öğrenci Başarıyla Kaydedildi");

            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata Var!" + ex.Message, "İşlem Hatası", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                baglantı.Close();
            }
        }
    }
}
