namespace HospitalManagementSystem.Blazor;

public record BillWithSelectionModel : InputBillDTO
{
    public bool IsUserIdValid   { get; set; }
    public bool IsDeadlineValid { get; set; }

    public OutputMedicalExamEpisodeDTO?     SelectedEpisode     { get; set; } = default!;
    public OutputUserDTO?                   SelectedUser        { get; set; } = default!;
    public ICollection<OutputUserDTO>?      UserSelectList      { get; set; } = default!;
}
