using DATN_NguyenThiThuHuong.API.Helpers;
using DATN_NguyenThiThuHuong.BL.Interfaces;
using DATN_NguyenThiThuHuong.Common;
using Microsoft.AspNetCore.Mvc;

namespace DATN_NguyenThiThuHuong.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AuthenPermission]
    public class StatisticController : Authentication
    {
        #region Field
        protected IStatisticService _statisticService;
        #endregion

        public StatisticController(IStatisticService statisticService, IHttpContextAccessor httpContextAccessor, IUserTokenService userTokenService) : base(httpContextAccessor, userTokenService)
        {
            _statisticService = statisticService;
        }
        /// <summary>
        /// Thêm 
        /// </summary>
        /// <param name="entity">Thông tin muốn thêm</param>
        /// <returns>Id mới</returns>
        [HttpGet("statistic-default")]
        public IActionResult StatisticDefault()
        {
            try
            {
                // Gọi hàm xử lý
                var result = _statisticService.StatisticsDefault();
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
