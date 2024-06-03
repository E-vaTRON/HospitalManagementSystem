namespace HospitalManagementSystem.Application;

public record OutputDiagnosisSuggestionDTO : DiagnosisSuggestionDTO
{
    public OutputAnalysisTestDTO?     AnalysisTestDTO     { get; init; }
    public OutputDiagnosisDTO?        DiagnosisDTO        { get; init; }
}