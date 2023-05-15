
using DATN_NguyenThiThuHuong.BL.Interfaces;
using DATN_NguyenThiThuHuong.Common.Models;

namespace DATN_NguyenThiThuHuong.API.Controllers
{
    [AuthenPermission]
    public class SizeController : BaseController<Size>
    {
        private IBaseService<Size> _baseService;
        public SizeController(IBaseService<Size> baseService, IHttpContextAccessor httpContextAccessor, IUserTokenService userTokenService) : base(baseService, httpContextAccessor, userTokenService)
        {
            _baseService = baseService;
        }
    }
}
