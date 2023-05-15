using DATN_NguyenThiThuHuong.Common;
using DATN_NguyenThiThuHuong.Common.Models;
using DATN_NguyenThiThuHuong.Common.Models.DTO;
using DATN_NguyenThiThuHuong.DL.Database;
using DATN_NguyenThiThuHuong.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN_NguyenThiThuHuong.DL.Repository
{
    public class AddressReceiveDL: BaseDL<AddressReceive>, IAddressReceiveDL
    {
        protected IDatabaseConnection _databaseConnection;
        public AddressReceiveDL(IDatabaseConnection databaseConnection):base(databaseConnection) 
        {
            _databaseConnection = databaseConnection;
        }
        public bool SetDefault(AddressReceiveSetDefauModel addressReceiveSetDefauModel)
        {
            try
            {
                    var dateNow = DateTime.Now.ToString("yyyy/MM/dd");
                    //Set tất cả các IsDefault của dữ liệu về 0
                    string query = $"Update AddressReceive set IsDefault = 0 where CustomerId = '{addressReceiveSetDefauModel.CustomerId}'; " +
                        $"Update AddressReceive set IsDefault = 1, ModifiedAt = '{dateNow}' where AddressReceiveId = '{addressReceiveSetDefauModel.AddressReceiveId}'";

                    //Mở kết nối\
                    _databaseConnection.Open();
                _databaseConnection.BeginTransaction();

                //Xử lý update dữ liệu
                int numberUpdate1 = _databaseConnection.Execute(query, commandType: CommandType.Text);
                if (numberUpdate1 == 0)
                {
                    return false;
                }
                _databaseConnection.CommitTransaction();
                _databaseConnection.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _databaseConnection.RollbackTransaction();
                _databaseConnection.Close();
                throw new MExceptionResponse(ex.Message);
            }
        }
    }
}
