using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN_NguyenThiThuHuong.Common.Models
{
    public class OrderDetail
    {
        public Guid OrderDetailId { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public decimal PriceSale { get; set; }
        public decimal PriceDel { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductVariantId { get; set; }
        public string ImageLink { get; set; }
        public string ProductName { get; set; }
        public string ColorName { get; set; }
        public string SizeNumber { get; set; }
        public decimal TotalPrice
        {
            get
            {
                return Quantity * PriceDel;
            }
        }
        public OrderDetail() 
        {

        }
    }
}
