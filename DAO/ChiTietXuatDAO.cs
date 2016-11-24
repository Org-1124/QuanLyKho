using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTO;
namespace DAO
{
    public class ChiTietXuatDAO
    {
        public static SqlConnection con;

        public static DataTable LoadDataCTX(int hdx)
        {
            string sTruyVan = string.Format("select ctx.MaHDXuat N'Mã hóa đơn', ctx.MaHangHoa N'Mã hàng hóa',hh.TenHang N'Tên hàng hóa', ctx.SoLuong N'Số lượng', ctx.DonGia N'Đơn giá', ctx.SoLuong*ctx.DonGia N'Thành tiền' from tblChiTietXuat ctx, tblHangHoa hh where MaHDXuat={0} and hh.MaHangHoa=ctx.MaHangHoa", hdx);
            con = DataProvider.KetNoi();
            DataTable dt = DataProvider.LayDataTable(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return dt;
        }

        public static bool ThemCTX(ChiTietXuatDTO ctx)
        {

            string sTruyVan = string.Format("Insert into tblChiTietXuat(MaHDXuat,MaHangHoa,SoLuong,DonGia) values ({0},'{1}','{2}','{3}') update tblHoaDonXuat set TongTien = TongTien + {4}*{5} where MaHDXuat={6}", ctx.MaHDXuat, ctx.MaHangHoa, ctx.SoLuong, ctx.DonGia,ctx.SoLuong,ctx.DonGia,ctx.MaHDXuat);
            con = DataProvider.KetNoi();
            DataTable dt = DataProvider.LayDataTable(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return true;

        }

        public static bool SuaCTX(ChiTietXuatDTO ctx)
        {
            try
            {
                con = DataProvider.KetNoi();
                string sTruyVan = string.Format("Update tblChiTietXuat set SoLuong='{0}',DonGia = '{1}' where MaHDXuat={2} and MaHangHoa = '{3}' update tblHoaDonXuat  set TongTien = TongTien+a.SoLuong*a.DonGia from(select ctx.SoLuong, ctx.DonGia from tblChiTietXuat ctx) a where tblHoaDonXuat.MaHDXuat ={4}", ctx.SoLuong, ctx.DonGia, ctx.MaHDXuat, ctx.MaHangHoa, ctx.MaHDXuat);
                DataProvider.ThucThiTruyVan(sTruyVan, con);
                DataProvider.DongKetNoi(con);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool XoaCTX(ChiTietXuatDTO ctx)
        {
            try
            {
                con = DataProvider.KetNoi();
                string sTruyVan = string.Format("Delete tblChiTietXuat where MaHangHoa={0} and MaHDXuat={1} ", ctx.MaHangHoa, ctx.MaHDXuat);
                DataProvider.ThucThiTruyVan(sTruyVan, con);
                DataProvider.DongKetNoi(con);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static DataTable TinhDonGia(int mahh)
        {
            string sTruyVan = string.Format("select * from tblHangHoa where MaHangHoa = '{0}'", mahh);
            con = DataProvider.KetNoi();
            DataTable dt = DataProvider.LayDataTable(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return dt;
        }

        public static DataTable TinhSoLuong(ChiTietXuatDTO ctx)
        {
            string sTruyVan = string.Format("select * from tblChiTietXuat where MaHangHoa = '{0}'and MaHDXuat={1}", ctx.MaHangHoa, ctx.MaHDXuat);
            con = DataProvider.KetNoi();
            DataTable dt = DataProvider.LayDataTable(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return dt;
        }
    }
}
