namespace DATN_NguyenThiThuHuong.Common.Models.DTO
{
    /// <summary>
    /// Class pagging chung
    /// </summary>
    public class PagingModel
    {
        /// <summary>
        /// Số trang trên 1 page
        /// </summary>
        public int pageSize { get; set; } = 20;

        /// <summary>
        /// Vị trí page
        /// </summary>
        public int pageNumber { get; set; } = 1;

        /// <summary>
        /// Text tìm kiếm
        /// </summary>
        public string? textSearch { get; set; }

        /// <summary>
        /// Text tìm kiếm
        /// </summary>
        public Guid? parentId { get; set; }

        public Guid? TypeId { get; set; }
        public Guid? BrandId { get; set; }
        public int Status { get; set; }
    }
    
}
