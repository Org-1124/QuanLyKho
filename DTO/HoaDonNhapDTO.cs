using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDonNhapDTO
    {
        private int _MaHDNhap;
        public int MaHDNhap
        {
            get { return _MaHDNhap; }
            set { _MaHDNhap = value; }
        }

        private string _NgayNhap;
        public string NgayNhap
        {
            get { return _NgayNhap; }
            set { _NgayNhap = value; }
        }

        private int _TongTien;
        public int TongTien
        {
            get { return _TongTien; }
            set { _TongTien = value; }
        }

        private int _MaNhaCC;
        public int MaNhaCC
        {
            get { return _MaNhaCC; }
            set { _MaNhaCC = value; }
        }
    }
}
