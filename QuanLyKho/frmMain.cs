using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKho
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void nhậpKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void xuấtKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmXuatKho f = new frmXuatKho();
            f.ShowDialog();
            Application.Exit();
        }

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void trợGiúpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
