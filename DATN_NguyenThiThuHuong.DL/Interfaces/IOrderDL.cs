using DATN_NguyenThiThuHuong.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN_NguyenThiThuHuong.DL.Interfaces
{
    public interface IOrderDL : IBaseDL<Order>
    {
        public bool Insert(Order order, List<OrderDetail> orderDetails, Guid customerId);
        public bool UpdateStatus(Guid orderId, int status);
    }
}
