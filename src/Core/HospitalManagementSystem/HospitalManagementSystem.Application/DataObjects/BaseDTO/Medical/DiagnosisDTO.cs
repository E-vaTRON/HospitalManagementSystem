namespace HospitalManagementSystem.Application;

public class DiagnosisDTO : DTOBase
{
    public string   DiagnosisCode   { get; set; } = string.Empty;
    public string?  Symptom         { get; set; }        // Làm bản riêng ?????
    public string?  Description     { get; set; }

    public virtual MedicalExamEpisodeDTO   MedicalExamEpisodeDTO      { get; set; } = default!;
    public virtual DiseasesDTO             DiseasesDTO                { get; set; } = default!;

    public virtual ICollection<DiagnosisTreatmentDTO> DiagnosisTreatmentDTOs { get; set; } = new HashSet<DiagnosisTreatmentDTO>();
}