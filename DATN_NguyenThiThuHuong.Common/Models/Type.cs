using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN_NguyenThiThuHuong.Common.Models
{
    public class Type
    {
        public Guid TypeId { get; set; }
        public string TypeCode { get; set; }
        public string TypeName { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public Type()
        {

        }
        public Type(Guid typeId, string typeName)
        {
            this.TypeId = typeId;
            this.TypeName = typeName;
        }
        public Type(Guid typeId, string typeName, string? description, DateTime createdAt, DateTime modifiedAt, bool isActive, bool isDelete) : this(typeId, typeName)
        {
            Description = description;
            CreatedAt = createdAt;
            ModifiedAt = modifiedAt;
            IsActive = isActive;
            IsDelete = isDelete;
        }
    }
}
