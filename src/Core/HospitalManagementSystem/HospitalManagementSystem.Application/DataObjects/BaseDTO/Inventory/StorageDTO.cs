namespace HospitalManagementSystem.Application;

public record StorageDTO : DTOBase
{
    public string Location { get; init; } = string.Empty;
}
