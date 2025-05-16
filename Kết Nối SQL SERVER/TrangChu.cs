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
    public partial class TrangChu : Form
    {
        public TrangChu()
        {
            InitializeComponent();
        }

        private void btnDX_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNS_Click(object sender, EventArgs e)
        {
            panel4.Height = btnNS.Height;
            panel4.Top = btnNS.Top;
            NhanVien nv = new NhanVien();
            nv.Show();
        }

        private void btnPB_Click(object sender, EventArgs e)
        {
            panel4.Height = btnPB.Height;
            panel4.Top = btnPB.Top;
            PhongBan pb = new PhongBan();
            pb.Show();
        }

        private void btnCV_Click(object sender, EventArgs e)
        {
            panel4.Height = btnCV.Height;
            panel4.Top = btnCV.Top;
            ChucVu cv = new ChucVu();
            cv.Show();
        }

        private void btnTL_Click(object sender, EventArgs e)
        {
            panel4.Height = btnTL.Height;
            panel4.Top = btnTL.Top;
            Tienluong tl = new Tienluong();
            tl.Show();
        }

        private void btnKL_Click(object sender, EventArgs e)
        {
            panel4.Height = btnKL.Height;
            panel4.Top = btnKL.Top;
            Khenthuong kt = new Khenthuong();
            kt.Show();
        }

        private void btnCC_Click(object sender, EventArgs e)
        {
            panel4.Height = btnCC.Height;
            panel4.Top = btnCC.Top;
            Chamcong cc = new Chamcong();
            cc.Show();
        }
    }
}
