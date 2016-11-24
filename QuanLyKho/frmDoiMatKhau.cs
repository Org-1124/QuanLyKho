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
    public partial class frmDoiMatKhau : Form
    {
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void btndoimk_Click(object sender, EventArgs e)
        {
            TaiKhoanDTO tk = new TaiKhoanDTO();
            if (txtmkcu.Text == "" || txtmkmoi.Text=="" || txtxacnhan.Text == "")
            {
                MessageBox.Show("Chưa nhập đầy đủ thông tin");
            }
            else
            {
                if (TaiKhoanDAO.DangNhap(txttk.Text, txtmkcu.Text) == true)
                {
                    if (txtmkmoi.Text == txtxacnhan.Text)
                    {
                        tk.TaiKhoan = txttk.Text;
                        tk.MatKhau = txtmkmoi.Text;
                        TaiKhoanDAO.DoiMK(tk);
                        MessageBox.Show("Đổi mật khẩu thành công");

                    }
                    else
                    {
                        txtmkmoi.Focus();
                        MessageBox.Show("Mật khẩu không trùng khớp", "Thông Báo", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng xem lại tài khoản hoặc mật khẩu của bạn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
