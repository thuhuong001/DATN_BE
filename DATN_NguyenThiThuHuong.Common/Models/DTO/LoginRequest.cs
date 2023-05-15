using DATN_NguyenThiThuHuong.Common.CustomAttributes;
using DATN_NguyenThiThuHuong.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN_NguyenThiThuHuong.Common.Models.DTO
{
    public class LoginRequest
    {
        [CustomRequired]
        public string Email { get; set; }
        [CustomRequired]
        public string Password { get; set; }

        public EnumRole RoleType { get; set; }
        public bool Remember { get; set; }
    }
}
