using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QuanLyNhanVien
{
    internal class Connection
    {
        private static string stringConnection = @"Data Source=DESKTOP-77LQJ4S;Initial Catalog=QuanLyNhanVien;Integrated Security=True";
        public static SqlConnection getConnection()
        {
            return new SqlConnection(stringConnection);
        }
    }
}
