namespace QuanLyKho
{
    partial class frmThongKe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnPhanTich = new System.Windows.Forms.Button();
            this.lblMatHangItQuanTam = new System.Windows.Forms.Label();
            this.lblMatHangUaChuongNhat = new System.Windows.Forms.Label();
            this.lblThangThapNhat = new System.Windows.Forms.Label();
            this.lblThangNhieuNhat = new System.Windows.Forms.Label();
            this.lblTongTienNam = new System.Windows.Forms.Label();
            this.cboXuatNhap = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboNam = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chartThongKe = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartThongKe)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnPhanTich);
            this.panel2.Controls.Add(this.lblMatHangItQuanTam);
            this.panel2.Controls.Add(this.lblMatHangUaChuongNhat);
            this.panel2.Controls.Add(this.lblThangThapNhat);
            this.panel2.Controls.Add(this.lblThangNhieuNhat);
            this.panel2.Controls.Add(this.lblTongTienNam);
            this.panel2.Controls.Add(this.cboXuatNhap);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cboNam);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(881, 140);
            this.panel2.TabIndex = 1;
            // 
            // btnPhanTich
            // 
            this.btnPhanTich.Location = new System.Drawing.Point(707, 15);
            this.btnPhanTich.Name = "btnPhanTich";
            this.btnPhanTich.Size = new System.Drawing.Size(75, 23);
            this.btnPhanTich.TabIndex = 9;
            this.btnPhanTich.Text = "Phân tích";
            this.btnPhanTich.UseVisualStyleBackColor = true;
            this.btnPhanTich.Click += new System.EventHandler(this.btnPhanTich_Click);
            // 
            // lblMatHangItQuanTam
            // 
            this.lblMatHangItQuanTam.AutoSize = true;
            this.lblMatHangItQuanTam.Location = new System.Drawing.Point(395, 109);
            this.lblMatHangItQuanTam.Name = "lblMatHangItQuanTam";
            this.lblMatHangItQuanTam.Size = new System.Drawing.Size(167, 13);
            this.lblMatHangItQuanTam.TabIndex = 8;
            this.lblMatHangItQuanTam.Text = "Mặt hàng ít được quan tâm nhất :";
            // 
            // lblMatHangUaChuongNhat
            // 
            this.lblMatHangUaChuongNhat.AutoSize = true;
            this.lblMatHangUaChuongNhat.Location = new System.Drawing.Point(37, 109);
            this.lblMatHangUaChuongNhat.Name = "lblMatHangUaChuongNhat";
            this.lblMatHangUaChuongNhat.Size = new System.Drawing.Size(136, 13);
            this.lblMatHangUaChuongNhat.TabIndex = 7;
            this.lblMatHangUaChuongNhat.Text = "Mặt hàng ưa chuộng nhất :";
            // 
            // lblThangThapNhat
            // 
            this.lblThangThapNhat.AutoSize = true;
            this.lblThangThapNhat.Location = new System.Drawing.Point(395, 68);
            this.lblThangThapNhat.Name = "lblThangThapNhat";
            this.lblThangThapNhat.Size = new System.Drawing.Size(92, 13);
            this.lblThangThapNhat.TabIndex = 6;
            this.lblThangThapNhat.Text = "Tháng thấp nhất :";
            // 
            // lblThangNhieuNhat
            // 
            this.lblThangNhieuNhat.AutoSize = true;
            this.lblThangNhieuNhat.Location = new System.Drawing.Point(704, 68);
            this.lblThangNhieuNhat.Name = "lblThangNhieuNhat";
            this.lblThangNhieuNhat.Size = new System.Drawing.Size(97, 13);
            this.lblThangNhieuNhat.TabIndex = 5;
            this.lblThangNhieuNhat.Text = "Tháng nhiều nhất :";
            // 
            // lblTongTienNam
            // 
            this.lblTongTienNam.AutoSize = true;
            this.lblTongTienNam.Location = new System.Drawing.Point(37, 68);
            this.lblTongTienNam.Name = "lblTongTienNam";
            this.lblTongTienNam.Size = new System.Drawing.Size(99, 13);
            this.lblTongTienNam.TabIndex = 4;
            this.lblTongTienNam.Text = "Tổng tiền cả năm : ";
            // 
            // cboXuatNhap
            // 
            this.cboXuatNhap.FormattingEnabled = true;
            this.cboXuatNhap.Items.AddRange(new object[] {
            "Xuất kho",
            "Nhập kho"});
            this.cboXuatNhap.Location = new System.Drawing.Point(450, 17);
            this.cboXuatNhap.Name = "cboXuatNhap";
            this.cboXuatNhap.Size = new System.Drawing.Size(121, 21);
            this.cboXuatNhap.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(395, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Loại";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Năm";
            // 
            // cboNam
            // 
            this.cboNam.FormattingEnabled = true;
            this.cboNam.Items.AddRange(new object[] {
            "2010",
            "2012",
            "2013",
            "2014",
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025",
            "2026",
            "2027"});
            this.cboNam.Location = new System.Drawing.Point(91, 17);
            this.cboNam.Name = "cboNam";
            this.cboNam.Size = new System.Drawing.Size(121, 21);
            this.cboNam.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chartThongKe);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 140);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(881, 324);
            this.panel1.TabIndex = 2;
            // 
            // chartThongKe
            // 
            chartArea1.Name = "ChartArea1";
            this.chartThongKe.ChartAreas.Add(chartArea1);
            this.chartThongKe.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartThongKe.Legends.Add(legend1);
            this.chartThongKe.Location = new System.Drawing.Point(0, 0);
            this.chartThongKe.Name = "chartThongKe";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartThongKe.Series.Add(series1);
            this.chartThongKe.Size = new System.Drawing.Size(881, 324);
            this.chartThongKe.TabIndex = 0;
            this.chartThongKe.Text = "Tháng thấp nhất";
            // 
            // frmThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 464);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "frmThongKe";
            this.Text = "frmThongKe";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartThongKe)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblMatHangItQuanTam;
        private System.Windows.Forms.Label lblMatHangUaChuongNhat;
        private System.Windows.Forms.Label lblThangThapNhat;
        private System.Windows.Forms.Label lblThangNhieuNhat;
        private System.Windows.Forms.Label lblTongTienNam;
        private System.Windows.Forms.ComboBox cboXuatNhap;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboNam;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartThongKe;
        private System.Windows.Forms.Button btnPhanTich;
    }
}