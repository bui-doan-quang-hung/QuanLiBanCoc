using QuanLiBanCoc.BanHang;
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

namespace QuanLiBanCoc
{
    public partial class FormBanHang : Form
    {
        private string connectionString = UserSession.connectionString;
        public FormBanHang()
        {
            InitializeComponent();
            this.Load += Form_Load;
        }
        public DataGridView getDataGridView2
        {
            get { return dataGridView2; }
        }
        private void Form_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT HangHoa.MaHang as N'Mã Hàng', " +
                                "HangHoa.TenHang as N'Tên Hàng', " +
                                "Loai.TenLoai as N'Tên Loại', " +
                                "HinhDang.TenHinhDang as N'Hình Dạng', " +
                                "ChatLieu.TenChatLieu as N'Chất Liệu', " +
                                "DacDiem.TenDacDiem as N'Đặc Điểm', " +
                                "MauSac.TenMau as N'Màu Sắc', " +
                                "NoiSanXuat.TenNoiSX as N'Nơi SX', " +
                                "HangHoa.SoLuong as N'Số Lượng'," +
                                "HangHoa.DonGiaBan as N'Giá Bán', " +
                                "HangHoa.ThoiGianBaoHanh as N'Bảo Hành' " +
                                "FROM HangHoa join Loai on Loai.MaLoai = HangHoa.MaLoai " +
                                "join HinhDang on HinhDang.MaHinhDang = HangHoa.MaHinhDang " +
                                "join ChatLieu on ChatLieu.MaChatLieu = HangHoa.MaChatLieu " +
                                "join DacDiem on DacDiem.MaDacDiem = HangHoa.MaDacDiem " +
                                "join MauSac on MauSac.MaMau = HangHoa.MaMau " +
                                "join NoiSanXuat on NoiSanXuat.MaNoiSX = HangHoa.MaNoiSX";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    dataGridView2.Columns.Clear();
                    dataGridView2.DataSource = dataSet.Tables[0];

                    connection.Close();
                }
            }
        }
        public DataGridView getDataGridView1
        {
            get { return dataGridView1; }
        }
        private void updateTongTien(object sender, DataGridViewCellEventArgs e)
        {
            double TongTien = 0;
            foreach (DataGridViewRow dv in dataGridView1.Rows)
            {
                object cellValue1 = dv.Cells[2].Value;
                object cellValue2 = dv.Cells[3].Value;
                if (cellValue1 != null && cellValue2 != null &&
                    double.TryParse(cellValue1.ToString(), out double value1) &&
                    double.TryParse(cellValue2.ToString(), out double value2))
                {
                    TongTien += value1 * value2;
                    dv.Cells[4].Value = (value1 * value2).ToString();
                }
            }
            textBox3.Text = TongTien.ToString() + "đ";
        }
        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                updateTongTien(sender, e);
            }
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow selectedRow = dgv.Rows[e.RowIndex];

                string value1 = selectedRow.Cells[0].Value.ToString();
                string value2 = selectedRow.Cells[1].Value.ToString();
                string value3 = selectedRow.Cells[9].Value.ToString();
                DataGridViewRow newRow = (DataGridViewRow)dataGridView1.Rows[0].Clone();

                newRow.Cells[0].Value = value1;
                newRow.Cells[1].Value = value2;
                newRow.Cells[2].Value = value3;
                newRow.Cells[3].Value = 1;
                dataGridView1.Rows.Add(newRow);
                updateTongTien(this, e);
            }
        }
        private void buttonHoaDon_Click(object sender, EventArgs e)
        {
            FormTimKiemHDB form = new FormTimKiemHDB();
            form.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn thanh toán?", "Confirm", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        bool HopLe = true;
                        //Get SoHDB
                        string val1 = string.Empty;
                        string selectQuery = "SELECT MAX(SoHDB) FROM HoaDonBan";
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

                        //Get Tong tien
                        double Total = Convert.ToDouble(textBox3.Text.Substring(0, textBox3.Text.Length - 1));

                        //Get Ma KH
                        string MaKH = textBox1 != null ? textBox1.Text : "0";
                        string selectMaKH;
                        selectMaKH = "SELECT MaKhach FROM KhachHang WHERE MaKhach = @MaKH";
                        using (SqlCommand selectCommand = new SqlCommand(selectMaKH, connection))
                        {
                            selectCommand.Parameters.AddWithValue("@MaKH", MaKH);
                            object result = selectCommand.ExecuteScalar();
                            if (result != null)
                            {
                                MaKH = result.ToString();
                            }
                            else
                            {
                                MaKH = "0";
                            }
                        }

                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (row.Cells[0].Value != null)
                            {
                                string ID = row.Cells["MaHang"].Value.ToString();
                                string SL = row.Cells["SoLuong"]?.Value.ToString();
                                string dgv1Value = "0";
                                foreach (DataGridViewRow row2 in dataGridView2.Rows)
                                {
                                    if (row2.Cells[0].Value != null && row2.Cells[0].Value.ToString().Equals(ID))
                                    {
                                        dgv1Value = row2.Cells[8]?.Value?.ToString();
                                        break; // Assuming you want to exit the loop after finding a matching row
                                    }
                                }

                                if (!string.IsNullOrEmpty(SL) &&
                                    !string.IsNullOrEmpty(dgv1Value) &&
                                    int.TryParse(SL, out int slValue) &&
                                    int.TryParse(dgv1Value, out int dgv1ValueInt))
                                {
                                    if (slValue < dgv1ValueInt)
                                    {
                                        string addSLQuery = "UPDATE HangHoa SET SoLuong = SoLuong - @SoLuong WHERE MaHang = @MaHang";
                                        using (SqlCommand command = new SqlCommand(addSLQuery, connection))
                                        {
                                            command.Parameters.AddWithValue("@SoLuong", SL);
                                            command.Parameters.AddWithValue("@MaHang", ID);
                                            command.ExecuteNonQuery();
                                        }
                                        Form_Load(this, e);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Không đủ hàng để bán, vui lòng nhập lại");
                                        HopLe = false;
                                        break;
                                    }
                                }
                            }
                        }

                        while (HopLe)
                        {
                            //Add to HoaDonBan
                            string HDBQuery = "INSERT INTO HoaDonBan(SoHDB, MaNV, NgayBan, MaKhach, TongTien)" +
                                          "VALUES (@SoHDB, @MaNV, @NgayBan, @MaKhach, @TongTien)";
                            using (SqlCommand command = new SqlCommand(HDBQuery, connection))
                            {
                                command.Parameters.AddWithValue("@SoHDB", val1);
                                command.Parameters.AddWithValue("@MaNV", UserSession.MaNV);
                                command.Parameters.AddWithValue("@NgayBan", val2);
                                command.Parameters.AddWithValue("@MaKhach", '1');
                                command.Parameters.AddWithValue("@TongTien", Total);
                                command.ExecuteNonQuery();
                            }

                            //Add to ChiTietHDB
                            string CTHDBQuery = "INSERT INTO ChiTietHDB(SoHDB, MaHang, SoLuong, DonGia, GiamGia, ThanhTien)" +
                                              "VALUES (@SoHDB, @MaHang, @SoLuong, @DonGia, 0, @ThanhTien)";
                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                int SL = Convert.ToInt32(row.Cells[3]?.Value);
                                int index = Convert.ToInt32(row.Cells[0].Value);
                                double GiaNhap = Convert.ToDouble(row.Cells[2].Value);
                                double ThanhTien = Convert.ToDouble(row.Cells[4].Value);

                                using (SqlCommand command = new SqlCommand(CTHDBQuery, connection))
                                {
                                    command.Parameters.AddWithValue("@SoHDB", val1);
                                    command.Parameters.AddWithValue("@MaHang", index);
                                    command.Parameters.AddWithValue("@SoLuong", SL);
                                    command.Parameters.AddWithValue("@DonGia", GiaNhap);
                                    command.Parameters.AddWithValue("@ThanhTien", ThanhTien);
                                    command.ExecuteNonQuery();
                                }
                                string updateTT = "UPDATE HoaDonBan set TongTien = @TongTien WHERE SoHDB = @SoHDB";
                                using (SqlCommand command = new SqlCommand(updateTT, connection))
                                {
                                    command.Parameters.AddWithValue("@TongTien", Total);
                                    command.Parameters.AddWithValue("@SoHDB", val1);
                                    command.ExecuteNonQuery();
                                }
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
		private void buttonLogOut_Click(object sender, EventArgs e)
		{
			Form2 form = new Form2();
			form.Show();
			this.Close();
		}
	}
}
