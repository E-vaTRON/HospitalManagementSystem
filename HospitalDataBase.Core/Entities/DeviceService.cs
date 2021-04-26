using HospitalDataBase.Core.Entities.UnitType;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalDataBase.Core.Entities
{
    public class DeviceService
    {
        [Key]
        public string DeviceID { get; set; }           //mã hàng
        public string DeviceName { get; set; }         //tên hàng
        public Units Unit { get; set; }                //đơn vị tính
        public int UnitPrice { get; set; }             //đơn giá
        public int ServicePrice { get; set; }          //giá thu phí
        public int HealthInsurancePrice { get; set; }  //giá bảo hiểm y tế
        public string Result { get; set; }             //kết quả <CHECK ?>
        public string ManagementID { get; set; }       //mã quản lí
        public string Country { get; set; }            //nước sản xuất 
        public string SmallID { get; set; }            //mã con
        public string GroupID { get; set; }            //mã số nhóm
        public int Min { get; set; }                   //MIN
        public int Max { get; set; }                   //MAX
        public FormType ResultFromType { get; set; }    //form kết quả chuẩn đoán (hình ảnh/ kết quả xét nghiệm<bản>)

        public virtual ICollection<AnalysationTest> AnalysationTests { get; set; }
    }
}
