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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLiBanCoc.NhanVien
{
    public partial class FormQLNV : Form
    {
        private string connectionString = UserSession.connectionString;
        public FormQLNV()
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
                    string query = "SELECT TenCV FROM CongViec";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataSet dataset = new DataSet();
                    adapter.Fill(dataset, "TableData");
                    comboBox2.DisplayMember = "TenCV";
                    comboBox2.ValueMember = "TenCV";
                    comboBox2.DataSource = dataset.Tables["TableData"];
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
		public DataGridView getDataGridView1
		{
			get { return dataGridView1; }
		}
		public void Form_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT NhanVien.MaNV AS N'Mã NV', NhanVien.TenNV AS N'Tên NV', " +
                    "NhanVien.GioiTinh AS N'Giới Tính', CAST(NhanVien.NgaySinh AS DATE) AS N'Ngày Sinh', " +
                    "NhanVien.DienThoai AS N'SĐT', NhanVien.DiaChi AS N'Địa Chỉ', CongViec.TenCV as N'Công Việc'," +
                    "NhanVien.Username AS N'Username' FROM NhanVien JOIN CongViec ON CongViec.MaCV = NhanVien.MaCV";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    dataGridView1.Columns.Clear();
                    dataGridView1.DataSource = dataSet.Tables[0];

                    connection.Close();
                }
                dateTimePicker1.Format = DateTimePickerFormat.Custom;
                dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            }
        }
        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
            this.Close();
        }
        private bool check()
        {
            if (textBox1.Text == "" || comboBox2.Text == "" ||
                textBox6.Text == "" || textBox5.Text == "" || comboBox1.SelectedIndex == -1)
            {
                return false;
            }
            return true;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (check() == true)
            {
                string val1 = string.Empty;
                string val2 = textBox1.Text;
                string val3 = comboBox1.Text;
                string val4 = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss");
                string val5 = textBox6.Text;
                string val6 = textBox5.Text;
                string val7 = (comboBox2.SelectedIndex + 1).ToString();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        string selectQuery = "SELECT MAX(MaNV) FROM NhanVien";
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

                        string insertQuery = "INSERT INTO NhanVien (MaNV, TenNV, GioiTinh, NgaySinh, DienThoai, " +
                                                          "DiaChi, MaCV, Username, Password) " +
                                                          "VALUES (@Value1, @Value2, @Value3, @Value4, @Value5, " +
                                                          "@Value6, @Value7, NULL, NULL)";

                        using (SqlCommand command = new SqlCommand(insertQuery, connection))
                        {
                            command.Parameters.AddWithValue("@Value1", val1);
                            command.Parameters.AddWithValue("@Value2", val2);
                            command.Parameters.AddWithValue("@Value3", val3);
                            command.Parameters.AddWithValue("@Value4", val4);
                            command.Parameters.AddWithValue("@Value5", val5);
                            command.Parameters.AddWithValue("@Value6", val6);
                            command.Parameters.AddWithValue("@Value7", val7);
                            command.ExecuteNonQuery();

                            Form_Load(this, e);
                        }
                    }
                    catch (Exception ex)
                    {
                       // MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Hãy điền hết tất cả dữ liệu");
            }
        }
        private void button2_Click(object sender, EventArgs e)
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

                                string deleteQuery = "DELETE FROM NhanVien WHERE MaNV = @MaNV";
                                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                                {
                                    command.Parameters.AddWithValue("@MaNV", selectedIdentifier);
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
        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox6.Text = string.Empty;
            textBox5.Text = string.Empty;
            dateTimePicker1.Value = DateTime.Now;
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = 0;
			dataGridView1.ClearSelection();
			Form_Load(this, e);
        }
		private void btnFind_Click(object sender, EventArgs e)
		{
            FormTimKiemNV form = new FormTimKiemNV();
            form.Show();
		}
        private void button1_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            int primaryKey = Convert.ToInt32(selectedRow.Cells[0].Value);

            string textBox1val = textBox1.Text;
            string comboBox1val = comboBox1.SelectedIndex == -1 ? null : comboBox1.Text;
            string date1 = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string textBox6val = textBox6.Text;
            string textBox5val = textBox5.Text;
            int comboBox2val = Convert.ToInt32(comboBox2.SelectedIndex == -1 ? (int?)null : comboBox2.SelectedIndex + 1);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string updateQuery = "UPDATE NhanVien SET " +
                                    "TenNV = ISNULL(@text1, TenNV), " +
                                    "GioiTinh = ISNULL(@combo1, GioiTinh), " +
                                    "NgaySinh = ISNULL(@date1, NgaySinh), " +
                                    "DienThoai = ISNULL(@text6, DienThoai), " +
                                    "DiaChi = ISNULL(@text5, DiaChi), " +
                                    "MaCV = ISNULL(@combo2, MaCV) " +
                                    "WHERE MaNV = @Key";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@text1", textBox1val);
                        command.Parameters.AddWithValue("@combo1", comboBox1val);
                        command.Parameters.AddWithValue("@date1", date1);
                        command.Parameters.AddWithValue("@text6", textBox6val);
                        command.Parameters.AddWithValue("@text5", textBox5val);
                        command.Parameters.AddWithValue("@combo2", comboBox2val);
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
        private void FormQLNV_Load(object sender, EventArgs e)
        {

        }
        private void button4_Click(object sender, EventArgs e)
        {
            FormTaoTK form1 = new FormTaoTK();
            form1.Show();
        }
    }
}
