using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProdSql
{
    public partial class Form1 : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=
        |DataDirectory|\AppData\ProdDB.mdf;Integrated Security=True");

        
        SqlDataAdapter adapter_products, adapter_kategooria;
        SqlCommand command;
        private void Lisabtn_Click(object sender, EventArgs e)
        {
            connect.Open();
            command = new SqlCommand("INSERT INTO KategooriaTable (Kategooria_name) VALUES (@Kat) ", connect);
            command.Parameters.AddWithValue("@Kat", KategooriaBox.Text);
            KategooriaBox.Items.Clear();
            command.ExecuteNonQuery();
            connect.Close();
            Kategooriad();
        }

        public Form1()
        {
            InitializeComponent();
            Andmed();
            Kategooriad();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void Kategooriad() 
        {
            connect.Open();

            adapter_kategooria = new SqlDataAdapter("SELECT Kategooria_name FROM KategooriaTable", connect);
            DataTable dt_kategooria = new DataTable();
            adapter_kategooria.Fill(dt_kategooria);
            foreach (DataRow item in dt_kategooria.Rows)
            {
                KategooriaBox.Items.Add(item["Kategooria_name"]);
            }
            connect.Close();

        }
        private void KategooriaBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public void Andmed()
        {
            connect.Open();

            DataTable dt_products = new DataTable();
            adapter_products = new SqlDataAdapter("SELECT * FROM Products", connect);
            adapter_products.Fill(dt_products);
            dataGridView1.DataSource = dt_products;

            connect.Close();

        }
    }
}
