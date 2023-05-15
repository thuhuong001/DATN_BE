

using DATN_NguyenThiThuHuong.Common.Models.DTO;

namespace DATN_NguyenThiThuHuong.DL.Interfaces
{
    /// <summary>
    /// Base interface Repository
    /// </summary>
    public interface IBaseDL<Entity>
    {
        /// <summary>
        /// Lấy danh sách có bộ lọc
        /// </summary>
        /// <param name="parameters">Param bộ lọc truyền vào truyền vào</param>
        /// <returns>Danh sách đối tượng</returns>
        public PagingResult<Entity> GetByFilter(dynamic parameters);

        /// <summary>
        /// Lấy dữ liệu theo ID
        /// </summary>
        /// <param name="id">Id đối tượng</param>
        /// <returns>Đối tượng</returns>
        public Entity GetById(Guid id);

        /// <summary>
        /// Lấy thông tin theo mã
        /// </summary>
        /// <param name="EntityCode">Mã đối tượng</param>
        /// <returns>Trả về Id đối tượng</returns>
        public Guid GetByCode(string EntityCode);

        /// <summary>
        /// Lấy thông tin theo tên
        /// </summary>
        /// <param name="EntityName">Tên đối tượng</param>
        /// <returns>Trả về Id đối tượng</returns>
        public Guid GetByName(string EntityName);

        /// <summary>
        /// Thêm 1 bản ghi
        /// </summary>
        /// <param name="entity">Đối tượng thêm</param>
        /// <returns>0 : thất bại - 1 : thành công</returns>
        public bool Insert(Entity entity);

        /// <summary>
        /// Sửa 1 bản ghi
        /// </summary>
        /// <param name="entity">Đối tượng update</param>
        /// <returns>0 : thất bại - 1 : thành công</returns>
        public bool Update(Entity entity);

        /// <summary>
        /// Xóa nhiều bản ghi
        /// </summary>
        /// <param name="listId">ListID</param>
        /// <returns>Số bản ghi thay đổi</returns>
        public bool DeleteRecords(List<Guid> listId);

        public bool DeleteUpdateRecords(List<Guid> listId);

        public bool LockUpRecords(List<Guid> listId);
    }
}
