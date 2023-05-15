using DATN_NguyenThiThuHuong.BL.Interfaces;
using DATN_NguyenThiThuHuong.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace DATN_NguyenThiThuHuong.API.Controllers
{
    [AuthenPermission]
    public class OrderDetailController : BaseController<OrderDetail>
    {
        private IBaseService<OrderDetail> _baseService;
        public OrderDetailController(IBaseService<OrderDetail> baseService, IHttpContextAccessor httpContextAccessor, IUserTokenService userTokenService) : base(baseService, httpContextAccessor, userTokenService)
        {
            _baseService = baseService;
        }
    }
}
