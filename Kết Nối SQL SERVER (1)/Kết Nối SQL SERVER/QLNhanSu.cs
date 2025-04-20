using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kết_Nối_SQL_SERVER
{
    public partial class QLNhanSu : Form
    {
        bool addNew = false;
        public QLNhanSu()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LayThongTin();
        }
        private void setEnable(bool check)
        {
            // textbox
            txtID.Enabled = false;
            txtTen.Enabled = check;
            txtDiaChi.Enabled = check;
            txtSDT.Enabled = check;
            txtNamSinh.Enabled = check;
            txtChucvu.Enabled = check;
            txtPhongban.Enabled = check;
            // buttton
            btnThem.Enabled = !check;
            btnLuu.Enabled = check;
            btnSua.Enabled = !check;
            btnXoa.Enabled = !check;
            btnCancel.Enabled = check;
            btnExit.Enabled = !check;
            // datagridview
            dataGridView1.Enabled = !check;
        }
        private void LayThongTin()
        {
            DBServices db = new DBServices();
            string sql = "SELECT * FROM HoSO_NhanVien";
            dataGridView1.DataSource = db.getData(sql);
            setEnable(false);
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i >= 0)
            {
                txtID.Text = dataGridView1.Rows[i].Cells["ID"].Value.ToString();
                txtTen.Text = dataGridView1.Rows[i].Cells["TENNV"].Value.ToString();
                txtDiaChi.Text = dataGridView1.Rows[i].Cells["DiaChi"].Value.ToString();
                txtSDT.Text = dataGridView1.Rows[i].Cells["SDT"].Value.ToString();
                txtNamSinh.Text = dataGridView1.Rows[i].Cells["NamSinh"].Value.ToString();
                txtChucvu.Text = dataGridView1.Rows[i].Cells["ChucVu"].Value.ToString();
                txtPhongban.Text = dataGridView1.Rows[i].Cells["PhongBan"].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            addNew = true;
            setEnable(true);
            txtID.Clear();
            txtTen.Clear();
            txtDiaChi.Clear();
            txtSDT.Clear();
            txtNamSinh.Clear();
            txtChucvu.Clear();
            txtPhongban.Clear();
            txtTen.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
                string id = txtID.Text;
                string ten = txtTen.Text;
                string diachi = txtDiaChi.Text;
                string sdt = txtSDT.Text;
                string nam = txtNamSinh.Text;
                string cv = txtChucvu.Text;
                string pb = txtPhongban.Text;
            if(addNew)
            {
                //Thêm dữ liệu vào bảng
                string sql = string.Format("INSERT INTO HoSO_NhanVien (TENNV, DiaChi, SDT, NamSinh, ChucVu, PhongBan) VALUES"
                + " (N'{0}',N'{1}','{2}','{3}',N'{4}',N'{5}')", ten,diachi,sdt,nam,cv,pb);
                DBServices db = new DBServices();
                db.runQuery (sql);
                LayThongTin();
            }
            else
            {
                string sql = string.Format("UPDATE HoSO_NhanVien SET "+ 
                    "TENNV=N'{0}',"+ 
                    "DiaChi=N'{1}',"+ 
                    "SDT='{2}',"+ 
                    "NamSinh='{3}',"+ 
                    "ChucVu=N'{4}',"+
                    "PhongBan=N'{5}'  WHERE ID = {6}",ten,diachi,sdt,nam,cv,pb,id);
                DBServices db = new DBServices();
                db.runQuery(sql);
                LayThongTin();
            }  
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            addNew = false;
            setEnable(true);
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            setEnable(false);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
            string sql = string.Format("DELETE FROM HoSO_NhanVien WHERE ID ={0}",id);
            if(MessageBox.Show("Bạn có muốn xoá  bản ghi này không ?","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Error)== DialogResult.Yes)
            {
            DBServices db = new DBServices();
            db.runQuery(sql);
            LayThongTin();
            }    
            
        }
    }
}
