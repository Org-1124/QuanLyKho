namespace QuanLyKho
{
    partial class frmDangNhap
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
            this.txttaikhoan = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkmk = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtmatkhau = new System.Windows.Forms.TextBox();
            this.btndangnhap = new System.Windows.Forms.Button();
            this.btnthoat = new System.Windows.Forms.Button();
            this.txttaikhoan.SuspendLayout();
            this.SuspendLayout();
            // 
            // txttaikhoan
            // 
            this.txttaikhoan.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txttaikhoan.Controls.Add(this.btnthoat);
            this.txttaikhoan.Controls.Add(this.btndangnhap);
            this.txttaikhoan.Controls.Add(this.txtmatkhau);
            this.txttaikhoan.Controls.Add(this.textBox1);
            this.txttaikhoan.Controls.Add(this.checkmk);
            this.txttaikhoan.Controls.Add(this.label2);
            this.txttaikhoan.Controls.Add(this.label1);
            this.txttaikhoan.Location = new System.Drawing.Point(0, 0);
            this.txttaikhoan.Name = "txttaikhoan";
            this.txttaikhoan.Size = new System.Drawing.Size(497, 305);
            this.txttaikhoan.TabIndex = 0;
            this.txttaikhoan.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tài Khoản";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mật Khẩu";
            // 
            // checkmk
            // 
            this.checkmk.AutoSize = true;
            this.checkmk.Location = new System.Drawing.Point(76, 189);
            this.checkmk.Name = "checkmk";
            this.checkmk.Size = new System.Drawing.Size(66, 17);
            this.checkmk.TabIndex = 2;
            this.checkmk.Text = "Hiển Thị";
            this.checkmk.UseVisualStyleBackColor = true;
            this.checkmk.CheckedChanged += new System.EventHandler(this.checkmk_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(203, 64);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(195, 20);
            this.textBox1.TabIndex = 3;
            // 
            // txtmatkhau
            // 
            this.txtmatkhau.Location = new System.Drawing.Point(203, 123);
            this.txtmatkhau.Name = "txtmatkhau";
            this.txtmatkhau.Size = new System.Drawing.Size(195, 20);
            this.txtmatkhau.TabIndex = 4;
            // 
            // btndangnhap
            // 
            this.btndangnhap.Location = new System.Drawing.Point(203, 185);
            this.btndangnhap.Name = "btndangnhap";
            this.btndangnhap.Size = new System.Drawing.Size(75, 26);
            this.btndangnhap.TabIndex = 5;
            this.btndangnhap.Text = "Đăng Nhập";
            this.btndangnhap.UseVisualStyleBackColor = true;
            this.btndangnhap.Click += new System.EventHandler(this.btndangnhap_Click);
            // 
            // btnthoat
            // 
            this.btnthoat.Location = new System.Drawing.Point(323, 183);
            this.btnthoat.Name = "btnthoat";
            this.btnthoat.Size = new System.Drawing.Size(75, 28);
            this.btnthoat.TabIndex = 6;
            this.btnthoat.Text = "Thoát";
            this.btnthoat.UseVisualStyleBackColor = true;
            this.btnthoat.Click += new System.EventHandler(this.btnthoat_Click);
            // 
            // frmDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 306);
            this.Controls.Add(this.txttaikhoan);
            this.Name = "frmDangNhap";
            this.Text = "frmDangNhap";
            this.txttaikhoan.ResumeLayout(false);
            this.txttaikhoan.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox txttaikhoan;
        private System.Windows.Forms.Button btnthoat;
        private System.Windows.Forms.Button btndangnhap;
        private System.Windows.Forms.TextBox txtmatkhau;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox checkmk;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}