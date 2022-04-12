using HospitalDataBase.Services;
using Microsoft.AspNetCore.Mvc;

namespace HospitalDataBase.DataObjects
{
    [ModelBinder(typeof(MultipleSourcesModelBinder<DeviceServiceDTO>))]
    public class DeviceServiceDTO
    {
        [FromRoute]
        public string   DeviceID                { get; set; } = string.Empty;
        public string   DeviceName              { get; set; } = string.Empty;       //tên hàng
        public string   Service                 { get; set; } = string.Empty;
        public string   Unit                    { get; set; } = string.Empty;       //đơn vị tính
        public int      UnitPrice               { get; set; }                       //đơn giá
        public int      ServicePrice            { get; set; }                       //giá thu phí
        public int      HealthInsurancePrice    { get; set; }                       //giá bảo hiểm y tế
        public string   ManagementID            { get; set; } = string.Empty;       //mã quản lí
        public string   Country                 { get; set; } = string.Empty;       //nước sản xuất 
        public string   SmallID                 { get; set; } = string.Empty;       //mã con
        public string   GroupID                 { get; set; } = string.Empty;       //mã số nhóm
        public int      Min                     { get; set; }                       //MIN
        public int      Max                     { get; set; }                       //MAX
        public string   ResultFromType          { get; set; } = string.Empty;
    }
}
