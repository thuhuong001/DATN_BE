using DATN_NguyenThiThuHuong.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN_NguyenThiThuHuong.BL.Interfaces
{
    public interface IRegionService
    {
        public List<Region> getByParentId(int id);
    }
}
