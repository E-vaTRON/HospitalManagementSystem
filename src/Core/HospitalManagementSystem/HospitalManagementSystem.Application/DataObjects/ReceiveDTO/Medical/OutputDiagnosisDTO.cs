namespace HospitalManagementSystem.Application;

public record OutputDiagnosisDTO : DiagnosisDTO
{
    public MedicalExamEpisodeDTO?   MedicalExamEpisodeDTO   { get; set; }
    public DiseasesDTO?             DiseasesDTO             { get; set; }

    public virtual ICollection<DiagnosisTreatmentDTO>? DiagnosisTreatmentDTOs { get; init; }
}