namespace HospitalManagementSystem.Application;

public record AnalysisTestDTO : DTOBase
{
    public string?  DoctorComment           { get; init; }
    public string?  ResultSummary           { get; init; }
    public string?  SpecificMeasurements    { get; init; }
    public string?  UserId                  { get; init; } // User Id Role<Doctor/Technician>
    public string?  TechnicianSignature     { get; init; }
}