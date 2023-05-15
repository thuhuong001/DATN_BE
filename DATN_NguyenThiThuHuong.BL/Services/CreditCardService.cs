using DATN_NguyenThiThuHuong.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DATN_NguyenThiThuHuong.BL
{
    public class CreditCardService : ICreditCardService
    {
        private string HashInforCreditCard(CreditCardInfo creditCardInfor)
        {
            string hashString = String.Empty;
            System.Text.UTF8Encoding enconding = new UTF8Encoding();
            byte[] keyBytes = enconding.GetBytes("Keys");
            string hashValue = $"{creditCardInfor.Amount}|{creditCardInfor.CardCode}|{creditCardInfor.ClientCode}||{creditCardInfor.MerchantCode}|{creditCardInfor.PaymentDetail}||{creditCardInfor.ClientTransCode}";
            byte[] messageBytes = enconding.GetBytes(hashValue);
            using (HMACSHA256 sha256 = new HMACSHA256(keyBytes))
            {
                byte[] hashBytes = sha256.ComputeHash(messageBytes);
                hashString = BitConverter.ToString(hashBytes).Replace("-", "").ToLower(); ;
            }
            return hashString;
        }
        public async Task<Dictionary<string, string>> Checkout(CreditCardInfo creditCardInfor)
        {
            string orderCode = "DH" + DateTime.Now.ToString("yyyyMMddHHmmss");

            creditCardInfor.ClientCode = "000001";
            creditCardInfor.MerchantCode = "00000081";
            creditCardInfor.PaymentDetail = $"Thanh toan mua hang {orderCode}";
            creditCardInfor.ClientTransCode = Guid.NewGuid().ToString();

            string hashString = HashInforCreditCard(creditCardInfor);
            creditCardInfor.CheckSum = hashString;

            Dictionary<string, object> dataPost = new Dictionary<string, object>()
            {
                {"ApiData", creditCardInfor }
            };

            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.PostAsJsonAsync(
                "https://vps.onelink.vn/api/VpsPayment/Payment", dataPost);

            response.EnsureSuccessStatusCode();
            var dataJSON = await response.Content.ReadAsStringAsync();

            var dicRes = new Dictionary<string, string>()
            {
                {"OrderCode", orderCode },
                {"Result", dataJSON }
            };

            return dicRes;
        }
    }
}
