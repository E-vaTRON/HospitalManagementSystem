namespace HospitalManagementSystem.Application;

public record OutputICDVersionDTO : ICDVersionDTO
{
    public ICollection<OutputICDCodeVersionDTO>? ICDCodeVersions { get; init; }
}
