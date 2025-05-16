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
    public partial class Khenthuong : Form
    {
        bool addnew = false;
        public Khenthuong()
        {
            InitializeComponent();
        }

        private void Khenthuong_Load(object sender, EventArgs e)
        {
            thongtin();
            loadcombobox();
            comboloai.Items.Insert(0,"Tất cả");
            comboloai.SelectedIndex = 0;
        }
        private void SetENble(bool check)
        {
            //textbox
            txtID.Enabled = false;
            txtTT.Enabled = check;
            txtNoidung.Enabled = check;
            //combobox
            cbht.Enabled = check;
            cbloai.Enabled = check;
            //datetime
            dateNgay.Enabled = check;
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
            string sql = "SELECT ID_KTKL,TenNhanVien,Loai,NoiDung,NgayQuyetDinh,SoTien From tblKTKL kt join tblNhanVien nv on kt.ID_NhanVien=nv.ID_NhanVien";
            datasql.DataSource = db.getData(sql);
            SetENble(false);
        }
        private void loadcombobox()
        {
            DBServices db = new DBServices();
            cbht.DataSource = db.getData("SELECT ID_NhanVien, TenNhanVien FROM tblNhanVien");
            cbht.DisplayMember = "TenNhanVien";
            cbht.ValueMember = "ID_NhanVien";
        }

        private void datasql_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if( i >= 0 )
            {
                txtID.Text = datasql.Rows[i].Cells["ID_KTKL"].Value.ToString();
                txtTT.Text = datasql.Rows[i].Cells["SoTien"].Value.ToString();
                txtNoidung.Text = datasql.Rows[i].Cells["NoiDung"].Value.ToString();
                cbht.Text = datasql.Rows[i].Cells["TenNhanVien"].Value.ToString();
                cbloai.Text = datasql.Rows[i].Cells["Loai"].Value.ToString();
                dateNgay.Text = datasql.Rows[i].Cells["NgayQuyetDinh"].Value.ToString();
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
            txtTT.Clear();
            txtNoidung.Clear();
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
           
            string tt = txtTT.Text;
            string nd = txtNoidung.Text;
            string ngay = dateNgay.Value.ToString("yyyy-MM-dd");
            string ht = cbht.SelectedValue.ToString();
            string l = cbloai.Text;
            if(addnew)
            {
                if(MessageBox.Show("Bạn có muốn thêm thông tin vào không","Thông Báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    string sql = string.Format("Insert into tblKTKL (ID_NhanVien ,Loai ,NoiDung ,NgayQuyetDinh ,SoTien) " +
                        "values ({0},N'{1}',N'{2}','{3}','{4}')",ht,l,nd,ngay,tt);
                    DBServices db = new DBServices();
                    db.runQuery(sql);
                    thongtin();
                }    
            }
            else
            { 
                if (MessageBox.Show("Bạn có chắc muốn sửa thông tin này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                string id = txtID.Text;
                string sql = string.Format("Update tblKTKL set ID_NhanVien = {0},Loai = N'{1}',NoiDung = N'{2}',NgayQuyetDinh = '{3}',SoTien = '{4}' " +
                        "where ID_KTKL = {5} ", ht, l, nd, ngay, tt, id);
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
            if(MessageBox.Show("Bạn có muốn Xóa thông tin trên bảng không","Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
            string sql = string.Format("Delete from tblKTKL where ID_KTKL = {0}",txtID.Text);
            DBServices db = new DBServices();
            db.runQuery(sql);
            thongtin();
            }
            
        }

        private void btntim_Click(object sender, EventArgs e)
        {
            string loai = comboloai.Text;
            string sql = "SELECT ID_KTKL, TenNhanVien, Loai, NoiDung, NgayQuyetDinh, SoTien " +
                         "FROM tblKTKL kt JOIN tblNhanVien nv ON kt.ID_NhanVien = nv.ID_NhanVien WHERE 1=1";
            if (!string.IsNullOrEmpty(loai) && loai != "Tất cả")
                sql += " AND Loai like N'%" + loai + "%'";
            DBServices db = new DBServices();
            datasql.DataSource = db.getData(sql);
        }
    }
}
