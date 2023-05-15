using DATN_NguyenThiThuHuong.BL.Interfaces;
using DATN_NguyenThiThuHuong.Common.Models;
using DATN_NguyenThiThuHuong.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN_NguyenThiThuHuong.BL.Services
{
    public class UserTokenService : IUserTokenService
    {
        private IUserTokenDL _userTokenDL;
        public UserTokenService(IUserTokenDL userTokenDL)
        {
            _userTokenDL = userTokenDL;
        }

        public UserToken GetUserByToken(string token)
        {
            return _userTokenDL.GetUserByToken(token);
        }
    }
}
