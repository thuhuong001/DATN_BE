using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN_NguyenThiThuHuong.Common.Enums
{
    /// <summary>
    /// Enum mã lỗi
    /// </summary>
    public static class EnumErrorCode
    {
        /// <summary>
        /// Dữ liệu không có
        /// </summary>
        public static int NOT_CONTENT = 0;

        /// <summary>
        /// Lỗi validate
        /// </summary>
        public static int BADREQUEST = 1;

        /// <summary>
        /// Lỗi Server
        /// </summary>
        public static int SERVER_ERROR = 2;
    }
}
