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
    public partial class frmNhapKho : Form
    {
        enum LuaChon
        {
            Them, Sua, Xoa, Luu
        }
        LuaChon lc;
        int x=0;
        public frmNhapKho()
        {
            InitializeComponent();
            btnLuu.Visible = false;
            btnHuy.Visible = false;
        }
        private void SuaHeaaderText()
        {
            dgvhoadonnhap.Columns["MaHDNhap"].HeaderText = "Mã Hóa Đơn";
            dgvhoadonnhap.Columns["NgayNhap"].HeaderText = "Ngày Nhập";
            dgvhoadonnhap.Columns["TenNhaCC"].HeaderText = "Nhà Cung Cấp";
            dgvhoadonnhap.Columns["DiaChi"].HeaderText = "Địa Chỉ";
            dgvhoadonnhap.Columns["SDT"].HeaderText = "Số Điện Thoại";
            dgvhoadonnhap.Columns["TongTien"].HeaderText = "Tổng Tiền";
        }
        private void LoadDuLieu()
        {
            dgvhoadonnhap.DataSource = HoaDonNhapDAO.LoadHoaDon();
            cboCC.DataSource = NhaCungCapDAO.LoadData();
            cboCC.ValueMember = "MaNhaCC";
            cboCC.DisplayMember = "TenNhaCC";
            ReadOnly();
        }
        private void LoadChiTiet(int t)
        {
            DataTable dt = HoaDonNhapDAO.LoadChiTiet(t);
            dgvchitiet.DataSource = dt;
            ReadOnly();
        }
        private void frmNhapKho_Load(object sender, EventArgs e)
        {
            LoadDuLieu();
            SuaHeaaderText();
        }

        private void dgvhoadonnhap_Click(object sender, EventArgs e)
        {
            if (x == 1) return;
            DataTable dt = HoaDonNhapDAO.LoadChiTiet(999999);
            dgvchitiet.DataSource = dt;
            DataGridViewRow dr = dgvhoadonnhap.SelectedRows[0];
            txtMaHD.Text = dr.Cells["MaHDNhap"].Value.ToString();
            txtTien.Text = dr.Cells["TongTien"].Value.ToString();
            cboCC.Text = dr.Cells["TenNhaCC"].Value.ToString();
            txtDiaChi.Text = dr.Cells["DiaChi"].Value.ToString();
            txtSDT.Text = dr.Cells["SDT"].Value.ToString();
            try { dateNhap.Value = DateTime.Parse(dr.Cells["NgayNhap"].Value.ToString()); }
            catch { dateNhap.Value = DateTimePicker.MinimumDateTime; }
            if(txtMaHD.Text!="") LoadChiTiet(int.Parse(txtMaHD.Text.ToString()));
        }
        private void AnButton()
        {
            btnLuu.Visible = true;
            btnHuy.Visible = true;
            btnThem.Visible = false;
            btnXoa.Visible = false;
            btnSua.Visible = false;
        }
        private void HienButton()
        {
            btnLuu.Visible = false;
            btnHuy.Visible = false;
            btnThem.Visible = true;
            btnXoa.Visible = true;
            btnSua.Visible = true;
        }
        private void UnReadOnly()
        {
            cboCC.Enabled = true;
            dateNhap.Enabled = true;
            dgvchitiet.ReadOnly =false;
        }
        private void ReadOnly()
        {
            cboCC.Enabled = false;
            dateNhap.Enabled = false;
            dgvchitiet.ReadOnly = true;
        }
        private void Xoatxt()
        {
            txtMaHD.Text = "";
            txtTien.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            cboCC.Text = null;
        }
        
        private void btnThem_Click(object sender, EventArgs e)
        {
            Xoatxt();
            x = 1;
            dgvchitiet.ReadOnly = false;
            DataTable dt = HoaDonNhapDAO.LoadChiTiet(999999);
            dgvchitiet.DataSource = dt;
            txtMaHD.Text = (HoaDonNhapDAO.MaxID() + 1).ToString();
            lc = LuaChon.Them;
            AnButton();
            UnReadOnly();
            dgvchitiet.AllowUserToAddRows = true;
        }
        private void Them()
        {
            HoaDonNhapDTO hd = new HoaDonNhapDTO();
            hd.MaHDNhap = int.Parse(txtMaHD.Text.ToString());
            hd.NgayNhap = dateNhap.Value.ToShortDateString();
            hd.MaNhaCC = (int)cboCC.SelectedValue;
            hd.TongTien = 0;
            HoaDonNhapDAO.them(hd);
            ChiTietNhapDTO hh = new ChiTietNhapDTO();
            hh.MaHDNhap = int.Parse(txtMaHD.Text.ToString());
            for(int i=0;i<dgvchitiet.RowCount-1;i++)
            {
                hh.TenHang = dgvchitiet.Rows[i].Cells[2].Value.ToString();
                hh.SoLuong = int.Parse(dgvchitiet.Rows[i].Cells[3].Value.ToString());
                hh.DonGia = int.Parse(dgvchitiet.Rows[i].Cells[4].Value.ToString());
                hh.GiaXuat = int.Parse(dgvchitiet.Rows[i].Cells[4].Value.ToString())*2;
                try { hh.GhiChu = dgvchitiet.Rows[i].Cells[0].Value.ToString(); }
                catch { }
                DataTable dt=HoaDonNhapDAO.TimHangHoa(hh.TenHang);
                try
                {
                    hh.MaHangHoa = int.Parse(dt.Rows[0][0].ToString());
                    ChiTietNhapDAO.them(hh);
                }
                catch
                {
                    hh.MaHangHoa = ChiTietNhapDAO.IDMax() + 1;
                    ChiTietNhapDAO.themmoi(hh);
                }
            }
            HoaDonNhapDAO.UpdateTongTien(hh);
        }

        private bool kiemtra()
        {
            try
            {
                string s = cboCC.SelectedValue.ToString();
            }
            catch
            {
                return false;
            }
            try
            {
                string s1 = dgvchitiet.Rows[0].Cells[2].Value.ToString();
                string s2 = dgvchitiet.Rows[0].Cells[3].Value.ToString();
                string s3 = dgvchitiet.Rows[0].Cells[4].Value.ToString();
                if (s1 == "") return false;
                else if (s2 == "") return false;
                else if (s3 == "") return false;
            }
            catch
            {
                return false;
            }
            return true;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            DataTable dt = HoaDonNhapDAO.LoadChiTiet(999999);
            switch (lc)
            {
                case LuaChon.Them:
                    if (kiemtra() == false)
                    {
                        MessageBox.Show("Bạn cần nhập đủ thông tin");
                        return;
                    }
                    Them();
                    LoadDuLieu();
                    Xoatxt();
                    dgvchitiet.DataSource = dt;
                    break;
                case LuaChon.Sua:
                    if (kiemtra() == false)
                    {
                        MessageBox.Show("Bạn cần nhập đủ thông tin");
                        return;
                    }
                    Sua();
                    LoadDuLieu();
                    break;
                case LuaChon.Xoa:
                    Xoa();
                    LoadDuLieu();
                    Xoatxt();
                    dgvchitiet.DataSource = dt;
                    break;

            }
            HienButton();
            ReadOnly();
            x = 0;
            dgvchitiet.AllowUserToAddRows = false;
        }

        private void cboCC_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataTable dt = NhaCungCapDAO.LoadData1((int)cboCC.SelectedValue);
            txtDiaChi.Text = dt.Rows[0][2].ToString();
            txtSDT.Text = dt.Rows[0][3].ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaHD.Text== "")
            {
                MessageBox.Show("Bạn chưa chọn hóa đơn");
                return;
            }
            x = 2;
            dgvchitiet.ReadOnly = false;
            lc = LuaChon.Sua;
            AnButton();
            UnReadOnly();
            dgvchitiet.AllowUserToAddRows = true;
        }
        private void Sua()
        {
            HoaDonNhapDTO hd = new HoaDonNhapDTO();
            hd.MaHDNhap = int.Parse(txtMaHD.Text.ToString());
            hd.NgayNhap = dateNhap.Value.ToShortDateString();
            hd.MaNhaCC = (int)cboCC.SelectedValue;
            hd.TongTien = 0;
            HoaDonNhapDAO.sua(hd);
            ChiTietNhapDTO hh = new ChiTietNhapDTO();
            hh.MaHDNhap = int.Parse(txtMaHD.Text.ToString());
            for (int i = 0; i < dgvchitiet.RowCount - 1; i++)
            {
                hh.TenHang = dgvchitiet.Rows[i].Cells[2].Value.ToString();
                hh.SoLuong = int.Parse(dgvchitiet.Rows[i].Cells[3].Value.ToString());
                hh.DonGia = int.Parse(dgvchitiet.Rows[i].Cells[4].Value.ToString());
                hh.GiaXuat = int.Parse(dgvchitiet.Rows[i].Cells[4].Value.ToString()) * 2;
                try { hh.GhiChu = dgvchitiet.Rows[i].Cells[0].Value.ToString(); }
                catch { }
                DataTable dt = HoaDonNhapDAO.TimHangHoa(hh.TenHang);
                try
                {
                    hh.MaHangHoa = int.Parse(dt.Rows[0][0].ToString());
                    ChiTietNhapDAO.SuaCT(hh);
                }
                catch
                {
                    hh.MaHangHoa = ChiTietNhapDAO.IDMax() + 1;
                    ChiTietNhapDAO.themmoi(hh);
                }
                HoaDonNhapDAO.UpdateTongTien(hh);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaHD.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn hóa đơn");
                return;
            }
            x = 1;
            lc = LuaChon.Xoa;
            AnButton();
        }
        private void Xoa()
        {
            HoaDonNhapDTO hd = new HoaDonNhapDTO();
            ChiTietNhapDTO ct = new ChiTietNhapDTO();
            ct.MaHDNhap = int.Parse(txtMaHD.Text.ToString());
            hd.MaHDNhap = int.Parse(txtMaHD.Text.ToString());
            for (int i = 0; i < dgvchitiet.RowCount - 1; i++)
            {
                DataTable dt = HoaDonNhapDAO.TimHangHoa(dgvchitiet.Rows[i].Cells[2].Value.ToString());
                try
                {
                    ct.SoLuong = int.Parse(dgvchitiet.Rows[i].Cells[3].Value.ToString());
                    ct.MaHangHoa = int.Parse(dt.Rows[0][0].ToString());
                    ChiTietNhapDAO.Xoa(ct);
                }
                catch { }
            }
            HoaDonNhapDAO.Xoa(hd);
        }
        private void dgvchitiet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if(x==1)
                {
                    try { dgvchitiet.Rows.RemoveAt(e.RowIndex); }
                    catch { }
                    return;
                }
                ChiTietNhapDTO hh = new ChiTietNhapDTO();
                hh.TenHang = dgvchitiet.Rows[e.RowIndex].Cells[2].Value.ToString();
                hh.MaHDNhap = int.Parse(txtMaHD.Text.ToString());
                DataTable dt = HoaDonNhapDAO.TimHangHoa(hh.TenHang);
                try
                {
                    hh.SoLuong = int.Parse(dgvchitiet.Rows[e.RowIndex].Cells[3].Value.ToString());
                    hh.MaHangHoa = int.Parse(dt.Rows[0][0].ToString());
                    ChiTietNhapDAO.Xoa(hh);
                    LoadChiTiet(int.Parse(txtMaHD.Text.ToString()));
                    HoaDonNhapDTO hd = new HoaDonNhapDTO();
                    hd.MaHDNhap = int.Parse(txtMaHD.Text.ToString());
                }
                catch
                {
                    try { dgvchitiet.Rows.RemoveAt(e.RowIndex); }
                    catch { }
                }
            }
            else
            {
                return;
            }
        }
        
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            dgvhoadonnhap.DataSource = HoaDonNhapDAO.TimHoaDon(txtTimKiem.Text);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            btnTimKiem_Click(sender, e);
        }

        private void dgvchitiet_CellErrorTextChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3) MessageBox.Show("sdf");
            if (e.ColumnIndex == 2) MessageBox.Show("sdf");
            if (e.ColumnIndex == 4) MessageBox.Show("sdf");
        }

        private void btnHuy_Click_1(object sender, EventArgs e)
        {
            Xoatxt();
            HienButton();
            ReadOnly();
            DataTable dt = HoaDonNhapDAO.LoadChiTiet(999999);
            dgvchitiet.DataSource = dt;
            dgvchitiet.AllowUserToAddRows = false;
            x = 0;
        }

    }
}
