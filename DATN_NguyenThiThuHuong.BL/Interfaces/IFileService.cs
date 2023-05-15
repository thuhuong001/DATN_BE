using DATN_NguyenThiThuHuong.Common.Models;
using DATN_NguyenThiThuHuong.Common.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN_NguyenThiThuHuong.BL.Interfaces
{
    public interface IFileService
    {
        public ServiceResult Insert(FileModel fileModel);
    }
}
