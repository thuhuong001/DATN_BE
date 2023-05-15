using Dapper;
using DATN_NguyenThiThuHuong.Common;
using DATN_NguyenThiThuHuong.Common.Constants;
using DATN_NguyenThiThuHuong.Common.Models.DTO;
using DATN_NguyenThiThuHuong.DL.Database;
using DATN_NguyenThiThuHuong.DL.Interfaces;
using MySqlConnector;
using System.Data;
using System.Reflection;

namespace DATN_NguyenThiThuHuong.DL.Repository
{
    public class BaseDL<Entity> : IBaseDL<Entity>
    {
        #region Field
        protected string tableName;
        protected IDatabaseConnection _databaseConnection;
        #endregion

        #region Contructor
        /// <summary>
        /// Khởi tạo kết nối DB
        /// </summary>
        public BaseDL(IDatabaseConnection databaseConnection)
        {
            tableName = typeof(Entity).Name;
            _databaseConnection = databaseConnection;
        }
        #endregion

        #region Method

        /// <summary>
        /// Lấy danh sách có bộ lọc
        /// </summary>
        /// <param name="parametersFilter">Param bộ lọc truyền vào truyền vào</param>
        /// <returns>Danh sách đối tượng</returns>
        public virtual PagingResult<Entity> GetByFilter(dynamic parametersFilter)
        {
            try
            {
                // Tên store procedure
                string storedProcedureName = string.Format(NameProcedureConstants.GetByFilter, tableName);

                var parameters = new DynamicParameters();
                parameters.Add("@TotalRecords", direction: ParameterDirection.Output);
                foreach (PropertyInfo propertyInfo in parametersFilter.GetType().GetProperties())
                {
                    // Add parameters
                    parameters.Add("p_" + propertyInfo.Name, propertyInfo.GetValue(parametersFilter));
                }

                // Mở kết nối
                _databaseConnection.Open();

                // Xử lý lấy dữ liệu trong stored
                var result = _databaseConnection.QueryMultiple(storedProcedureName, parameters, commandType: CommandType.StoredProcedure);

                var data = new PagingResult<Entity>()
                {
                    Data = result.Read<Entity>().ToList(),
                    Total = parameters.Get<int>("@TotalRecords")
                };

                // Đóng kết nối
                _databaseConnection.Close();

                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _databaseConnection.Close();
                throw new MExceptionResponse(ex.Message);
            }
        }

        /// <summary>
        /// Lấy thông tin theo mã
        /// </summary>
        /// <param name="EntityCode">Mã đối tượng</param>
        /// <returns>Trả về Id đối tượng</returns>
        public Guid GetByCode(string EntityCode)
        {
            try
            {
                // Tên store procedure
                string storedProcedureName = string.Format(NameProcedureConstants.GetByCode, tableName);

                // Add param
                var parameters = new DynamicParameters();
                parameters.Add($"p_{tableName}Code", EntityCode);

                // Mở kết nối
                _databaseConnection.Open();

                // Xử lý lấy dữ liệu trong stored
                Guid result = _databaseConnection.QueryFirstOrDefault<Guid>(storedProcedureName, parameters, commandType: CommandType.StoredProcedure);

                // Đóng kết nối
                _databaseConnection.Close();

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _databaseConnection.Close();
                throw new MExceptionResponse(ex.Message);
            }
        }

        /// <summary>
        /// Lấy thông tin theo tên
        /// </summary>
        /// <param name="EntityName">Tên đối tượng</param>
        /// <returns>Trả về Id đối tượng</returns>
        public Guid GetByName(string EntityName)
        {
            try
            {
                // Tên store procedure
                string storedProcedureName = string.Format(NameProcedureConstants.GetByName, tableName);

                // Add param
                var parameters = new DynamicParameters();
                parameters.Add($"p_{tableName}Name", EntityName);

                // Mở kết nối
                _databaseConnection.Open();

                Guid result = _databaseConnection.QueryFirstOrDefault<Guid>(storedProcedureName, parameters, commandType: CommandType.StoredProcedure);

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

        /// <summary>
        /// Lấy ra 1 nhân viên theo Id
        /// </summary>
        /// <param name="id">Id nhân viên</param>
        /// <returns>Thông tin 1 nhân viên</returns>
        public virtual Entity GetById(Guid id)
        {
            try
            {
                // Tên store procedure
                string storedProcedureName = string.Format(NameProcedureConstants.GetById, typeof(Entity).Name);

                // Thêm parameter
                var parameters = new DynamicParameters();
                parameters.Add($"p_{tableName}Id", id);

                // Mở kết nối
                _databaseConnection.Open();

                // Xử lý lấy dữ liệu trong stored
                var result = _databaseConnection.QueryFirstOrDefault<Entity>(storedProcedureName, parameters, commandType: CommandType.StoredProcedure);

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

        /// <summary>
        /// Thêm 
        /// </summary>
        /// <param name="entity">Thông tin nhân viên cần thêm</param>
        /// <returns>true - false</returns>
        public virtual bool Insert(Entity entity)
        {
            try
            {
                // Tên store procedure
                string storedProcedureName = string.Format(NameProcedureConstants.Insert, tableName);

                // Chuẩn bị parameters cho stored procedure
                var parameters = new DynamicParameters();
                foreach (PropertyInfo propertyInfo in entity.GetType().GetProperties())
                {
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

        /// <summary>
        /// Cập nhập
        /// </summary>
        /// <param name="entity">Thông tin nhân viên cần cập nhập</param>
        /// <returns>true - false</returns>
        public bool Update(Entity entity)
        {
            try
            {
                // Tên store procedure
                string storedProcedureName = string.Format(NameProcedureConstants.Update, tableName);

                // Chuẩn bị parameters cho stored procedure
                var parameters = new DynamicParameters();
                foreach (PropertyInfo propertyInfo in entity.GetType().GetProperties())
                {
                    // Add parameters
                    parameters.Add("p_" + propertyInfo.Name, propertyInfo.GetValue(entity));
                }

                // Mở kết nối
                _databaseConnection.Open();

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

        /// <summary>
        /// Xóa bản ghi
        /// </summary>
        /// <param name="entityId">Id đối tượng cần xóa</param>
        /// <returns>true - false</returns>
        public virtual bool DeleteRecords(List<Guid> listGuid)
        {
            try
            {
                bool result = true;

                // Tên store procedure
                string storedProcedureName = string.Format(NameProcedureConstants.DeleteRecords, typeof(Entity).Name);

                // Thêm parameter
                var parameters = new DynamicParameters();
                parameters.Add($"p_{tableName}Ids", string.Join(",", listGuid));

                // Mở kết nối
                _databaseConnection.Open();
                _databaseConnection.BeginTransaction();

                // Xử lý xóa dữ liệu trong stored
                int numberDeleted = _databaseConnection.DeleteRecords(tableName, listGuid);

                if (numberDeleted == listGuid.Count) _databaseConnection.CommitTransaction();
                else
                {
                    _databaseConnection.RollbackTransaction();
                    result = false;
                }

                // Đóng kết nối
                _databaseConnection.Close();

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _databaseConnection.RollbackTransaction();
                _databaseConnection.Close();
                throw new MExceptionResponse(ex.Message);
            }
        }


        /// <summary>
        /// Xóa bản ghi
        /// </summary>
        /// <param name="entityId">Id đối tượng cần xóa</param>
        /// <returns>true - false</returns>
        public virtual bool DeleteUpdateRecords(List<Guid> listGuid)
        {
            try
            {
                bool result = true;

                // Tên store procedure
                string storedProcedureName = string.Format(NameProcedureConstants.DeleteRecords, tableName);

                // Thêm parameter
                var parameters = new DynamicParameters();
                parameters.Add($"p_{tableName}Ids", string.Join(",", listGuid));

                // Mở kết nối
                _databaseConnection.Open();
                _databaseConnection.BeginTransaction();

                // Xử lý xóa dữ liệu trong stored
                int numberDeleted = _databaseConnection.DeleteUpdateRecords(tableName, listGuid);

                if (numberDeleted == listGuid.Count) _databaseConnection.CommitTransaction();
                else
                {
                    _databaseConnection.RollbackTransaction();
                    result = false;
                }

                // Đóng kết nối
                _databaseConnection.Close();

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _databaseConnection.RollbackTransaction();
                _databaseConnection.Close();
                throw new MExceptionResponse(ex.Message);
            }
        }

        public bool LockUpRecords(List<Guid> listGuid)
        {
            try
            {
                bool result = true;

                _databaseConnection.Open();
                _databaseConnection.BeginTransaction();
                // Xử lý xóa dữ liệu trong stored
                int numberDeleted = _databaseConnection.LockUpRecords(tableName, listGuid);

                if (numberDeleted == listGuid.Count) _databaseConnection.CommitTransaction();
                else
                {
                    _databaseConnection.RollbackTransaction();
                    result = false;
                }
                // Đóng kết nối
                _databaseConnection.Close();

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _databaseConnection.RollbackTransaction();
                _databaseConnection.Close();
                throw new MExceptionResponse(ex.Message);
            }
        }
        #endregion
    }
}
