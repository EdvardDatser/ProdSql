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
        SqlConnection connect = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProductsDatabase;Integrated Security=True");

        
        SqlDataAdapter adapter_products, adapter_kategooria;
        SqlCommand command;

        private void Lisabtn_Click(object sender, EventArgs e)
        {
            bool on = false;
            foreach(var item in KategooriaBox.Items)
            {
                if (item.ToString()==KategooriaBox.Text)
                {
                    on = true;
                }
            }
            if (on==false)
            {
                connect.Open();
                command = new SqlCommand("INSERT INTO KategooriaTable (Kategooria_name) VALUES (@Kat) ", connect);
                command.Parameters.AddWithValue("@Kat", KategooriaBox.Text);
                KategooriaBox.Items.Clear();
                command.ExecuteNonQuery();
                connect.Close();
                Kategooriad();
            }
            else
            {
                MessageBox.Show("Selline kategooriat on juba olemas!");
            }
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
            KategooriaBox.Items.Clear();
            KategooriaBox.Text = "";
            connect.Open();

            adapter_kategooria = new SqlDataAdapter("SELECT Id,Kategooria_name FROM KategooriaTable", connect);
            DataTable dt_kategooria = new DataTable();
            adapter_kategooria.Fill(dt_kategooria);
            foreach (DataRow item in dt_kategooria.Rows)
            {
                if (!KategooriaBox.Items.Contains(item["Kategooria_name"]))
                {
                    KategooriaBox.Items.Add(item["Kategooria_name"]);
                }
                else
                {
                    command = new SqlCommand("DELETE FROM KateegoriaTable WHERE Id=@id", connect);
                    command.Parameters.AddWithValue("@id", item["Id"]);
                    command.ExecuteNonQuery();
                }
            }
            connect.Close();

        }
        private void KategooriaBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void KustutaKat_Click(object sender, EventArgs e)
        {
            if (KategooriaBox.SelectedItem !=null)
            {
                string val_kat = KategooriaBox.SelectedItem.ToString();

                connect.Open();
                SqlCommand command = new SqlCommand("DELETE FROM KategooriaTable WHERE Kategooria_name = @kat", connect);
                command.Parameters.AddWithValue("@kat", val_kat);
                command.ExecuteNonQuery();
                connect.Close();
                KategooriaBox.Items.Clear();
                Kategooriad();
            }
        }

        int Id = 0;

        private void addAllbtn_Click(object sender, EventArgs e)
        {
            if (ToodeBox.Text.Trim()!=string.Empty && KogusBox.Text.Trim()!=string.Empty && HindBox.Text.Trim()!=string.Empty && KategooriaBox.SelectedItem!=null)
            {
                try
                {
                    connect.Open();

                    command = new SqlCommand("SELECT Id FROM KategooriaTable WHERE Kategooria_name=@kat", connect);
                    command.Parameters.AddWithValue("@kat", KategooriaBox.Text);
                    command.ExecuteNonQuery();
                    Id = Convert.ToInt32(command.ExecuteScalar());

                    command = new SqlCommand("INSERT INTO Products(ProductName,Quanty,Price,Image,Kategooriad) VALUES(@ProdName,@Kolvo,@Pprice,@Pimage,@Kat)", connect);
                    command.Parameters.AddWithValue("@ProdName", ToodeBox.Text);
                    command.Parameters.AddWithValue("@Kolvo", KogusBox.Text);
                    command.Parameters.AddWithValue("@Pprice", HindBox.Text);
                    command.Parameters.AddWithValue("@Pimage", ToodeBox.Text+".jpg");
                    command.Parameters.AddWithValue("@Kat", Id);
                    command.ExecuteNonQuery();

                    connect.Close();

                    Andmed();
                }
                catch (Exception)
                {

                    MessageBox.Show("Andmebaasiga viga!");
                }
            }
        }

        public void Andmed()
        {
            connect.Open();

            DataTable dt_products = new DataTable();
            DataTable table = new DataTable();
            adapter_products = new SqlDataAdapter("SELECT p.Id, p.ProductName, p.Quanty,p.Price, p.Image, k.Kategooria_name FROM Products as p INNER JOIN KategooriaTable as k on p.Kategooriad=k.Id;", connect);
            adapter_products.Fill(dt_products);
            dgv.DataSource = dt_products;
            table.Columns.Add("Nimetus");
            table.Columns.Add("Kogus");
            table.Columns.Add("Hind");
            table.Columns.Add("Pilt");
            DataGridViewComboBoxColumn dgvcb = new DataGridViewComboBoxColumn();
            foreach (DataRow item in dt_products.Rows)
            {
                if (!dgvcb.Items.Contains(item["Kategooria_name"]))
                {
                    dgvcb.Items.Add(item["Kategooria_name"]);
                }
            }
            foreach (DataRow item in dt_products.Rows)
            {
                table.Rows.Add(item["ProductName"], item["Quanty"], item["Price"], item["Image"]);
            }
            dgv.DataSource = table;
            dgv.Columns.Add(dgvcb);
            connect.Close();

        }
    }
}
