using DATN_NguyenThiThuHuong.BL.Interfaces;
using DATN_NguyenThiThuHuong.Common.Models;
using DATN_NguyenThiThuHuong.DL.Interfaces;
using DATN_NguyenThiThuHuong.DL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN_NguyenThiThuHuong.BL.Services
{
    public class RegionService : IRegionService
    {
        private readonly IRegionDL _regionDL;
        public RegionService(IRegionDL regionDL)
        {
            _regionDL = regionDL;
        }
        public List<Region> getByParentId(int id)
        {
            return _regionDL.getByParentId(id);
        }
    }
}
