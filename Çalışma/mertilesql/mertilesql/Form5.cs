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
    
    public partial class Form5 : Form
    {
        SqlConnection baglantı = new SqlConnection("Data Source=DESKTOP-IL5URS6\\SQLEXPRESS;Initial Catalog=ogrenci;Integrated Security=True");
        SqlCommand komut;
        SqlDataAdapter adp;

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
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            verigoster();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Close();   
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int satirno = e.RowIndex;
            textBox1.Text = dataGridView1.Rows[satirno].Cells[0].Value.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            komut = new SqlCommand("delete from Table_1 where no=@no", baglantı);
            komut.Parameters.AddWithValue("@no", Convert.ToInt32(textBox1.Text));
            komut.ExecuteNonQuery();
            baglantı.Close();
            verigoster();
            MessageBox.Show(textBox1.Text + "numaralı öğrenciye ait bilgiler silindi");


        }
    }
}
