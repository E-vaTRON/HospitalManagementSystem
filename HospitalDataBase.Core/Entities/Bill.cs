

namespace HospitalDataBase.Core.Entities
{
    public class Bill : BaseEntity
    {
        public int      TransactionID   { get; set; }
        public int      InventoryID     { get; set; }
        public string   DrugName        { get; set; } = string.Empty;
        public int      Amount          { get; set; }

        public PatientTransactionHistory?   Transaction { get; set; }
        public Inventory?                   Inventory { get; set; }

    }
}
