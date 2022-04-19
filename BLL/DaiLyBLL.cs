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
    internal class DaiLyBLL : IDaiLyBLL
    {
        IDaiLyDAL dal = new DaiLyDAL();

        public string Add(DaiLy daiLy)
        {
            int rs = dal.Add(daiLy);
            if (rs > 0) return "Thành công";
            return "Thất bại";
        }

        public string Delete(int id)
        {
            int rs = dal.Delete(id);
            if (rs > 0) return "Thành công";
            return "Thất bại"; ;
        }

        public List<DaiLy> GetAll(string TimKiem)
        {
            if (string.IsNullOrEmpty(TimKiem))
            {
                return dal.GetAll();
            }
            return dal.GetAll().Where(
                x => x.TenDL.ToLower().Contains(TimKiem.ToLower())
            || x.DiaChi.ToLower().Contains(TimKiem.ToLower())
            || x.SDT.Contains(TimKiem.ToLower())).ToList();
        }

        public DaiLy GetDaiLy(int id)
        {
            return dal.GetDaiLy(id);
        }

        public string Update(DaiLy daiLy)
        {
            int rs = dal.Update(daiLy);
            if (rs > 0) return "Thành công";
            return "Thất bại"; ;
        }
    }
}
