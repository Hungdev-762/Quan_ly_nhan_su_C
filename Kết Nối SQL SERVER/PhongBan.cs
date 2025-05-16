using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kết_Nối_SQL_SERVER
{
    public partial class PhongBan : Form
    {
        bool addnew = false;
        public PhongBan()
        {
            InitializeComponent();
        }

        private void PhongBan_Load(object sender, EventArgs e)
        {
            thongtin();
            cbCoso.Items.Add("Tất cả");
            cbCoso.Items.Add("A");
            cbCoso.Items.Add("B");
            cbCoso.Items.Add("C");
            cbCoso.SelectedIndex = 0;
        }

        private void SetENble(bool check)
        {
            txtIDphong.Enabled = false;
            txtTenPhong.Enabled = check;
            dateTimeNgay.Enabled = check;
            Txtcoso.Enabled = check;
            //button
            btnhuy.Enabled = check;
            btnLuu.Enabled = check;
            btnthem.Enabled = !check;
            btnSua.Enabled = !check;
            btnthoat.Enabled = !check;
            btnXoa.Enabled = !check;
            // datagridview
            datasql.Enabled = !check;
        }

        private void thongtin()
        {
            DBServices db = new DBServices();
            string sql = "SELECT * FROM tblPhongBan";
            datasql.DataSource = db.getData(sql);
            SetENble(false);
        }

        private void datasql_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i >= 0)
            {
                txtIDphong.Text = datasql.Rows[i].Cells["ID_PhongBan"].Value.ToString();
                txtTenPhong.Text = datasql.Rows[i].Cells["TenPhongBan"].Value.ToString();
                dateTimeNgay.Text = datasql.Rows[i].Cells["NgayThanhLap"].Value.ToString();
                Txtcoso.Text = datasql.Rows[i].Cells["CoSo"].Value.ToString();
            }
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            addnew = true;
            SetENble(true);
            txtIDphong.Clear();
            txtTenPhong.Clear();
            Txtcoso.Clear();
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            SetENble(false);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(txtTenPhong.Text.Trim() =="")
            {
                MessageBox.Show("Thông Tin phòng phải được đầy đủ!", "Thông Báo");
                txtTenPhong.Focus();
                return;
            } 
            if(Txtcoso.Text.Trim() =="")
            {
                MessageBox.Show("Thông Tin phòng phải được đầy đủ!", "Thông Báo");
                txtTenPhong.Focus();
                return;
            }
            string tp = txtTenPhong.Text;
            string cs = Txtcoso.Text;
            DateTime ntl = dateTimeNgay.Value;
            string ngay = ntl.ToString("yyyy-MM-dd");
            if (addnew)
            {
                if (MessageBox.Show("Bạn Có Muốn Thêm Thông Tin Vào Không", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                        string sql = string.Format("Insert into tblPhongBan values " +
                           "(N'{0}','{1}',N'{2}')", tp, ngay, cs);
                        DBServices db = new DBServices();
                        db.runQuery(sql);
                        thongtin();
                }
            }    
            else
            {
                string id = txtIDphong.Text;
                string sql = string.Format("Update tblPhongBan set TenPhongBan=N'{0}',NgayThanhLap='{1}',CoSo=N'{2}' where ID_PhongBan = {3}", tp, ngay, cs, id);
                DBServices db = new DBServices();
                db.runQuery(sql);
                thongtin();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            addnew = false;
            SetENble(true);
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn Có Muốn Xóa Không","Thông Báo",MessageBoxButtons.YesNo,MessageBoxIcon.Stop)==DialogResult.Yes)
            {
            string sql = string.Format("Delete from tblPhongBan where ID_PhongBan = {0}",  txtIDphong.Text);
            DBServices db = new DBServices();
            db.runQuery(sql);
            thongtin();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string coSo = cbCoso.SelectedItem.ToString();
            string sql;

            if (coSo == "Tất cả")
            {
                sql = "SELECT * FROM tblPhongBan";
            }
            else
            {
                sql = string.Format("SELECT * FROM tblPhongBan WHERE CoSo = N'{0}'", coSo);
            }
            DBServices db = new DBServices();
            datasql.DataSource = db.getData(sql);
        }
    }
}
