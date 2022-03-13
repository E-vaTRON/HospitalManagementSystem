using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalDataBase.Core.Entities
{
    public class Inventory
    {
        [Key]
        public int          InventoryID     { get; set; }
        public string       GoodID          { get; set; } = string.Empty;       //mã hàng
        public string       ShipmentID      { get; set; } = string.Empty;       //số lô
        public DateTime     ExpiryDate      { get; set; }                       //hạng dùng
        public int          CurrentAmount   { get; set; }                       //số lượng hiện tại

        public Drug?    Drug    { get; set; }
        public virtual ICollection<GoodsExportation>    Exportations    { get; set; } = new HashSet<GoodsExportation>();
        public virtual ICollection<GoodsImportation>    Importations    { get; set; } = new HashSet<GoodsImportation>();
    }
}
