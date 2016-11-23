using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DTO;

namespace DAO
{
    public class HoaDonNhapDAO
    {
        public static SqlConnection con;
        public static DataTable LoadHoaDon()
        {
            string sTruyVan = "select MaHDNhap, NgayNhap, TenNhaCC, DiaChi, SDT, TongTien from tblHoaDonNhap a, tblNhaCungCap b where a.MaNhaCC=b.MaNhaCC";
            con = DataProvider.KetNoi();
            DataTable dt = DataProvider.LayDataTable(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return dt;
        }

        public static int MaxID()
        {
            string sTruyVan = "select Max(MaHDNhap) from tblHoaDonNhap";
            con = DataProvider.KetNoi();
            DataTable dt = DataProvider.LayDataTable(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            try
            {
                return int.Parse(dt.Rows[0][0].ToString());
            }
            catch
            {
                return 0;
            }

        }


        public static DataTable LoadChiTiet(int t)
        {
            string sTruyVan = string.Format("select TenHang, a.SoLuong, DonGia from tblChiTietNhap a, tblHangHoa b where a.MaHangHoa=b.MaHangHoa and a.MaHDNhap={0}", t);
            DataProvider.KetNoi();
            DataTable dt = DataProvider.LayDataTable(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return dt;
        }

        public static bool them(HoaDonNhapDTO hd)
        {
            string sTruyVan = string.Format("insert into tblHoaDonNhap values ({0},'{1}',{2},{3})", hd.MaHDNhap, hd.NgayNhap, hd.TongTien, hd.MaNhaCC);
            con = DataProvider.KetNoi();
            DataProvider.ThucThiTruyVan(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return true;
        }

        public static DataTable TimHangHoa(string p)
        {
            string sTruyVan = string.Format("select *from tblHangHoa where TenHang=N'{0}'", p);
            DataProvider.KetNoi();
            DataTable dt = DataProvider.LayDataTable(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return dt;
        }

        public static bool sua(HoaDonNhapDTO hd)
        {
            string sTruyVan = string.Format("update tblHoaDonNhap set NgayNhap='{0}',MaNhaCC={1} where MaHDNhap={2}", hd.NgayNhap, hd.MaNhaCC, hd.MaHDNhap);
            con = DataProvider.KetNoi();
            DataProvider.ThucThiTruyVan(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return true;
        }

        public static bool UpdateTongTien(ChiTietNhapDTO hh)
        {
            string sTruyVan = string.Format("update tblHoaDonNhap set TongTien=(select sum(SoLuong*DonGia) from tblChiTietNhap a where a.MaHDNhap={0}) where MaHDNhap={0}", hh.MaHDNhap);
            con = DataProvider.KetNoi();
            DataProvider.ThucThiTruyVan(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return true;
        }

        public static bool Xoa(HoaDonNhapDTO hd)
        {
            string sTruyVan = string.Format("delete tblHoaDonNhap where MaHDNhap={0}", hd.MaHDNhap);
            con = DataProvider.KetNoi();
            DataProvider.ThucThiTruyVan(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return true;
        }

        public static DataTable TimHoaDon(string p)
        {
            string sTruyVan = string.Format("select a.MaHDNhap,NgayNhap,TenNhaCC,DiaChi,SDT,TongTien from tblHoaDonNhap a,tblNhaCungCap b where a.MaNhaCC=b.MaNhaCC and (b.TenNhaCC like '%{0}%' or DiaChi like '%{0}%' or SDT like '%{0}%')", p);
            con = DataProvider.KetNoi();
            DataTable dt = DataProvider.LayDataTable(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return dt;
        }
    }
}
