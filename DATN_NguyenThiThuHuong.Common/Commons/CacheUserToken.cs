using DATN_NguyenThiThuHuong.Common.Enums;
using DATN_NguyenThiThuHuong.Common.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;
using System.Text;

namespace DATN_NguyenThiThuHuong.Commons
{
    public static class CacheUserToken
    {
        const int HOUR_TIMEOUT_TOKEN = 24 * 2;
        const int HOUR_TIMEOUT_TOKEN_REMEMBER = 24 * 7;
        public static string GetTokenFromRequest(HttpRequest request)
        {
            string token = "";
            if (request == null) return "request == null";

            if (string.IsNullOrEmpty(request.Headers["Authorization"])) return "";
            token = request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            return token;
        }
        public static UserToken CreateToken(Customer customer, string ipAddress = "", bool IsRememberPassword = false)
        {
            string msg;
            string token;
            Guid ID = Guid.NewGuid();

            token = CreateToken(ID.ToString());

            var userToken = new UserToken
            {
                UserTokenId = ID,
                UserID = customer.CustomerId,
                IsRememberPassword = IsRememberPassword,
                Token = token,
                ExpiredAt = DateTime.Now.AddHours(IsRememberPassword ? HOUR_TIMEOUT_TOKEN_REMEMBER : HOUR_TIMEOUT_TOKEN),
                CreatedAt = DateTime.Now,
                IpAddress = ipAddress,
                Username = customer.FullName,
                EnumRole = EnumRole.Customer
            };

            return userToken;
        }
        public static UserToken CreateToken(Admin admin, string ipAddress = "", bool IsRememberPassword = false)
        {
            string msg;
            string token;
            Guid ID = Guid.NewGuid();

            token = CreateToken(ID.ToString());
            var userToken = new UserToken
            {
                UserTokenId = Guid.NewGuid(),
                UserID = admin.AdminId,
                IsRememberPassword = IsRememberPassword,
                Token = token,
                ExpiredAt = DateTime.Now.AddHours(IsRememberPassword ? HOUR_TIMEOUT_TOKEN_REMEMBER : HOUR_TIMEOUT_TOKEN),
                CreatedAt = DateTime.Now,
                IpAddress = ipAddress,
                Username = admin.FullName,
                EnumRole = EnumRole.Admin
            };

            //UserToken.ID = newID.ToGuid(new Guid());
            //UserToken.TimeUpdateExpiredDateToDB = DateTime.Now;

            //// Trường hợp setting redis làm cache: 0 (không dùng) 1 (có dùng)
            //if (Common.GetSettingWithDefault("IS_REDIS", "0") == "1")
            //{
            //    // Lưu vào cache
            //    RCache.SetData($"{RConstant.USER_TOKEN_KEY}:{UserToken.Token}", UserToken, 36000);
            //    return "";
            //}
            //if (CacheUserToken.LtUser_Token == null || CacheUserToken.LtUser_Token.Count == 0)
            //{
            //    msg = GetAllToken();
            //    if (msg.Length > 0) return msg;
            //}
            //LtUser_Token.Add(UserToken);

            return userToken;
        }

        public static string CreateToken(string id)
        {
            string token;
            var key = Encoding.ASCII.GetBytes("mahoadatnmatkhau!@12321321321");

            byte[] dataBytes = Encoding.ASCII.GetBytes(id);

            // Tạo mã hóa HmacSha256Signature
            using (var hmac = new HMACSHA256(key))
            {
                byte[] hash = hmac.ComputeHash(dataBytes);
                token = Convert.ToBase64String(hash);
            }

            return token.Replace("/", "+");
        }
    }
}