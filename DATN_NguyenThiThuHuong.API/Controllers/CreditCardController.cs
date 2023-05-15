using DATN_NguyenThiThuHuong.API.Helpers;
using DATN_NguyenThiThuHuong.BL;
using DATN_NguyenThiThuHuong.BL.Interfaces;
using DATN_NguyenThiThuHuong.Common;
using DATN_NguyenThiThuHuong.Common.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DATN_NguyenThiThuHuong.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardController : Authentication
    {
        private ICreditCardService _creditCardService;

        public CreditCardController(ICreditCardService creditCardService, IHttpContextAccessor httpContextAccessor, IUserTokenService userTokenService) : base(httpContextAccessor, userTokenService)
        {
            _creditCardService = creditCardService;
        }

        [HttpPost]
        public async Task<IActionResult> Checkout([FromBody] CreditCardInfo creditCardInfo)
        {
            try
            {
                // Gọi hàm xử lý
                ServiceResult result = new ServiceResult();

                result.Data = await _creditCardService.Checkout(creditCardInfo);

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
