using DATN_NguyenThiThuHuong.BL.Interfaces;
using DATN_NguyenThiThuHuong.BL.Services;
using Microsoft.AspNetCore.Http;

namespace DATN_NguyenThiThuHuong.API.Helpers
{
    public class AuthenticationMiddleware
    {

        //private readonly IUserTokenService _userTokenService;
        private readonly RequestDelegate _next;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
            //_userTokenService = userTokenService;
        }

        public async Task Invoke(HttpContext context)
        {
            //var request = context?.Request;
            //if (!request.Path.Equals("/api/v1/customer/"))
            //{
            //    string token = CacheUserToken.GetTokenFromRequest(request);
            //    var response = context.Response;
            //    response.StatusCode = StatusCodes.Status401Unauthorized;
            //    if (token == "")
            //    {
            //        response.WriteAsync("bạn chưa đăng nhập");
            //        return;
            //    }
            //    //else
            //    //{
            //    //    var userToken = _userTokenService.GetUserByToken(token);
            //    //    if (userToken is null)
            //    //    {
            //    //        response.WriteAsync("Token không hợp lệ.");
            //    //        return;
            //    //    }
            //    //    else if (userToken.ExpiredAt < userToken.CreatedAt)
            //    //    {
            //    //        response.WriteAsync("Phiên làm việc hết hạn.");
            //    //        return;
            //    //    }
            //    //}
            //    response.WriteAsync("Phiên làm việc hết hạn.");
            //    return;
            //}
            // Nếu user đã đăng nhập, tiếp tục xử lý yêu cầu
            await _next(context);
        }
    }
}
