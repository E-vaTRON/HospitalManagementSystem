namespace HospitalManagementSystem.Blazor;

public record UserWithPaymentModel : InputUserDTO
{
    public bool                       IsFullyPaid { get; set; } = true;
    public ICollection<OutputBillDTO> Bills       {get; set;} = default!;
}