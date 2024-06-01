namespace HospitalManagementSystem.Application;

public record OutputICDVersionDTO : ICDVersionDTO
{
    public ICollection<OutputICDCodeVersionDTO>? ICDCodeVersionDTOs { get; init; }
}
