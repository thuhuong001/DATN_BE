using DATN_NguyenThiThuHuong.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN_NguyenThiThuHuong.BL
{
    public interface ICreditCardService
    {
        public Task<Dictionary<string, string>> Checkout(CreditCardInfo creditCardInfor);
    }
}
