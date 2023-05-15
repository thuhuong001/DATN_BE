using DATN_NguyenThiThuHuong.BL.Services;
using DATN_NguyenThiThuHuong.Common.Enums;
using DATN_NguyenThiThuHuong.Common.Models;
using DATN_NguyenThiThuHuong.Common.Models.DTO;
using DATN_NguyenThiThuHuong.Common.Resources;
using DATN_NguyenThiThuHuong.Commons;
using DATN_NguyenThiThuHuong.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN_NguyenThiThuHuong.BL.Interfaces
{
    public interface IAuthService
    {
        public dynamic AuthenticateUser(LoginRequest loginRequest);
    }
}
