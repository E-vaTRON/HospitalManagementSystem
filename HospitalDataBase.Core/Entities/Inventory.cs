using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalDataBase.Core.Entities
{
    public class Inventory
    {
        [Key]
        public int InventoryID { get; set; }
        public string GoodID { get; set; }                 //mã hàng
        public string ShipmentID { get; set; }             //số lô
        public DateTime ExpiryDate { get; set; }           //hạng dùng
        public int CurrentAmount { get; set; }             //số lượng hiện tại

        public Drug Drug { get; set; }
        public virtual ICollection<GoodsExportation> Exportations { get; set; }
        public virtual ICollection<GoodsImportation> Importations  { get; set; }
    }
}
