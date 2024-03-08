using System;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace QuanLiBanCoc
{
    public partial class FormHDB : Form
    {
        private string connectionString = UserSession.connectionString;
        public FormHDB()
        {
            InitializeComponent();
            this.Load += Form_Load_HDB;
        }
        public DataGridView getDataGridView1
        {
            get { return dataGridView1; }
        }
        private void Form_Load_HDB(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string query1 = "SELECT HoaDonBan.SoHDB as N'Số HĐB', " +
                                "HoaDonBan.MaNV as N'Mã NV', " +
                                "HoaDonBan.NgayBan as N'Ngày Bán', " +
                                "HoaDonBan.MaKhach as N'Mã Khách', " +
                                "HoaDonBan.TongTien as N'Tổng tiền' " +
                                "FROM HoaDonBan";

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
        private void button3_Click(object sender, EventArgs e)
        {
            ExportExcel(dataGridView2, "ChiTietHDB");
        }
        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
            this.Close();
        }
        private void buttonHoaDon_Click(object sender, EventArgs e)
        {
            
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

            if (text.Equals("ChiTietHDB"))
            {
                fileName = text + dataGridView.Rows[1].Cells[0].Value.ToString() + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx";
                // Combine the file path with the solution folder, XuatHoaDon folder, and HDB subfolder
                solutionFolder = AppDomain.CurrentDomain.BaseDirectory;
                int binIndex = solutionFolder.IndexOf("\\bin\\");
                if (binIndex >= 0)
                {
                    solutionFolder = solutionFolder.Substring(0, binIndex);
                }
                exportFolderPath = Path.Combine(solutionFolder, "XuatHoaDon", "HDB", "HDB_Details");
            }
            else if (text.Equals("HoaDonBan"))
            {
                fileName = text + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx";
                // Combine the file path with the solution folder, XuatHoaDon folder, and HDB subfolder
                solutionFolder = AppDomain.CurrentDomain.BaseDirectory;
                int binIndex = solutionFolder.IndexOf("\\bin\\");
                if (binIndex >= 0)
                {
                    solutionFolder = solutionFolder.Substring(0, binIndex);
                }
                exportFolderPath = Path.Combine(solutionFolder, "XuatHoaDon", "HDB");
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
            ExportExcel(dataGridView1, "HoaDonBan");
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
                    string query2 = "SELECT ChiTietHDB.SoHDB as N'Số HĐB', " +
                                    "ChiTietHDB.MaHang as N'Mã Hàng', " +
                                    "ChiTietHDB.SoLuong as N'Số Lượng', " +
                                    "ChiTietHDB.DonGia as N'Đơn Giá', " +
                                    "ChiTietHDB.GiamGia as N'Giảm Giá', " +
                                    "ChiTietHDB.ThanhTien as N'Thành Tiền' " +
                                    "FROM ChiTietHDB WHERE ChiTietHDB.SoHDB = @SoHDB";
                    using (SqlCommand command = new SqlCommand(query2, connection))
                    {
                        command.Parameters.AddWithValue("@SoHDB", rowData);

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
    }
}
