namespace HospitalManagementSystem.Application;

public record AnalysisTestDTO : DTOBase
{
    public string?  DoctorComment       { get; init; }
    public string?  Result              { get; init; }
}