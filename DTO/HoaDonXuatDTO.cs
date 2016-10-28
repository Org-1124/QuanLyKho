using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDonXuatDTO
    {
        private int _maHDXuat;
        public int MaHDXuat
        {
            get { return _maHDXuat; }
            set { _maHDXuat = value; }
        }
        private DateTime _ngayXuat;
        public System.DateTime NgayXuat
        {
            get { return _ngayXuat; }
            set { _ngayXuat = value; }
        }
        private string _tongTien;
        public string TongTien
        {
            get { return _tongTien; }
            set { _tongTien = value; }
        }
        private int _maKhachHang;
        public int MaKhachHang
        {
            get { return _maKhachHang; }
            set { _maKhachHang = value; }
        }
    }
}
