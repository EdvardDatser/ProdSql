namespace ProdSql
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgv = new System.Windows.Forms.DataGridView();
            this.KategooriaBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.HindBox = new System.Windows.Forms.ComboBox();
            this.KogusBox = new System.Windows.Forms.ComboBox();
            this.ToodeBox = new System.Windows.Forms.ComboBox();
            this.Lisabtn = new System.Windows.Forms.Button();
            this.addAllbtn = new System.Windows.Forms.Button();
            this.refresh = new System.Windows.Forms.Button();
            this.Kustuta = new System.Windows.Forms.Button();
            this.KustutaKat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(71, 221);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(639, 164);
            this.dgv.TabIndex = 0;
            // 
            // KategooriaBox
            // 
            this.KategooriaBox.FormattingEnabled = true;
            this.KategooriaBox.Location = new System.Drawing.Point(178, 151);
            this.KategooriaBox.Name = "KategooriaBox";
            this.KategooriaBox.Size = new System.Drawing.Size(160, 21);
            this.KategooriaBox.TabIndex = 1;
            this.KategooriaBox.SelectedIndexChanged += new System.EventHandler(this.KategooriaBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(67, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Kategooriad:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(117, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "Hind:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(104, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "Kogus:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(104, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 21);
            this.label4.TabIndex = 6;
            this.label4.Text = "Toode:";
            // 
            // HindBox
            // 
            this.HindBox.FormattingEnabled = true;
            this.HindBox.Location = new System.Drawing.Point(178, 108);
            this.HindBox.Name = "HindBox";
            this.HindBox.Size = new System.Drawing.Size(160, 21);
            this.HindBox.TabIndex = 7;
            // 
            // KogusBox
            // 
            this.KogusBox.FormattingEnabled = true;
            this.KogusBox.Location = new System.Drawing.Point(178, 67);
            this.KogusBox.Name = "KogusBox";
            this.KogusBox.Size = new System.Drawing.Size(160, 21);
            this.KogusBox.TabIndex = 8;
            // 
            // ToodeBox
            // 
            this.ToodeBox.FormattingEnabled = true;
            this.ToodeBox.Location = new System.Drawing.Point(178, 25);
            this.ToodeBox.Name = "ToodeBox";
            this.ToodeBox.Size = new System.Drawing.Size(160, 21);
            this.ToodeBox.TabIndex = 9;
            // 
            // Lisabtn
            // 
            this.Lisabtn.Location = new System.Drawing.Point(344, 151);
            this.Lisabtn.Name = "Lisabtn";
            this.Lisabtn.Size = new System.Drawing.Size(101, 23);
            this.Lisabtn.TabIndex = 10;
            this.Lisabtn.Text = "Lisa kategooriad";
            this.Lisabtn.UseVisualStyleBackColor = true;
            this.Lisabtn.Click += new System.EventHandler(this.Lisabtn_Click);
            // 
            // addAllbtn
            // 
            this.addAllbtn.Location = new System.Drawing.Point(71, 194);
            this.addAllbtn.Name = "addAllbtn";
            this.addAllbtn.Size = new System.Drawing.Size(101, 23);
            this.addAllbtn.TabIndex = 12;
            this.addAllbtn.Text = "Lisa";
            this.addAllbtn.UseVisualStyleBackColor = true;
            this.addAllbtn.Click += new System.EventHandler(this.addAllbtn_Click);
            // 
            // refresh
            // 
            this.refresh.Location = new System.Drawing.Point(178, 194);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(101, 23);
            this.refresh.TabIndex = 13;
            this.refresh.Text = "Uuenda";
            this.refresh.UseVisualStyleBackColor = true;
            // 
            // Kustuta
            // 
            this.Kustuta.Location = new System.Drawing.Point(285, 194);
            this.Kustuta.Name = "Kustuta";
            this.Kustuta.Size = new System.Drawing.Size(101, 23);
            this.Kustuta.TabIndex = 14;
            this.Kustuta.Text = "Kustuta";
            this.Kustuta.UseVisualStyleBackColor = true;
            this.Kustuta.Click += new System.EventHandler(this.button3_Click);
            // 
            // KustutaKat
            // 
            this.KustutaKat.Location = new System.Drawing.Point(451, 151);
            this.KustutaKat.Name = "KustutaKat";
            this.KustutaKat.Size = new System.Drawing.Size(105, 23);
            this.KustutaKat.TabIndex = 15;
            this.KustutaKat.Text = "Kustuta Kategooria";
            this.KustutaKat.UseVisualStyleBackColor = true;
            this.KustutaKat.Click += new System.EventHandler(this.KustutaKat_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 412);
            this.Controls.Add(this.KustutaKat);
            this.Controls.Add(this.Kustuta);
            this.Controls.Add(this.refresh);
            this.Controls.Add(this.addAllbtn);
            this.Controls.Add(this.Lisabtn);
            this.Controls.Add(this.ToodeBox);
            this.Controls.Add(this.KogusBox);
            this.Controls.Add(this.HindBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.KategooriaBox);
            this.Controls.Add(this.dgv);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.ComboBox KategooriaBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox HindBox;
        private System.Windows.Forms.ComboBox KogusBox;
        private System.Windows.Forms.ComboBox ToodeBox;
        private System.Windows.Forms.Button Lisabtn;
        private System.Windows.Forms.Button addAllbtn;
        private System.Windows.Forms.Button refresh;
        private System.Windows.Forms.Button Kustuta;
        private System.Windows.Forms.Button KustutaKat;
    }
}

