using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
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
            if (dgv.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgv.SelectedRows[0];
                int selectedRowID = Convert.ToInt32(selectedRow.Cells["Id"].Value);

                try
                {
                    if (connect.State == ConnectionState.Closed)
                    {
                        connect.Open();
                    }
                    string deleteQuery = "DELETE FROM Products WHERE Id = @id";
                    command = new SqlCommand(deleteQuery, connect);
                    command.Parameters.AddWithValue("@id", selectedRowID);
                    command.ExecuteNonQuery();
                    connect.Close();

                    dgv.Rows.Remove(selectedRow);
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Probleem tekkis kustutamisel: " + ex.Message);
                }
                finally
                {
                    if (connect.State == ConnectionState.Open)
                    {
                        connect.Close();
                    }
                }
            }

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
                    string file_pilt = ToodeBox.Text + extension;
                    command.Parameters.AddWithValue("@Pimage", file_pilt);
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

        string Kat;
        SaveFileDialog save;
        OpenFileDialog open;
        string extension = null;

        private void imagebtn_Click(object sender, EventArgs e)
        {
            open = new OpenFileDialog();
            open.InitialDirectory = @"C:\\Users\\opilane\\Pictures";
            open.Multiselect = true;
            open.Filter = "Images Files(*.jpeg, *.bmp, *.png, *.jpg)|*.jpeg; *.bmp; *.png; *.jpg";
            open.ShowDialog();

            //FileInfo open_info = new FileInfo(@"C:\Users\opilane\Pictures\"+open.FileName);
            if (open.ShowDialog() == DialogResult.OK && ToodeBox.Text != null)
            {
                save = new SaveFileDialog();
                save.InitialDirectory = Path.GetFullPath(@"..\..\Images");
                extension = Path.GetExtension(open.FileName);
                save.FileName = ToodeBox.Text + Path.GetExtension(open.FileName);//extension
                save.Filter = "Images" + Path.GetExtension(open.FileName) + "|" + Path.GetExtension(open.FileName);
                if (save.ShowDialog() == DialogResult.OK)
                {
                    File.Copy(open.FileName, save.FileName);
                    PictureBox.Image = Image.FromFile(save.FileName);
                }
            }
            else
            {
                MessageBox.Show("Viga");
            }

        }



        private void dgv_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ToodeBox.Text = dgv.Rows[e.RowIndex].Cells["ProductName"].Value.ToString();
            KogusBox.Text = dgv.Rows[e.RowIndex].Cells["Quanty"].Value.ToString();
            HindBox.Text = dgv.Rows[e.RowIndex].Cells["Price"].Value.ToString();
            KategooriaBox.Text = dgv.Rows[e.RowIndex].Cells["Image"].Value.ToString();
            if (dgv.SelectedRows.Count > 0)
            {
                string ImageName = dgv.SelectedRows[0].Cells["Image"].Value.ToString();
                string ImagePath = Path.Combine(Path.GetFullPath(@"..\..\..\..\..\Pictures"), ImageName);
                if (File.Exists(ImagePath))
                {
                    Image img = Image.FromFile(ImagePath);

                    PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    PictureBox.ClientSize = new Size(150, 150);
                    PictureBox.Image = (Image)(new Bitmap(img, PictureBox.ClientSize));
                }
                else
                {
                    MessageBox.Show($"Pilt '{ImageName}' ei ole leitud",$"Путь до картинки '{ImagePath}'");
                }
            }
            else
            {
                PictureBox.Image = null;
            }
        }

        public void Andmed()
        {
            connect.Open();

            DataTable dt_products = new DataTable();
            adapter_products = new SqlDataAdapter("SELECT p.Id, p.ProductName, p.Quanty,p.Price, p.Image, k.Kategooria_name FROM Products as p INNER JOIN KategooriaTable as k on p.Kategooriad=k.Id;", connect);
            adapter_products.Fill(dt_products);
            dgv.Columns.Clear();
            dgv.DataSource = dt_products;
            DataGridViewComboBoxColumn dgvcb = new DataGridViewComboBoxColumn();
            //table.Columns.Add("Nimetus");
            //table.Columns.Add("Kogus");
            //table.Columns.Add("Hind");
            //table.Columns.Add("Pilt");
            //DataGridViewComboBoxColumn dgvcb = new DataGridViewComboBoxColumn();
            dgvcb.HeaderText= "Kategooria";
            dgvcb.Name = "KategooriaColumn";
            dgvcb.DataPropertyName= "Kategooria";
            HashSet<string> uncat = new HashSet<string>();
            foreach (DataRow dr in dt_products.Rows)
            {
                string category = dr["Kategooria_name"].ToString();
                if (!uncat.Contains(category))
                {
                    uncat.Add(category);
                    dgvcb.Items.Add(category);
                }
            }
            dgv.Columns.Add(dgvcb);
            dgv.Columns["Kategooria_name"].Visible = false;
            //foreach (DataRow item in dt_products.Rows)
            //{
            //    if (!dgvcb.Items.Contains(item["Kategooria_name"]))
            //    {
            //        dgvcb.Items.Add(item["Kategooria_name"]);
            //    }
            //}
            //foreach (DataRow item in dt_products.Rows)
            //{
            //    table.Rows.Add(item["ProductName"], item["Quanty"], item["Price"], item["Image"]);
            //}
            //dgv.DataSource = table;
            //dgv.Columns.Add(dgvcb);
            connect.Close();
        }
    }
}
