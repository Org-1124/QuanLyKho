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
namespace QuanLyKho
{
    public partial class frmKhachHang : Form
    {
        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            dgvKhachHang.DataSource = KhachHangDAO.LoadDataKH();
            SetHeaderColumn();
            An();
        }
        public void SetHeaderColumn()
        {
            dgvKhachHang.Columns["MaKhachHang"].HeaderText = "Mã Khách Hàng";
            dgvKhachHang.Columns["HoTen"].HeaderText = "Họ và Tên";
            dgvKhachHang.Columns["DiaChi"].HeaderText = "Địa Chỉ";
            dgvKhachHang.Columns["Email"].HeaderText = "Email";
            dgvKhachHang.Columns["SDT"].HeaderText = "SĐT";
        }
        public void An()
        {
            txtMaKhachHang.ReadOnly = true;
            txtDiaChi.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtHoTen.ReadOnly = true;
            txtSDT.ReadOnly = true;
            txtSearch.ReadOnly = true;
        }
        public void Hien()
        {
            txtDiaChi.ReadOnly = false;
            txtEmail.ReadOnly = false;
            txtHoTen.ReadOnly = false;
            txtSDT.ReadOnly = false;
            txtSearch.ReadOnly = false;
        }
    }
}
