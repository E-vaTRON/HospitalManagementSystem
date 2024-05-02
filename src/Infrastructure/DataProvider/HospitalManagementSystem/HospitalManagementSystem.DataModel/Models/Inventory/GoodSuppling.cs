﻿namespace HospitalManagementSystem.DataProvider;

public class GoodSuppling : ModelBase
{
    public string   GoodInformation { get; set; } = string.Empty;
    public DateTime ExpiryDate      { get; set; }       //hạng dùng
    public int      OrinaryAmount   { get; set; }

    public DrugInventory?   DrugInventory   { get; set; } // This is Principal Table

    public Guid?        ImportationId   { get; set; }
    public Importation? Importation     { get; set; }
    public Guid?        DrugId          { get; set; }
    public Drug?        Drug            { get; set; }
}