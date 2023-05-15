using DATN_NguyenThiThuHuong.BL.Interfaces;
using DATN_NguyenThiThuHuong.Common.Models;
using DATN_NguyenThiThuHuong.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN_NguyenThiThuHuong.BL.Services
{

    public class CartService : BaseService<Cart>, ICartService
    {
        private ICartDL _cartDL;
        public CartService(ICartDL cartDL) : base(cartDL)
        {
            _cartDL = cartDL;
        }

        public int CartNumber(Guid CustomerId)
        {
            return _cartDL.CartNumber(CustomerId);
        }
        public override object GetByFilter(object parameters)
        {
            return _cartDL.GetByFilter(parameters);
        }

        /// <summary>
        /// Cập nhật số lượng
        /// </summary>
        /// <param name="id"></param>
        /// <param name="quantity"> Trường hợp nhập hàng thì Quantity > 0, TH bán Quantity < 0</param>
        /// <returns>true - false</returns>
        public bool UpdateQuantity(Guid id, int quantity)
        {
            return _cartDL.UpdateQuantity(id, quantity);
        }
    }
}
