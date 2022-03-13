
using HospitalDataBase.Core.Entities.UnitType;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalDataBase.Core.Entities
{
    public class DeviceService
    {
        [Key]
        public string       DeviceID                { get; set; } = null!;              //mã hàng
        public string       DeviceName              { get; set; } = string.Empty;       //tên hàng
        public string       Service                 { get; set; } = string.Empty;       //tên dich4 vụ
        public Units        Unit                    { get; set; }                       //đơn vị tính
        public int          UnitPrice               { get; set; }                       //đơn giá
        public int          ServicePrice            { get; set; }                       //giá thu phí
        public int          HealthInsurancePrice    { get; set; }                       //giá bảo hiểm y tế
        public string       ManagementID            { get; set; } = string.Empty;       //mã quản lí
        public string       Country                 { get; set; } = string.Empty;       //nước sản xuất 
        public string       SmallID                 { get; set; } = null!;              //mã con
        public string       GroupID                 { get; set; } = null!;              //mã số nhóm
        public int          Min                     { get; set; }                       //MIN
        public int          Max                     { get; set; }                       //MAX
        public FormTypes    ResultFromType          { get; set; }                       //form kết quả chuẩn đoán

        public virtual ICollection<AnalysationTest>     AnalysationTests    { get; set; } = new HashSet<AnalysationTest>();
    }
}
