namespace HospitalManagementSystem.Application;

public record GoodSupplingDTO : DTOBase
{
    public string   GoodInformation { get; init; } = string.Empty;
    public DateTime ExpiryDate      { get; init; }       //hạng dùng
    public int      OrinaryAmount   { get; init; }
}
