using DATN_NguyenThiThuHuong.Common;
using DATN_NguyenThiThuHuong.Common.Enums;
using DATN_NguyenThiThuHuong.Common.Models.DTO;
using DATN_NguyenThiThuHuong.Common.Resources;
using Microsoft.AspNetCore.Mvc;

namespace DATN_NguyenThiThuHuong.API.Hepers
{
    /// <summary>
    /// Custom lại controllerBase
    /// </summary>
    public class MControllerBase : ControllerBase
    {
        #region Method
        /// <summary>
        /// Xử lý kết quả trả về exception
        /// </summary>
        /// <param name="ex">Lỗi exception</param>
        /// <param name="traceId">Id lỗi nếu có</param>
        /// <returns>ObjectResult</returns>
        [NonAction]
        public IActionResult ExceptionErrorResponse(MExceptionResponse ex, dynamic? traceId = null)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new ServiceResult(EnumErrorCode.SERVER_ERROR, ex.Message, ResourceVI.ErrorServer, ex.Data, traceId));
        }
        #endregion
    }
}