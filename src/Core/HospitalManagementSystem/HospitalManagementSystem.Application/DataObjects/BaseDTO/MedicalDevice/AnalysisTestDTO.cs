namespace HospitalManagementSystem.Application;

public class AnalysisTestDTO : DTOBase
{
    public string?  DoctorComment       { get; set; }
    public string?  Result              { get; set; }

    public DeviceServiceDTO         DeviceServiceDTO        { get; set; } = default!;
    public MedicalExamEpisodeDTO    MedicalExamEpisodeDTO   { get; set; } = default!;

    //public virtual ICollection<DiagnosisSuggestion> DiagnosisSuggestions { get; set; } = new HashSet<DiagnosisSuggestion>();
}