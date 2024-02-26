namespace HospitalManagementSystem.DataProvider;

public class DiagnosisSuggestion :ModelBase
{
    public string?  ThresholdValue  { get; set; }
    public bool     IsActive        { get; set; }

    public string?      AnalysisTestId  { get; set; }
    public AnalysisTest AnalysisTest    { get; set; } = default!;
    public string?      DiagnosisId     { get; set; }   
    public Diagnosis    Diagnosis       { get; set; } = default!;
}