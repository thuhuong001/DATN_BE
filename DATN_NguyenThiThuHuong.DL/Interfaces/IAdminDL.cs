using DATN_NguyenThiThuHuong.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN_NguyenThiThuHuong.DL.Interfaces
{
    public interface IAdminDL : IBaseDL<Admin>
    {
        public Admin getByEmailAndPassword(string email, string password);
    }
}
