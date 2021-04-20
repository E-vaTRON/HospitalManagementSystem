using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalDataBase.Core.Entities
{
    public class DeviceService : BaseEntity
    {
        public string DeviceID { get; set; }           //mã hàng
        public string DeviceName { get; set; }         //tên hàng
        public string Unit { get; set; }               //đơn vị tính
        public int UnitPrice { get; set; }             //đơn giá
        public int ServicePrice { get; set; }          //giá thu phí
        public int HealthInsurancePrice { get; set; }  //giá bảo hiểm y tế
        public string Result { get; set; }             //kết quả <CHECK ?>
        public string ManagementID { get; set; }       //mã quản lí
        public string Country { get; set; }            //nước sản xuất 
        public string SmallID { get; set; }            //mã con
        public string RpoupID { get; set; }           //mã số nhóm
        public int Min { get; set; }                   //MIN
        public int Max { get; set; }                   //MAX
    }
}
