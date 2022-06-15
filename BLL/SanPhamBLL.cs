using QuanLyMyPham.BLL.InterfaceService;
using QuanLyMyPham.DAL;
using QuanLyMyPham.DAL.InterfaceService;
using QuanLyMyPham.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyMyPham.BLL
{
    internal class SanPhamBLL : ISanPhamBLL
    {
        ISanPhamDAL dal = new SanPhamDAL();

        public string Add(SanPham sanPham)
        {
            int rs = dal.Add(sanPham);
            if (rs > 0) return "Thành công";
            return "Thất bại";
        }

        public string Delete(int id)
        {
            int rs = dal.Delete(id);
            if (rs > 0) return "Thành công";
            return "Thất bại"; ;
        }

        public List<SanPham> GetAll(string TimKiem)
        {
            if (string.IsNullOrEmpty(TimKiem))
            {
                return dal.GetAll();
            }
            return dal.GetAll().Where(
                x => x.TenSP.ToLower().Contains(TimKiem.ToLower())
            || x.MaSP.ToString().ToLower().Contains(TimKiem.ToLower())).ToList();
        }

        public SanPham GetSanPham(int id)
        {
            return dal.GetSanPham(id);
        }

        public string Update(SanPham sanPham)
        {
            int rs = dal.Update(sanPham);
            if (rs > 0) return "Thành công";
            return "Thất bại";
        }
    }
}
