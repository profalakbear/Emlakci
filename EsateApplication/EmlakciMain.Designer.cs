namespace EsateApplication
{
    partial class EmlakciMain
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.emlakMainName = new System.Windows.Forms.Label();
            this.emlakMainSurname = new System.Windows.Forms.Label();
            this.emlakMainAddress = new System.Windows.Forms.Label();
            this.emlakMainPhone = new System.Windows.Forms.Label();
            this.emlakMainFax = new System.Windows.Forms.Label();
            this.emlakMainEmail = new System.Windows.Forms.Label();
            this.emlakMainBusinessname = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.emlakciMainGrid = new System.Windows.Forms.DataGridView();
            this.emlakciMainResimGrid = new System.Windows.Forms.DataGridViewImageColumn();
            this.emlakMainIDGrid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emlakciMainSehirGrid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emlakciMainFiyatGrid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emlakciMainDetayGrid = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.emlakciMainGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Emlakci bilgileri";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(86, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Yetkili kisi adi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(86, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Yetkili kisi soyadi";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(86, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Adresi";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(553, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Telefonu";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(553, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Fax";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(553, 198);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "E-posta";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(850, 105);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 16);
            this.label8.TabIndex = 7;
            this.label8.Text = "Isletme adi";
            // 
            // emlakMainName
            // 
            this.emlakMainName.AutoSize = true;
            this.emlakMainName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.emlakMainName.Location = new System.Drawing.Point(244, 105);
            this.emlakMainName.Name = "emlakMainName";
            this.emlakMainName.Size = new System.Drawing.Size(88, 16);
            this.emlakMainName.TabIndex = 8;
            this.emlakMainName.Text = "Yetkili kisi adi";
            // 
            // emlakMainSurname
            // 
            this.emlakMainSurname.AutoSize = true;
            this.emlakMainSurname.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.emlakMainSurname.Location = new System.Drawing.Point(244, 157);
            this.emlakMainSurname.Name = "emlakMainSurname";
            this.emlakMainSurname.Size = new System.Drawing.Size(110, 16);
            this.emlakMainSurname.TabIndex = 9;
            this.emlakMainSurname.Text = "Yetkili kisi soyadi";
            // 
            // emlakMainAddress
            // 
            this.emlakMainAddress.AutoSize = true;
            this.emlakMainAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.emlakMainAddress.Location = new System.Drawing.Point(244, 198);
            this.emlakMainAddress.Name = "emlakMainAddress";
            this.emlakMainAddress.Size = new System.Drawing.Size(107, 16);
            this.emlakMainAddress.TabIndex = 10;
            this.emlakMainAddress.Text = "Yetkili kisi adresi";
            // 
            // emlakMainPhone
            // 
            this.emlakMainPhone.AutoSize = true;
            this.emlakMainPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.emlakMainPhone.Location = new System.Drawing.Point(658, 105);
            this.emlakMainPhone.Name = "emlakMainPhone";
            this.emlakMainPhone.Size = new System.Drawing.Size(116, 16);
            this.emlakMainPhone.TabIndex = 11;
            this.emlakMainPhone.Text = "Yetkili kisi telefonu";
            // 
            // emlakMainFax
            // 
            this.emlakMainFax.AutoSize = true;
            this.emlakMainFax.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.emlakMainFax.Location = new System.Drawing.Point(658, 157);
            this.emlakMainFax.Name = "emlakMainFax";
            this.emlakMainFax.Size = new System.Drawing.Size(86, 16);
            this.emlakMainFax.TabIndex = 12;
            this.emlakMainFax.Text = "Yetkili kisi fax";
            // 
            // emlakMainEmail
            // 
            this.emlakMainEmail.AutoSize = true;
            this.emlakMainEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.emlakMainEmail.Location = new System.Drawing.Point(658, 198);
            this.emlakMainEmail.Name = "emlakMainEmail";
            this.emlakMainEmail.Size = new System.Drawing.Size(115, 16);
            this.emlakMainEmail.TabIndex = 13;
            this.emlakMainEmail.Text = "Yetkili kisi e-posta";
            // 
            // emlakMainBusinessname
            // 
            this.emlakMainBusinessname.AutoSize = true;
            this.emlakMainBusinessname.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.emlakMainBusinessname.Location = new System.Drawing.Point(987, 105);
            this.emlakMainBusinessname.Name = "emlakMainBusinessname";
            this.emlakMainBusinessname.Size = new System.Drawing.Size(72, 16);
            this.emlakMainBusinessname.TabIndex = 14;
            this.emlakMainBusinessname.Text = "Isletme adi";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1218, 105);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 135);
            this.button1.TabIndex = 15;
            this.button1.Text = "Yeni ilan yayinla";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // emlakciMainGrid
            // 
            this.emlakciMainGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.emlakciMainGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.emlakciMainResimGrid,
            this.emlakMainIDGrid,
            this.emlakciMainSehirGrid,
            this.emlakciMainFiyatGrid,
            this.emlakciMainDetayGrid});
            this.emlakciMainGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.emlakciMainGrid.Location = new System.Drawing.Point(0, 369);
            this.emlakciMainGrid.Name = "emlakciMainGrid";
            this.emlakciMainGrid.RowHeadersWidth = 51;
            this.emlakciMainGrid.RowTemplate.Height = 100;
            this.emlakciMainGrid.Size = new System.Drawing.Size(1621, 477);
            this.emlakciMainGrid.TabIndex = 16;
            this.emlakciMainGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // emlakciMainResimGrid
            // 
            this.emlakciMainResimGrid.HeaderText = "";
            this.emlakciMainResimGrid.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.emlakciMainResimGrid.MinimumWidth = 320;
            this.emlakciMainResimGrid.Name = "emlakciMainResimGrid";
            this.emlakciMainResimGrid.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.emlakciMainResimGrid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.emlakciMainResimGrid.Width = 325;
            // 
            // emlakMainIDGrid
            // 
            this.emlakMainIDGrid.HeaderText = "ID";
            this.emlakMainIDGrid.MinimumWidth = 6;
            this.emlakMainIDGrid.Name = "emlakMainIDGrid";
            this.emlakMainIDGrid.Width = 125;
            // 
            // emlakciMainSehirGrid
            // 
            this.emlakciMainSehirGrid.HeaderText = "Sehir";
            this.emlakciMainSehirGrid.MinimumWidth = 320;
            this.emlakciMainSehirGrid.Name = "emlakciMainSehirGrid";
            this.emlakciMainSehirGrid.Width = 325;
            // 
            // emlakciMainFiyatGrid
            // 
            this.emlakciMainFiyatGrid.HeaderText = "Fiyat";
            this.emlakciMainFiyatGrid.MinimumWidth = 320;
            this.emlakciMainFiyatGrid.Name = "emlakciMainFiyatGrid";
            this.emlakciMainFiyatGrid.Width = 325;
            // 
            // emlakciMainDetayGrid
            // 
            this.emlakciMainDetayGrid.HeaderText = "Detay";
            this.emlakciMainDetayGrid.MinimumWidth = 320;
            this.emlakciMainDetayGrid.Name = "emlakciMainDetayGrid";
            this.emlakciMainDetayGrid.Text = "Detaya Git";
            this.emlakciMainDetayGrid.Width = 325;
            // 
            // EmlakciMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1621, 846);
            this.Controls.Add(this.emlakciMainGrid);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.emlakMainBusinessname);
            this.Controls.Add(this.emlakMainEmail);
            this.Controls.Add(this.emlakMainFax);
            this.Controls.Add(this.emlakMainPhone);
            this.Controls.Add(this.emlakMainAddress);
            this.Controls.Add(this.emlakMainSurname);
            this.Controls.Add(this.emlakMainName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EmlakciMain";
            this.Text = "EmlakciMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.emlakciMainGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label emlakMainName;
        private System.Windows.Forms.Label emlakMainSurname;
        private System.Windows.Forms.Label emlakMainAddress;
        private System.Windows.Forms.Label emlakMainPhone;
        private System.Windows.Forms.Label emlakMainFax;
        private System.Windows.Forms.Label emlakMainEmail;
        private System.Windows.Forms.Label emlakMainBusinessname;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView emlakciMainGrid;
        private System.Windows.Forms.DataGridViewImageColumn emlakciMainResimGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn emlakMainIDGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn emlakciMainSehirGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn emlakciMainFiyatGrid;
        private System.Windows.Forms.DataGridViewButtonColumn emlakciMainDetayGrid;
    }
}