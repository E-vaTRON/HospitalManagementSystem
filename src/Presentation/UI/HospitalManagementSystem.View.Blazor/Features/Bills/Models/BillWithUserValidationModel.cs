namespace HospitalManagementSystem.Blazor;

public record BillWithUserValidationModel : InputBillDTO
{
    public OutputUserDTO User { get; set; } = default!; //????

    public bool IsUserIdValid   { get; set; }
    public bool IsDeadlineValid { get; set; }
}
