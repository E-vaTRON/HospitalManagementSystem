﻿namespace HospitalManagementSystem.DataProvider;

public class DrugInventory : ModelBase
{
    public int CurrentAmount { get; set; }       //số lượng hiện tại

    public string? StorageId { get; set; }       //mã kho
    public Storage Storage { get; set; } = default!;
    public string? GoodSupplingId { get; set; } = default!;
    public GoodSuppling GoodSuppling { get; set; } = default!;

    public virtual ICollection<Bill> Bills { get; set; } = new HashSet<Bill>();
}
