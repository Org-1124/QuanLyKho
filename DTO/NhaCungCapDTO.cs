using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhaCungCapDTO
    {
        private int _MaNhaCC;
        public int MaNhaCC
        {
            get { return _MaNhaCC; }
            set { _MaNhaCC = value; }
        }
        private string _TenNhaCC;
        public string TenNhaCC
        {
            get { return _TenNhaCC; }
            set { _TenNhaCC = value; }
        }
        private string _DiaChi;
        public string DiaChi
        {
            get { return _DiaChi; }
            set { _DiaChi = value; }
        }
        private string _SDT;
        public string SDT
        {
            get { return _SDT; }
            set { _SDT = value; }
        }
    }
}
