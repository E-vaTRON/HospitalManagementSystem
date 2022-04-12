using HospitalDataBase.DataObjects.UnitType;
using System.ComponentModel.DataAnnotations;

namespace HospitalDataBase.DataObjects.CreateDTO
{
    public class CreateDeviceServiceDTO
    {
        [Required]
        public string   DeviceName { get; set; } = string.Empty;          //tên hàng

        [Required]
        public string   Service { get; set; } = string.Empty;

        [Required]
        public Units        Unit { get; set; }                          //đơn vị tính

        public int          UnitPrice { get; set; }                     //đơn giá

        public int          ServicePrice { get; set; }                  //giá thu phí

        public int          HealthInsurancePrice { get; set; }          //giá bảo hiểm y tế

        [Required]
        public string       ManagementID { get; set; } = null!;         //mã quản lí

        public string       Country { get; set; } = string.Empty;       //nước sản xuất 

        [Required]
        public string       SmallID { get; set; } = string.Empty;       //mã con

        [Required]
        public string       GroupID { get; set; } = string.Empty;       //mã số nhóm

        public int          Min { get; set; }                           //MIN

        public int          Max { get; set; }                           //MAX

        [Required]
        public FormTypes    ResultFromType { get; set; }
    }
}
