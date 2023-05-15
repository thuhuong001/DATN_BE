using Dapper;
using DATN_NguyenThiThuHuong.Common;
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
    public class StatisticDL : IStatisticDL
    {
        #region Field
        protected IDatabaseConnection _databaseConnection;
        #endregion
        /// <summary>
        /// Khởi tạo kết nối DB
        /// </summary>
        public StatisticDL(IDatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }
        public object StatisticsDefault()
        {
            try
            {
                var obj = new StatisticModel();
                // Tên store procedure
                string storedProcedureName = "Proc_Statistic_Default";

                // Thêm parameter
                var parameters = new DynamicParameters();
                parameters.Add("p_FromDate", new DateTime());
                parameters.Add("p_ToDate", new DateTime());

                // Mở kết nối
                _databaseConnection.Open();
                // Xử lý lấy dữ liệu trong stored

                var result = _databaseConnection.QueryMultiple(storedProcedureName, param: parameters, commandType: CommandType.StoredProcedure);

                obj = result.ReadSingleOrDefault<StatisticModel>();

                return obj;
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
