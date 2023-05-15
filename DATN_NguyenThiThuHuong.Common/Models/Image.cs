using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN_NguyenThiThuHuong.Common.Models
{
    public class Image
    {
        public Guid ImageId { get; set; }
        public string ImageName { get; set; }
        public string ImageLink { get; set; }
        public Guid ObjectId { get; set; }
        public int IsDefault { get; set; }
    }
}
