using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanCoc
{
    public static class UserSession
    {
        public static string MaNV { get; set; }
        public static string TenNV { get; set; }
        public static string MaCV { get; set; }
        public static string Username { get; set; }
        public static string Password { get; set; }
        public static string connectionString = "Data Source=LAPTOP-SRCDJ92D\\SQLEXPRESS;Initial Catalog=QLBanCoc;Integrated Security=True";
        // Add other properties as needed
    }
}
