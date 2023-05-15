using DATN_NguyenThiThuHuong.BL.Interfaces;
using DATN_NguyenThiThuHuong.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace DATN_NguyenThiThuHuong.API.Controllers
{
    public class AdminController : BaseController<Admin>
    {
        private IAdminService _adminService;
        public AdminController(IAdminService adminService, IHttpContextAccessor httpContextAccessor, IUserTokenService userTokenService) : base(adminService, httpContextAccessor, userTokenService)
        {
            _adminService = adminService;
        }
    }
}
