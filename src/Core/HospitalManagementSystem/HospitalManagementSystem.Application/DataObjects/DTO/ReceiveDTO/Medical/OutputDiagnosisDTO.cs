namespace HospitalManagementSystem.Application;

public record OutputDiagnosisDTO : DiagnosisDTO
{
    public MedicalExamEpisodeDTO?   MedicalExamEpisodeDTO   { get; init; }
    public DiseasesDTO?             DiseasesDTO             { get; init; }

    public virtual ICollection<DiagnosisTreatmentDTO>? DiagnosisTreatmentDTOs { get; init; }
}