namespace HospitalManagementSystem.DataProvider;

public class Bill : ModelBase
{
    public string?      TransactionId   { get; set; }
    public Transaction  Transaction     { get; set; } = default!;
}