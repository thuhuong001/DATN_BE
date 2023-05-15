using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN_NguyenThiThuHuong.Common.Models
{
    public class ProductVariant
    {
        public Guid ProductVariantId { get; set; }
        public int Quantity { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public Guid ProductId { get; set; }
        public Guid ColorId { get; set; }
        public string ColorCode { get; set; }
        public List<Size> Sizes { get; set; }
        public Guid SupplierId { get; set; }
        public decimal PriceSupply { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public string ColorName { get; set; }
        public string SizeCode { get; set; }
        public string SizeNumber { get; set; }
        public Guid SizeId { get; set; }
    }
}
