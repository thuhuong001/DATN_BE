using Dapper;
using DATN_NguyenThiThuHuong.Common.Constants;
using DATN_NguyenThiThuHuong.Common;
using DATN_NguyenThiThuHuong.Common.Models;
using DATN_NguyenThiThuHuong.DL.Database;
using DATN_NguyenThiThuHuong.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace DATN_NguyenThiThuHuong.DL.Repository
{
    public class CustomerDL : BaseDL<Customer>, ICustomerDL
    {
        public CustomerDL(IDatabaseConnection databaseConnection) : base(databaseConnection)
        {
        }

        public Customer getByEmail(string email)
        {
            try
            {
                // Tên store procedure
                string storedProcedureName = string.Format(NameProcedureConstants.GetByEmail, "Customer");

                // Thêm parameter
                var parameters = new DynamicParameters();
                parameters.Add($"p_Email", email);

                // Mở kết nối
                _databaseConnection.Open();

                // Xử lý lấy dữ liệu trong stored
                var result = _databaseConnection.QueryFirstOrDefault<Customer>(storedProcedureName, parameters, commandType: CommandType.StoredProcedure);

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
        public Customer getByEmailAndPassword(string email, string password)
        {
            try
            {   
                //Tên store procedure
                string storedProcedureName = string.Format(NameProcedureConstants.GetByEmailAndPassword, "Customer");
                 
                //Thêm param
                var parameters = new DynamicParameters();
                parameters.Add($"p_Email", email);
                parameters.Add($"p_Password", password);

                //Mở kết nối
                _databaseConnection.Open();

                //Xử lý lấy dữ liệu
                var result = _databaseConnection.QueryFirstOrDefault<Customer>(storedProcedureName, parameters, commandType: CommandType.StoredProcedure);

                //Đóng kết nối
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
