namespace HospitalManagementSystem.Application;

public record OutputDiagnosisSuggestionDTO : DiagnosisSuggestionDTO
{
    public AnalysisTestDTO?     AnalysisTestDTO     { get; set; }
    public DiagnosisDTO?        DiagnosisDTO        { get; set; }
}