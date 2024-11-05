namespace HospitalManagementSystem.Application;

public record DiseasesDTO : DTOBase
{
    public string       Name        { get; init; } = string.Empty;
    public string?      Description { get; init; }
    public CodeStatus   Status      { get; init; }
}