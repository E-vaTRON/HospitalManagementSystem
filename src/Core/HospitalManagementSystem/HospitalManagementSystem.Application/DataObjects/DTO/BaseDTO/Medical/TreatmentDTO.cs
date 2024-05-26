namespace HospitalManagementSystem.Application;

public record TreatmentDTO : DTOBase
{
    public string   Name        { get; init; } = string.Empty;
    public string   Details     { get; init; } = string.Empty;
    public string?  Description { get; init; }
}
