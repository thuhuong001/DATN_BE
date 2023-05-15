using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Text;

namespace DATN_NguyenThiThuHuong.Commons
{
    public static class Commons
    {
        /// <summary>
        /// Chuyển đối tượng thành dữ liệu DataTable
        /// </summary>
        /// <typeparam name="T">Đối tượng</typeparam>
        /// <param name="obj">Dữ liệu</param>
        /// <returns>Một table với kiểu đối tượng truyền vào</returns>
        public static DataTable ToDataTable<T>(this List<T> obj)
        {
            DataTable dt = new DataTable();

            // Add cột vào table
            foreach (PropertyInfo prop in typeof(T).GetProperties())
            {
                // Bỏ qua các property không cần thiết
                var attributes = prop.GetCustomAttribute(typeof(NotMappedAttribute), false);
                if (attributes is null)
                {
                    dt.Columns.Add(prop.Name);
                }
            }

            // Add dữ liệu vào
            if (obj != null)
            {
                foreach (var item in obj)
                {
                    DataRow dr = dt.NewRow();
                    foreach (PropertyInfo propertyInfo in item.GetType().GetProperties())
                    {
                        // Bỏ qua các property không cần thiết
                        var attributes = propertyInfo.GetCustomAttribute(typeof(NotMappedAttribute), false);
                        if (attributes is null)
                        {
                            // Add properties
                            dr[propertyInfo.Name] = propertyInfo.GetValue(item);
                        }
                    }
                    dt.Rows.Add(dr);
                }
            }

            return dt;
        }

        /// <summary>
        /// Chuyển kiểu dữ liệu thành string, null thành chuỗi empty
        /// </summary>
        /// <param name="value">object muốn chuyển</param>
        /// <returns></returns>
        static public string ObjToStr(this object value)
        {
            if (value is null) return "";
            else return value.ToString();
        }

        /// <summary>
        /// Chuyển byte thành số MB
        /// </summary>
        /// <param name="numberBytes">Số bytes</param>
        /// <returns></returns>
        static public int ConvertBytesToMebibytes(double numberBytes)
        {
            return (int)(numberBytes / 1048576);
        }
        public static string MD5Hash(string input)
        {
            using (var md5 = MD5.Create())
            {
                var inputBytes = Encoding.ASCII.GetBytes(input);
                var hashBytes = md5.ComputeHash(inputBytes);
                var sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
