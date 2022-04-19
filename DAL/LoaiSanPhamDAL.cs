using System.Collections.Generic;
using System.Linq;
using QuanLyMyPham.DAL.InterfaceService;
using QuanLyMyPham.Models;

namespace QuanLyMyPham.DAL
{
    public class LoaiSanPhamDAL:ILoaiSanPhamDAL
    {
        private DBContext db = new DBContext();

        public int Add(LoaiSanPham loaiSanPham)
        {
            db.LoaiSanPhams.Add(loaiSanPham);
            return db.SaveChanges();
        }

        public int Update(LoaiSanPham loaiSanPham)
        {
            var model = db.LoaiSanPhams.Find(loaiSanPham.MaLoai);
            if (model != null)
            {
                model.TenLoai = loaiSanPham.TenLoai;
                return db.SaveChanges();
            }
            return 0;
        }

        public int Delete(int id)
        {
            var model = db.LoaiSanPhams.Find(id);
            if (model != null)
            {
                db.LoaiSanPhams.Remove(model);
                db.SaveChanges();
            }

            return 0;
        }

        public List<LoaiSanPham> GetAll()
        {
            return db.LoaiSanPhams.ToList();
        }

        public LoaiSanPham GetLoaiSanPham(int id)
        {
            return db.LoaiSanPhams.Find(id);
        }
    }
}