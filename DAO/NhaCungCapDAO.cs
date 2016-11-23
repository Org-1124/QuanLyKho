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
    public class NhaCungCapDAO
    {
        public static SqlConnection con;
        public static DataTable LoadData()
        {
            string sTruyVan = "select * from tblNhaCungCap";
            con = DataProvider.KetNoi();
            DataTable dt = DataProvider.LayDataTable(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return dt;
        }

        public static DataTable LoadData1(int CC)
        {
            string sTruyVan = string.Format("select *from tblNhaCungCap where MaNhaCC={0}", CC);
            con = DataProvider.KetNoi();
            DataTable dt = DataProvider.LayDataTable(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return dt;
        }
    }
}
