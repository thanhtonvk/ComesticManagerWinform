using QuanLyMyPham.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyMyPham.DAL.InterfaceService;

namespace QuanLyMyPham.DAL
{
    internal class TaiKhoanDAL : ITaiKhoanDAL
    {
        private DBContext db = new DBContext();

        public int Add(TaiKhoan taiKhoan)
        {
            db.TaiKhoans.Add(taiKhoan);
            return db.SaveChanges();
        }

        public string DangNhap(string TenDangNhap, string MatKhau)
        {
            var tk = db.TaiKhoans.FirstOrDefault(x => x.TenDangNhap == TenDangNhap && x.MatKhau == MatKhau);
            if (tk == null)
            {
                return "";
            }

            return tk.LoaiTK;
        }

        public int Delete(string id)
        {
            var tk = db.TaiKhoans.Find(id);
            db.TaiKhoans.Remove(tk);
            return db.SaveChanges();
        }

        public List<TaiKhoan> GetAll()
        {
            return db.TaiKhoans.ToList();
        }

        public TaiKhoan GetTaiKhoan(string TenDangNhap)
        {
            return db.TaiKhoans.Find(TenDangNhap);
        }

        public int Update(TaiKhoan taiKhoan)
        {
            var model = db.TaiKhoans.Find(taiKhoan.TenDangNhap);
            if (model != null)
            {
                model.MatKhau = taiKhoan.MatKhau;
                model.LoaiTK = taiKhoan.LoaiTK;
                return db.SaveChanges();
            }

            return 0;
        }
    }
}