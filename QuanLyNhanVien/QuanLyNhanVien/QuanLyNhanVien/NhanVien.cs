using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanVien
{
    internal class NhanVien
    {
        private string _maNV;
        private string _tenNV;
        private string _gioiTinh;
        private DateTime _ngaySinh;
        private string _diaChi;
        private string _dienThoai;

        public NhanVien()
        {
        }

        public NhanVien(string maNV, string tenNV, string gioiTinh, DateTime ngaySinh, string diaChi, string dienThoai)
        {
            _maNV = maNV;
            _tenNV = tenNV;
            _gioiTinh = gioiTinh;
            _ngaySinh = ngaySinh;
            _diaChi = diaChi;
            _dienThoai = dienThoai;
        }

        public string MaNV { get => _maNV; set => _maNV = value; }
        public string TenNV { get => _tenNV; set => _tenNV = value; }
        public string GioiTinh { get => _gioiTinh; set => _gioiTinh = value; }
        public DateTime NgaySinh { get => _ngaySinh; set => _ngaySinh = value; }
        public string DiaChi { get => _diaChi; set => _diaChi = value; }
        public string DienThoai { get => _dienThoai; set => _dienThoai = value; }
    }
}
