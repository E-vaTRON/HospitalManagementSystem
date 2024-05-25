namespace HospitalManagementSystem.Application;

public record ImportationDTO : DTOBase
{
    public string       ReceiptNumber   { get; init; } = string.Empty;       //số chứng từ
    public string       Billnumber      { get; init; } = string.Empty;       //số hóa đơn
    public DateTime     RecordDay       { get; init; }                       //ngày ghi sổ
    public DateTime     ReceiptDay      { get; init; }                       //ngày chứng từ
    public int          Tax             { get; init; }                       //thuế VAT
    public int          TotalPrice      { get; init; }                       //thành tiền
    public string       Company         { get; init; } = string.Empty;       //nhà cung cấp
}
