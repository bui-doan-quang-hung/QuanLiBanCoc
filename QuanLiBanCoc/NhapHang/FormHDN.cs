using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace QuanLiBanCoc
{
    public partial class FormHDN : Form
    {
        private string connectionString = UserSession.connectionString;
        public FormHDN()
        {
            InitializeComponent();
            this.Load += Form_Load_HDN;
        }
        private void Form_Load_HDN(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string query1 = "SELECT HoaDonNhap.SoHDN as N'Số HĐN', " +
                                "HoaDonNhap.MaNV as N'Mã NV', " +
                                "HoaDonNhap.NgayNhap as N'Ngày nhập', " +
                                "HoaDonNhap.MaNCC as N'Mã Nhà CC', " +
                                "HoaDonNhap.TongTien as N'Tổng tiền' " +
                                "FROM HoaDonNhap";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query1, connection))
                {
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    dataGridView1.Columns.Clear();
                    dataGridView1.DataSource = dataSet.Tables[0];
                    connection.Close();
                }
            }
        }
        public DataGridView getDataGridView1
        {
            get { return dataGridView1; }
        }
        private void buttonHoaDon_Click(object sender, EventArgs e)
        {
            SearchHDN form = new SearchHDN();
            form.Show();
        }
        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
            this.Close();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow selectedRow = dgv.Rows[e.RowIndex];
                string rowData = selectedRow.Cells[0].Value.ToString();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query2 = "SELECT ChiTietHDN.SoHDN as N'Số HĐN', " +
                                    "ChiTietHDN.MaHang as N'Mã Hàng', " +
                                    "ChiTietHDN.SoLuong as N'Số Lượng', " +
                                    "ChiTietHDN.DonGia as N'Đơn Giá', " +
                                    "ChiTietHDN.GiamGia as N'Giảm Giá', " +
                                    "ChiTietHDN.ThanhTien as N'Thành Tiền' " +
                                    "FROM ChiTietHDN WHERE ChiTietHDN.SoHDN = @SoHDN";
                    using (SqlCommand command = new SqlCommand(query2, connection))
                    {
                        command.Parameters.AddWithValue("@SoHDN", rowData);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataSet dataSet = new DataSet();
                            adapter.Fill(dataSet);

                            dataGridView2.Columns.Clear();
                            dataGridView2.DataSource = dataSet.Tables[0];
                        }
                    }
                }
            }
        }
        private void ExportExcel(DataGridView dataGridView, string text)
        {
            Excel.Application exApp = new Excel.Application();
            Excel.Workbook exBook = exApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet exSheet = exBook.ActiveSheet;
            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                exSheet.Cells[1, i + 1] = dataGridView.Columns[i].HeaderText;
            }
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView.Columns.Count; j++)
                {
                    exSheet.Cells[i + 2, j + 1] = dataGridView.Rows[i].Cells[j].Value != null ? dataGridView.Rows[i].Cells[j].Value.ToString() : "";
                }
            }

            string fileName = text;
            string solutionFolder;
            string exportFolderPath = "";

            if (text.Equals("ChiTietHDN"))
            {
                fileName = text + "_So" + dataGridView.Rows[0].Cells[0].Value.ToString() + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx";
                // Combine the file path with the solution folder, XuatHoaDon folder, and HDB subfolder
                solutionFolder = AppDomain.CurrentDomain.BaseDirectory;
                int binIndex = solutionFolder.IndexOf("\\bin\\");
                if (binIndex >= 0)
                {
                    solutionFolder = solutionFolder.Substring(0, binIndex);
                }
                exportFolderPath = Path.Combine(solutionFolder, "XuatHoaDon", "HDN", "HDN_Details");
            }
            else if (text.Equals("HoaDonNhap"))
            {
                fileName = text + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx";
                // Combine the file path with the solution folder, XuatHoaDon folder, and HDB subfolder
                solutionFolder = AppDomain.CurrentDomain.BaseDirectory;
                int binIndex = solutionFolder.IndexOf("\\bin\\");
                if (binIndex >= 0)
                {
                    solutionFolder = solutionFolder.Substring(0, binIndex);
                }
                exportFolderPath = Path.Combine(solutionFolder, "XuatHoaDon", "HDN");
            }
            Directory.CreateDirectory(exportFolderPath);
            string filePath = Path.Combine(exportFolderPath, fileName);

            exBook.SaveAs(filePath);

            MessageBox.Show("Data exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            exBook.Close();
            exApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(exSheet);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(exBook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(exApp);
            exSheet = null;
            exBook = null;
            exApp = null;
            GC.Collect();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ExportExcel(dataGridView1, "HoaDonNhap");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            ExportExcel(dataGridView2, "ChiTietHDN");
        }
    }
}
