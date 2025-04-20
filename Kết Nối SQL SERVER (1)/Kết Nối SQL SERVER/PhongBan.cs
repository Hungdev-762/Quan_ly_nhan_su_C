using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Kết_Nối_SQL_SERVER
{
    public partial class PhongBan : Form
    {
        bool addNew = false;
        public PhongBan()
        {
            InitializeComponent();
        }

        private void PhongBan_Load(object sender, EventArgs e)
        {
            ThongTin();
        }
        private void setEnable(bool check)
        {
            //textbox
            txtIDPB.Enabled = false;
            txtTenPB.Enabled = check;
            txtTenNV.Enabled = check;
            txtTruongPB.Enabled = check;
            txtDA.Enabled = check;
            txtNgaytao.Enabled = check;
            txtCapNhat.Enabled = check;
            txtTrangthai.Enabled = check;
            //button
            btnthem.Enabled = !check;
            btnxoa.Enabled = !check;
            btnsua.Enabled = !check;
            btnthoat.Enabled = !check;
            btnluu.Enabled = check;
            btnhuy.Enabled = check;
            //datagridview
            dataGridView2.Enabled = !check;
        }
        private void ThongTin()
        {
            DBServices db = new DBServices();
            string sql = "SELECT * FROM tblPhongBan";
            dataGridView2.DataSource = db.getData(sql);
            setEnable(false);
        }

        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i >= 0)
            {
                txtIDPB.Text = dataGridView2.Rows[i].Cells["PB_ID"].Value.ToString();
                txtTenPB.Text = dataGridView2.Rows[i].Cells["Ma_Phong"].Value.ToString();
                txtTenNV.Text= dataGridView2.Rows[i].Cells["TENNV"].Value.ToString();
                txtTruongPB.Text = dataGridView2.Rows[i].Cells["Truong_Phong"].Value.ToString();
                txtDA.Text = dataGridView2.Rows[i].Cells["Du_An"].Value.ToString();
                txtNgaytao.Text = dataGridView2.Rows[i].Cells["Ngay_Tao"].Value.ToString();
                txtCapNhat.Text = dataGridView2.Rows[i].Cells["Ngay_CN"].Value.ToString();
                txtTrangthai.Text = dataGridView2.Rows[i].Cells["Trang_Thai"].Value.ToString();
            }    
        }
        private void btnthem_Click(object sender, EventArgs e)
        {
            addNew = true;
            setEnable(true);
            txtIDPB.Clear();
            txtTenPB.Clear();
            txtTenNV.Clear();
            txtTruongPB.Clear();
            txtDA.Clear();
            txtNgaytao.Clear();
            txtCapNhat.Clear();
            txtTrangthai.Clear();
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            setEnable(false);
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            string id = txtIDPB.Text;
            string tnv = txtTenNV.Text;
            string tpb = txtTenPB.Text;
            string truong = txtTruongPB.Text;
            string da = txtDA.Text;
            string nt = txtNgaytao.Text;
            string ncn = txtCapNhat.Text;
            string tt = txtTrangthai.Text;
            if (addNew)
            {
                string sql = string.Format("INSERT INTO  tblPhongBan (TENNV, Ma_Phong, Truong_Phong, Du_An, Ngay_Tao, Ngay_CN, Trang_Thai) VALUES" 
                +" (N'{0}', N'{1}', N'{2}', N'{3}', N'{4}', N'{5}', N'{6}') ",tnv,tpb,truong,da,nt,ncn,tt);
                DBServices db = new DBServices();
                db.runQuery(sql);
                ThongTin();
            }
            else
            {
                string sql = string.Format("UPDATE tblPhongBan SET " +
                    " TENNV = N'{0}'," +
                    "Ma_Phong = N'{1}'," +
                    "Truong_Phong = N'{2}'," +
                    "Du_An = N'{3}'," +
                    "Ngay_Tao = N'{4}'," +
                    "Ngay_CN = N'{5}'," +
                    "Trang_Thai = N'{6}'  WHERE PB_ID = {7}", tnv, tpb, truong, da, nt, ncn, tt, id);
                DBServices db = new DBServices();
                db.runQuery(sql);
                ThongTin();
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            addNew = false;
            setEnable(true);
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string id = txtIDPB.Text;
            string sql = string.Format("DELETE FROM tblPhongBan WHERE PB_ID = {0}",id);
            if(MessageBox.Show ("Bạn có muốn xóa bảng thông tin này không?","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Error) == DialogResult.Yes )
            {
                DBServices db = new DBServices();
                db.runQuery(sql);
                ThongTin();
            }    
        }
    }
}
