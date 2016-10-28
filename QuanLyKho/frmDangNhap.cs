using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using DAO;
namespace QuanLyKho
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void checkmk_CheckedChanged(object sender, EventArgs e)
        {
            txtmatkhau.UseSystemPasswordChar = checkmk.Checked ? false : true;
        }

        private void btndangnhap_Click(object sender, EventArgs e)
        {
            if (TaiKhoanDAO.DangNhap(txttaikhoan.Text, txtmatkhau.Text) == true)
            {
                MessageBox.Show("Đăng nhập thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmMain f = new frmMain();
                f.ShowDialog();
                Application.Exit();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txttaikhoan.Focus();
            }
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Bạn có muốn thoát không ?", "Thông Báo", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
            
        }
    }
}
