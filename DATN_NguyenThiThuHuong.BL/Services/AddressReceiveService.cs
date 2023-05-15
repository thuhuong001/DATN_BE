using DATN_NguyenThiThuHuong.BL.Interfaces;
using DATN_NguyenThiThuHuong.Common.Models;
using DATN_NguyenThiThuHuong.Common.Models.DTO;
using DATN_NguyenThiThuHuong.DL.Interfaces;
using DATN_NguyenThiThuHuong.DL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN_NguyenThiThuHuong.BL.Services
{
    public class AddressReceiveService : BaseService<AddressReceive>,IAddressReceiveService
    {
        private readonly IAddressReceiveDL _addressReceiveDL;
        public AddressReceiveService(IAddressReceiveDL addressReceiveDL) : base(addressReceiveDL)
        {
            _addressReceiveDL = addressReceiveDL;
        }
        public bool SetDefault(AddressReceiveSetDefauModel addressReceiveSetDefauModel)
        {
            return _addressReceiveDL.SetDefault(addressReceiveSetDefauModel);
        }
    }
}