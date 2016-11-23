using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
namespace QuanLyKho
{
    public partial class frmThongKe : Form
    {
        LuaChon lc;
        bool isNam;
        bool isLuaChon;
        public enum LuaChon
        {
            XuatKho,
            NhapKho
        }
        public frmThongKe()
        {
            isNam = false;
            isLuaChon = false;
            InitializeComponent();
        }

        private void btnPhanTich_Click(object sender, EventArgs e)
        {
            if (cboNam.Text == "" || cboXuatNhap.Text == "")
            {
                MessageBox.Show("Mời bạn nhập đủ thông tin");
                return;
            }
            chartThongKe.Series.Clear();
            var series = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                Name = "Thang",
                Color = Color.Green,
                IsVisibleInLegend = true,
                IsXValueIndexed = true,
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column
            };
            chartThongKe.Series.Add(series);
            DataTable dt;
            string[] hang;
            if (cboXuatNhap.Text == "Xuất kho")
            {
                dt = ThongKeDAO.TongTienXuatTungThang(int.Parse(cboNam.Text));
                hang = ThongKeDAO.HangHoaXuatNhieuItNhatNam(int.Parse(cboNam.Text)).Split('|');
            }
            else
            {
                dt = ThongKeDAO.TongTienNhapTungThang(int.Parse(cboNam.Text));
                hang = ThongKeDAO.HangHoaNhapNhieuItNhatNam(int.Parse(cboNam.Text)).Split('|');
            }
            lblMatHangUaChuongNhat.Text = "Mặt hàng ưa chuộng nhất : " + hang[1];
            lblMatHangItQuanTam.Text = "Mặt hàng ít được quan tâm nhất : " + hang[0];
            int[] thang = new int[13];
            int sum = 0;
            int min = int.MaxValue;
            int max = int.MinValue;
            int imin = 0;
            int imax = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int t = int.Parse(dt.Rows[i][1].ToString());
                int index = int.Parse(dt.Rows[i][0].ToString());
                thang[index] = t;
                sum += t;
                if (min > t)
                {
                    min = t;
                    imin = index;
                }
                if (max < t)
                {
                    max = t;
                    imax = index;
                }

            }
            for (int i = 0; i <= 12; i++)
            {
                series.Points.AddXY(i, thang[i]);
            }
            chartThongKe.Invalidate();
            lblTongTienNam.Text += sum;
            lblThangNhieuNhat.Text += imax;
            lblThangThapNhat.Text += imin;
        }
    }
}
