using DATN_NguyenThiThuHuong.BL.Interfaces;
using DATN_NguyenThiThuHuong.Common.Enums;
using DATN_NguyenThiThuHuong.Common.Models;
using DATN_NguyenThiThuHuong.Common.Models.DTO;
using DATN_NguyenThiThuHuong.Common.Resources;
using DATN_NguyenThiThuHuong.Commons;
using DATN_NguyenThiThuHuong.DL.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace DATN_NguyenThiThuHuong.BL.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserTokenDL _userTokenDL;
        private readonly ICustomerDL _customerDL;
        private readonly IAdminDL _adminDL;
        public AuthService(IUserTokenDL userTokenDL, IAdminDL adminDL, ICustomerDL customerDL)
        {
            _userTokenDL = userTokenDL;
            _customerDL = customerDL;
            _adminDL = adminDL;
        }
        public dynamic AuthenticateUser(LoginRequest loginRequest)
        {
            dynamic result = new ServiceResult(EnumErrorCode.SERVER_ERROR, ResourceVI.ErrorServer, ResourceVI.ErrorServer); ;
            // trả về lỗi validate
            dynamic validationResults = null;
            var listErrorValidate = new Dictionary<string, string>();
            // Kiểm tra attribute hợp lệ của dữ liệu
            if (!Validator.TryValidateObject(loginRequest, new ValidationContext(loginRequest), validationResults, true))
            {
                foreach (var item in validationResults)
                {
                    listErrorValidate.Add(item.MemberNames.First(), item.ErrorMessage is null ? "" : item.ErrorMessage);
                }
            }

            if (loginRequest.RoleType == EnumRole.Customer)
            {
                var password = Commons.Commons.MD5Hash(loginRequest.Password);

                var customer = _customerDL.getByEmailAndPassword(loginRequest.Email, password);
                if (customer == null)
                {
                    listErrorValidate.Add("LoginError", "Tài khoản hoặc mật khẩu không chính xác.!");
                    result = new ServiceResult(EnumErrorCode.BADREQUEST, ResourceVI.ErrorValidate, ResourceVI.ErrorValidate, listErrorValidate);
                }
                else
                {
                    UserToken userToken = CacheUserToken.CreateToken(customer);

                    var response = _userTokenDL.Insert(userToken);
                    if (!response)
                        result = new ServiceResult(EnumErrorCode.SERVER_ERROR, ResourceVI.ErrorServer, ResourceVI.ErrorServer);

                    customer.Password = "";

                    result = new ServiceResult(new
                    {
                        Token = userToken.Token,
                        Customer = customer,
                    });
                }
            }
            if (loginRequest.RoleType == EnumRole.Admin)
            {
                var password = Commons.Commons.MD5Hash(loginRequest.Password);

                var admin = _adminDL.getByEmailAndPassword(loginRequest.Email, password);
                if (admin == null)
                {
                    listErrorValidate.Add("LoginError", "Tài khoản hoặc mật khẩu không chính xác.!");
                    result = new ServiceResult(EnumErrorCode.BADREQUEST, ResourceVI.ErrorValidate, ResourceVI.ErrorValidate, listErrorValidate);
                }
                else
                {
                    UserToken userToken = CacheUserToken.CreateToken(admin);

                    var response = _userTokenDL.Insert(userToken);
                    if (!response)
                        result = new ServiceResult(EnumErrorCode.SERVER_ERROR, ResourceVI.ErrorServer, ResourceVI.ErrorServer);

                    admin.Password = "";

                    result = new ServiceResult(new
                    {
                        Token = userToken.Token,
                        Admin = admin,
                    });
                }
            }

            return result;
        }
    }
}
