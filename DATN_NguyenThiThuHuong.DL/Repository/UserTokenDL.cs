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
using System.Reflection;

namespace DATN_NguyenThiThuHuong.DL.Repository
{
    public class UserTokenDL : BaseDL<UserToken>, IUserTokenDL
    {
        public UserTokenDL(IDatabaseConnection databaseConnection) : base(databaseConnection)
        {
        }

        public bool DeleteToken(string token)
        {
            try
            {
                //Tên stored procedure
                string storedProcedureName = String.Format(NameProcedureConstants.DeleteByToken, "UserToken");

                //Thêm parameters
                var parameters = new DynamicParameters();
                parameters.Add($"p_Token", token);

                //Mở kết nối
                _databaseConnection.Open();

                //Xử lý lấy dữ liệu trong stored
                var result = _databaseConnection.Execute(storedProcedureName, parameters, commandType: CommandType.StoredProcedure);

                //Đóng kết nối
                _databaseConnection.Close();
                return result > 0 ? true : false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // Đóng kết nối
                _databaseConnection.Close();
                throw new MExceptionResponse(ex.Message);
            }
        }

        public UserToken GetUserByToken(string token)
        {
            try
            {
                // Tên store procedure
                string storedProcedureName = string.Format(NameProcedureConstants.GetByToken,"UserToken");

                // Thêm parameter
                var parameters = new DynamicParameters();
                parameters.Add($"p_Token", token);

                // Mở kết nối
                _databaseConnection.Open();

                // Xử lý lấy dữ liệu trong stored
                UserToken result = _databaseConnection.QueryFirstOrDefault<UserToken>(storedProcedureName, parameters, commandType: CommandType.StoredProcedure);

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
        public override bool Insert(UserToken entity)
        {
            try
            {
                // Tên store procedure
                string storedProcedureName = string.Format(NameProcedureConstants.Insert, tableName);

                // Chuẩn bị parameters
                var parameters = new DynamicParameters();
                foreach (PropertyInfo propertyInfo in entity.GetType().GetProperties())
                {
                    var value = propertyInfo.GetValue(entity);
                    if (value != null && value.GetType().IsEnum)
                    {
                        parameters.Add("p_" + propertyInfo.Name, Convert.ToInt32(value));
                        continue;
                    }
                    // Add parameters
                    parameters.Add("p_" + propertyInfo.Name, propertyInfo.GetValue(entity));
                }

                // Mở kết nối
                _databaseConnection.Open();

                // Xử lý thêm dữ liệu trong stored
                int res = _databaseConnection.Execute(storedProcedureName, param: parameters, commandType: CommandType.StoredProcedure);

                // Đóng kết nối
                _databaseConnection.Close();

                //Trả kết quả về
                return res == 0 ? false : true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _databaseConnection.Close();
                throw new MExceptionResponse(ex.Message);
            }
        }
    }
}
