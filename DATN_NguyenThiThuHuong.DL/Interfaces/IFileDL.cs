using DATN_NguyenThiThuHuong.Common.Models;
using DATN_NguyenThiThuHuong.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN_NguyenThiThuHuong.DL.Interfaces
{
    public interface IFileDL
    {
        public bool Insert(List<Image> images);

        public List<Image> GetFileByObjectId(Guid id);

        public bool DeleteFile(List<Guid> listId);
    }
}