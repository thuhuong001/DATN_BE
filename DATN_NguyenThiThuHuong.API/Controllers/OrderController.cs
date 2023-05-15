using DATN_NguyenThiThuHuong.BL.Interfaces;
using DATN_NguyenThiThuHuong.BL.Services;
using DATN_NguyenThiThuHuong.Common;
using DATN_NguyenThiThuHuong.Common.Enums;
using DATN_NguyenThiThuHuong.Common.Models;
using DATN_NguyenThiThuHuong.Common.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace DATN_NguyenThiThuHuong.API.Controllers
{
    [AuthenPermission]
    public class OrderController : BaseController<Order>
    {
        private IOrderService _orderService;
        public OrderController(IOrderService orderService, IHttpContextAccessor httpContextAccessor, IUserTokenService userTokenService) : base(orderService, httpContextAccessor, userTokenService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// Thêm 
        /// </summary>
        /// <param name="entity">Thông tin muốn thêm</param>
        /// <returns>Id mới</returns>
        [HttpPost]
        public override IActionResult Insert([FromBody] Order order)
        {
            try
            {
                // Gọi hàm xử lý
                ServiceResult result = _orderService.Insert(order, userToken.UserID);

                if (result.ErrorCode is null) return StatusCode(StatusCodes.Status200OK, result);
                else if (result.ErrorCode == EnumErrorCode.NOT_CONTENT) return StatusCode(StatusCodes.Status204NoContent, result);
                else if (result.ErrorCode == EnumErrorCode.BADREQUEST) return StatusCode(StatusCodes.Status400BadRequest, result);

                return StatusCode(StatusCodes.Status500InternalServerError, result);
            }
            catch (MExceptionResponse ex)
            {
                Console.WriteLine(ex.Message);
                // Bắn lỗi exeption
                return ExceptionErrorResponse(ex, HttpContext.TraceIdentifier);
            }
        }

        [HttpPost("update-status")]
        public IActionResult UpdateStatus([FromBody] UpdateOrder updateOrder)
        {
            try
            {
                // Gọi hàm xử lý
                bool result = _orderService.UpdateStatus(updateOrder.OrderId, updateOrder.Status);
                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (MExceptionResponse ex)
            {
                Console.WriteLine(ex.Message);
                // Bắn lỗi exeption
                return ExceptionErrorResponse(ex, HttpContext.TraceIdentifier);
            }
        }
        public override IActionResult GetByFilter([FromBody] PagingModel paramFilter)
        {
            if(userToken.EnumRole == EnumRole.Customer)
            {
                paramFilter.parentId = userToken.UserID;
            }
            return base.GetByFilter(paramFilter);
        }
    }
}
