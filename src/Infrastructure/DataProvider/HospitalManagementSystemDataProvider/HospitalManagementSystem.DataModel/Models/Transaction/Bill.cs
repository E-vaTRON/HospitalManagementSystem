namespace HospitalManagementSystem.DataProvider;

public class Bill : ModelBase
{
    public long TotalDrugPrice      { get; set; }
    public long TotalServicePrice   { get; set; }

    public string?      TransactionId   { get; set; }
    public Transaction  Transaction     { get; set; } = default!;

    public ICollection<DrugBillDetail>  DrugBillDetails { get; set; } = new HashSet<DrugBillDetail>();
    public ICollection<AnalysisTest>    AnalysisTests   { get; set; } = new HashSet<AnalysisTest>();
}