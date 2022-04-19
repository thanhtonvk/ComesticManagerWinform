using System.Collections.Generic;
using QuanLyMyPham.Models;

namespace QuanLyMyPham.DAL.InterfaceService
{
    public interface ILoaiSanPhamDAL
    {
        int Add(LoaiSanPham loaiSanPham);
        int Update(LoaiSanPham loaiSanPham);
        int Delete(int id);
        List<LoaiSanPham> GetAll();
        LoaiSanPham GetLoaiSanPham(int id);
    }
}