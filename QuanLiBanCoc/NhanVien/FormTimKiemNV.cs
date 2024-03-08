using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiBanCoc.NhanVien
{
    public partial class FormTimKiemNV : Form
    {
        public FormTimKiemNV()
        {
            InitializeComponent();
        }

		private void btnFind_Click(object sender, EventArgs e)
		{
			string searchVal1 = txt1.Text;
			string searchVal2 = txt2.Text.ToLower();
			string searchVal3 = txt3.Text.ToLower();
			FormQLNV form = Application.OpenForms["FormQLNV"] as FormQLNV;
			if (form != null)
			{
				DataGridView dataGridView = form.getDataGridView1;
				dataGridView.ClearSelection();
				foreach (DataGridViewRow row in dataGridView.Rows)
				{
					if (row.Cells[0].Value != null && row.Cells[0].Value.ToString().Equals(searchVal1))
					{
						row.Selected = true;
						dataGridView.FirstDisplayedScrollingRowIndex = row.Index;
						break;
					}
					else if (row.Cells[6].Value != null && row.Cells[6].Value.ToString().ToLower().Contains(searchVal2))
					{
						row.Selected = true;
						dataGridView.FirstDisplayedScrollingRowIndex = row.Index;
					}
					else if (row.Cells[1].Value != null && row.Cells[1].Value.ToString().ToLower().Contains(searchVal3))
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
