using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN_NguyenThiThuHuong.Common.Constants
{
    public static class NameProcedureConstants
    {
        /// <summary>
        /// Store lấy tất cả dữ liệu
        /// </summary>
        public static string GetByAll = "Proc_{0}_GetAll";

        /// <summary>
        // Store lấy dữ liệu có bộ lọc
        /// </summary>
        /// 
        public static string GetByFilter = "Proc_{0}_GetByFilter";
        public static string GetByFilterDetail = "Proc_{0}_GetByFilterDetail";

        /// <summary>
        // Store lấy mã code mới
        /// </summary>
        /// 
        public static string GetNewCode = "Proc_{0}_GetNewCode";

        /// <summary>
        // Store lấy mã max
        /// </summary>
        /// 
        public static string GetMaxCode = "Proc_{0}_GetMaxCode";

        /// <summary>
        // Store lấy đối tượng theo ID
        /// </summary>
        /// 
        public static string GetById = "Proc_{0}_GetById";
        public static string GetByToken = "Proc_{0}_GetByToken";
        public static string GetByEmail = "Proc_{0}_GetByEmail";
        public static string GetByIdDetail = "Proc_{0}_GetByIdDetail";
        public static string DeleteByToken = "Proc_{0}_DeleteByToken";
        public static string GetByEmailAndPassword = "Proc_{0}_GetByEmailAndPassword";

        /// <summary>
        // Store lấy đối tượng theo số cmnd
        /// </summary>
        /// 
        public static string GetByIdentityNumber = "Proc_{0}_GetByIdentityNumber";

        /// <summary>
        // Store lấy đối tượng theo mã
        /// </summary>
        /// 
        public static string GetByCode = "Proc_{0}_GetByCode";

        /// <summary>
        // Store lấy đối tượng theo tên
        /// </summary>
        /// 
        public static string GetByName = "Proc_{0}_GetByName";

        /// <summary>
        // Store thêm bản ghi
        /// </summary>
        /// 
        public static string Insert = "Proc_{0}_Insert";

        /// <summary>
        // Store sửa bản ghi
        /// </summary>
        /// 
        public static string Update = "Proc_{0}_Update";

        /// <summary>
        // Store xóa bản ghi
        /// </summary>
        /// 
        public static string Delete = "Proc_{0}_Delete";

        /// <summary>
        // Store nhiều bản ghi
        /// </summary>
        /// 
        public static string DeleteRecords = "Proc_{0}_DeleteRecords";
    }
}
