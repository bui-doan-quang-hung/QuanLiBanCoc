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
    public partial class FormTaoTK : Form
    {
        private string connectionString = UserSession.connectionString;
        public FormTaoTK()
        {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {

            int textBox1val = Convert.ToInt32(textBox1.Text);
            string textBox2val = textBox2.Text;
            string textBox3val = textBox3.Text;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string updateQuery = "UPDATE NhanVien SET " +
                                    "Username = ISNULL(@text2, Username), " +
                                    "Password = ISNULL(@text3, Password) " +
                                    "WHERE MaNV = @text1";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@text1", textBox1val);
                        command.Parameters.AddWithValue("@text2", textBox2val);
                        command.Parameters.AddWithValue("@text3", textBox3val);
                        command.ExecuteNonQuery();
                        FormQLNV form = Application.OpenForms["FormQLNV"] as FormQLNV;
                        form.Form_Load(this, e);
                    }
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
