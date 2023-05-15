using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN_NguyenThiThuHuong.Common.Models
{
    public class Cart: Image
    {
        public Guid CartId { get; set; }
        public int Quantity { get; set; }
        public decimal PriceSale { get; set; }
        public int Discount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ProductVariantId { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string ColorName { get; set; }
        public string SizeCode { get; set; }
        public string SizeNumber { get; set; }
        public int ProVariantQuantity { get; set; }
        public List<Image> Images { get; set; }
        public decimal TotalPrice
        {
            get
            {
                return Quantity * PriceSale * (decimal)(1 - Discount * 0.01);
            }
        }
        public decimal TotalDel
        {
            get
            {
                return Quantity * PriceSale;
            }
        }
        public decimal PriceDel
        {
            get
            {
                return PriceSale * (decimal)(1 - Discount * 0.01);
            }
            set
            {
                value = PriceDel;
            }
        }
        public Cart()
        {

        }
        public Cart(Guid cartId, int quantity, Guid customerId, Guid productVariantId)
        {
            this.CartId = cartId;
            this.Quantity = quantity;
            this.CustomerId = customerId;
            this.ProductVariantId = productVariantId;
        }
        public Cart(Guid cartId, int quantity, DateTime createdAt, DateTime modifiedAt, Guid customerId, Guid productVariantId)
        {
            CartId = cartId;
            Quantity = quantity;
            CreatedAt = createdAt;
            ModifiedAt = modifiedAt;
            CustomerId = customerId;
            ProductVariantId = productVariantId;
        }
    }
}
