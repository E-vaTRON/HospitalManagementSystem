namespace HospitalManagementSystem.Application;

public record OutputDiagnosisDTO : DiagnosisDTO
{
    public OutputMedicalExamEpisodeDTO?   MedicalExamEpisodeDTO   { get; init; }
    public OutputDiseasesDTO?             DiseasesDTO             { get; init; }

    public virtual ICollection<OutputDiagnosisTreatmentDTO>? DiagnosisTreatmentDTOs { get; init; }
}