﻿namespace HospitalManagementSystem.DataProvider;

public class Importation : ModelBase
{
    public string       ReceiptNumber   { get; set; } = string.Empty;       //số chứng từ
    public string       Billnumber      { get; set; } = string.Empty;       //số hóa đơn
    public DateTime     RecordDay       { get; set; }                       //ngày ghi sổ
    public DateTime     ReceiptDay      { get; set; }                       //ngày chứng từ
    public int          Tax             { get; set; }                       //thuế VAT
    public int          TotalPrice      { get; set; }                       //thành tiền
    public string       Company         { get; set; } = string.Empty;       //nhà cung cấp


    public virtual ICollection<DrugInventory> DrugInventories { get; set; } = new HashSet<DrugInventory>();
}
