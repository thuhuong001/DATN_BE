using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN_NguyenThiThuHuong.Common.Models
{
    public class Size
    {
        public Guid SizeId { get; set; }
        public string SizeCode { get; set; }
        public string SizeNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public Size()
        {

        }
        public Size(Guid sizeId, string sizeNumber)
        {
            this.SizeId = sizeId;
            this.SizeNumber = sizeNumber;
        }
        public Size(Guid sizeId, string sizeNumber, DateTime createdAt, DateTime modifiedAt, bool isActive, bool isDelete) : this(sizeId, sizeNumber)
        {
            CreatedAt = createdAt;
            ModifiedAt = modifiedAt;
            IsActive = isActive;
            IsDelete = isDelete;
        }
    }
}
