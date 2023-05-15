using DATN_NguyenThiThuHuong.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN_NguyenThiThuHuong.Common.Models
{
    public class UserToken
    {
        public Guid UserTokenId { get; set; }

        public Guid UserID { get; set; }
        public EnumRole EnumRole { get; set; }
        public string Username { get; set; }

        public bool IsRememberPassword { get; set; }

        public string Token { get; set; }

        public DateTime ExpiredAt { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime TimeUpdateExpiredDateToDB { get; set; }

        public string Language { get; set; } = "vn";

        //public string Theme { get; set; }

        public string IpAddress { get; set; }

        public string CountriesCode { get; set; }
    }
}
