using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using DTO;
using System.IO;
namespace QuanLyKho
{
    public partial class frmMenu : Form
    {
        TabPage tabPage2 = new TabPage();
        TabPage tabPage3 = new TabPage();
        TabPage tabPage4 = new TabPage();
        TabPage tabPage5 = new TabPage();
        public frmMenu()
        {
            InitializeComponent();
            an();
            txtmatkhau.UseSystemPasswordChar = true;
        }
        public void remove()
        {
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.TabPages.Remove(tabPage3);
            tabControl1.TabPages.Remove(tabPage4);
            tabControl1.TabPages.Remove(tabPage5);
        }

        private void nhậpKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            remove();
            frmNhapKho f = new frmNhapKho();
            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;
            tabPage2.Controls.Add(f);
            f.Visible = true;
            tabPage2.Text = "Nhập Kho";
            tabControl1.TabPages.Add(tabPage2);
        }

        private void xuấtKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            remove();
            frmXuatKho f = new frmXuatKho();
            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;
            tabPage3.Controls.Add(f);
            f.Visible = true;
            tabPage3.Text = "Xuất Kho";
            tabControl1.TabPages.Add(tabPage3);
        }

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            remove();
            frmThongKe f = new frmThongKe();
            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;
            tabPage4.Controls.Add(f);
            f.Visible = true;
            tabPage4.Text = "Thống Kê";
            tabControl1.TabPages.Add(tabPage4);
        }

        private void thêmTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThemTaiKhoan f = new frmThemTaiKhoan();
            f.ShowDialog();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmDoiMatKhau f = new frmDoiMatKhau();
            f.ShowDialog();
        }

        private void checkmk_CheckedChanged(object sender, EventArgs e)
        {
            if(txtmatkhau.UseSystemPasswordChar ==true)
            {
                txtmatkhau.UseSystemPasswordChar = false;
            }
            else
            {
                txtmatkhau.UseSystemPasswordChar = true;
            }
            //txtmatkhau.UseSystemPasswordChar = true;
        }

        private void btndangnhap_Click(object sender, EventArgs e)
        {
            if (TaiKhoanDAO.DangNhap(txttk.Text, txtmatkhau.Text) == true)
            {
                tabControl1.TabPages.Remove(tabPage1);
                hien();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txttaikhoan.Focus();
            }
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void trợGiúpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            remove();
            frmTroGiup f = new frmTroGiup();
            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;
            tabPage2.Controls.Add(f);
            f.Visible = true;
            tabPage5.Text = "Trợ Giúp";
            tabControl1.TabPages.Add(tabPage5);
        }
        public void an()
        {
            btnNhapKho.Enabled = false;
            btnXuatKho.Enabled = false;
            btnThongKe.Enabled = false;
            btnTaiKhoan.Enabled = false;
            btnTroGiup.Enabled = false;
        }
        public void hien()
        {
            btnNhapKho.Enabled = true;
            btnXuatKho.Enabled = true;
            btnThongKe.Enabled = true;
            btnTaiKhoan.Enabled = true;
            btnTroGiup.Enabled = true;
        }

        private void hướngDẫnSửDụngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string HelpPath;
            HelpPath = Application.StartupPath + @"\Helps\Help.docx";
            if (File.Exists(HelpPath))
            {
                System.Diagnostics.ProcessStartInfo proStarInfor = new System.Diagnostics.ProcessStartInfo();
                HelpPath = "\"" + HelpPath + "\"";
                System.Diagnostics.Process.Start("WINWORD.EXE", HelpPath);
            }
            else
                MessageBox.Show("File trợ giúp không tồn tại. " + System.Environment.NewLine +
                    "Kiểm tra lại đường dẫn: " + HelpPath, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    } 
}   
