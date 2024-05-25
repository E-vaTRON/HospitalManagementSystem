namespace HospitalManagementSystem.Application;

public record InputDiagnosisSuggestionDTO : DiagnosisSuggestionDTO
{
    public string? AnalysisTestDTOId    { get; init; }
    public string? DiagnosisDTOId       { get; init; }
}