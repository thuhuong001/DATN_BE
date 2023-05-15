using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN_NguyenThiThuHuong.Common.Models.DTO
{
    public class ServiceResult
    {
        #region Contructor

        /// <summary>
        /// Contructor khởi tạo mặc định
        /// </summary>
        public ServiceResult() { }

        /// <summary>
        /// Hàm khởi tạo lỗi
        /// </summary>
        /// <param name="errorCode">Mã lỗi</param>
        /// <param name="devMsg">Message lỗi cho bên kỹ thuật</param>
        /// <param name="userMsg">Message lỗi cho user</param>
        /// <param name="moreInfo">Chi tiết lỗi</param>
        /// <param name="traceId">Id log lỗi</param>
        public ServiceResult(int errorCode, string devMsg, string userMsg, object moreInfo, dynamic? traceId = null)
        {
            ErrorCode = errorCode;
            DevMsg = devMsg;
            UserMsg = userMsg;
            MoreInfo = moreInfo;
            TraceId = traceId;
        }

        /// <summary>
        /// Hàm khởi tạo lỗi
        /// </summary>
        /// <param name="errorCode">Mã lỗi</param>
        /// <param name="devMsg">Message lỗi cho bên kỹ thuật</param>
        /// <param name="userMsg">Message lỗi cho user</param>
        /// <param name="moreInfo">Chi tiết lỗi</param>
        /// <param name="traceId">Id log lỗi</param>
        public ServiceResult(int errorCode, string devMsg, string userMsg)
        {
            ErrorCode = errorCode;
            DevMsg = devMsg;
            UserMsg = userMsg;
        }

        /// <summary>
        /// Hàm khởi success
        /// </summary>
        /// <param name="data">Dữ liệu trả về</param>
        public ServiceResult(object data)
        {
            Data = data;
        }
        #endregion

        #region Properties
        // Mã lỗi
        public int? ErrorCode { get; set; }

        // Thông báo lỗi bên dev
        public string? DevMsg { get; set; }

        // Thông báo lỗi cho khách hàng
        public string UserMsg { get; set; }

        // Dữ liệu trả về
        public object? Data { get; set; }

        // Chi tiết lỗi
        public object? MoreInfo { get; set; }

        // Mã log lỗi
        public dynamic? TraceId { get; set; }
        #endregion
    }
}
