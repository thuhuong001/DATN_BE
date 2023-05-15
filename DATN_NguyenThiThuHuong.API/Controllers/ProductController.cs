using DATN_NguyenThiThuHuong.BL.Interfaces;
using DATN_NguyenThiThuHuong.Common;
using DATN_NguyenThiThuHuong.Common.Models;
using DATN_NguyenThiThuHuong.Common.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DATN_NguyenThiThuHuong.API.Controllers
{
    public class ProductController : BaseController<Product>
    {
        private IProductService _productService;
        public ProductController(IProductService productService, IHttpContextAccessor httpContextAccessor, IUserTokenService userTokenService) : base(productService, httpContextAccessor, userTokenService)
        {
            _productService = productService;
        }

        [HttpPut]
        [Route("Update-Sold/{id}")]
        public IActionResult UpdateSold([FromRoute] Guid id, [FromBody] int sold)
        {
            try
            {
                bool result = _productService.UpdateSold(id, sold);

                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (MExceptionResponse ex)
            {
                Console.WriteLine(ex.Message);
                // Bắn lỗi exeption
                return ExceptionErrorResponse(ex, HttpContext.TraceIdentifier);
            }
        }

        /// <summary>
        /// Lấy thông tin có bộ lọc
        /// </summary>
        /// <param name="paramFilter">Bộ lọc</param>
        /// <returns>Thông tin đối tượng</returns>
        [Authorize(Policy = "AllowAnonymousPolicy")]
        [HttpPost]
        [Route("Filter-Detail")]
        public virtual IActionResult GetByFilterDetail([FromBody] ProductFilterModel paramFilter)
        {
            try
            {
                // Xử lý
                var result = _productService.GetByFilterDetail(paramFilter);

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

        /// <summary>
        /// Lấy thông tin theo ID
        /// </summary>
        /// <param name="id">ID muốn lấy</param>
        /// <returns>Thông tin theo ID</returns>
        [AllowAnonymous]
        [HttpGet]
        [Route("Detail/{id}")]
        public IActionResult GetByIDDetail([FromRoute] Guid id)
        {
            try
            {
                // Xử lý
                var result = _productService.GetByIDDetail(id);

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
