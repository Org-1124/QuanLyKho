using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class HangHoaDAO
    {
        public static SqlConnection con;
        public static DataTable LoadDataHangHoa()
        {
            string sTruyVan = "select * from tblHangHoa";
            con = DataProvider.KetNoi();
            DataTable dt = DataProvider.LayDataTable(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return dt;
        }
    }
}
