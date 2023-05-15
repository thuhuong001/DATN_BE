using DATN_NguyenThiThuHuong.BL.Interfaces;
using DATN_NguyenThiThuHuong.Common.Models;
using DATN_NguyenThiThuHuong.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN_NguyenThiThuHuong.BL.Services
{
    public class ProductService : BaseService<Product>, IProductService
    {
        private readonly IProductDL _productDL;
        public ProductService(IProductDL productDL) : base(productDL)
        {
            _productDL = productDL;
        }

        public bool UpdateSold(Guid productId, int sold)
        {
            return _productDL.UpdateSold(productId, sold);
        }
        public object GetByFilterDetail(object parameters)
        {
            return _productDL.GetByFilterDetail(parameters);
        }

        public object GetByIDDetail(Guid id)
        {
            return _productDL.GetByIDDetail(id);
        }

        /// <summary>
        /// Xóa nhiều bản ghi
        /// </summary>
        /// <param name="listId">ListID</param>
        /// <returns>Số bản ghi thay đổi</returns>
        public override bool DeleteRecords(List<Guid> listId)
        {
            return _productDL.DeleteUpdateRecords(listId);
        }
    }
}
