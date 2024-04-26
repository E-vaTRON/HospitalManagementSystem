namespace HospitalManagementSystem.Domain;

public class Diagnosis : EntityBase
{
    public string   DiagnosisCode   { get; set; } = string.Empty;
    public string?  Description     { get; set; }

    public string?                      MedicalExamEpisodeId    { get; set; }
    public virtual MedicalExamEposode   MedicalExamEposode      { get; set; } = default!;
    public string?                      ICDId                   { get; set; }
    public virtual ICD                  ICD                     { get; set; } = default!;
}