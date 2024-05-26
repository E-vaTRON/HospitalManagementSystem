namespace HospitalManagementSystem.Application;

public record OutputDiagnosisSuggestionDTO : DiagnosisSuggestionDTO
{
    public AnalysisTestDTO?     AnalysisTestDTO     { get; init; }
    public DiagnosisDTO?        DiagnosisDTO        { get; init; }
}