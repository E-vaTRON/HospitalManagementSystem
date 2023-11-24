namespace HospitalManagementSystem.Domain;

public class GoodsImportation : BaseEntity
{
    public int          StorageID       { get; set; }                       //mã kho
    public int          GoodID          { get; set; }                       //mã hàng
    public string       ReceiptNumber   { get; set; } = string.Empty;       //số chứng từ
    public string       Billnumber      { get; set; } = string.Empty;       //số hóa đơn
    public DateTime     RecordDay       { get; set; }                       //ngày ghi sổ
    public DateTime     ReceiptDay      { get; set; }                       //ngày chứng từ
    public DateTime     ExpiryDate      { get; set; }                       //hạng dùng
    public int          Amout           { get; set; }                       //số lượng
    public int          Tax             { get; set; }                       //thuế VAT
    public int          TotalPrice      { get; set; }                       //thành tiền
    public string       Company         { get; set; } = string.Empty;       //nhà cung cấp
    
    public virtual ICollection<Suppling> Goods { get; set; } = new HashSet<Suppling>();
}
