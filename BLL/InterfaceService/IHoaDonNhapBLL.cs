using System.Collections.Generic;
using QuanLyMyPham.Models;

namespace QuanLyMyPham.BLL.InterfaceService
{
    public interface IHoaDonNhapBLL
    {
        string Add(HoaDonNhap hoaDonNhap);
        string Update(HoaDonNhap hoaDonNhap);
        string Delete(int id);
        List<GetHoaDonNhap_Result> GetAll(string TimKiem);
        HoaDonNhap GetHoaDonNhap(int id);
    }
}