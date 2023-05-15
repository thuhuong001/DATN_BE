using DATN_NguyenThiThuHuong.BL.Interfaces;
using DATN_NguyenThiThuHuong.Common.Enums;
using DATN_NguyenThiThuHuong.Common.Models.DTO;
using DATN_NguyenThiThuHuong.Common.Models;
using DATN_NguyenThiThuHuong.Common.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATN_NguyenThiThuHuong.DL.Interfaces;

namespace DATN_NguyenThiThuHuong.BL.Services
{
    public class OrderService : BaseService<Order>, IOrderService
    {
        private readonly IOrderDL _orderDL;
        public OrderService(IOrderDL orderDL) : base(orderDL)
        {
            _orderDL = orderDL;
        }

        public override Order processPropertyCustom(Order order, bool IsInsert)
        {

            Random random = new Random();
            if(string.IsNullOrEmpty(order.OrderCode))
            {
                string orderDetailCode = "DH" + DateTime.Now.ToString("yyyyMMddHHmmss");
                order.OrderCode = orderDetailCode;
            }
            order.OrderDetails.ForEach(d =>
            {
                d.CreatedAt = DateTime.Now;
                d.OrderId = order.OrderId;
                d.OrderDetailId = Guid.NewGuid();
                d.ProductVariantId = d.ProductVariantId;
                d.ProductName = d.ProductName;
                d.ColorName = d.ColorName;
                d.SizeNumber = d.SizeNumber;
                d.Discount = d.Discount;
                d.ImageLink = d.ImageLink;
                d.PriceDel = d.PriceDel;
                d.Quantity = d.Quantity;
                d.PriceSale = d.PriceSale;
            });
            return order;
        }

        public ServiceResult Insert(Order order, Guid customerId)
        {
            dynamic result;
            var isValid = this.IsValidate(order);

            // Kiểm tra validate
            if (isValid)
            {
                order.CustomerId = customerId;
                order = AddProperties(order, true, null, out Guid id);

                bool response = _orderDL.Insert(order, order.OrderDetails, customerId);
                if (!response)
                    result = new ServiceResult(EnumErrorCode.SERVER_ERROR, ResourceVI.ErrorServer, ResourceVI.ErrorServer);
                else result = new ServiceResult(id);
            }
            else
            {
                // trả về lỗi validate
                result = new ServiceResult(EnumErrorCode.BADREQUEST, ResourceVI.ErrorValidate, ResourceVI.ErrorValidate, listErrorValidate);
            }

            return result;
        }

        public bool UpdateStatus(Guid orderId, int status)
        {
            return _orderDL.UpdateStatus(orderId, status);
        }
    }
}
