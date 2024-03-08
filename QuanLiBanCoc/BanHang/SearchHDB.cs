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
    public partial class SearchHDB : Form
    {
        public SearchHDB()
        {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string searchVal1 = txt1.Text;
            string searchVal2 = txt2.Text;
            FormHDB form = Application.OpenForms["FormHDB"] as FormHDB;
            if (form != null)
            {
                DataGridView dataGridView = form.getDataGridView1;
                dataGridView.ClearSelection();
                foreach(DataGridViewRow row in dataGridView.Rows)
                {
                    if((row.Cells[0].Value != null && row.Cells[0].Value.ToString().Equals(searchVal1))
                        || (row.Cells[1].Value !=null && row.Cells[1].Value.ToString().Equals(searchVal2)))
                    {
                        row.Selected = true;
                        dataGridView.FirstDisplayedScrollingRowIndex = row.Index;
                    }
                }
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
