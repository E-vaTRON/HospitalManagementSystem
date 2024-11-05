namespace HospitalManagementSystem.Application;

public record OutputDiagnosisSuggestionDTO : DiagnosisSuggestionDTO
{
    public OutputAnalysisTestDTO?     AnalysisTest     { get; init; }
    public OutputDiagnosisDTO?        Diagnosis        { get; init; }
}