namespace HospitalManagementSystem.Application;

public record DiagnosisSuggestionDTO : DTOBase
{
    public string?  ThresholdValue  { get; init; }
    public bool     IsActive        { get; init; }
}