using DATN_NguyenThiThuHuong.BL.Interfaces;
using DATN_NguyenThiThuHuong.Common.Models;
using DATN_NguyenThiThuHuong.Common.Models.DTO;
using DATN_NguyenThiThuHuong.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN_NguyenThiThuHuong.BL.Services
{
    public class BrandService : BaseService<Brand>, IBrandService
    {
        private readonly IBrandService _brandService;
        public BrandService(IBaseDL<Brand> baseDL) : base(baseDL)
        {
        }

        /// <summary>
        /// Xóa nhiều bản ghi
        /// </summary>
        /// <param name="listId">ListID</param>
        /// <returns>Số bản ghi thay đổi</returns>
        public override bool DeleteRecords(List<Guid> listId)
        {
            return _baseDL.DeleteUpdateRecords(listId);
        }
    }
}
