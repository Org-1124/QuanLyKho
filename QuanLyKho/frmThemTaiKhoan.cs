using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DTO;
using DAO;

namespace QuanLyKho
{
    public partial class frmThemTaiKhoan : Form
    {
        public frmThemTaiKhoan()
        {
            InitializeComponent();
        }

        private void btntao_Click(object sender, EventArgs e)
        {
            TaiKhoanDTO tk = new TaiKhoanDTO();
            if (txttk.Text == "" || txtmk.Text == "" || txtxacnhan.Text == "")
            {
                MessageBox.Show("Chưa nhập đầy đủ thông tin");
            }
            else
            {
                if (txtmk.Text == txtxacnhan.Text)
                {
                    tk.TaiKhoan = txttk.Text;
                    tk.MatKhau = txtmk.Text;
                    TaiKhoanDAO.ThemTK(tk);
                    MessageBox.Show("Thêm tài khoản thành công");
                }
                else
                {
                    txtmk.Focus();
                    MessageBox.Show("Mật khẩu không trùng khớp");
                }
            }
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
