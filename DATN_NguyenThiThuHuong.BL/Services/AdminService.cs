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
    public class AdminService : BaseService<Admin>, IAdminService
    {
        public AdminService(IBaseDL<Admin> baseDL) : base(baseDL)
        {
        }

        public override Admin processPropertyCustom(Admin admin, bool isInsert)
        {
            if (isInsert)
            {
                admin.Password = DATN_NguyenThiThuHuong.Commons.Commons.MD5Hash("12345678@Abc");
            }

            return admin;
        }
    }
}
