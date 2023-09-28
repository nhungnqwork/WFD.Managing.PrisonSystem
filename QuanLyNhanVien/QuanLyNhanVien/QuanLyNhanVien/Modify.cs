using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanVien
{
    internal class Modify
    {
        public Modify() { }
        //Dataset
        //DataTable
        SqlDataAdapter dataAdapter;
        SqlCommand sqlCommand;

        public DataTable getAllNhanVien()
        {
            DataTable dataTable = new DataTable();
            string query = "select * from tNhanVien";
            using (SqlConnection sqlConnection = Connection.getConnection())
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter(query, sqlConnection);
                dataAdapter.Fill(dataTable);
                sqlConnection.Close();
            }
            return dataTable;
        }

        public bool insert(NhanVien nhanVien)
        {
            SqlConnection sqlConnection = Connection.getConnection();
            string query = "insert into tNhanVien values (@MaNV,@TenNV,@GioiTinh,@NgaySinh,@DiaChi,@DienThoai)";
            //  5       4       3       2       1           0
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@MaNV", SqlDbType.NVarChar).Value = nhanVien.MaNV;
                sqlCommand.Parameters.Add("@TenNV", SqlDbType.NVarChar).Value = nhanVien.TenNV;
                sqlCommand.Parameters.Add("@GioiTinh", SqlDbType.NVarChar).Value = nhanVien.GioiTinh;
                sqlCommand.Parameters.Add("@NgaySinh", SqlDbType.DateTime).Value = nhanVien.NgaySinh.ToShortTimeString();
                sqlCommand.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = nhanVien.DiaChi;
                sqlCommand.Parameters.Add("@DienThoai", SqlDbType.NVarChar).Value = nhanVien.DienThoai;
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }

        public bool update(NhanVien nhanVien)
        {
            SqlConnection sqlConnection = Connection.getConnection();
            string query = "update tNhanVien set TenNV = @TenNV,GioiTinh = @GioiTinh,DiaChi = @DiaChi,DienThoai = @DienThoai Where MaNV=@MaNV";
            //  5       4       3       2       1           0
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@MaNV", SqlDbType.NVarChar).Value = nhanVien.MaNV;
                sqlCommand.Parameters.Add("@TenNV", SqlDbType.NVarChar).Value = nhanVien.TenNV;
                sqlCommand.Parameters.Add("@GioiTinh", SqlDbType.NVarChar).Value = nhanVien.GioiTinh;
                sqlCommand.Parameters.Add("@NgaySinh", SqlDbType.DateTime).Value = nhanVien.NgaySinh.ToShortTimeString();
                sqlCommand.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = nhanVien.DiaChi;
                sqlCommand.Parameters.Add("@DienThoai", SqlDbType.NVarChar).Value = nhanVien.DienThoai;
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }

        public bool delete(string manv)
        {
            SqlConnection sqlConnection = Connection.getConnection();
            string query = "delete tNhanVien Where MaNV=@MaNV";
            //  5       4       3       2       1           0
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@MaNV", SqlDbType.NVarChar).Value = manv;
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }
    }
}
