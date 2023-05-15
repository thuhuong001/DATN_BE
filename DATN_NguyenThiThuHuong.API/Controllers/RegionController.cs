using DATN_NguyenThiThuHuong.Common.Models.DTO;
using DATN_NguyenThiThuHuong.Common;
using Microsoft.AspNetCore.Mvc;
using DATN_NguyenThiThuHuong.DL.Interfaces;
using DATN_NguyenThiThuHuong.BL.Interfaces;
using DATN_NguyenThiThuHuong.API.Hepers;
using DATN_NguyenThiThuHuong.API.Helpers;

namespace DATN_NguyenThiThuHuong.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AuthenPermission]
    public class RegionController : Authentication
    {
        private readonly IRegionService _regionService;
        public RegionController(IRegionService regionService, IHttpContextAccessor httpContextAccessor, IUserTokenService userTokenService) : base(httpContextAccessor, userTokenService)
        {
            _regionService = regionService;
        }
        /// <summary>
        /// Lấy thông tin có bộ lọc
        /// </summary>
        /// <param name="paramFilter">Bộ lọc</param>
        /// <returns>Thông tin đối tượng</returns>
        [HttpPost]
        public virtual IActionResult GetByFilter(RegionRequest regionRequest)
        {
            try
            {
                // Xử lý
                var result = _regionService.getByParentId(regionRequest.parentId);

                // Trả về thông tin của employee muốn lấy
                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (MExceptionResponse ex)
            {
                Console.WriteLine(ex.Message);
                // Bắn lỗi exeption
                return ExceptionErrorResponse(ex, HttpContext.TraceIdentifier);
            }
        }
    }
}
