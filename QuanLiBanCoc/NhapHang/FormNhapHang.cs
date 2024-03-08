using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLiBanCoc.Nhap;

namespace QuanLiBanCoc
{
    public partial class FormNhapHang : Form
    {
        private string connectionString = UserSession.connectionString;
        public FormNhapHang()
        {
            InitializeComponent();
            this.Load += Form_Load;
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
            this.Close();
        }
        private void Form_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT MaHang as N'Mã Hàng', " +
                                "TenHang as N'Tên Hàng', " +
                                "DonGiaNhap as N'Giá Nhập', " +
                                "DonGiaBan as N'Giá Bán', " +
                                "SoLuong as N'Số Lượng' from HangHoa";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    dataGridView1.Columns.Clear();
                    dataGridView1.DataSource = dataSet.Tables[0];

                    connection.Close();
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form_Load(this, e);
            dataGridView2.Rows.Clear();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn thêm số lượng này không?", "Confirm", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        //Get SoHDN
                        string val1 = string.Empty;
                        string selectQuery = "SELECT MAX(SoHDN) FROM HoaDonNhap";
                        using (SqlCommand selectCommand = new SqlCommand(selectQuery, connection))
                        {
                            object result = selectCommand.ExecuteScalar();
                            if (result != DBNull.Value)
                            {
                                int maxMaHang = Convert.ToInt32(result);
                                val1 = (maxMaHang + 1).ToString();
                            }
                            else
                            {
                                val1 = "1";
                            }
                        }

                        //Get Date
                        string val2 = string.Empty;
                        string DateQuery = "SELECT GETDATE()";
                        using (SqlCommand selectCommand = new SqlCommand(DateQuery, connection))
                        {
                            object result = selectCommand.ExecuteScalar();
                            val2 = result.ToString();
                        }

                        foreach (DataGridViewRow row in dataGridView2.Rows)
                        {
                            if (row.Cells[0].Value != null)
                            {
                                string ID = row.Cells["MaHang"].Value.ToString();
                                string SL = row.Cells["SoLuong"]?.Value.ToString();
                                //int SL = Convert.ToInt32(row.Cells["SoLuong"]?.Value);

                                string addSLQuery = "UPDATE HangHoa SET SoLuong = SoLuong + @SoLuong WHERE MaHang = @MaHang";
                                using (SqlCommand command = new SqlCommand(addSLQuery, connection))
                                {
                                    command.Parameters.AddWithValue("@SoLuong", SL);
                                    command.Parameters.AddWithValue("@MaHang", ID);
                                    command.ExecuteNonQuery();
                                }
                                Form_Load(this, e);
                            }
                        }

                        string HDNQuery = "INSERT INTO HoaDonNhap(SoHDN, MaNV, NgayNhap, MaNCC, TongTien)" +
                                          "VALUES (@SoHDN, @MaNV, @NgayNhap, @MaNCC, @TongTien)";
                        using (SqlCommand command = new SqlCommand(HDNQuery, connection))
                        {
                            command.Parameters.AddWithValue("@SoHDN", val1);
                            command.Parameters.AddWithValue("@MaNV", UserSession.MaNV);
                            command.Parameters.AddWithValue("@NgayNhap", val2);
                            command.Parameters.AddWithValue("@MaNCC", '1');
                            command.Parameters.AddWithValue("@TongTien", '0');
                            command.ExecuteNonQuery();
                        }

                        //Add to ChiTietHDN
                        string CTHDNQuery = "INSERT INTO ChiTietHDN(SoHDN, MaHang, SoLuong, DonGia, GiamGia, ThanhTien)" +
                                          "VALUES (@SoHDN, @MaHang, @SoLuong, @DonGia, 0, @ThanhTien)";
                        double TongTien = 0;
                        foreach (DataGridViewRow row in dataGridView2.Rows)
                        {
                            int SL = Convert.ToInt32(row.Cells["SoLuong"]?.Value);
                            int index = Convert.ToInt32(row.Cells["MaHang"].Value);
                            DataGridViewRow dRow = dataGridView1.Rows[index-1];
                            double GiaNhap = Convert.ToDouble(dRow.Cells[2].Value);
                            double ThanhTien = GiaNhap * SL;
                            TongTien += ThanhTien;

                            using (SqlCommand command = new SqlCommand(CTHDNQuery, connection))
                            {
                                command.Parameters.AddWithValue("@SoHDN", val1);
                                command.Parameters.AddWithValue("@MaHang", index);
                                command.Parameters.AddWithValue("@SoLuong", SL);
                                command.Parameters.AddWithValue("@DonGia", GiaNhap);
                                command.Parameters.AddWithValue("@ThanhTien", ThanhTien);
                                command.ExecuteNonQuery();
                            }
                            string updateTT = "UPDATE HoaDonNhap set TongTien = @TongTien WHERE SoHDN = @SoHDN";
                            using (SqlCommand command = new SqlCommand(updateTT, connection))
                            {
                                command.Parameters.AddWithValue("@TongTien", TongTien);
                                command.Parameters.AddWithValue("@SoHDN", val1);
                                command.ExecuteNonQuery();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            FormTimKiemHDN form = new FormTimKiemHDN();
            form.Show();
        }
        public DataGridView getDataGridView1
        {
            get { return dataGridView1; }
        }
    }
}
