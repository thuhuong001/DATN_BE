using Dapper;
using DATN_NguyenThiThuHuong.Common;
using DATN_NguyenThiThuHuong.Common.Constants;
using DATN_NguyenThiThuHuong.Common.Models;
using DATN_NguyenThiThuHuong.DL.Database;
using DATN_NguyenThiThuHuong.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace DATN_NguyenThiThuHuong.DL.Repository
{
    public class FileDL : IFileDL
    {
        #region Field
        protected string tableName;
        protected IDatabaseConnection _databaseConnection;
        #endregion

        #region Contructor
        /// <summary>
        /// Khởi tạo kết nối DB
        /// </summary>
        public FileDL(IDatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }

        public bool DeleteFile(List<Guid> listId)
        {
            try
            {
                string query = $"Delete from Image where ImageId in (@Id)";
                _databaseConnection.Open();
                _databaseConnection.BeginTransaction();
                int numberRecoredDeleted = _databaseConnection.Connection().Execute(query, listId.AsEnumerable().Select(i => new { Id = i }).ToList(), _databaseConnection.Transaction());
                if (numberRecoredDeleted == 0) _databaseConnection.RollbackTransaction();
                else _databaseConnection.CommitTransaction();
                // Đóng kết nối
                _databaseConnection.Close();

                return numberRecoredDeleted > 0 ? true : false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _databaseConnection.RollbackTransaction();
                // Đóng kết nối
                _databaseConnection.Close();
                throw new MExceptionResponse(ex.Message);
            }
        }

        public List<Image> GetFileByObjectId(Guid id)
        {
            try
            {
                // Tên store procedure
                string query = $"select * from Image where ObjectId = '{id}'";

                // Mở kết nối
                _databaseConnection.Open();

                // Xử lý lấy dữ liệu trong stored
                var result = _databaseConnection.Connection().Query<Image>(query);

                // Đóng kết nối
                _databaseConnection.Close();

                return result.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // Đóng kết nối
                _databaseConnection.Close();
                throw new MExceptionResponse(ex.Message);
            }
        }


        public bool Insert(List<Image> images)
        {
            // Mở kết nối
            _databaseConnection.Open();

            // Đóng kết nối
            int result = _databaseConnection.InsertRecords<Image>(images);

            return result > 0 ? true : false;
        }
        #endregion
    }
}
