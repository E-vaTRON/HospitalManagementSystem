namespace HospitalManagementSystem.DataProvider;

public class AnalysisTest : ModelBase
{
    public string?  DSymptom            { get; set; }        // Làm bản riêng ?????
    public string?  DoctorComment       { get; set; }
    public string?  Result              { get; set; }

    public Guid?                DeviceServiceId         { get; set; }
    public DeviceService        DeviceService           { get; set; } = default!;
    public Guid?                MedicalExamEposodeId    { get; set; }
    public MedicalExamEposode   MedicalExamEposode      { get; set; } = default!;

    //public virtual ICollection<DiagnosisSuggestion> DiagnosisSuggestions { get; set; } = new HashSet<DiagnosisSuggestion>();
}