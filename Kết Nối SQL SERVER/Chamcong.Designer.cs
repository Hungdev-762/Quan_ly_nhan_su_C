namespace Kết_Nối_SQL_SERVER
{
    partial class Chamcong
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
            this.txtID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtsolan = new System.Windows.Forms.TextBox();
            this.cbht = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbdl = new System.Windows.Forms.ComboBox();
            this.dtNgaycc = new System.Windows.Forms.DateTimePicker();
            this.datasql = new System.Windows.Forms.DataGridView();
            this.btnthem = new System.Windows.Forms.Button();
            this.btnluu = new System.Windows.Forms.Button();
            this.btnsua = new System.Windows.Forms.Button();
            this.btnhuy = new System.Windows.Forms.Button();
            this.btnxoa = new System.Windows.Forms.Button();
            this.btnthoat = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btntim = new System.Windows.Forms.Button();
            this.cobodl = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.datasql)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(127, 115);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(121, 22);
            this.txtID.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(291, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Họ Tên";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(294, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Số Lần";
            // 
            // txtsolan
            // 
            this.txtsolan.Location = new System.Drawing.Point(349, 112);
            this.txtsolan.Name = "txtsolan";
            this.txtsolan.Size = new System.Drawing.Size(121, 22);
            this.txtsolan.TabIndex = 1;
            // 
            // cbht
            // 
            this.cbht.FormattingEnabled = true;
            this.cbht.Location = new System.Drawing.Point(349, 154);
            this.cbht.Name = "cbht";
            this.cbht.Size = new System.Drawing.Size(330, 24);
            this.cbht.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(503, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Họ Tên";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(72, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Đi Làm";
            // 
            // cbdl
            // 
            this.cbdl.FormattingEnabled = true;
            this.cbdl.Items.AddRange(new object[] {
            "ít",
            "nhiều"});
            this.cbdl.Location = new System.Drawing.Point(127, 154);
            this.cbdl.Name = "cbdl";
            this.cbdl.Size = new System.Drawing.Size(121, 24);
            this.cbdl.TabIndex = 2;
            // 
            // dtNgaycc
            // 
            this.dtNgaycc.CustomFormat = "dd/MM/yyyy";
            this.dtNgaycc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtNgaycc.Location = new System.Drawing.Point(561, 113);
            this.dtNgaycc.Name = "dtNgaycc";
            this.dtNgaycc.Size = new System.Drawing.Size(118, 22);
            this.dtNgaycc.TabIndex = 3;
            // 
            // datasql
            // 
            this.datasql.AllowUserToAddRows = false;
            this.datasql.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datasql.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datasql.Location = new System.Drawing.Point(29, 233);
            this.datasql.Name = "datasql";
            this.datasql.RowHeadersWidth = 51;
            this.datasql.RowTemplate.Height = 24;
            this.datasql.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datasql.Size = new System.Drawing.Size(918, 183);
            this.datasql.TabIndex = 4;
            this.datasql.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.datasql_CellEnter);
            // 
            // btnthem
            // 
            this.btnthem.Location = new System.Drawing.Point(730, 94);
            this.btnthem.Name = "btnthem";
            this.btnthem.Size = new System.Drawing.Size(75, 23);
            this.btnthem.TabIndex = 5;
            this.btnthem.Text = "Thêm";
            this.btnthem.UseVisualStyleBackColor = true;
            this.btnthem.Click += new System.EventHandler(this.btnthem_Click);
            // 
            // btnluu
            // 
            this.btnluu.Location = new System.Drawing.Point(811, 94);
            this.btnluu.Name = "btnluu";
            this.btnluu.Size = new System.Drawing.Size(75, 23);
            this.btnluu.TabIndex = 5;
            this.btnluu.Text = "Lưu";
            this.btnluu.UseVisualStyleBackColor = true;
            this.btnluu.Click += new System.EventHandler(this.btnluu_Click);
            // 
            // btnsua
            // 
            this.btnsua.Location = new System.Drawing.Point(730, 123);
            this.btnsua.Name = "btnsua";
            this.btnsua.Size = new System.Drawing.Size(75, 23);
            this.btnsua.TabIndex = 5;
            this.btnsua.Text = "Sửa";
            this.btnsua.UseVisualStyleBackColor = true;
            this.btnsua.Click += new System.EventHandler(this.btnsua_Click);
            // 
            // btnhuy
            // 
            this.btnhuy.Location = new System.Drawing.Point(811, 123);
            this.btnhuy.Name = "btnhuy";
            this.btnhuy.Size = new System.Drawing.Size(75, 23);
            this.btnhuy.TabIndex = 5;
            this.btnhuy.Text = "Hủy";
            this.btnhuy.UseVisualStyleBackColor = true;
            this.btnhuy.Click += new System.EventHandler(this.btnhuy_Click);
            // 
            // btnxoa
            // 
            this.btnxoa.Location = new System.Drawing.Point(730, 152);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(75, 23);
            this.btnxoa.TabIndex = 5;
            this.btnxoa.Text = "Xóa";
            this.btnxoa.UseVisualStyleBackColor = true;
            this.btnxoa.Click += new System.EventHandler(this.btnxoa_Click);
            // 
            // btnthoat
            // 
            this.btnthoat.Location = new System.Drawing.Point(811, 152);
            this.btnthoat.Name = "btnthoat";
            this.btnthoat.Size = new System.Drawing.Size(75, 23);
            this.btnthoat.TabIndex = 5;
            this.btnthoat.Text = "Thoát";
            this.btnthoat.UseVisualStyleBackColor = true;
            this.btnthoat.Click += new System.EventHandler(this.btnthoat_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(382, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(173, 32);
            this.label6.TabIndex = 6;
            this.label6.Text = "Chấm Công";
            // 
            // btntim
            // 
            this.btntim.Location = new System.Drawing.Point(843, 183);
            this.btntim.Name = "btntim";
            this.btntim.Size = new System.Drawing.Size(43, 27);
            this.btntim.TabIndex = 7;
            this.btntim.Text = "Tìm";
            this.btntim.UseVisualStyleBackColor = true;
            this.btntim.Click += new System.EventHandler(this.btntim_Click);
            // 
            // cobodl
            // 
            this.cobodl.FormattingEnabled = true;
            this.cobodl.Items.AddRange(new object[] {
            "Nhiều",
            "Ít"});
            this.cobodl.Location = new System.Drawing.Point(730, 184);
            this.cobodl.Name = "cobodl";
            this.cobodl.Size = new System.Drawing.Size(114, 24);
            this.cobodl.TabIndex = 8;
            this.cobodl.Text = "Số Lần Đi Làm";
            // 
            // Chamcong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 450);
            this.Controls.Add(this.cobodl);
            this.Controls.Add(this.btntim);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnthoat);
            this.Controls.Add(this.btnxoa);
            this.Controls.Add(this.btnhuy);
            this.Controls.Add(this.btnsua);
            this.Controls.Add(this.btnluu);
            this.Controls.Add(this.btnthem);
            this.Controls.Add(this.datasql);
            this.Controls.Add(this.dtNgaycc);
            this.Controls.Add(this.cbdl);
            this.Controls.Add(this.cbht);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtsolan);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label1);
            this.Name = "Chamcong";
            this.Text = "Chamcong";
            this.Load += new System.EventHandler(this.Chamcong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datasql)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtsolan;
        private System.Windows.Forms.ComboBox cbht;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbdl;
        private System.Windows.Forms.DateTimePicker dtNgaycc;
        private System.Windows.Forms.DataGridView datasql;
        private System.Windows.Forms.Button btnthem;
        private System.Windows.Forms.Button btnluu;
        private System.Windows.Forms.Button btnsua;
        private System.Windows.Forms.Button btnhuy;
        private System.Windows.Forms.Button btnxoa;
        private System.Windows.Forms.Button btnthoat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btntim;
        private System.Windows.Forms.ComboBox cobodl;
    }
}