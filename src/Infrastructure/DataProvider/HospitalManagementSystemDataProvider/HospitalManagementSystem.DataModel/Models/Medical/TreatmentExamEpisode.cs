namespace HospitalManagementSystem.DataProvider;

public class TreatmentExamEpisode : ModelBase
{
    public string?              TreatmentId         { get; set; }
    public Treatment            Treatment           { get; set; } = default!;
    public string?              MedicalExamEpisode  { get; set; }
    public MedicalExamEposode   MedicalExamEposode  { get; set; } = default!;
}
