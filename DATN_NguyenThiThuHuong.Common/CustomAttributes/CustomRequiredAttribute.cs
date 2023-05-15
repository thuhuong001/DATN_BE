using DATN_NguyenThiThuHuong.Common.Resources;
using DATN_NguyenThiThuHuong.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN_NguyenThiThuHuong.Common.CustomAttributes
{
    /// <summary>
    /// Class custom lại sttribute Required bắn lỗi
    /// </summary>
    public class CustomRequiredAttribute : RequiredAttribute
    {
        #region Contructor
        public CustomRequiredAttribute() { } 
        #endregion

        #region Method
        /// <summary>
        /// Override hàm hiển thị lỗi
        /// </summary>
        /// <param name="name">Display name</param>
        /// <returns>Format lỗi mong muốn</returns>
        public override string FormatErrorMessage(string name)
        {
            return name + " " + ResourceVI.NotEmtity;
        }

        /// <summary>
        /// Override hàm check validate
        /// </summary>
        /// <param name="value">Giá trị</param>
        /// <returns>Trả ra true - false</returns>
        public override bool IsValid(object? value)
        {
            return !string.IsNullOrEmpty(value.ObjToStr().Trim());
        } 
        #endregion
    }
}
