namespace HospitalManagementSystem.Application;

public record FormTypeDTO : DTOBase
{
    public string   Name                { get; init; } = string.Empty;
    public string?  Description         { get; init; }
    public string?  DocumentPath        { get; init; }
}
