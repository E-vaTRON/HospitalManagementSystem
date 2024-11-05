namespace HospitalManagementSystem.Domain;

public class AnalysisTest : EntityBase
{
    public string?  DoctorComment           { get; set; }
    public string?  ResultSummary           { get; set; }
    public string?  SpecificMeasurements    { get; set; }
    public string?  UserId                  { get; set; } // ID of user
    public string?  TechnicianSignature     { get; set; }

    public string?              DeviceInventoryId       { get; set; }
    public DeviceInventory      DeviceInventory         { get; set; } = default!;
    public string?              MedicalExamEpisodeId    { get; set; }
    public MedicalExamEpisode   MedicalExamEpisode      { get; set; } = default!;

    //public virtual ICollection<DiagnosisSuggestion> DiagnosisSuggestions { get; set; } = new HashSet<DiagnosisSuggestion>();
}