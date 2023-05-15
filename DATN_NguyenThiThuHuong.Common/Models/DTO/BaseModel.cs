using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN_NguyenThiThuHuong.Common.Models.DTO
{
    public class BaseModel
    {
        /// <summary>
        /// Thời gian tạo
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Người tạo
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Người sửa gần nhất
        /// </summary>
        public string ModifiedBy{ get; set; }

        /// <summary>
        /// Thời gian sửa gần nhất
        /// </summary>
        public DateTime ModifiedAt { get; set; }
    }
}
