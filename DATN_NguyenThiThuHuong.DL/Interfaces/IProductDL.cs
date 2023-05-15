using DATN_NguyenThiThuHuong.Common.Models;
using DATN_NguyenThiThuHuong.Common.Models.DTO;
using DATN_NguyenThiThuHuong.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN_NguyenThiThuHuong.DL.Interfaces
{
    public interface IProductDL : IBaseDL<Product>
    {
        public bool UpdateSold(Guid productId, int sold);
        public object GetByFilterDetail(dynamic parametersFilter);
        public object GetByIDDetail(Guid id);
    }
}
