using DATN_NguyenThiThuHuong.BL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DATN_NguyenThiThuHuong.API.Controllers
{
    public class TypeController : BaseController<DATN_NguyenThiThuHuong.Common.Models.Type>
    {
        private IBaseService<DATN_NguyenThiThuHuong.Common.Models.Type> _baseService;
        public TypeController(IBaseService<DATN_NguyenThiThuHuong.Common.Models.Type> baseService, IHttpContextAccessor httpContextAccessor, IUserTokenService userTokenService) : base(baseService, httpContextAccessor, userTokenService)
        {
            _baseService = baseService;
        }
    }
}
