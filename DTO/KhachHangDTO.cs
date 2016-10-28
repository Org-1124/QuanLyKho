using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhachHangDTO
    {
        private int _maKhachHang;
        public int MaKhachHang
        {
            get { return _maKhachHang; }
            set { _maKhachHang = value; }
        }
        private string _hoTen;
        public string HoTen
        {
            get { return _hoTen; }
            set { _hoTen = value; }
        }
        private string _diaChi;
        public string DiaChi
        {
            get { return _diaChi; }
            set { _diaChi = value; }
        }
        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        private string _sDT;
        public string SDT
        {
            get { return _sDT; }
            set { _sDT = value; }
        }
    }
}
