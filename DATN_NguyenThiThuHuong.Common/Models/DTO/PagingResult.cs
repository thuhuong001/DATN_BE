using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN_NguyenThiThuHuong.Common.Models.DTO
{
    /// <summary>
    /// Dữ liệu trả về dữ liệu đối tượng
    /// </summary>
    public class PagingResult<T>
    {
        /// <summary>
        /// Tổng số bản ghi filter
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// Dữ liệu list
        /// </summary>
        public List<T> Data { get; set; }
    }
}