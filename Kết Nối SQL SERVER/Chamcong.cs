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
    public partial class Chamcong : Form
    {
        bool addnew = false;
        public Chamcong()
        {
            InitializeComponent();
        }

        private void Chamcong_Load(object sender, EventArgs e)
        {
            thongtin();
            LoadComboBox();
            cobodl.Items.Insert(0,"Tất Cả");
            cobodl.SelectedIndex = 0;
        }

        private void SetEnble(bool check)
        {
            //textbox
            txtID.Enabled = false;
            txtsolan.Enabled = check;
            //combobox
            cbdl.Enabled = check;
            cbht.Enabled = check;
            //datetime
            dtNgaycc.Enabled = check;
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
        private void LoadComboBox()
        {
            DBServices db = new DBServices();
            cbht.DataSource = db.getData("SELECT ID_NhanVien, TenNhanVien FROM tblNhanVien");
            cbht.DisplayMember = "TenNhanVien";
            cbht.ValueMember = "ID_NhanVien";
        }
        private void thongtin()
        {
            string sql = string.Format("Select ID_ChamCong,TenNhanVien,NgayChamCong,DiLam,SoGioLam from tblChamCong cc join tblNhanVien nv on cc.ID_NhanVien=nv.ID_NhanVien");
            DBServices db = new DBServices();
            datasql.DataSource = db.getData(sql);
            SetEnble(false);
        }
        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void datasql_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i >= 0)
            {
                txtID.Text = datasql.Rows[i].Cells["ID_ChamCong"].Value.ToString();
                txtsolan.Text = datasql.Rows[i].Cells["SoGioLam"].Value.ToString();
                cbht.Text = datasql.Rows[i].Cells["TenNhanVien"].Value.ToString();
                cbdl.Text = datasql.Rows[i].Cells["DiLam"].Value.ToString();
                dtNgaycc.Text = datasql.Rows[i].Cells["NgayChamCong"].Value.ToString();
            }
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            SetEnble(false);
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            addnew = true;
            SetEnble(true);
            txtID.Clear();
            txtsolan.Clear();
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
           
            string sl = txtsolan.Text;
            string dl = cbdl.Text;
            string ngay = dtNgaycc.Value.ToString("yyyy-MM-dd");
            string idht = cbht.SelectedValue.ToString();
            if (addnew)
            {
                if (MessageBox.Show("Bạn Có Muốn Thêm Thông Tin Vào Không", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string sql = string.Format("INSERT INTO tblChamCong (ID_NhanVien,NgayChamCong,DiLam,SoGioLam) " +
                        "VALUES ({0}, '{1}' ,N'{2}','{3}')",
                        idht,ngay,dl,sl);
                    DBServices db = new DBServices();
                    db.runQuery(sql);
                    thongtin();
                }
                
            }
            else
            {
                if (MessageBox.Show("Bạn Có Muốn Sửa Thông Tin Không", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                { 
                     string id = txtID.Text;
                     string sql = string.Format("UPDATE tblChamCong SET ID_NhanVien = {0} ,NgayChamCong = '{1}',DiLam = N'{2}',SoGioLam = '{3}' where ID_ChamCong = {4}",
                     idht,ngay,dl,sl,id);
                     DBServices db = new DBServices();
                     db.runQuery(sql);
                     thongtin();
                }
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            addnew = false;
            SetEnble(true);
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa nhân viên này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = string.Format("DELETE FROM tblChamCong WHERE ID_ChamCong = {0}", txtID.Text);
                DBServices db = new DBServices();
                db.runQuery(sql);
                thongtin();
            }
        }

        private void btntim_Click(object sender, EventArgs e)
        {
            string tdl = cobodl.Text;
            string sql = "Select ID_ChamCong,TenNhanVien,NgayChamCong,DiLam,SoGioLam from tblChamCong cc join tblNhanVien nv on cc.ID_NhanVien=nv.ID_NhanVien " +
                " WHERE 1=1";
            if(!string.IsNullOrEmpty(tdl) && tdl != "Tất Cả")
                sql += "and DiLam like N'%"+ tdl +"%'";
            DBServices db = new DBServices();
            datasql.DataSource = db.getData(sql);
        }
    }
}
