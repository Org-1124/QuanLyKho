using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietXuatDTO
    {
        private int _maHDXuat;
        public int MaHDXuat
        {
            get { return _maHDXuat; }
            set { _maHDXuat = value; }
        }
        private int _maHangHoa;
        public int MaHangHoa
        {
            get { return _maHangHoa; }
            set { _maHangHoa = value; }
        }
        private int _soLuong;
        public int SoLuong
        {
            get { return _soLuong; }
            set { _soLuong = value; }
        }
        private int _donGia;
        public int DonGia
        {
            get { return _donGia; }
            set { _donGia = value; }
        }
    }
}
