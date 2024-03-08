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

namespace QuanLiBanCoc.KhachHang
{
    public partial class QLKH : Form
    {
        private string connectionString = UserSession.connectionString;
        public QLKH()
        {
            InitializeComponent();
			this.Load += Form_Load;
        }
		private void Form_Load(object sender, EventArgs e)
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();

				string query = "SELECT KhachHang.MaKhach as N'Mã KH', " +
								"KhachHang.TenKhach as N'Tên KH', " +
								"KhachHang.DienThoai as N'Điện Thoại', " +
								"KhachHang.DiaChi as N'Địa Chỉ' " +
								"FROM KhachHang ";

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
		private void buttonLogOut_Click(object sender, EventArgs e)
		{
			Form2 form = new Form2();
			form.Show();
			this.Close();
		}
		private bool check()
		{
			if (textBox1.Text == "" ||
				textBox6.Text == "" || 
				textBox5.Text == "")
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
				string val3 = textBox6.Text;
				string val4 = textBox5.Text;

				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					try
					{
						connection.Open();

						string selectQuery = "SELECT MAX(MaKhach) FROM KhachHang";
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

						string insertQuery = "INSERT INTO KhachHang (MaKhach, TenKhach, DienThoai, DiaChi) " +
														  "VALUES (@Value1, @Value2, @Value3, @Value4)";

						using (SqlCommand command = new SqlCommand(insertQuery, connection))
						{
							command.Parameters.AddWithValue("@Value1", val1);
							command.Parameters.AddWithValue("@Value2", val2);
							command.Parameters.AddWithValue("@Value3", val3);
							command.Parameters.AddWithValue("@Value4", val4);
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

								string deleteQuery = "DELETE FROM Khachhang WHERE MaKhach = @MaKH";
								using (SqlCommand command = new SqlCommand(deleteQuery, connection))
								{
									command.Parameters.AddWithValue("@MaKH", selectedIdentifier);
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
			Form_Load(this, e);
			dataGridView1.ClearSelection();
		}

        private void button1_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            int primaryKey = Convert.ToInt32(selectedRow.Cells[0].Value);

            string textBox1val = textBox1.Text;
            string textBox6val = textBox6.Text;
            string textBox5val = textBox5.Text;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string updateQuery = "UPDATE KhachHang SET " +
                                    "TenKhach = ISNULL(@text1, TenKhach), " +
                                    "DienThoai = ISNULL(@text6, DienThoai), " +
                                    "DiaChi = ISNULL(@text5, DiaChi) " +
                                    "WHERE MaKhach = @Key";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@text1", textBox1val);
                        command.Parameters.AddWithValue("@text6", textBox6val);
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
