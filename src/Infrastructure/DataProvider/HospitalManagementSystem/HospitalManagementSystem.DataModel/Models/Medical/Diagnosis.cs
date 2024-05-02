namespace HospitalManagementSystem.DataProvider;

public class Diagnosis : ModelBase
{
    public string   DiagnosisCode   { get; set; } = string.Empty;
    public string?  Symptom         { get; set; }        // Làm bản riêng ?????
    public string?  Description     { get; set; }

    public Guid?                        MedicalExamEpisodeId    { get; set; }
    public virtual MedicalExamEposode   MedicalExamEposode      { get; set; } = default!;
    public Guid?                        DiseasesId              { get; set; }
    public virtual Diseases             Diseases                { get; set; } = default!; 

    public virtual ICollection<DiagnosisTreatment> DiagnosisTreatments { get; set; } = new HashSet<DiagnosisTreatment>();
}