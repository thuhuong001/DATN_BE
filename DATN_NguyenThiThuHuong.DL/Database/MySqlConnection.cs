using Dapper;
using DATN_NguyenThiThuHuong.Common;
using DATN_NguyenThiThuHuong.Common.Models;
using DATN_NguyenThiThuHuong.Commons;
using DATN_NguyenThiThuHuong.DL.Helpers;
using MySqlConnector;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Reflection;
using static Dapper.SqlMapper;

namespace DATN_NguyenThiThuHuong.DL.Database
{

    /// <summary>
    /// Xử lý kết nối db
    /// </summary>
    public class DatabaseConnection : IDatabaseConnection
    {
        #region Field
        private MySqlConnection? _connection;
        protected MySqlTransaction? _transaction;
        #endregion

        #region Method
        /// <summary>
        /// Khởi tạo kết nối
        /// </summary>
        /// <returns>MySqlConnection</returns>
        public void Open()
        {
            _connection = new MySqlConnection(DatabaseContext.connectionString);
            _connection.Open();
        }

        /// <summary>
        /// Đóng state kết nối
        /// </summary>
        public void Close()
        {
            if (_connection != null)
            {
                _connection.Close();
                _connection.Dispose();
            }
        }

        /// <summary>
        /// transaction khởi tạo
        /// </summary>
        public void BeginTransaction()
        {
            _transaction = _connection.BeginTransaction();
        }

        public MySqlTransaction? Transaction()
        {
            return _transaction;
        }

        /// <summary>
        /// transaction thực thi
        /// </summary>
        public void CommitTransaction()
        {
            _transaction.Commit();
        }

        public MySqlConnection? Connection()
        {
            return _connection;
        }

        /// <summary>
        /// transaction rollback
        /// </summary>
        public void RollbackTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Rollback();
            }
        }
        /// <summary>
        /// Execute parameterized SQL.
        /// </summary>
        /// <param name="sql">The SQL to execute for this query.</param>
        /// <param name="param">The parameters to use for this query.</param>
        /// <param name="transaction">The transaction to use for this query.</param>
        /// <param name="commandTimeout">Number of seconds before command execution timeout.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns>The number of rows affected.</returns>
        public GridReader QueryMultiple(string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {

            var response = _connection.QueryMultiple(sql, param, _transaction, commandTimeout, commandType);

            return response;
        }


        /// <summary>
        /// Return a dynamic object with properties matching the columns.
        /// </summary>
        /// <param name="sql">The SQL to execute for the query.</param>
        /// <param name="param">The parameters to pass, if any.</param>
        /// <param name="transaction">The transaction to use, if any.</param>
        /// <param name="commandTimeout">The command timeout (in seconds).</param>
        /// <param name="commandType">The type of command to execute.</param>
        /// <remarks>Note: the row can be accessed via "dynamic", or by casting to an IDictionary&lt;string,object&gt;</remarks>
        public T QueryFirstOrDefault<T>(string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            T response = _connection.QueryFirstOrDefault<T>(sql, param, _transaction, commandTimeout, commandType);

            return response;
        }

        /// <summary>
        /// Return a dynamic object with properties matching the columns.
        /// </summary>
        /// <param name="sql">The SQL to execute for the query.</param>
        /// <param name="param">The parameters to pass, if any.</param>
        /// <param name="transaction">The transaction to use, if any.</param>
        /// <param name="commandTimeout">The command timeout (in seconds).</param>
        /// <param name="commandType">The type of command to execute.</param>
        /// <remarks>Note: the row can be accessed via "dynamic", or by casting to an IDictionary&lt;string,object&gt;</remarks>
        public object QueryFirstOrDefault(string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            var response = _connection.QueryFirstOrDefault(sql, param, _transaction, commandTimeout, commandType);

            return response; throw new NotImplementedException();
        }

        /// <summary>
        /// Return a dynamic object with properties matching the columns.
        /// </summary>
        /// <param name="sql">The SQL to execute for this query.</param>
        /// <param name="param">The parameters to use for this query.</param>
        /// <param name="transaction">The transaction to use for this query.</param>
        /// <param name="commandTimeout">Number of seconds before command execution timeout.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns>The number of rows affected.</returns>
        public int Execute(string sql, object? param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            var response = _connection.Execute(sql, param, _transaction, commandTimeout, commandType);

            return response;
        }

        /// <summary>
        /// Xóa nhiều bản ghi theo id
        /// </summary>
        /// <param name="tableName">Tên bảng</param>
        /// <param name="listId">List id</param>
        /// <returns>Số lượng bản ghi được xóa</returns>
        public int DeleteRecords(string tableName, List<Guid> listId)
        {
            string query = $"delete from {tableName} where {tableName}Id in (@Id)";

            int numberRecoredDeleted = _connection.Execute(query, listId.AsEnumerable().Select(i => new { Id = i }).ToList(), _transaction);

            return numberRecoredDeleted;
        }

        /// <summary>
        /// Xóa nhiều theo update
        /// </summary>
        /// <param name="tableName">Tên bảng</param>
        /// <param name="listId">List id</param>
        /// <returns>Số lượng bản ghi được xóa</returns>
        public int DeleteUpdateRecords(string tableName, List<Guid> listId)
        {
            string query = $"Update {tableName} set IsDelete = 1 where {tableName}Id in (@Id)";

            int numberRecoredDeleted = _connection.Execute(query, listId.AsEnumerable().Select(i => new { Id = i }).ToList(), _transaction);

            return numberRecoredDeleted;
        }

        /// <summary>
        /// Khóa nhiều theo update
        /// </summary>
        /// <param name="tableName">Tên bảng</param>
        /// <param name="listId">List id</param>
        /// <returns>Số lượng bản ghi được khóa</returns>
        public int LockUpRecords(string tableName, List<Guid> listId)
        {
            string query = $"Update {tableName} set IsActive = !IsActive where {tableName}Id in (@Id)";

            int numberRecoredDeleted = _connection.Execute(query, listId.AsEnumerable().Select(i => new { Id = i }).ToList(), _transaction);

            return numberRecoredDeleted;
        }

        /// <summary>
        /// Import
        /// </summary>
        /// <param name="tableName">Tên bảng</param>
        /// <param name="dataTable">Dữ liệu bảng</param>
        /// <returns>Số lượng bản ghi được thêm</returns>
        public int InsertRecords<T>(List<T> records, string queryCustom = "")
        {
            try
            {
                int numberRecoredImportSuccess;
                List<string> queryListItem = new List<string>();
                var listPropery = new List<string>();

                // Lấy các property trong class
                foreach (var property in typeof(T).GetProperties())
                {
                    // Loại bỏ các attribute không có trang bảng
                    var attributes = property.GetCustomAttribute(typeof(NotMappedAttribute), false);
                    if (attributes is null)
                    {
                        // Add properties
                        listPropery.Add(property.Name);
                    }
                }

                string query = $"INSERT INTO {typeof(T).Name} ({string.Join(", ", listPropery)}) VALUES";

                // Tạo các value query
                foreach (var entity in records)
                {
                    List<string> listColumnRow = new List<string>();
                    foreach (PropertyInfo property in entity.GetType().GetProperties())
                    {
                        var attributes = property.GetCustomAttribute(typeof(NotMappedAttribute), false);
                        if (attributes is null)
                        {
                            var value = property.GetValue(entity);

                            if (value != null && value.GetType().IsEnum)
                            {
                                listColumnRow.Add("'" + Convert.ToInt32(value) + "'");
                                continue;
                            }
                            else if (property.PropertyType == typeof(DateTime?) || property.PropertyType == typeof(DateTime))
                            {
                                if (value != null && !value.ObjToStr().Equals(""))
                                {
                                    DateTime dateTime = DateTime.Parse(value.ObjToStr());
                                    listColumnRow.Add("'" + dateTime.ToString("yyyy/MM/dd H:m:s") + "'");
                                }
                                else listColumnRow.Add("null");
                                continue;
                            }
                            else if (property.PropertyType == typeof(long?) || property.PropertyType == typeof(long))
                            {
                                if (value is null) listColumnRow.Add("null");
                                continue;
                            }

                            listColumnRow.Add("'" + property.GetValue(entity) + "'");
                        }

                    }
                    string queryItem = "(" + String.Join(", ", listColumnRow) + ")";
                    queryListItem.Add(queryItem);
                }

                query += String.Join(",", queryListItem);

                if (!queryCustom.Equals(""))
                {
                    query += "; ";
                    query += queryCustom;
                }

                // Mở kết nối
                //Open();
                //BeginTransaction();

                numberRecoredImportSuccess = _connection.Execute(query, null, _transaction);
                if (numberRecoredImportSuccess < 1) RollbackTransaction();
                //CommitTransaction();

                // Đóng kết nối
                //Close();

                return numberRecoredImportSuccess;
            }
            catch (Exception ex)
            {
                RollbackTransaction();
                Close();
                throw new MExceptionResponse(ex.Message);
            }
        }

        #endregion
    }
}
