namespace HospitalManagementSystem.Domain;

public class Bill : EntityBase
{
    public string?      TransactionId   { get; set; }
    public Transaction  Transaction     { get; set; } = default!;
}