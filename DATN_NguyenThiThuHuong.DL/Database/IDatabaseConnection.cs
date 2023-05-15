using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace DATN_NguyenThiThuHuong.DL.Database
{
    public interface IDatabaseConnection
    {
        /// <summary>
        /// Mở state kết nối
        /// </summary>
        void Open();

        /// <summary>
        /// Đóng kết nối
        /// </summary>
        /// /// 
        void Close();

        /// <summary>
        /// Khởi tạo transaction
        /// </summary>
        /// /// 
        void BeginTransaction();

        MySqlConnection? Connection();

        /// <summary>
        /// transaction thực thi
        /// </summary>
        /// /// 
        void CommitTransaction();

        /// <summary>
        /// transaction
        /// </summary>
        /// /// 
        MySqlTransaction? Transaction();

        /// <summary>
        /// rollback transaction
        /// </summary>
        /// /// 
        void RollbackTransaction();

        /// <summary>
        /// Execute a command that returns multiple result sets, and access each in turn.
        /// </summary>
        /// <param name="cnn">The connection to query on.</param>
        /// <param name="sql">The SQL to execute for this query.</param>
        /// <param name="param">The parameters to use for this query.</param>
        /// <param name="transaction">The transaction to use for this query.</param>
        /// <param name="commandTimeout">Number of seconds before command execution timeout.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// 
        public GridReader QueryMultiple(string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null);

        /// <summary>
        /// Execute parameterized SQL.
        /// </summary>
        /// <param name="sql">The SQL to execute for this query.</param>
        /// <param name="param">The parameters to use for this query.</param>
        /// <param name="transaction">The transaction to use for this query.</param>
        /// <param name="commandTimeout">Number of seconds before command execution timeout.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns>The number of rows affected.</returns>
        /// 
        public int Execute(string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null);

        /// <summary>
        /// Return a dynamic object with properties matching the columns.
        /// </summary>
        /// <param name="sql">The SQL to execute for the query.</param>
        /// <param name="param">The parameters to pass, if any.</param>
        /// <param name="transaction">The transaction to use, if any.</param>
        /// <param name="commandTimeout">The command timeout (in seconds).</param>
        /// <param name="commandType">The type of command to execute.</param>
        /// <remarks>Note: the row can be accessed via "dynamic", or by casting to an IDictionary&lt;string,object&gt;</remarks>
        /// 
        public T QueryFirstOrDefault<T>(string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null);

        /// <summary>
        /// Return a dynamic object with properties matching the columns.
        /// </summary>
        /// <param name="sql">The SQL to execute for the query.</param>
        /// <param name="param">The parameters to pass, if any.</param>
        /// <param name="transaction">The transaction to use, if any.</param>
        /// <param name="commandTimeout">The command timeout (in seconds).</param>
        /// <param name="commandType">The type of command to execute.</param>
        /// <remarks>Note: the row can be accessed via "dynamic", or by casting to an IDictionary&lt;string,object&gt;</remarks>
        /// 
        public object QueryFirstOrDefault(string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null);

        /// <summary>
        /// Xóa nhiều bản ghi theo id
        /// </summary>
        /// <param name="tableName">Tên bảng</param>
        /// <param name="listId">List id</param>
        /// <returns>Số lượng bản ghi được xóa</returns>
        public int DeleteRecords(string tableName, List<Guid> listId);

        /// <summary>
        /// Xóa nhiều bản ghi theo id
        /// </summary>
        /// <param name="tableName">Tên bảng</param>
        /// <param name="listId">List id</param>
        /// <returns>Số lượng bản ghi được xóa</returns>
        public int DeleteUpdateRecords(string tableName, List<Guid> listId);


        public int LockUpRecords(string tableName, List<Guid> listId);

        /// <summary>
        /// Import
        /// </summary>
        /// <param name="tableName">Tên bảng</param>
        /// <param name="dataTable">Dữ liệu bảng</param>
        /// <returns>Số lượng bản ghi được thêm</returns>

        public int InsertRecords<T>(List<T> records, string query = "");
    }
}

