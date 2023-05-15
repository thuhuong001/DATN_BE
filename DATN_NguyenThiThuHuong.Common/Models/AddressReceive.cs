using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN_NguyenThiThuHuong.Common.Models
{
    public class AddressReceive
    {
        public Guid AddressReceiveId { get; set; }
        public string Receiver { get; set; }
        public string AddressDetail { get; set; }
        public string Phone { get; set; }
        public int ProvinceID { get; set; }
        public int WardID { get; set; }
        public int DistrictID { get; set; }
        public string Address { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public Guid CustomerId { get; set; }
        public bool IsDefault { get; set; }
        public AddressReceive()
        {

        }
        public AddressReceive(Guid addressReceive, string receiver, string addressDetail, string phone, Guid customerId)
        {
            this.AddressReceiveId = addressReceive;
            this.Receiver = receiver;
            this.AddressDetail = addressDetail;
            this.Phone = phone;
            this.CustomerId = customerId;
        }
        public AddressReceive(Guid addressReceiveId, string receiver, string addressDetail, string phone, DateTime createdAt, DateTime modifiedAt, bool isActive, bool isDelete, Guid customerId)
        {
            AddressReceiveId = addressReceiveId;
            Receiver = receiver;
            AddressDetail = addressDetail;
            Phone = phone;
            CreatedAt = createdAt;
            ModifiedAt = modifiedAt;
            IsActive = isActive;
            IsDelete = isDelete;
            CustomerId = customerId;
        }
    }
}
