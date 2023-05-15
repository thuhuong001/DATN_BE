using DATN_NguyenThiThuHuong.BL.Interfaces;
using DATN_NguyenThiThuHuong.BL.Services;
using DATN_NguyenThiThuHuong.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace DATN_NguyenThiThuHuong.API.Controllers
{
    [AuthenPermission]
    public class ColorController : BaseController<Color>
    {
        private IBaseService<Color> _baseService;
        public ColorController(IBaseService<Color> baseService, IHttpContextAccessor httpContextAccessor, IUserTokenService userTokenService) : base(baseService, httpContextAccessor, userTokenService)
        {
            _baseService = baseService;
        }
    }
}
