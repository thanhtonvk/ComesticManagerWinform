using QuanLyMyPham.DAL.InterfaceService;
using QuanLyMyPham.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyMyPham.DAL
{
    internal class SanPhamDAL : ISanPhamDAL
    {
        private DBContext db = new DBContext();

        public int Add(SanPham sanPham)
        {
            db.SanPhams.Add(sanPham);
            return db.SaveChanges();
        }

        public int Update(SanPham sanPham)
        {
            var model = db.SanPhams.Find(sanPham.MaSP);
            if (model != null)
            {
                model.TenSP = sanPham.TenSP;
                model.SoLo = sanPham.SoLo;
                model.NgaySX = sanPham.NgaySX;
                model.MaLoai = sanPham.MaLoai;
                model.DonGia = sanPham.DonGia;
                model.HanSD = sanPham.HanSD;
                return db.SaveChanges();
            }
            return 0;
        }

        public int Delete(int id)
        {
            var model = db.SanPhams.Find(id);
            if (model != null)
            {
                db.SanPhams.Remove(model);
                db.SaveChanges();
            }

            return 0;
        }

        public List<SanPham> GetAll()
        {
            return db.SanPhams.ToList();
        }

        public SanPham GetSanPham(int id)
        {
            return db.SanPhams.Find(id);
        }
    }
}
