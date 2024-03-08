using QuanLiBanCoc.NhanVien;
using QuanLiBanCoc.KhachHang;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiBanCoc
{
    public partial class Form2 : Form
    {
        string tenNV = UserSession.TenNV;
        int MaCV = Convert.ToInt16(UserSession.MaCV);
        public Form2()
        {
            InitializeComponent();
            label1.Text = "Welcome back, " + tenNV;
        }
        //Logout
        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            UserSession.Username = null;
            UserSession.Password = null;
            UserSession.MaCV = null;
            UserSession.TenNV = null;
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }
        //Quan li San pham
        private void buttonQLSP_Click(object sender, EventArgs e)
        {
            if(MaCV <= 2)
            {
                FormQLSP form1 = new FormQLSP();
                form1.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền quản lí sản phẩm (Quản lí trở lên)");
            }
        }
        //Ban Hang
        private void buttonThanhToan_Click(object sender, EventArgs e)
        {
            FormBanHang form1 = new FormBanHang();
            form1.Show();
            this.Hide();
        }
        //Kiem tra Hoa don
        private void buttonHoaDon_Click(object sender, EventArgs e)
        {
            if(MaCV <= 2)
            {
                Transition form = new Transition();
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập hóa đơn (Quản lí trở lên)");
            }
        }
        //Nhap Hang
        private void button2_Click(object sender, EventArgs e)
        {
            if(MaCV <= 2)
            {
                FormNhapHang form = new FormNhapHang();
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Bạn không được phép nhập thêm hàng (Quản lí trở lên)");
            }
        }
        //Quan li Nhan vien
        private void buttonQLNV_Click(object sender, EventArgs e)
        {
            if (MaCV <= 2)
            {
                FormQLNV form = new FormQLNV();
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Bạn không được phép nhập quản lí nhân viên (Quản lí trở lên)");
            }
        }
        //Quan li Khach Hang
        private void button1_Click(object sender, EventArgs e)
        {
            if (MaCV <= 2)
            {
                QLKH form = new QLKH();
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Bạn không được phép nhập quản lí khách hàng (Quản lí trở lên)");
            }
        }
    }
}
