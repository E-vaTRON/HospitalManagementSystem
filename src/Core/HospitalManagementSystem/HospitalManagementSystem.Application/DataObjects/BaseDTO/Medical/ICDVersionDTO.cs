namespace HospitalManagementSystem.Application;

public record ICDVersionDTO : DTOBase
{
    public string? Version { get; init; }
}
