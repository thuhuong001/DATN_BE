using DATN_NguyenThiThuHuong.Common.Enums;
using DATN_NguyenThiThuHuong.Common.Resources;
using System.Collections;
using System.Net;

namespace DATN_NguyenThiThuHuong.Common
{
    /// <summary>
    /// Class bắn lỗi exception
    /// </summary>
    public class MExceptionResponse : Exception
    {
        #region Field
        public Dictionary<string, string>? objMessageError;
        public string? msgError;
        public string msgUser = ResourceVI.ErrorServer;
        public int? errorCode = EnumErrorCode.SERVER_ERROR;
        #endregion

        #region Contructor
        /// <summary>
        /// Contructor 1 đối số
        /// </summary>
        /// <param name="msgError">Lỗi</param>
        public MExceptionResponse(string? msgError = null)
        {
            this.msgError = msgError;
        }

        /// <summary>
        /// Contructor không đối số
        /// </summary>
        public MExceptionResponse() { }
        #endregion

        #region Method
        /// <summary>
        /// Gán lỗi
        /// </summary>
        public override string Message => this.msgError;

        /// <summary>
        /// Gán chi tiết lỗi
        /// </summary>
        public override IDictionary Data => this.objMessageError; 
        #endregion
    }
}
