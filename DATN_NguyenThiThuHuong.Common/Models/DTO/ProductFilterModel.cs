using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN_NguyenThiThuHuong.Common.Models.DTO
{
    public class ProductFilterModel : PagingModel
    {
        public int FilterType { get; set; }
    }
}
