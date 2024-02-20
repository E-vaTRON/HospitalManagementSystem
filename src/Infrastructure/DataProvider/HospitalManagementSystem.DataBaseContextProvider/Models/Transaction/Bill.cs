namespace HospitalManagementSystem.DataBaseContextProvider;

public class Bill : ModelBase
{
    public long TotalDrugPrice      { get; set; }
    public long TotalTestPrice      { get; set; }

    public string?      TransactionID   { get; set; }
    public Transaction  Transaction     { get; set; } = default!;

    public ICollection<DrugBillDetail>  DrugBillDetails { get; set; } = new HashSet<DrugBillDetail>();
    public ICollection<AnalysisTest>    AnalysisTests   { get; set; } = new HashSet<AnalysisTest>();
}