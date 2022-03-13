using HospitalDataBase.Core.Entities.UnitType;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalDataBase.Core.Entities
{
    public class Drug
    {
        [Key]
        public string   GoodID                  { get; set; } = null!;
        public string   GoodName                { get; set; } = string.Empty;       //tên hàng
        public string   ActiveIngredientName    { get; set; } = string.Empty;       //tên hoạt chất
        public Units    Unit                    { get; set; }                       //đơn vị tính
        public string   GoodType                { get; set; } = string.Empty;       //loại hàng hóa
        public int      UnitPrice               { get; set; }                       //đơn giá
        public int      HealthInsurancePrice    { get; set; }                       //giá bảo hiểm y tế
        public string   ManagementID            { get; set; } = string.Empty;       //mã quản lý
        public string   Country                 { get; set; } = string.Empty;       //nước sản xuất
        public string   GroupID                 { get; set; } = string.Empty;       //mã số nhóm

        public virtual ICollection<Inventory>   Inventories     { get; set; } = new HashSet<Inventory>();
    }
}
