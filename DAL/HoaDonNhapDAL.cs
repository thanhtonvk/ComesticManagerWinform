using System.Collections.Generic;
using System.Linq;
using QuanLyMyPham.DAL.InterfaceService;
using QuanLyMyPham.Models;

namespace QuanLyMyPham.DAL
{
    public class HoaDonNhapDAL:IHoaDonNhapDAL
    {
        private DBContext db = new DBContext();

        public int Add(HoaDonNhap hoaDonNhap)
        {
            db.HoaDonNhaps.Add(hoaDonNhap);
            return db.SaveChanges();
        }

        public int Update(HoaDonNhap hoaDonNhap)
        {
            var model = db.HoaDonNhaps.Find(hoaDonNhap.MaHD);
            if (model != null)
            {
                model.NgayNhap = hoaDonNhap.NgayNhap;
                model.MaDL = hoaDonNhap.MaDL;
                return db.SaveChanges();
            }
            return 0;
        }

        public int Delete(int id)
        {
            var model = db.HoaDonNhaps.Find(id);
            if (model != null)
            {
                db.HoaDonNhaps.Remove(model);
                db.SaveChanges();
            }

            return 0;
        }

        public List<GetHoaDonNhap_Result> GetAll()
        {
            return db.GetHoaDonNhap().ToList();
        }

        public HoaDonNhap GetHoaDonNhap(int id)
        {
            return db.HoaDonNhaps.Find(id);
        }
    }
}