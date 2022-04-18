using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalDataBase.Core.Entities
{
    public class Inventory : BaseEntity
    {
        public int          DrugID          { get; set; }       //mã hàng
        public int          StorageID       { get; set; }       //mã kho
        public DateTime     ExpiryDate      { get; set; }       //hạng dùng
        public int          CurrentAmount   { get; set; }       //số lượng hiện tại
        public int          OrinaryAmount   { get; set; }


        public Drug?        Drug        { get; set; }
        public Storage?     Storage     { get; set; }

        public virtual ICollection<Suppling>    Supplings   { get; set; } = new HashSet<Suppling>();
        public virtual ICollection<Bill>        Bills       { get; set; } = new HashSet<Bill>();
    }
}
