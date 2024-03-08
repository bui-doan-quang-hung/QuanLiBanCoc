using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiBanCoc
{
    public partial class Form1 : Form
    {
        private string connectionString = UserSession.connectionString;
        public Form1()
        {
            InitializeComponent();
        }
        
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = textUsername.Text;
            string password = textPassword.Text;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT (SELECT COUNT(*) FROM NhanVien " +
                    "WHERE Username = @Username AND Password = @Password) AS Count, " +
                    "TenNV, MaCV, Username, Password, MaNV FROM NhanVien " +
                    "WHERE Username = @Username AND Password = @Password";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);
                    connection.Open();
                    int count;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            count = Convert.ToInt32(reader["Count"]);
                            if(count > 0)
                            {
                                UserSession.TenNV = reader["TenNV"].ToString();
                                UserSession.MaCV = reader["MaCV"].ToString();
                                UserSession.Username = reader["Username"].ToString();
                                UserSession.Password = reader["Password"].ToString();
                                UserSession.MaNV = reader["MaNV"].ToString();
                                // Login successful
                                Form2 form2 = new Form2();
                                form2.Show();
                                this.Hide();
                            }
                            else
                            {
                                // Login failed
                                MessageBox.Show("Invalid username or password. Please try again.");
                            }
                        }
                    }
                    connection.Close();
                }
            }
        }
    }
}
