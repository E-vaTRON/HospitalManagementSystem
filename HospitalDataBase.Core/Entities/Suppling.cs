using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDataBase.Core.Entities
{
    public class Suppling : BaseEntity
    {
        public int      ShipmentID      { get; set; }
        public int      InventoryID     { get; set; }
        public int      DrugID          { get; set; }
        public string   GooodName       { get; set; } = string.Empty;
        public int      Amount          { get; set; }

        public Inventory?           Inventory           { get; set; }
        public GoodsImportation?    GoodsImportation    { get; set; }
        public Drug?                Drug                { get; set; }

    }
}
