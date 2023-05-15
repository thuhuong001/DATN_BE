using DATN_NguyenThiThuHuong.API.Hepers;
using DATN_NguyenThiThuHuong.BL.Interfaces;
using DATN_NguyenThiThuHuong.BL.Services;
using DATN_NguyenThiThuHuong.Common.Models;
using DATN_NguyenThiThuHuong.Commons;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DATN_NguyenThiThuHuong.API.Helpers
{
    public class Authentication : MControllerBase
    {
        public UserToken userToken = null;
        public bool IsOke = false;
        private readonly IUserTokenService _userTokenService;

        public Authentication(IHttpContextAccessor httpContextAccessor,IUserTokenService userTokenService)
        {
            _userTokenService = userTokenService;

            // List api không cần token

            var request = httpContextAccessor.HttpContext.Request;
            if (!request.Path.Equals("/api/customer/"))
            {
                string token = CacheUserToken.GetTokenFromRequest(request);
                userToken = _userTokenService.GetUserByToken(token);
                return;
            }
            IsOke = true;
        }
    }
}
