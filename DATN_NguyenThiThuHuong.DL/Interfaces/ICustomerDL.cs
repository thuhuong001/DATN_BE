using DATN_NguyenThiThuHuong.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN_NguyenThiThuHuong.DL.Interfaces
{
    public interface ICustomerDL : IBaseDL<Customer>
    {
        public Customer getByEmail(string email);
        public Customer getByEmailAndPassword(string email, string password);
    }
}
