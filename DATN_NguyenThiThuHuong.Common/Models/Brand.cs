using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN_NguyenThiThuHuong.Common.Models
{
    public class Brand
    {
        public Guid BrandId { get; set; }
        public string BrandCode { get; set; }
        public string BrandName { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public Brand()
        {

        }
        public Brand(Guid brandId, string brandName)
        {
            this.BrandId = brandId;
            this.BrandName = brandName;
        }
        public Brand(Guid brandId, string brandName, string? description, DateTime createdAt, DateTime modifiedAt, bool isActive, bool isDelete) : this(brandId, brandName)
        {
            Description = description;
            CreatedAt = createdAt;
            ModifiedAt = modifiedAt;
            IsActive = isActive;
            IsDelete = isDelete;
        }
    }
}
