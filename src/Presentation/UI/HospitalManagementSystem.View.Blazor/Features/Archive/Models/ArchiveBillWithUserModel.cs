namespace HospitalManagementSystem.Blazor;

public record ArchiveBillWithUserModel : InputBillDTO
{
    public OutputUserDTO                User    { get; set; } = default!;
    public OutputMedicalExamEpisodeDTO  Episode { get; set; } = default!;
}