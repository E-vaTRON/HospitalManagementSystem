namespace HospitalManagementSystem.Domain;

public class TreatmentExamEpisode : EntityBase
{
    public string?              TreatmentId             { get; set; }
    public Treatment            Treatment               { get; set; } = default!;
    public string?              MedicalExamEpisodeId    { get; set; }
    public MedicalExamEposode   MedicalExamEposode      { get; set; } = default!;
}
