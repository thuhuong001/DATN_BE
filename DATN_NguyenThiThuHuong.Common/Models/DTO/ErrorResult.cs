namespace DATN_NguyenThiThuHuong.BL.Models.DTO
{
    /// <summary>
    /// Đối tượng dữ liệu lỗi trả về
    /// </summary>
    public class ErrorResult
    {
        #region Contructor
        /// <summary>
        /// Hàm khởi tạo lỗi
        /// </summary>
        /// <param name="errorCode">Mã lỗi</param>
        /// <param name="devMsg">Message lỗi cho bên kỹ thuật</param>
        /// <param name="userMsg">Message lỗi cho user</param>
        /// <param name="moreInfo">Chi tiết lỗi</param>
        /// <param name="traceId">Id log lỗi</param>
        public ErrorResult(int errorCode, string devMsg, string userMsg, object moreInfo, dynamic? traceId)
        {
            ErrorCode = errorCode;
            DevMsg = devMsg;
            UserMsg = userMsg;
            MoreInfo = moreInfo;
            TraceId = traceId;
        } 
        #endregion

        #region Properties
        // Mã lỗi
        public int ErrorCode { get; set; }

        // Thông báo lỗi bên dev
        public string DevMsg { get; set; }

        // Thông báo lỗi cho khách hàng
        public string UserMsg { get; set; }

        // Chi tiết lỗi
        public object MoreInfo { get; set; }

        // Mã log lỗi
        public dynamic? TraceId { get; set; } 
        #endregion
    }
}
