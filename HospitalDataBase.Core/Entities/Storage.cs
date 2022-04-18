using System.Collections.Generic;

namespace HospitalDataBase.Core.Entities
{
    public class Storage : BaseEntity
    {
        public string location { get; set; } = string.Empty;

        public virtual ICollection<Inventory> Inventories { get; set; } = new HashSet<Inventory>();

    }
}
