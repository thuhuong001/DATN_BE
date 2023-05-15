using DATN_NguyenThiThuHuong.API.Hepers;
using DATN_NguyenThiThuHuong.BL.Interfaces;
using DATN_NguyenThiThuHuong.Common.Enums;
using DATN_NguyenThiThuHuong.Common.Models.DTO;
using DATN_NguyenThiThuHuong.Common;
using Microsoft.AspNetCore.Mvc;
using DATN_NguyenThiThuHuong.Common.Models;
using DATN_NguyenThiThuHuong.API.Helpers;

namespace DATN_NguyenThiThuHuong.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AuthenPermission]
    public class FileController : Authentication
    {
        #region Field
        protected IFileService _fileService;
        #endregion

        #region Contructor
        public FileController(IFileService fileService, IHttpContextAccessor httpContextAccessor, IUserTokenService userTokenService) : base(httpContextAccessor, userTokenService)
        {
            _fileService = fileService;
        }
        #endregion

        /// <summary>
        /// Thêm 
        /// </summary>
        /// <param name="entity">Thông tin muốn thêm</param>
        /// <returns>Id mới</returns>
        [HttpPost]
        public IActionResult Insert([FromForm] FileModel fileModel)
        {
            try
            {
                // Gọi hàm xử lý
                ServiceResult result = _fileService.Insert(fileModel);

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
    }
}
