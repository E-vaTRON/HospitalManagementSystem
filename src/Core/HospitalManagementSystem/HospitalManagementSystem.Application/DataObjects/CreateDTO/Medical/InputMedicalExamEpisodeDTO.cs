namespace HospitalManagementSystem.Application;

public record InputMedicalExamEpisodeDTO : MedicalExamEpisodeDTO
{
    public string? MedicalExamDTOId { get; init; }
}