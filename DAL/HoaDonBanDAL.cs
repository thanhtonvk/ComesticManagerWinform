using QuanLyMyPham.DAL.InterfaceService;
using QuanLyMyPham.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyMyPham.DAL
{
    internal class HoaDonBanDAL : IHoaDonBanDAL
    {
        DBContext db = new DBContext();
        public int Add(HoaDonBan hoaDonBan)
        {
            db.HoaDonBans.Add(hoaDonBan);
            return db.SaveChanges();
        }

        public int Delete(int id)
        {
            db.HoaDonBans.Remove(GetHoaDonBan(id));
            return db.SaveChanges();
        }

        public List<GetHoaDonBan_Result> GetAll()
        {
           return db.GetHoaDonBan().ToList();
        }

        public HoaDonBan GetHoaDonBan(int id)
        {
            return db.HoaDonBans.Find(id);
        }

        public int Update(HoaDonBan hoaDonBan)
        {
            var model = db.HoaDonBans.Find(hoaDonBan.MaHD);
            if (model != null)
            {
                model.NgayBan = hoaDonBan.NgayBan;
                model.TenKhach = hoaDonBan.TenKhach;
                model.DiaChi = hoaDonBan.DiaChi;
                model.SDT = hoaDonBan.SDT;
                return db.SaveChanges();
            }
            return 0;

        }
    }
}
