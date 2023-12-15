using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;

namespace ProdSql
{
    public partial class UserForm : Form
    {
        private Button button1;
        private Label FindKat;
        private ComboBox FindByKatcb;
        SqlConnection connect = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProductsDatabase;Integrated Security=True");

        SqlDataAdapter adapter_kategooria, adapter_FindByKat, adapter_products;
        private DataGridView dgv_user;
        SqlCommand command;

        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.FindKat = new System.Windows.Forms.Label();
            this.FindByKatcb = new System.Windows.Forms.ComboBox();
            this.dgv_user = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_user)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(208, 81);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(47, 28);
            this.button1.TabIndex = 0;
            this.button1.Text = "Find";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FindKat
            // 
            this.FindKat.AutoSize = true;
            this.FindKat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.FindKat.Location = new System.Drawing.Point(12, 48);
            this.FindKat.Name = "FindKat";
            this.FindKat.Size = new System.Drawing.Size(190, 20);
            this.FindKat.TabIndex = 1;
            this.FindKat.Text = "Otsing kategooria järgi";
            this.FindKat.Click += new System.EventHandler(this.label1_Click);
            // 
            // FindByKatcb
            // 
            this.FindByKatcb.BackColor = System.Drawing.Color.Gray;
            this.FindByKatcb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.FindByKatcb.FormattingEnabled = true;
            this.FindByKatcb.Location = new System.Drawing.Point(16, 81);
            this.FindByKatcb.Name = "FindByKatcb";
            this.FindByKatcb.Size = new System.Drawing.Size(186, 28);
            this.FindByKatcb.TabIndex = 2;
            this.FindByKatcb.Text = "Otsi...";
            this.FindByKatcb.SelectedIndexChanged += new System.EventHandler(this.FindByKatcb_SelectedIndexChanged);
            // 
            // dgv_user
            // 
            this.dgv_user.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_user.Location = new System.Drawing.Point(16, 262);
            this.dgv_user.Name = "dgv_user";
            this.dgv_user.Size = new System.Drawing.Size(556, 302);
            this.dgv_user.TabIndex = 3;
            this.dgv_user.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // UserForm
            // 
            this.ClientSize = new System.Drawing.Size(1261, 576);
            this.Controls.Add(this.dgv_user);
            this.Controls.Add(this.FindByKatcb);
            this.Controls.Add(this.FindKat);
            this.Controls.Add(this.button1);
            this.Name = "UserForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_user)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        public UserForm()
        {
            InitializeComponent();
            Kategooriad();
            Andmed();
        }


        public void Kategooriad()
        {
            FindByKatcb.Items.Clear();
            FindByKatcb.Text = "";
            connect.Open();

            adapter_kategooria = new SqlDataAdapter("SELECT Id,Kategooria_name FROM KategooriaTable", connect);
            DataTable dt_kategooria = new DataTable();
            adapter_kategooria.Fill(dt_kategooria);
            foreach (DataRow item in dt_kategooria.Rows)
            {
                if (!FindByKatcb.Items.Contains(item["Kategooria_name"]))
                {
                    FindByKatcb.Items.Add(item["Kategooria_name"]);
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
        public void Find_By_Kat()
        {
            connect.Open();

            string katId = "SELECT Id FROM KategooriaTable";
            string sqlQuery = "SELECT ProductName, Price, Image FROM Products WHERE Id = @Kat_Id";

            using (SqlCommand command = new SqlCommand(sqlQuery, connect))
            {
                // Add parameters to the SqlCommand to prevent SQL injection
                command.Parameters.AddWithValue("@Kat_Id", katId);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Retrieve product information from the reader
                        string productName = reader["ProductName"].ToString();
                        decimal price = Convert.ToDecimal(reader["Price"]);
                        string image = reader["Image"].ToString();

                        // Do something with the retrieved data (e.g., display it, process it, etc.)
                        Console.WriteLine($"Product: {productName}, Price: {price}, Image: {image}");
                    }
                }
            }
            connect.Close();
        }
        public void Andmed()
        {
            connect.Open();

            DataTable dt_products = new DataTable();
            adapter_products = new SqlDataAdapter("SELECT ProductName, Price, Image FROM Products", connect);
            adapter_products.Fill(dt_products);
            dgv_user.Columns.Clear();
            dgv_user.DataSource = dt_products;
            DataGridViewComboBoxColumn dgvcb = new DataGridViewComboBoxColumn();
            dgvcb.HeaderText = "Name";
            dgvcb.Name = "Price";
            dgvcb.DataPropertyName = "Image";
            connect.Close();
        }




        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Find_By_Kat();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FindByKatcb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
