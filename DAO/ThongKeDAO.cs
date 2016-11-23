using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DAO
{
    // thong ke luong tien xuat nhap hang thang
    // thong ke mat hang xuat nhieu nhat
    // thong ke mat hang nhap nhieu nhat

    public class ThongKeDAO
    {
        public static SqlConnection con;
        // hang hoa xuat nhieu nhat theo thang 
        public static DataTable TongTienXuatTungThang(int nam)
        {
            string sTruyVan = string.Format(@"select Thang=MONTH(tblHoaDonXuat.NgayXuat) ,TongTien = sum( tblChiTietXuat.SoLuong* tblChiTietXuat.DonGia) from tblChiTietXuat, tblHoaDonXuat, tblHangHoa
            where tblChiTietXuat.MaHDXuat = tblHoaDonXuat.MaHDXuat and tblHangHoa.MaHangHoa = tblChiTietXuat.MaHangHoa and YEAR(tblHoaDonXuat.NgayXuat) = {0}
            group by MONTH(tblHoaDonXuat.NgayXuat)", nam);
            con = DataProvider.KetNoi();
            DataTable dt = DataProvider.LayDataTable(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return dt;
        }

        public static string HangHoaXuatNhieuItNhatNam(int nam)
        {
            string sTruyVan = string.Format(@"select tblHangHoa.TenHang ,TongTien = sum( tblChiTietXuat.SoLuong* tblChiTietXuat.DonGia) from tblChiTietXuat, tblHoaDonXuat, tblHangHoa where  tblChiTietXuat.MaHDXuat = tblHoaDonXuat.MaHDXuat and tblHangHoa.MaHangHoa = tblChiTietXuat.MaHangHoa and YEAR(tblHoaDonXuat.NgayXuat) = {0}
            group by tblHangHoa.TenHang", nam);
            con = DataProvider.KetNoi();
            DataTable dt = DataProvider.LayDataTable(sTruyVan, con);
            int min = int.MaxValue;
            int max = int.MinValue;
            string hangmin = "";
            string hangmax = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (min > int.Parse(dt.Rows[i][1].ToString()))
                {
                    min = int.Parse(dt.Rows[i][1].ToString());
                    hangmin = dt.Rows[i][0].ToString();
                }
                if (max < int.Parse(dt.Rows[i][1].ToString()))
                {
                    max = int.Parse(dt.Rows[i][1].ToString());
                    hangmax = dt.Rows[i][0].ToString();
                }    
            }
            return hangmin + "|" + hangmax;

        }
        public static DataTable TongTienNhapTungThang(int nam)
        {
            string sTruyVan = string.Format(@"select Thang=MONTH(tblHoaDonNhap.NgayNhap) ,TongTien = sum( tblChiTietNhap.SoLuong* tblChiTietNhap.DonGia) from tblChiTietNhap, tblHoaDonNhap, tblHangHoa
            where tblChiTietNhap.MaHDNhap = tblHoaDonNhap.MaHDNhap and tblHangHoa.MaHangHoa = tblChiTietNhap.MaHangHoa and YEAR(tblHoaDonNhap.NgayNhap) = {0}
            group by MONTH(tblHoaDonNhap.NgayNhap)", nam);
            con = DataProvider.KetNoi();
            DataTable dt = DataProvider.LayDataTable(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return dt;
        }
        public static string HangHoaNhapNhieuItNhatNam(int nam)
        {
            string sTruyVan = string.Format(@"select tblHangHoa.TenHang ,TongTien = sum( tblChiTietNhap.SoLuong* tblChiTietNhap.DonGia) from tblChiTietNhap, tblHoaDonNhap, tblHangHoa where  tblChiTietNhap.MaHDNhap = tblHoaDonNhap.MaHDNhap and tblHangHoa.MaHangHoa = tblChiTietNhap.MaHangHoa and YEAR(tblHoaDonNhap.NgayNhap) = {0}
            group by tblHangHoa.TenHang", nam);
            con = DataProvider.KetNoi();
            DataTable dt = DataProvider.LayDataTable(sTruyVan, con);
            int min = int.MaxValue;
            int max = int.MinValue;
            string hangmin = "";
            string hangmax = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (min > int.Parse(dt.Rows[i][1].ToString()))
                {
                    min = int.Parse(dt.Rows[i][1].ToString());
                    hangmin = dt.Rows[i][0].ToString();
                }
                if (max < int.Parse(dt.Rows[i][1].ToString()))
                {
                    max = int.Parse(dt.Rows[i][1].ToString());
                    hangmax = dt.Rows[i][0].ToString();
                }
            }
            return hangmin + "|" + hangmax;
        }
    }
}
