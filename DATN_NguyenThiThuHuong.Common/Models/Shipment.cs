using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN_NguyenThiThuHuong.Common.Models
{
    public class Shipment
    {
        public Guid ShipmentId { get; set; }
        public string ShipmentCode { get; set; }
        public string ShipmentName { get; set; }
        public string Method { get; set; }
        public int DateFrom { get; set; }
        public int DateTo { get; set; }
        public decimal PriceShip { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public string DateReceive
        {
            get
            {
                string dateReceive = "Giao hàng vào ";
                DateTime dateNow = DateTime.Now;
                dateReceive += dateNow.AddDays(DateFrom + 1).ToString("dd/MM/yyyy");
                dateReceive += " - ";
                dateReceive += dateNow.AddDays(DateTo + 1).ToString("dd/MM/yyyy");
                return dateReceive;
            }
        }
        //Số ngày giao hàng dự kiến của pt ship
        public string DateShip { get{
                return DateFrom + " - " + DateTo + " ngày";
           } }
        public Shipment()
        {

        }
    }
}
