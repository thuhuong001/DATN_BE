using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN_NguyenThiThuHuong.Common.Models
{
    public class Supply
    {
        public Guid SupplyId { get; set; }
        public DateTime SupplyDate { get; set; }
        public int Quantity { get; set; }
        public decimal PriceSupply { get; set; }
        public Guid SupplierId { get; set; }
        public Guid ProductVariantId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string SupplierName { get; set; }
        public string ColorName { get; set; }
        public string SizeCode { get; set; }
        public string SizeNumber { get; set; }
        public Supply()
        {

        }
        public Supply(Guid supplyId, DateTime supplyDate, int quantity, decimal price, Guid supplierId, Guid productVariantId)
        {
            this.SupplyId = supplyId;
            this.SupplyDate = supplyDate;
            this.Quantity = quantity;
            this.PriceSupply = price;
            this.SupplierId = supplierId;
            this.ProductVariantId = productVariantId;
        }
    }
}
