namespace HospitalManagementSystem.DataProvider;

public class TreatmentExamEpisode : ModelBase
{
    public Guid?                TreatmentId             { get; set; }
    public Treatment            Treatment               { get; set; } = default!;
    public Guid?                MedicalExamEpisodeId    { get; set; }
    public MedicalExamEposode   MedicalExamEposode      { get; set; } = default!;
}
