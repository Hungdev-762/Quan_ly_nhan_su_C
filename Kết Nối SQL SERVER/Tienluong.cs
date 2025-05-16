using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kết_Nối_SQL_SERVER
{
    public partial class Tienluong : Form
    {
        bool addnew = false;
        public Tienluong()
        {
            InitializeComponent();
        }
        private void Tienluong_Load(object sender, EventArgs e)
        {
            thongtin();
            LoadComboBox();
        }
        private void SetEnble(bool check)
        {
            //textbox
            txtid.Enabled = false;
            txtLT.Enabled = check;
            txtngaycong.Enabled = check;
            txtTL.Enabled = false;
            //combobox
            cbht.Enabled = check;
            //button
            btnhuy.Enabled = check;
            btnluu.Enabled = check;
            btnthem.Enabled = !check;
            btnsua.Enabled = !check;
            btnthoat.Enabled = !check;
            btnxoa.Enabled = !check;
            // datagridview
            datasql.Enabled = !check;
        }
        private void thongtin()
        {
            string sql = "SELECT ID_Luong, TenNhanVien, LuongThang, SoNgayCong, (LuongThang * SoNgayCong) AS TongLuong " +
                     " FROM tblLuongThang l JOIN tblNhanVien nv ON l.ID_NhanVien = nv.ID_NhanVien";
            DBServices db = new DBServices();
            datasql.DataSource = db.getData(sql);
            SetEnble(false);
        }
        private void LoadComboBox()
        {
            DBServices db = new DBServices();
            cbht.DataSource = db.getData("SELECT ID_NhanVien, TenNhanVien FROM tblNhanVien");
            cbht.DisplayMember = "TenNhanVien";
            cbht.ValueMember = "ID_NhanVien";
        }

        private void datasql_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if(i >= 0)
            {
                txtid.Text = datasql.Rows[i].Cells["ID_Luong"].Value.ToString();
                cbht.Text = datasql.Rows[i].Cells["TenNhanVien"].Value.ToString();
                txtLT.Text = datasql.Rows[i].Cells["LuongThang"].Value.ToString();
                txtngaycong.Text = datasql.Rows[i].Cells["SoNgayCong"].Value.ToString();
                if (decimal.TryParse(txtLT.Text, out decimal luongThang) && int.TryParse(txtngaycong.Text, out int soNgayCong))
                {
                    txtTL.Text = (luongThang * soNgayCong).ToString("N0");
                }
                else
                {
                    txtTL.Text = "0";
                }
            }
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            SetEnble(false);
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            addnew = true;
            SetEnble(true);
            txtLT.Clear();
            txtngaycong.Clear();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            addnew = false;
            SetEnble(true);
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            string ht = cbht.SelectedValue.ToString();
            string lthang = txtLT.Text;
            string ncong = txtngaycong.Text;
            if (!decimal.TryParse(lthang, out decimal lt) || !int.TryParse(ncong, out int nc))
            {
                MessageBox.Show("Lương tháng hoặc số ngày công không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string sql = "";

            if (addnew)
            {
                if (MessageBox.Show("Bạn có muốn thêm thông tin vào không", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                { 
                    sql = string.Format("INSERT INTO tblLuongThang (ID_NhanVien, LuongThang, SoNgayCong) " +
                                    "VALUES ({0}, {1}, {2})", ht, lt, nc);
                }    
                    
            }
            else
            {
                if (MessageBox.Show("Bạn có chắc muốn sửa nhân viên này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                string id = txtid.Text;
                sql = string.Format("UPDATE tblLuongThang SET ID_NhanVien = {0}, LuongThang = {1}, SoNgayCong = {2} " +
                                    " WHERE ID_Luong = {3}", ht, lt, nc, id);
                }    
                    
            }
            DBServices db = new DBServices();
            db.getData(sql);
            thongtin();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa bản ghi này?", "Xác nhận",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = string.Format("DELETE FROM tblLuongThang WHERE ID_Luong = {0}",txtid.Text); 
                DBServices db = new DBServices();
                db.runQuery(sql);
                thongtin();
            }
        }
    }
}
