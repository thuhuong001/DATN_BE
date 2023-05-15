using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN_NguyenThiThuHuong.Common.Models
{
    public class Admin
    {
        public Guid AdminId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        public string Phone { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public bool IsBoss { get; set; }
        public Admin()
        {

        }
        public Admin(Guid adminId, string fullName, string email, string password)
        {
            this.AdminId = adminId;
            this.FullName = fullName;
            this.Email = email;
            this.Password = password;
        }
        public Admin(Guid adminId, string fullName, string email, string password, string image, string phone, DateTime createdAt, DateTime modifiedAt, bool isActive, bool isDelete) : this(adminId, fullName, email, password)
        {
            Image = image;
            Phone = phone;
            CreatedAt = createdAt;
            ModifiedAt = modifiedAt;
            IsActive = isActive;
            IsDelete = isDelete;
        }
    }
}
