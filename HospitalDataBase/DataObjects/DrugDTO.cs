using HospitalDataBase.Services;
using Microsoft.AspNetCore.Mvc;

namespace HospitalDataBase.DataObjects
{
    [ModelBinder(typeof(MultipleSourcesModelBinder<DrugDTO>))]
    public class DrugDTO : BaseDTO
    {
        public string GoodID { get; set; }
        public string GoodName { get; set; }             //tên hàng
        public string ActiveIngredientName { get; set; } //tên hoạt chất
        public string Unit { get; set; }                 //đơn vị tính
        public string GoodType { get; set; }             //loại hàng hóa
        public string UnitPrice { get; set; }            //đơn giá
        public int HealthInsurancePrice { get; set; }    //giá bảo hiểm y tế
        public string ManagementID { get; set; }         //mã quản lý
        public string Country { get; set; }              //nước sản xuất
        public string GroupID { get; set; }              //mã số nhóm
    }
}
