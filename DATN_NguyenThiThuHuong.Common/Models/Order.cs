using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN_NguyenThiThuHuong.Common.Models
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public string OrderCode { get; set; }
        public int TotalAmount { get; set; }
        public int PaymentMethod { get; set; }
        public decimal TotalPrice { get; set; }
        public string Note { get; set; }
        public int Status { get; set; }
        public string CancelReason { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public Guid AddressReceiveId { get; set; }
        public Guid ShipmentId { get; set; }
        public string ShipmentName { get; set; }
        public string Receiver { get; set; }
        public string AddressDetail { get; set; }
        public string Phone { get; set; }
        public string ImageLink { get; set; }
        public int Quantity { get; set; }
        public int IsPaid { get; set; }
        public Guid CustomerId { get; set; }
        public decimal PriceShip { get; set; }
        public DateTime DateReceive { get; set; }
        public string FullName { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
    public class OrderDB : Order
    {
        public string ColorName { get; set; }
        public string SizeNumber { get; set; }
        public Guid OrderDetailId { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public decimal PriceDel { get; set; }
        public string ProductName { get; set; }
        public string ImageLink { get; set; }
    }
    public class UpdateOrder
    {
        public Guid OrderId { get; set; }
        public int Status { get; set; }
    }
}

