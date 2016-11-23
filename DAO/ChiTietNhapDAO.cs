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
   public class ChiTietNhapDAO
    {
        public static SqlConnection con;

        public static int IDMax()
        {
            string sTruyVan = "select Max(MaHangHoa) from tblHangHoa";
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
        public static bool them(ChiTietNhapDTO hh)
        {
            string sTruyVan = string.Format("insert into tblChiTietNhap values ({0},{1},{2},{3})", hh.MaHDNhap, hh.MaHangHoa, hh.SoLuong, hh.DonGia);
            con = DataProvider.KetNoi();
            DataProvider.ThucThiTruyVan(sTruyVan, con);
            string s = string.Format("update tblHangHoa set GiaNhap={0},GiaXuat={1},GhiChu=N'{2}' where MaHangHoa={3}", hh.DonGia, hh.GiaXuat, hh.GhiChu, hh.MaHangHoa);
            DataProvider.ThucThiTruyVan(s, con);
            string s1 = string.Format("update tblHangHoa set SoLuong=A from (select Sum(SoLuong)A from tblChiTietNhap where MaHangHoa={0})A where MaHangHoa={0}", hh.MaHangHoa);
            DataProvider.ThucThiTruyVan(s1, con);
            DataProvider.DongKetNoi(con);
            return true;
        }

        public static bool themmoi(ChiTietNhapDTO hh)
        {
            string s = string.Format("insert into tblHangHoa values ({0},N'{1}',{2},{3},{4},N'{5}')", hh.MaHangHoa, hh.TenHang, hh.SoLuong, hh.DonGia, hh.GiaXuat, hh.GhiChu);
            con = DataProvider.KetNoi();
            DataProvider.ThucThiTruyVan(s, con);
            string sTruyVan = string.Format("insert into tblChiTietNhap values ({0},{1},{2},{3})", hh.MaHDNhap, hh.MaHangHoa, hh.SoLuong, hh.DonGia);
            DataProvider.ThucThiTruyVan(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return true;
        }

        public static bool SuaCT(ChiTietNhapDTO hh)
        {
            string sTruyVan = string.Format("update tblChiTietNhap set SoLuong={0},DonGia={1} where MaHDNhap={2} and MaHangHoa={3}", hh.SoLuong, hh.DonGia, hh.MaHDNhap, hh.MaHangHoa);
            con = DataProvider.KetNoi();
            DataProvider.ThucThiTruyVan(sTruyVan, con);
            string s = string.Format("update tblHangHoa set GiaNhap={0},GiaXuat={1},GhiChu=N'{2}' where MaHangHoa={3}", hh.DonGia, hh.DonGia * 1.15, hh.GhiChu, hh.MaHangHoa);
            DataProvider.ThucThiTruyVan(s, con);
            string s1 = string.Format("update tblHangHoa set SoLuong=A from (select Sum(SoLuong)A from tblChiTietNhap where MaHangHoa={0})A where MaHangHoa={0}", hh.MaHangHoa);
            DataProvider.ThucThiTruyVan(s1, con);
            DataProvider.DongKetNoi(con);
            return true;
        }

        public static bool Xoa(ChiTietNhapDTO ct)
        {
            string sTruyVan = string.Format("update tblHangHoa set SoLuong=SoLuong-{0} where MaHangHoa={1}", ct.SoLuong, ct.MaHangHoa);
            con = DataProvider.KetNoi();
            DataProvider.ThucThiTruyVan(sTruyVan, con);
            string s = string.Format("delete tblChiTietNhap where MaHDNhap={0} and MaHangHoa={1}", ct.MaHDNhap, ct.MaHangHoa);
            DataProvider.ThucThiTruyVan(s, con);
            DataProvider.DongKetNoi(con);
            return true;
        }
    }
}
