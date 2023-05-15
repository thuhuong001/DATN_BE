using DATN_NguyenThiThuHuong.Common.Models;
using DATN_NguyenThiThuHuong.DL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN_NguyenThiThuHuong.DL.Interfaces
{
    public interface ICartDL : IBaseDL<Cart>
    {
        public int CartNumber(Guid CustomerId);

        public bool UpdateQuantity(Guid id, int quantity);
    }
}
