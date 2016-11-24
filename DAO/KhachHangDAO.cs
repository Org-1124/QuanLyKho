using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTO;
namespace DAO
{
    public class KhachHangDAO
    {
        public static SqlConnection con;

        public static DataTable LoadDataKH()
        {
            string sTruyVan = "select * from tblKhachHang ";
            con = DataProvider.KetNoi();
            DataTable dt = DataProvider.LayDataTable(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return dt;
        }

        public static bool ThemKH(KhachHangDTO kh)
        {
            try
            {
                string sTruyVan = string.Format("Insert into tblKhachHang(MaKhachHang,HoTen,DiaChi,Email,SDT) values ({0},N'{1}',N'{2}',N'{3}',N'{4}')", kh.MaKhachHang, kh.HoTen, kh.DiaChi, kh.Email, kh.SDT);
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

        public static bool SuaKH(KhachHangDTO kh)
        {
            try
            {
                con = DataProvider.KetNoi();
                string sTruyVan = string.Format("Update tblKhachHang set HoTen = N'{0}',DiaChi='{1}',Email = N'{2}', SDT=N'{3}'where MaKhachHang={4}", kh.HoTen, kh.DiaChi, kh.Email, kh.SDT, kh.MaKhachHang);
                DataProvider.ThucThiTruyVan(sTruyVan, con);
                DataProvider.DongKetNoi(con);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool XoaKH(KhachHangDTO kh)
        {
            try
            {
                con = DataProvider.KetNoi();
                string sTruyVan = string.Format("Delete tblKhachHang where MaKhachHang={0} ", kh.MaKhachHang);
                DataProvider.ThucThiTruyVan(sTruyVan, con);
                DataProvider.DongKetNoi(con);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static DataTable LayIDKhachCuoi()
        {
            string sTruyVan = "select max(MaKhachHang) MaxMK from tblKhachHang ";
            con = DataProvider.KetNoi();
            DataTable dt = DataProvider.LayDataTable(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return dt;
        }
    }
}
