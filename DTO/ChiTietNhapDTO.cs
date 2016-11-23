using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietNhapDTO
    {
        private int _MaHDNhap;
        public int MaHDNhap
        {
            get { return _MaHDNhap; }
            set { _MaHDNhap = value; }
        }

        private int _MaHangHoa;
        public int MaHangHoa
        {
            get { return _MaHangHoa; }
            set { _MaHangHoa = value; }
        }

        private int _SoLuong;
        public int SoLuong
        {
            get { return _SoLuong; }
            set { _SoLuong = value; }
        }

        private int _DonGia;
        public int DonGia
        {
            get { return _DonGia; }
            set { _DonGia = value; }
        }

        private string _TenHang;
        public string TenHang
        {
            get { return _TenHang; }
            set { _TenHang = value; }
        }
        private string _GhiChu;
        public string GhiChu
        {
            get { return _GhiChu; }
            set { _GhiChu = value; }
        }

        private int _GiaXuat;
        public int GiaXuat
        {
            get { return _GiaXuat; }
            set { _GiaXuat = value; }
        }
    }
}
