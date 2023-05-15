using DATN_NguyenThiThuHuong.BL.Interfaces;
using DATN_NguyenThiThuHuong.Common.Enums;
using DATN_NguyenThiThuHuong.Common;
using DATN_NguyenThiThuHuong.Common.Models;
using DATN_NguyenThiThuHuong.Common.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using static Dapper.SqlMapper;

namespace DATN_NguyenThiThuHuong.API.Controllers
{
    [AuthenPermission]
    public class ProductVariantController : BaseController<ProductVariant>
    {
        public ProductVariantController(IBaseService<ProductVariant> baseService,IHttpContextAccessor httpContextAccessor,IUserTokenService userTokenService) : base(baseService, httpContextAccessor, userTokenService)
        {
        }
    }
}
