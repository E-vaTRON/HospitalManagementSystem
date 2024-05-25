namespace HospitalManagementSystem.Application;

public record DiagnosisTreatmentDTO : DTOBase
{
    public string? Order    { get; init; }
    public string? Note     { get; init; }
}
