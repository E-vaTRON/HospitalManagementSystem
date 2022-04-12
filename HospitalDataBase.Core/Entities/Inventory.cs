using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalDataBase.Core.Entities
{
    public class Inventory : BaseEntity
    {
        public string       DrugID          { get; set; } = string.Empty;       //mã hàng
        public string       ShipmentID      { get; set; } = string.Empty;       //số lô
        public DateTime     ExpiryDate      { get; set; }                       //hạng dùng
        public int          CurrentAmount   { get; set; }                       //số lượng hiện tại

        public Drug?        Drug            { get; set; }
        public virtual ICollection<PatientTransactionHistory>    Exportations    { get; set; } = new HashSet<PatientTransactionHistory>();
        public virtual ICollection<GoodsImportation>    Importations    { get; set; } = new HashSet<GoodsImportation>();
    }
}
