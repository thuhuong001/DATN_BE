using DATN_NguyenThiThuHuong.Common.Models.DTO;
using DATN_NguyenThiThuHuong.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN_NguyenThiThuHuong.BL.Interfaces
{
    public interface IOrderService : IBaseService<Order>
    {
        public ServiceResult Insert(Order order, Guid customerId);
        public bool UpdateStatus(Guid orderId, int status);
    }
}
