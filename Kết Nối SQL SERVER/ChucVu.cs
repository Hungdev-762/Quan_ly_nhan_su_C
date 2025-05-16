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
    public partial class ChucVu : Form
    {
        bool AddNew = false;
        public ChucVu()
        {
            InitializeComponent();
        }

        private void ChucVu_Load(object sender, EventArgs e)
        {
            thongtin();
        }

        private void SetENble(bool check)
        {
            txtID.Enabled= false;
            txtIDCV.Enabled = check;
            txtTenCV.Enabled = check;
            txtLuong.Enabled = check;
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
            DBServices db = new DBServices();
            string sql = "SELECT * FROM tblChucVu";
            datasql.DataSource = db.getData(sql);
            SetENble(false);
        }

        private void datasql_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i >= 0)
            {
                txtID.Text = datasql.Rows[i].Cells["ID_ChucVu"].Value.ToString();
                txtIDCV.Text = datasql.Rows[i].Cells["Ma_ChucVu"].Value.ToString();
                txtTenCV.Text = datasql.Rows[i].Cells["TenChucVu"].Value.ToString();
                txtLuong.Text = datasql.Rows[i].Cells["HeSoLuong"].Value.ToString();
            }
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            AddNew = true;
            SetENble(true);
            txtIDCV.Clear();
            txtTenCV.Clear();
            txtLuong.Clear();
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            SetENble(false);
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            AddNew = false;
            SetENble(true);
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            string mcv = txtIDCV.Text;
            string tcv = txtTenCV.Text;
            string luong = txtLuong.Text;
            if(AddNew)
            {
                if (MessageBox.Show("Bạn Có Muốn Thêm Thông Tin Vào Không", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        string sql = string.Format("Insert into tblChucVu values " +
                        "(N'{0}',N'{1}','{2}')", mcv, tcv, luong);
                        DBServices db = new DBServices();
                        db.runQuery(sql);
                        thongtin();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi thêm dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                string id = txtID.Text;
                string sql = string.Format("UPDATE tblChucVu set Ma_ChucVu = N'{0}',TenChucVu = N'{1}',HeSoLuong = {2} where ID_ChucVu = {3}",mcv,tcv,luong,id);
                DBServices db = new DBServices();
                db.runQuery(sql);
                thongtin();
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn Có Muốn Xóa Không", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
            {
                string sql = string.Format("Delete from tblChucVu where ID_ChucVu = {0}", txtID.Text);
                DBServices db = new DBServices();
                db.runQuery(sql);
                thongtin();
            }
        }
    }
}