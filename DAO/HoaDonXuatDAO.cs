using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTO;
namespace DAO
{
    public class HoaDonXuatDAO
    {
        public static SqlConnection con;

        public static DataTable LoadDataHD()
        {
            string sTruyVan = "select * from tblHoaDonXuat";
            con = DataProvider.KetNoi();
            DataTable dt = DataProvider.LayDataTable(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return dt;
        }

        public static bool ThemHD(HoaDonXuatDTO hd)
        {
            try
            {
                string sTruyVan = string.Format("Insert into tblHoaDonXuat(MaHDXuat,NgayXuat,TongTien,MaKhachHang ) values ({0},'{1}',N'{2}','{3}')", hd.MaHDXuat, hd.NgayXuat, hd.TongTien, hd.MaKhachHang);
                con = DataProvider.KetNoi();
                DataTable dt = DataProvider.LayDataTable(sTruyVan, con);
                DataProvider.DongKetNoi(con);
                return true;
            }

            catch
            {
                return false;
            }
        }

        public static bool SuaHD(HoaDonXuatDTO hd)
        {
            try
            {
                con = DataProvider.KetNoi();
                string sTruyVan = string.Format("Update tblHoaDonXuat set NgayXuat = N'{0}',TongTien=N'{1}',MaKhachHang = '{2}'where MaHDXuat={3}", hd.NgayXuat, hd.TongTien, hd.MaKhachHang, hd.MaHDXuat);
                DataProvider.ThucThiTruyVan(sTruyVan, con);
                DataProvider.DongKetNoi(con);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool XoaHD(HoaDonXuatDTO hd)
        {
            try
            {
                con = DataProvider.KetNoi();
                string sTruyVan = string.Format(" Delete tblChiTietXuat where MaHDXuat ={0} Delete tblHoaDonXuat where MaHDXuat={1}", hd.MaHDXuat,hd.MaHDXuat);
                DataProvider.ThucThiTruyVan(sTruyVan, con);
                DataProvider.DongKetNoi(con);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static DataTable LoadDataHoaDonVaKhach()
        {
            string sTruyVan = "select hd.MaHDXuat N'Mã Xuất hàng', hd.NgayXuat N'Ngày xuất hàng', kh.MaKhachHang N'Mã khách', kh.HoTen N'Họ Tên', kh.DiaChi N'Địa chỉ', kh.Email , kh.SDT N'Số điện thoại', hd.TongTien N'Tổng tiền' from tblHoaDonXuat hd ,tblKhachHang kh where hd.MaKhachHang =kh.MaKhachHang";
            con = DataProvider.KetNoi();
            DataTable dt = DataProvider.LayDataTable(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return dt;
        }
        public static DataTable LayMaxIDHD()
        {
            string sTruyVan = "select max(MaHDXuat) MaHDXuat from tblHoaDonXuat";
            con = DataProvider.KetNoi();
            DataTable dt = DataProvider.LayDataTable(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return dt;
        }

        public static DataTable Search(string gt)
        {
            string sTruyVan = string.Format("select hd.MaHDXuat N'Mã Xuất hàng', hd.NgayXuat N'Ngày xuất hàng', kh.MaKhachHang N'Mã khách', kh.HoTen N'Họ Tên', kh.DiaChi N'Địa chỉ', kh.Email, kh.SDT N'Số điện thoại', hd.TongTien N'Tổng tiền' from tblHoaDonXuat hd , tblKhachHang kh where hd.MaKhachHang = kh.MaKhachHang and (kh.HoTen like N'%{0}%' or kh.DiaChi like N'%{1}%' or kh.Email like N'%{2}%')", gt, gt, gt);
            con = DataProvider.KetNoi();
            DataTable dt = DataProvider.LayDataTable(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return dt;
        }

    }
}
