﻿namespace HospitalManagementSystem.DataProvider;

public class DrugInventory : ModelBase
{
    public string   GoodInformation { get; set; } = string.Empty;
    public DateTime ExpiryDate      { get; set; }       //hạng dùng
    public int      OrinaryAmount   { get; set; }
    public int      CurrentAmount   { get; set; }       //số lượng hiện tại

    public Guid?        StorageId       { get; set; }       //mã kho
    public Storage      Storage         { get; set; } = default!;
    public Guid?        ImportationId   { get; set; }
    public Importation? Importation     { get; set; }
    public Guid?        DrugId          { get; set; }
    public Drug?        Drug            { get; set; }

    public virtual ICollection<DrugPrescription> DrugPrescriptions { get; set; } = new HashSet<DrugPrescription>();
}
