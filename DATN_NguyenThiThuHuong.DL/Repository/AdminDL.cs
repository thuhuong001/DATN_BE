using Dapper;
using DATN_NguyenThiThuHuong.Common.Models;
using DATN_NguyenThiThuHuong.Common;
using DATN_NguyenThiThuHuong.DL.Database;
using DATN_NguyenThiThuHuong.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATN_NguyenThiThuHuong.Common.Constants;

namespace DATN_NguyenThiThuHuong.DL.Repository
{
    public class AdminDL : BaseDL<Admin>, IAdminDL
    {
        public AdminDL(IDatabaseConnection databaseConnection) : base(databaseConnection)
        {
        }

        public Admin getByEmailAndPassword(string email, string password)
        {
            try
            {
                // Tên store procedure
                string storedProcedureName = string.Format(NameProcedureConstants.GetByEmailAndPassword, "Admin");

                // Thêm parameter
                var parameters = new DynamicParameters();
                parameters.Add($"p_Email", email);
                parameters.Add($"p_Password", password);

                // Mở kết nối
                _databaseConnection.Open();

                // Xử lý lấy dữ liệu trong stored
                var result = _databaseConnection.QueryFirstOrDefault<Admin>(storedProcedureName, parameters, commandType: CommandType.StoredProcedure);

                // Đóng kết nối
                _databaseConnection.Close();

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // Đóng kết nối
                _databaseConnection.Close();
                throw new MExceptionResponse(ex.Message);
            }
        }
    }
}
