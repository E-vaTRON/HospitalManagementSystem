namespace HospitalManagementSystem.DataProvider;

public class Bill : ModelBase
{
    public DateTime     Deadline            { get; set; }
    public DateTime?    PaidDate            { get; set; }
    public string?      Status              { get; set; } // BillStatus
    public decimal      TotalAmount         { get; set; }
    public decimal      ExcessAmount        { get; set; }
    public decimal      UnderPaidAmount     { get; set; }
    public decimal      DiscountAmount      { get; set; }
    public decimal      AdjustmentAmount    { get; set; }
    public string?      PaymentMethod       { get; set; }
    public string?      Notes               { get; set; }

    public Guid?                MedicalExamEpisodeId    { get; set; }
    public MedicalExamEpisode   MedicalExamEpisode      { get; set; } = default!;
}