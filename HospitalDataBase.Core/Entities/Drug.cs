using HospitalDataBase.Core.Entities.UnitType;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalDataBase.Core.Entities
{
    public class Drug
    {
        [Key]
        public string GoodID { get; set; }
        public string GoodName { get; set; }             //tên hàng
        public string ActiveIngredientName { get; set; } //tên hoạt chất
        public Units Unit { get; set; }                   //đơn vị tính
        public string GoodType { get; set; }             //loại hàng hóa
        public string UnitPrice { get; set; }            //đơn giá
        public int HealthInsurancePrice { get; set; }    //giá bảo hiểm y tế
        public string ManagementID { get; set; }         //mã quản lý
        public string Country { get; set; }              //nước sản xuất
        public string GroupID { get; set; }              //mã số nhóm

        public virtual ICollection<Inventory> Inventories { get; set; } = new HashSet<Inventory>();
        public virtual ICollection<GoodsExportation> Exportations { get; set; } = new HashSet<GoodsExportation>();
        public virtual ICollection<GoodsImportation> Importations { get; set; } = new HashSet<GoodsImportation>();
    }
}
