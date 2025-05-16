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
    public partial class NhanVien : Form
    {
        bool addnew = false;
        public NhanVien()
        {
            InitializeComponent();
        }

        private void NhanVien_Load(object sender, EventArgs e)
        {
            thongtin();
            LoadComboBox();
            combogt.Items.Insert(0, "Tất Cả");
            combodc.Items.Insert(0, "Tất Cả");
            combott.Items.Insert(0, "Tất Cả");
            combodc.SelectedIndex = 0;
            combogt.SelectedIndex = 0;
            combott.SelectedIndex = 0;
        }
        private void SetENble(bool check)
        {
            //textbox
            txtID.Enabled = false;
            txtHoTen.Enabled = check;
            txtSDT.Enabled = check;
            //combobox
            cbdiachi.Enabled = check;
            cbgioitinh.Enabled = check;
            cbtrangthai.Enabled = check;
            cbpb.Enabled = check;
            cbcv.Enabled = check;
            //datetime
            dtNgayLam.Enabled = check;
            dtNgaysinh.Enabled = check;
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
            cbpb.DataSource = db.getData("SELECT ID_PhongBan, TenPhongBan FROM tblPhongBan");
            cbpb.DisplayMember = "TenPhongBan";
            cbpb.ValueMember = "ID_PhongBan";

            cbcv.DataSource = db.getData("SELECT ID_ChucVu, TenChucVu FROM tblChucVu");
            cbcv.DisplayMember = "TenChucVu";
            cbcv.ValueMember = "ID_ChucVu";
        }


        private void thongtin()
        {
            DBServices db = new DBServices();
            string sql = "SELECT ID_NhanVien,TenNhanVien,NgaySinh,GioiTinh,DiaChi,SoDienThoai,TenPhongBan,TenChucVu,NgayVaoLAm,TrangThai FROM tblNhanVien nv join tblPhongBan pb on nv.ID_PhongBan = pb.ID_PhongBan join tblChucVu cv on nv.ID_ChucVu=cv.ID_ChucVu";
            datasql.DataSource = db.getData(sql);
            SetENble(false);
        }
        private void datasql_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i >= 0)
            {
                txtID.Text = datasql.Rows[i].Cells["ID_NhanVien"].Value.ToString();
                txtHoTen.Text = datasql.Rows[i].Cells["TenNhanVien"].Value.ToString();
                txtSDT.Text = datasql.Rows[i].Cells["SoDienThoai"].Value.ToString();
                cbpb.Text = datasql.Rows[i].Cells["TenPhongBan"].Value.ToString();
                cbcv.Text = datasql.Rows[i].Cells["TenChucVu"].Value.ToString();
                cbdiachi.Text = datasql.Rows[i].Cells["DiaChi"].Value.ToString();
                cbgioitinh.Text = datasql.Rows[i].Cells["GioiTinh"].Value.ToString();
                cbtrangthai.Text = datasql.Rows[i].Cells["TrangThai"].Value.ToString();
                dtNgaysinh.Text = datasql.Rows[i].Cells["NgaySinh"].Value.ToString();
                dtNgayLam.Text = datasql.Rows[i].Cells["NgayVaoLam"].Value.ToString();
            }
        }
        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            SetENble(false);
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            addnew = true;
            SetENble(true);
            txtID.Clear();
            txtHoTen.Clear();
            txtSDT.Clear();
        }

        private void btnluu_Click(object sender, EventArgs e)
        { 
            string ht = txtHoTen.Text;
            string sdt = txtSDT.Text;
            string tt = cbtrangthai.Text;
            string dc = cbdiachi.Text;
            string gt = cbgioitinh.Text;
            string ngaylam = dtNgayLam.Value.ToString("yyyy-MM-dd");
            string ngaysinh = dtNgaysinh.Value.ToString("yyyy-MM-dd");
            string idpb = cbpb.SelectedValue.ToString();
            string idcv = cbcv.SelectedValue.ToString();

            if (addnew) 
            {
                if (MessageBox.Show("Bạn Có Muốn Thêm Thông Tin Vào Không", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                        string sql = string.Format("INSERT INTO tblNhanVien (TenNhanVien, NgaySinh, GioiTinh, DiaChi, SoDienThoai, ID_PhongBan, ID_ChucVu, NgayVaoLam, TrangThai) " +
                            "VALUES (N'{0}','{1}',N'{2}',N'{3}','{4}',{5},{6},'{7}',N'{8}')",
                            ht, ngaysinh, gt, dc, sdt, idpb, idcv, ngaylam, tt);
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
                        string sql = string.Format("UPDATE tblNhanVien SET TenNhanVien = N'{0}', NgaySinh = '{1}', GioiTinh = N'{2}', DiaChi = N'{3}', SoDienThoai = '{4}', ID_PhongBan = {5}, ID_ChucVu = {6}, NgayVaoLam = '{7}', TrangThai = N'{8}' WHERE ID_NhanVien = {9}",
                            ht, ngaysinh, gt, dc, sdt, idpb, idcv, ngaylam, tt, id);
                        DBServices db = new DBServices();
                        db.runQuery(sql);
                        thongtin();
                }
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            addnew = false;
            SetENble(true);
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa nhân viên này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                    string sql = string.Format("DELETE FROM tblNhanVien WHERE ID_NhanVien = {0}",txtID.Text );
                    DBServices db = new DBServices();
                    db.runQuery(sql);
                    thongtin();           
            }
        }

        private void btntim_Click(object sender, EventArgs e)
        {
            string tgt = combogt.Text;
            string tdc = combodc.Text;
            string ttt = combott.Text;

            string sql = "SELECT nv.ID_NhanVien, TenNhanVien, NgaySinh, GioiTinh, DiaChi, SoDienThoai, pb.TenPhongBan, cv.TenChucVu, NgayVaoLam, TrangThai " +
                         "FROM tblNhanVien nv " +
                         "JOIN tblPhongBan pb ON nv.ID_PhongBan = pb.ID_PhongBan " +
                         "JOIN tblChucVu cv ON nv.ID_ChucVu = cv.ID_ChucVu " +
                         "WHERE 1=1";
            if (!string.IsNullOrEmpty(tgt) && tgt != "Tất Cả")
                sql += " AND GioiTinh LIKE N'%" + tgt + "%'";
            if (!string.IsNullOrEmpty(tdc) && tdc != "Tất Cả")
                sql += " AND DiaChi LIKE N'%" + tdc + "%'";
            if (!string.IsNullOrEmpty(ttt) && ttt != "Tất Cả")
                sql += " AND TrangThai LIKE N'%" + ttt + "%'";
            DBServices db = new DBServices();
            datasql.DataSource = db.getData(sql);
        }
}
}
