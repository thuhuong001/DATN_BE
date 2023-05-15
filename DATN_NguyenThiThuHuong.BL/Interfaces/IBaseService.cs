using DATN_NguyenThiThuHuong.Common.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN_NguyenThiThuHuong.BL.Interfaces
{
    /// <summary>
    /// Base Service
    /// </summary>
    /// <typeparam name="Entity"></typeparam>
    public interface IBaseService<Entity>
    {
        #region Method

        /// <summary>
        /// Lấy danh sách có bộ lọc
        /// </summary>
        /// <param name="parameters">Param bộ lọc truyền vào truyền vào</param>
        /// <returns>Danh sách đối tượng</returns>
        public object GetByFilter(dynamic parameters);

        /// <summary>
        /// Lấy dữ liệu theo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Đối tượng</returns>
        public Entity GetById(Guid id);

        /// <summary>
        /// Thêm vào dữ liệu 
        /// </summary>
        /// <param name="enity"></param>
        public ServiceResult Insert(Entity enity);

        /// <summary>
        /// Sửa dữ liệu
        /// </summary>
        /// <param name="enity"></param>
        /// <returns></returns>
        public ServiceResult Update(Guid id, Entity enity);

        public bool LockUpRecords(List<Guid> listId);

        /// <summary>
        /// Xóa nhiều bản ghi
        /// </summary>
        /// <param name="listId">ListID</param>
        /// <returns>Số bản ghi thay đổi</returns>
        public bool DeleteRecords(List<Guid> listId);
        #endregion
    }
}
