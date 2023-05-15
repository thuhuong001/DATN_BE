using DATN_NguyenThiThuHuong.API.Helpers;
using DATN_NguyenThiThuHuong.API.Hepers;
using DATN_NguyenThiThuHuong.BL.Interfaces;
using DATN_NguyenThiThuHuong.Common;
using DATN_NguyenThiThuHuong.Common.Enums;
using DATN_NguyenThiThuHuong.Common.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DATN_NguyenThiThuHuong.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<Entity> : Authentication
    {
        #region Field
        protected IBaseService<Entity> _baseService;
        #endregion

        #region Contructor
        public BaseController(IBaseService<Entity> baseService, IHttpContextAccessor httpContextAccessor, IUserTokenService userTokenService) : base(httpContextAccessor, userTokenService)
        {
            _baseService = baseService;
        }
        #endregion

        #region Action

        /// <summary>
        /// Lấy thông tin có bộ lọc
        /// </summary>
        /// <param name="paramFilter">Bộ lọc</param>
        /// <returns>Thông tin đối tượng</returns>
        [HttpPost]
        [Route("Filter")]
        public virtual IActionResult GetByFilter([FromBody] PagingModel paramFilter)
        {
            try
            {
                // Xử lý
                var result = _baseService.GetByFilter(paramFilter);

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
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetByID([FromRoute] Guid id)
        {
            try
            {
                // Xử lý
                var result = _baseService.GetById(id);

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
        /// Thêm 
        /// </summary>
        /// <param name="entity">Thông tin muốn thêm</param>
        /// <returns>Id mới</returns>
        [HttpPost]
        public virtual IActionResult Insert([FromBody] Entity entity)
        {
            try
            {
                // Gọi hàm xử lý
                ServiceResult result = _baseService.Insert(entity);

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

        /// <summary>
        /// Sửa 
        /// </summary>
        /// <param name="id">ID muốn sửa</param>
        /// <param name="entity">Thông tin  muốn sửa</param>
        /// <returns>Thông tin đã sửa</returns>
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] Guid id, [FromBody] Entity entity)
        {
            try
            {
                // Gọi hàm xử lý
                var result = _baseService.Update(id, entity);

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

        /// <summary>
        /// Xóa 
        /// </summary>
        /// <param name="id">ID muốn xóa</param>
        /// <returns>ID đã xóa thành công</returns>
        [HttpPost]
        [Route("Delete-Records")]
        public IActionResult DeleteRecords([FromBody] List<Guid> listId)
        {
            try
            {
                // Xử lý
                bool result = _baseService.DeleteRecords(listId);

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
        /// Khóa 
        /// </summary>
        /// <param name="id">ID muốn xóa</param>
        /// <returns>ID đã xóa thành công</returns>
        [HttpPost]
        [Route("Lock-Up")]
        public IActionResult LockUpRecords([FromBody] List<Guid> listId)
        {
            try
            {
                // Xử lý
                bool result = _baseService.LockUpRecords(listId);

                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (MExceptionResponse ex)
            {
                Console.WriteLine(ex.Message);
                // Bắn lỗi exeption
                return ExceptionErrorResponse(ex, HttpContext.TraceIdentifier);
            }
        }
        #endregion
    }
}