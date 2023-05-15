using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN_NguyenThiThuHuong.Common.Models
{
    public class Color
    {
        public Guid ColorId { get; set; }
        public string ColorCode { get; set; }
        public string ColorName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public Color()
        {

        }
        public Color(Guid colorId, string colorName)
        {
            ColorId = colorId;
            ColorName = colorName;
        }
        public Color(Guid colorId, string colorName, DateTime createdAt, DateTime modifiedAt, bool isActive, bool isDelete) : this(colorId, colorName)
        {
            CreatedAt = createdAt;
            ModifiedAt = modifiedAt;
            IsActive = isActive;
            IsDelete = isDelete;
        }
    }
}
