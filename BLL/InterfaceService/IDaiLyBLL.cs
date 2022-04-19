using System.Collections.Generic;
using QuanLyMyPham.Models;

namespace QuanLyMyPham.BLL.InterfaceService
{
    public interface IDaiLyBLL
    {
        string Add(DaiLy daiLy);
        string Update(DaiLy daiLy);
        string Delete(int id);
        List<DaiLy> GetAll(string TimKiem);
        DaiLy GetDaiLy(int id);
    }
}