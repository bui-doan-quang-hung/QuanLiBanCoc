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
    public partial class FormQLSP : Form
    {
        private string connectionString = UserSession.connectionString;
        public FormQLSP()
        {
            InitializeComponent();
            PopulateOptions();
            this.Load += Form_Load;
        }
        private void PopulateOptions()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT TenLoai FROM Loai";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataSet dataset = new DataSet();
                    adapter.Fill(dataset, "TableData");
                    comboBox1.DisplayMember = "TenLoai";
                    comboBox1.ValueMember = "TenLoai";
                    comboBox1.DataSource = dataset.Tables["TableData"];

                    query = "SELECT TenHinhDang FROM HinhDang";
                    adapter = new SqlDataAdapter(query, connection);
                    dataset = new DataSet();
                    adapter.Fill(dataset, "TableData");
                    comboBox2.DisplayMember = "TenHinhDang";
                    comboBox2.ValueMember = "TenHinhDang";
                    comboBox2.DataSource = dataset.Tables["TableData"];

                    query = "SELECT TenChatLieu FROM ChatLieu";
                    adapter = new SqlDataAdapter(query, connection);
                    dataset = new DataSet();
                    adapter.Fill(dataset, "TableData");
                    comboBox3.DisplayMember = "TenChatLieu";
                    comboBox3.ValueMember = "TenChatLieu";
                    comboBox3.DataSource = dataset.Tables["TableData"];

                    query = "SELECT TenDacDiem FROM DacDiem";
                    adapter = new SqlDataAdapter(query, connection);
                    dataset = new DataSet();
                    adapter.Fill(dataset, "TableData");
                    comboBox4.DisplayMember = "TenDacDiem";
                    comboBox4.ValueMember = "TenDacDiem";
                    comboBox4.DataSource = dataset.Tables["TableData"];

                    query = "SELECT TenMau FROM MauSac";
                    adapter = new SqlDataAdapter(query, connection);
                    dataset = new DataSet();
                    adapter.Fill(dataset, "TableData");
                    comboBox5.DisplayMember = "TenMau";
                    comboBox5.ValueMember = "TenMau";
                    comboBox5.DataSource = dataset.Tables["TableData"];

                    query = "SELECT TenNoiSX FROM NoiSanXuat";
                    adapter = new SqlDataAdapter(query, connection);
                    dataset = new DataSet();
                    adapter.Fill(dataset, "TableData");
                    comboBox6.DisplayMember = "TenNoiSX";
                    comboBox6.ValueMember = "TenNoiSX";
                    comboBox6.DataSource = dataset.Tables["TableData"];
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
            this.Close();
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            FormTimKiemSP form1 = new FormTimKiemSP();
            form1.Show();
        }
        public DataGridView getDataGridView1
        {
            get { return dataGridView1; }
        }
        private void Form_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT HangHoa.MaHang as N'Mã Hàng', " +
                                "HangHoa.TenHang as N'Tên Hàng', " +
                                "HangHoa.DonGiaNhap as N'Giá Nhập', " +
                                "HangHoa.DonGiaBan as N'Giá Bán', " +
                                "HangHoa.SoLuong as N'Số lượng', " +
                                "Loai.TenLoai as N'Loại', " +
                                "HinhDang.TenHinhDang as N'Hình Dạng', " +
                                "ChatLieu.TenChatLieu as N'Chất Liệu', " +
                                "DacDiem.TenDacDiem as N'Đặc Điểm', " +
                                "MauSac.TenMau as N'Màu Sắc', " +
                                "HangHoa.ThoiGianBaoHanh as N'Bảo Hành', " +
                                "NoiSanXuat.TenNoiSX as N'Nơi SX' " +
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
                    dataGridView1.Columns.Clear();
                    dataGridView1.DataSource = dataSet.Tables[0];

                    connection.Close();
                }
            }
        }
        private bool check()
        {
            if( textBox2.Text == "" || textBox3.Text == "" ||
                textBox4.Text == "" || textBox5.Text == "" || comboBox1.SelectedIndex == -1 ||
                comboBox2.SelectedIndex == -1 || comboBox3.SelectedIndex == -1 || comboBox4.SelectedIndex == -1 ||
                comboBox5.SelectedIndex == -1 || comboBox6.SelectedIndex == -1 || comboBox7.SelectedIndex == -1)
            {
                return false;
            }
            return true;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(check() == true) 
            {
                string val1 = string.Empty;
                string val2 = textBox2.Text;
                string val3 = (comboBox1.SelectedIndex + 1).ToString();
                string val4 = (comboBox2.SelectedIndex + 1).ToString();
                string val5 = (comboBox3.SelectedIndex + 1).ToString();
                string val6 = (comboBox4.SelectedIndex + 1).ToString();
                string val7 = (comboBox5.SelectedIndex + 1).ToString();
                string val8 = (comboBox6.SelectedIndex + 1).ToString();
                string val12 = comboBox7.SelectedIndex.ToString();
                string val10 = textBox3.Text;
                string val11 = textBox4.Text;
                string val9 = textBox5.Text;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        string selectQuery = "SELECT MAX(MaHang) FROM HangHoa";
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

                        string insertQuery = "INSERT INTO HangHoa (MaHang, TenHang, MaLoai, MaHinhDang, MaChatLieu, " +
                                                          "CongDung, MaDacDiem, MaMau, MaNoiSX, SoLuong, DonGiaNhap, " +
                                                          "DonGiaBan, ThoiGianBaoHanh, Anh, GhiChu) " +
                                                          "VALUES (@Value1, @Value2, @Value3, @Value4, @Value5, '', " +
                                                          "@Value6, @Value7, @Value8, @Value9, @Value10, @Value11, " +
                                                          "@Value12, '', '')";

                        using (SqlCommand command = new SqlCommand(insertQuery, connection))
                        {
                            command.Parameters.AddWithValue("@Value1", val1);
                            command.Parameters.AddWithValue("@Value2", val2);
                            command.Parameters.AddWithValue("@Value3", val3);
                            command.Parameters.AddWithValue("@Value4", val4);
                            command.Parameters.AddWithValue("@Value5", val5);
                            command.Parameters.AddWithValue("@Value6", val6);
                            command.Parameters.AddWithValue("@Value7", val7);
                            command.Parameters.AddWithValue("@Value8", val8);
                            command.Parameters.AddWithValue("@Value9", val9);
                            command.Parameters.AddWithValue("@Value10", val10);
                            command.Parameters.AddWithValue("@Value11", val11);
                            command.Parameters.AddWithValue("@Value12", val12);
                            command.ExecuteNonQuery();

                            Form_Load(this, e);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Hãy điền hết tất cả dữ liệu");
            }
        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có muốn xóa những trường này không", "Confirm", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();

                            foreach (DataGridViewRow selectedRow in dataGridView1.SelectedRows)
                            {
                                string selectedIdentifier = selectedRow.Cells[0].Value.ToString();

                                string deleteQuery = "DELETE FROM HangHoa WHERE MaHang = @MaHang";
                                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                                {
                                    command.Parameters.AddWithValue("@MaHang", selectedIdentifier);
                                    command.ExecuteNonQuery();
                                }
                                Form_Load(this, e);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Hãy chọn một hoặc nhiều trường để xóa.");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
            comboBox6.SelectedIndex = 0;
            comboBox7.SelectedIndex = -1;
			dataGridView1.ClearSelection();
			Form_Load(this, e);
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
			DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
			int primaryKey = Convert.ToInt32(selectedRow.Cells[0].Value);

            string textBox2val = textBox2.Text;
            double? textBox3val = string.IsNullOrWhiteSpace(textBox3.Text) ? (double?)null : Convert.ToDouble(textBox3.Text);
            double? textBox4val = string.IsNullOrWhiteSpace(textBox4.Text) ? (double?)null : Convert.ToDouble(textBox4.Text);
            int? textBox5val = string.IsNullOrWhiteSpace(textBox5.Text) ? (int?)null : Convert.ToInt32(textBox5.Text);
            int comboBox1val = Convert.ToInt32(comboBox1.SelectedIndex == -1 ? (int?)null : comboBox1.SelectedIndex + 1);
            int comboBox2val = Convert.ToInt32(comboBox2.SelectedIndex == -1 ? (int?)null : comboBox2.SelectedIndex + 1);
            int comboBox3val = Convert.ToInt32(comboBox3.SelectedIndex == -1 ? (int?)null : comboBox3.SelectedIndex + 1);
            int comboBox4val = Convert.ToInt32(comboBox4.SelectedIndex == -1 ? (int?)null : comboBox4.SelectedIndex + 1);
            int comboBox5val = Convert.ToInt32(comboBox5.SelectedIndex == -1 ? (int?)null : comboBox5.SelectedIndex + 1);
            int comboBox6val = Convert.ToInt32(comboBox6.SelectedIndex == -1 ? (int?)null : comboBox6.SelectedIndex + 1);
            int comboBox7val = Convert.ToInt32(comboBox7.Text);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string updateQuery = "UPDATE HangHoa SET " +
                                    "TenHang = ISNULL(@text2, TenHang), " +
                                    "MaLoai = ISNULL(@combo1, MaLoai), " +
                                    "MaHinhDang = ISNULL(@combo2, MaHinhDang), " +
                                    "MaChatLieu = ISNULL(@combo3, MaChatLieu), " +
                                    "MaDacDiem = ISNULL(@combo4, MaDacDiem), " +
                                    "MaMau = ISNULL(@combo5, MaMau), " +
                                    "MaNoiSX = ISNULL(@combo6, MaNoiSX), " +
                                    "ThoiGianBaoHanh = ISNULL(@combo7, ThoiGianBaoHanh), " +
                                    "DonGiaNhap = ISNULL(@text3, DonGiaNhap), " +
                                    "DonGiaBan = ISNULL(@text4, DonGiaBan), " +
                                    "SoLuong = ISNULL(@text5, SoLuong) " +
                                    "WHERE MaHang = @Key";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@text2", textBox2val);
                        command.Parameters.AddWithValue("@combo1", comboBox1val);
                        command.Parameters.AddWithValue("@combo2", comboBox2val);
                        command.Parameters.AddWithValue("@combo3", comboBox3val);
                        command.Parameters.AddWithValue("@combo4", comboBox4val);
                        command.Parameters.AddWithValue("@combo5", comboBox5val);
                        command.Parameters.AddWithValue("@combo6", comboBox6val);
                        command.Parameters.AddWithValue("@combo7", comboBox7val);
                        command.Parameters.AddWithValue("@text3", textBox3val);
                        command.Parameters.AddWithValue("@text4", textBox4val);
                        command.Parameters.AddWithValue("@text5", textBox5val);
                        command.Parameters.AddWithValue("@Key", primaryKey);
                        command.ExecuteNonQuery();

                        Form_Load(this, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
		}
    }
}
