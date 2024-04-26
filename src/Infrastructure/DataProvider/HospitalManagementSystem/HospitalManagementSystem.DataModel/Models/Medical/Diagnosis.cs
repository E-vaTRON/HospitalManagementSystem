namespace HospitalManagementSystem.DataProvider;

public class Diagnosis : ModelBase
{
    public string   DiagnosisCode   { get; set; } = string.Empty;
    public string?  Description     { get; set; }

    public Guid?                        MedicalExamEpisodeId    { get; set; }
    public virtual MedicalExamEposode   MedicalExamEposode      { get; set; } = default!;
    public Guid?                        ICDId                   { get; set; }
    public virtual ICD                  ICD                     { get; set; } = default!;
}