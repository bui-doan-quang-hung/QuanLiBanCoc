using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiBanCoc
{
    public partial class Transition : Form
    {
        public Transition()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
            this.Close();
        }

        private void btnHDB_Click(object sender, EventArgs e)
        {
            FormHDB form = new FormHDB();
            form.Show();
            this.Close();
        }

        private void btnHDN_Click(object sender, EventArgs e)
        {
            FormHDN form = new FormHDN();
            form.Show();
            this.Close();
        }
    }
}
