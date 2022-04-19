using System.Collections.Generic;
using System.Linq;
using QuanLyMyPham.DAL.InterfaceService;
using QuanLyMyPham.Models;

namespace QuanLyMyPham.DAL
{
    public class NhanVienDAL : INhanVienDAL
    {
        private DBContext db = new DBContext();

        public int Add(NhanVien nhanVien)
        {
            db.NhanViens.Add(nhanVien);
            return db.SaveChanges();
        }

        public int Update(NhanVien nhanVien)
        {
            var model = db.NhanViens.Find(nhanVien.MaNV);
            if (model != null)
            {
                model.TenNV = nhanVien.TenNV;
                model.DiaChi = nhanVien.DiaChi;
                model.SDT = nhanVien.SDT;
                return db.SaveChanges();
            }
            return 0;
        }

        public int Delete(int id)
        {
            var model = db.NhanViens.Find(id);
            if (model != null)
            {
                db.NhanViens.Remove(model);
                db.SaveChanges();
            }

            return 0;
        }

        public List<NhanVien> GetAll()
        {
            return db.NhanViens.ToList();
        }

        public NhanVien GetNhanVien(int id)
        {
            return db.NhanViens.Find(id);
        }
    }
}