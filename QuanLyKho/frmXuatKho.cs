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
namespace QuanLyKho
{
    public partial class frmXuatKho : Form
    {
        int kthd = 0;
        int ktctx = 0;
        public frmXuatKho()
        {
            InitializeComponent();
        }

        private void frmXuatKho_Load(object sender, EventArgs e)
        {
            dgvHoaDon.DataSource = HoaDonXuatDAO.LoadDataHoaDonVaKhach();
            anhd();
            btnLuuHD.Visible = false;
            btnLuuCTXH.Visible = false;
            LoadComboBox();
        }
        private void anhd()
        {
            txtDiaChi.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtSDT.ReadOnly = true;
            txtTenKhachHang.ReadOnly = true;
            txtTongTien.ReadOnly = true;
            txtDonGiaCTXH.ReadOnly = true;
            txtSoLuongCTXH.ReadOnly = true;
            txtThanhTien.ReadOnly = true;
            cboTenSanPham.Enabled = false;
        }
        private void hienhd()
        {
            txtDiaChi.ReadOnly = false;
            txtEmail.ReadOnly = false;
            txtSDT.ReadOnly = false;
            txtSearchHD.ReadOnly = false;
            txtTenKhachHang.ReadOnly = false;
            //txtTongTien.ReadOnly = false;
        }
        private void hienctx()
        {
            txtDonGiaCTXH.ReadOnly = false;
            txtSoLuongCTXH.ReadOnly = false;
            txtThanhTien.ReadOnly = true;
            cboTenSanPham.Enabled = true;
        }
        private void resettext()
        {
            txtTongTien.Text = "0";
            txtTenKhachHang.Text = "";
            txtSDT.Text = "";
            txtEmail.Text = "";
            txtDiaChi.Text = "";
            txtDonGiaCTXH.Text = "";
            txtSoLuongCTXH.Text = "";
            txtThanhTien.Text = "";
        }
        int maHoaDon = 0;
        private void dgvHoaDon_Click(object sender, EventArgs e)
        {
            DataGridViewRow dr = dgvHoaDon.SelectedRows[0];
            txtDiaChi.Text = dr.Cells["Địa chỉ"].Value.ToString();
            txtEmail.Text = dr.Cells["Email"].Value.ToString();
            txtSDT.Text = dr.Cells["Số điện thoại"].Value.ToString();
            txtTenKhachHang.Text = dr.Cells["Họ Tên"].Value.ToString();
            txtTongTien.Text = dr.Cells["Tổng tiền"].Value.ToString();
            dtpThoiGian.Text = dr.Cells["Ngày xuất hàng"].Value.ToString();
            int.TryParse(dr.Cells["Mã Xuất hàng"].Value.ToString(), out maHoaDon);
            dgvChiTietXuat.DataSource = ChiTietXuatDAO.LoadDataCTX(maHoaDon);
            btnLuuCTXH.Visible = false;
            btnLuuHD.Visible = false;

        }

        private void dgvChiTietXuat_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow dw = dgvChiTietXuat.SelectedRows[0];
                txtThanhTien.Text = dw.Cells["Thành tiền"].Value.ToString();
                cboTenSanPham.Text = dw.Cells["Tên hàng hóa"].Value.ToString();
                txtSoLuongCTXH.Text = dw.Cells["Số lượng"].Value.ToString();
                txtDonGiaCTXH.Text = dw.Cells["Đơn giá"].Value.ToString();
                txtThanhTien.Text = dw.Cells["Thành tiền"].Value.ToString();
            }
            catch
            {

            }
        }

        private void btnThemHD_Click(object sender, EventArgs e)
        {
            btnLuuHD.Visible = true;
            hienhd();
            txtTenKhachHang.Focus();
            resettext();
            kthd = 1;
        }

        private void btnLuuHD_Click(object sender, EventArgs e)
        {
            KhachHangDTO kh = new KhachHangDTO();
            HoaDonXuatDTO hdx = new HoaDonXuatDTO();
            int makh = 0;
            int mahd = 0;
            kh.HoTen = txtTenKhachHang.Text;
            kh.SDT = txtSDT.Text;
            kh.Email = txtEmail.Text;
            kh.DiaChi = txtDiaChi.Text;
            hdx.TongTien = "0";
            // khi phím bấm là phím thêm 
            if (kthd == 1)
            {

                int.TryParse(KhachHangDAO.LayIDKhachCuoi().Rows[0]["MaxMK"].ToString(), out makh);
                kh.MaKhachHang = makh + 1;
                hdx.MaKhachHang = makh + 1;
                hdx.NgayXuat = dtpThoiGian.Value;
                int.TryParse(HoaDonXuatDAO.LayMaxIDHD().Rows[0]["MaHDXuat"].ToString(), out mahd);
                hdx.MaHDXuat = mahd + 1;
                try
                {
                    KhachHangDAO.ThemKH(kh);
                    HoaDonXuatDAO.ThemHD(hdx);
                }
                catch
                {
                    MessageBox.Show("Có lỗi chưa thêm được mời làm lại ");
                }
            }
            // khi bấm phím sửa
            if (kthd == 2)
            {
                DataGridViewRow dr = dgvHoaDon.SelectedRows[0];
                int.TryParse(dr.Cells["Mã khách"].Value.ToString(), out makh);
                kh.MaKhachHang = makh;
                int.TryParse(dr.Cells["Mã Xuất hàng"].Value.ToString(), out mahd);
                hdx.MaHDXuat = mahd;
                try
                {
                    KhachHangDAO.SuaKH(kh);
                    HoaDonXuatDAO.SuaHD(hdx);
                }
                catch
                {
                    MessageBox.Show("Chưa sửa được mời làm lại ");
                }
            }
            anhd();
            btnLuuHD.Visible = false;
            dgvHoaDon.DataSource = HoaDonXuatDAO.LoadDataHoaDonVaKhach();
            resettext();
            kthd = 0;
        }

        private void btnSuaHD_Click(object sender, EventArgs e)
        {
            kthd = 2;
            txtTenKhachHang.Focus();
            btnLuuHD.Visible = true;
            hienhd();
        }

        private void btnXoaHD_Click(object sender, EventArgs e)
        {
            KhachHangDTO kh = new KhachHangDTO();
            HoaDonXuatDTO hdx = new HoaDonXuatDTO();
            int makh = 0;
            int mahd = 0;
            DataGridViewRow dr = dgvHoaDon.SelectedRows[0];
            int.TryParse(dr.Cells["Mã khách"].Value.ToString(), out makh);
            kh.MaKhachHang = makh;
            int.TryParse(dr.Cells["Mã Xuất hàng"].Value.ToString(), out mahd);
            hdx.MaHDXuat = mahd;
            if(DialogResult.Yes == MessageBox.Show("Bạn chắc không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                try
                {
                    KhachHangDAO.XoaKH(kh);
                    HoaDonXuatDAO.XoaHD(hdx);
                    MessageBox.Show("Bạn đã xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);    
                }
                catch
                {
                    MessageBox.Show("Chưa xóa được mời làm lại ");
                }
            }
            
            dgvHoaDon.DataSource = HoaDonXuatDAO.LoadDataHoaDonVaKhach();
        }

        private void btnSearchHD_Click(object sender, EventArgs e)
        {
            string gt = txtSearchHD.Text;
            dgvHoaDon.DataSource = HoaDonXuatDAO.Search(gt);
        }
        public void LoadComboBox()
        {
            cboTenSanPham.DataSource = HangHoaDAO.LoadDataHangHoa();
            cboTenSanPham.ValueMember = "MaHangHoa";
            cboTenSanPham.DisplayMember = "TenHang";
        }

        private void btnThemCTXH_Click(object sender, EventArgs e)
        {
            btnLuuCTXH.Visible = true;
            ktctx = 1;
            hienctx();
        }

        private void btnLuuCTXH_Click(object sender, EventArgs e)
        {
            ChiTietXuatDTO ctx = new ChiTietXuatDTO();
            int dongia = 0;
            int soluong = 0;
            int.TryParse(txtDonGiaCTXH.Text, out dongia);
            int.TryParse(txtSoLuongCTXH.Text, out soluong);
            ctx.DonGia = dongia;
            ctx.SoLuong = soluong;
            ctx.MaHangHoa = (int)cboTenSanPham.SelectedValue;
            ctx.MaHDXuat = maHoaDon;
            // trường hợp bấm phím thêm
            if (ktctx == 1)
            {
                try
                {
                    ChiTietXuatDAO.ThemCTX(ctx);
                }
                catch
                {

                    try
                    {
                        int soluongcon = 0;
                        int.TryParse(ChiTietXuatDAO.TinhSoLuong(ctx).Rows[0]["SoLuong"].ToString(), out soluongcon);
                        ctx.SoLuong += soluongcon;
                        ChiTietXuatDAO.SuaCTX(ctx);
                    }
                    catch
                    {
                        MessageBox.Show("Có lỗi không thêm được");
                    }


                }

            }


            // trường hợp bấm phím sửa
            if (ktctx == 2)
            {
                try
                {
                    ChiTietXuatDAO.SuaCTX(ctx);
                }
                catch
                {
                    MessageBox.Show("Lỗi chưa sửa được");
                }
            }


            anhd();
            btnLuuCTXH.Visible = false;
            dgvHoaDon.DataSource = HoaDonXuatDAO.LoadDataHoaDonVaKhach();
            dgvChiTietXuat.DataSource = ChiTietXuatDAO.LoadDataCTX(maHoaDon);
            resettext();
            ktctx = 0;



        }

        private void cboTenSanPham_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                int mahh = 0;
                //DataGridViewRow dr = dgvChiTietXuat.SelectedRows[0];
                int.TryParse(cboTenSanPham.SelectedValue.ToString(), out mahh);
                DataTable t = ChiTietXuatDAO.TinhDonGia(mahh);
               // int.TryParse(cboTenSanPham.SelectedValue.ToString(), out mahh);
                txtDonGiaCTXH.Text = t.Rows[0]["GiaXuat"].ToString();
            }
            catch
            {

            }
        }

        private void btnSuaCTXH_Click(object sender, EventArgs e)
        {
            ktctx = 2;
            btnLuuCTXH.Visible = true;
            hienctx();
            cboTenSanPham.Enabled = false;
            txtDonGiaCTXH.Focus();
        }

        private void btnXoaCTXH_Click(object sender, EventArgs e)
        {
            ChiTietXuatDTO ctx = new ChiTietXuatDTO();
            ctx.MaHangHoa = (int)cboTenSanPham.SelectedValue;
            ctx.MaHDXuat = maHoaDon;
            try
            {
                ChiTietXuatDAO.XoaCTX(ctx);
            }
            catch
            {
                MessageBox.Show("Chưa xóa được!");
            }
            dgvHoaDon.DataSource = HoaDonXuatDAO.LoadDataHoaDonVaKhach();
            dgvChiTietXuat.DataSource = ChiTietXuatDAO.LoadDataCTX(maHoaDon);
            resettext();
        }
    }
}
