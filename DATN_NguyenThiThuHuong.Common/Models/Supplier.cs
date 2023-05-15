using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN_NguyenThiThuHuong.Common.Models
{
    public class Supplier
    {
        public Guid SupplierId { get; set; }
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public Supplier()
        {

        }
        public Supplier(Guid supplierId, string supplierName)
        {
            this.SupplierId = supplierId;
            this.SupplierName = supplierName;
        }
        public Supplier(Guid supplierId, string supplierName, string phone, string address, DateTime createdAt, DateTime modifiedAt, bool isActive, bool isDelete) : this(supplierId, supplierName)
        {
            Phone = phone;
            Address = address;
            CreatedAt = createdAt;
            ModifiedAt = modifiedAt;
            IsActive = isActive;
            IsDelete = isDelete;
        }
    }
}
