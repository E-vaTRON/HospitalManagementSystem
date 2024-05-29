namespace HospitalManagementSystem.Application;

public record BillDTO : DTOBase
{
    public DateTime     Deadline            { get; init; }
    public DateTime?    PaidDate            { get; init; }
    public string?      Status              { get; init; } // BillStatus
    public decimal      TotalAmount         { get; init; }
    public decimal      ExcessAmount        { get; init; }
    public decimal      UnderPaidAmount     { get; init; }
    public decimal      DiscountAmount      { get; init; }
    public decimal      AdjustmentAmount    { get; init; }
    public string?      PaymentMethod       { get; init; }
    public string?      Notes               { get; init; }
}
