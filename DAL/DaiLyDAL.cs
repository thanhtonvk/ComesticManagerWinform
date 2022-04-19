using System.Collections.Generic;
using System.Linq;
using QuanLyMyPham.DAL.InterfaceService;
using QuanLyMyPham.Models;

namespace QuanLyMyPham.DAL
{
    public class DaiLyDAL:IDaiLyDAL
    {
        private DBContext db = new DBContext();

        public int Add(DaiLy daiLy)
        {
            db.DaiLies.Add(daiLy);
            return db.SaveChanges();
        }

        public int Update(DaiLy daiLy)
        {
            var model = db.DaiLies.Find(daiLy.MaDL);
            if (model != null)
            {
                model.TenDL = daiLy.TenDL;
                return db.SaveChanges();
            }
            return 0;
        }

        public int Delete(int id)
        {
            var model = db.DaiLies.Find(id);
            if (model != null)
            {
                db.DaiLies.Remove(model);
                db.SaveChanges();
            }

            return 0;
        }

        public List<DaiLy> GetAll()
        {
            return db.DaiLies.ToList();
        }

        public DaiLy GetDaiLy(int id)
        {
            return db.DaiLies.Find(id);
        }
    }
}