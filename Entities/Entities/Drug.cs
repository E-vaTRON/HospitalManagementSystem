using System;
using System.Collections.Generic;
using HospitalDataBase.Entities.Entities.UnitType;
namespace HospitalDataBase.Entities.Entities
{
    public class Drug
    {
        public Guid ID { get; set; }
        public string goodID { get; set; }               //mã hàng
        public string goodName { get; set; }             //tên hàng
        public string activeIngredientName { get; set; } //tên hoạt chất
        public Unit unit { get; set; }                 //đơn vị tính
        public string goodType { get; set; }             //loại hàng hóa
        public string unitPrice { get; set; }            //đơn giá
        public int healthInsurancePrice { get; set; }    //giá bảo hiểm y tế
        public string managementID { get; set; }         //mã quản lý
        public string country { get; set; }              //nước sản xuất
        public string groupID { get; set; }              //mã số nhóm

        public ICollection<Inventory> inventories { get; set; }
        public ICollection<GoodsExportation> exportations { get; set; }
        public ICollection<GoodsImportation> importations { get; set; }
    }
}
