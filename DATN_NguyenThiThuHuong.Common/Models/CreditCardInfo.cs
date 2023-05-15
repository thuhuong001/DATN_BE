using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN_NguyenThiThuHuong.Common
{
    public class CreditCardInfo
    {
        public int Amount { get; set; }
        public string ClientCode { get; set; }
        public string MerchantCode { get; set; }
        public string PaymentDetail { get; set; }
        public string CardCode { get; set; }
        public string ClientTransCode { get; set; }
        public string CheckSum { get; set; }
    }
}
