using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class HangHoaDTO
    {
        private int _maHangHoa;
        public int MaHangHoa
        {
            get { return _maHangHoa; }
            set { _maHangHoa = value; }
        }
        private string _tenHang;
        public string TenHang
        {
            get { return _tenHang; }
            set { _tenHang = value; }
        }
        private int _soLuong;
        public int SoLuong
        {
            get { return _soLuong; }
            set { _soLuong = value; }
        }
        private int _giaNhap;
        public int GiaNhap
        {
            get { return _giaNhap; }
            set { _giaNhap = value; }
        }
        private int _giaXuat;
        public int GiaXuat
        {
            get { return _giaXuat; }
            set { _giaXuat = value; }
        }
        private string _ghiChu;
        public string GhiChu
        {
            get { return _ghiChu; }
            set { _ghiChu = value; }
        }
    }
}
