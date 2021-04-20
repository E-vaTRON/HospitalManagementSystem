using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalDataBase.Entities.Entities
{
    public class DeviceService
    {
        public Guid ID { get; set; }
        public string deviceID { get; set; }           //mã hàng
        public string deviceName { get; set; }         //tên hàng
        public string unit { get; set; }               //đơn vị tính
        public int unitPrice { get; set; }             //đơn giá
        public int servicePrice { get; set; }          //giá thu phí
        public int healthInsurancePrice { get; set; }  //giá bảo hiểm y tế
        public string result { get; set; }             //kết quả <CHECK ?>
        public string managementID { get; set; }       //mã quản lí
        public string country { get; set; }            //nước sản xuất 
        public string smallID { get; set; }            //mã con
        public string grpoupID { get; set; }           //mã số nhóm
        public int min { get; set; }                   //MIN
        public int max { get; set; }                   //MAX
    }
}
