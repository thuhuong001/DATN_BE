using DATN_NguyenThiThuHuong.Common.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN_NguyenThiThuHuong.BL.Interfaces
{
    public interface IProductService: IBaseService<Product>
    {
        public bool UpdateSold(Guid productId, int sold);
        /// <summary>
        /// Lấy danh sách có bộ lọc
        /// </summary>
        /// <param name="parameters">Param bộ lọc truyền vào truyền vào</param>
        /// <returns>Danh sách đối tượng</returns>
        public object GetByFilterDetail(dynamic parameters);

        public object GetByIDDetail([FromRoute] Guid id);
    }
}
