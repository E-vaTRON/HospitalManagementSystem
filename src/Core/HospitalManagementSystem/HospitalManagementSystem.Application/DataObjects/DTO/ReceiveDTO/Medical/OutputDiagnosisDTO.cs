namespace HospitalManagementSystem.Application;

public record OutputDiagnosisDTO : DiagnosisDTO
{
    public OutputMedicalExamEpisodeDTO?   MedicalExamEpisode   { get; init; }
    public OutputDiseasesDTO?             Diseases             { get; init; }

    public virtual ICollection<OutputDiagnosisTreatmentDTO>? DiagnosisTreatments { get; init; }
}