namespace HospitalManagementSystem.Application;

public class DiagnosisSuggestionDTO : DTOBase
{
    public string?  ThresholdValue  { get; set; }
    public bool     IsActive        { get; set; }

    public AnalysisTestDTO  AnalysisTestDTO { get; set; } = default!;
    public DiagnosisDTO     DiagnosisDTO    { get; set; } = default!;
}