using DATN_NguyenThiThuHuong.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN_NguyenThiThuHuong.DL.Interfaces
{
    public interface IUserTokenDL : IBaseDL<UserToken>
    {
        public UserToken GetUserByToken(string token);
        public bool DeleteToken(string token);
    }
}
